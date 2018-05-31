using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using MicronBETest.Inputs;
using MicronBETest.DataModel;
using Mozart.SeePlan;
using Mozart.Task.Execution.Persists;

namespace MicronBETest.Logic
{
    [FeatureBind()]
    public partial class PersistInputs
    {
        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        //int i = 1;
        public bool OnAfterLoad_Demand(Demand entity)
        {
            MicronBETestProduct demandProd = FindHelper.FindDemandProduct(entity.PRODUCT_ID);
            if (demandProd == null)
                return false;

            MicronBETestBEMoMaster moMaster;
            if (InputMart.Instance.MicronBETestBEMoMaster.TryGetValue(entity.PRODUCT_ID, out moMaster) == false)
            {
                moMaster = new MicronBETestBEMoMaster();

                moMaster.Product = demandProd;
               
                InputMart.Instance.MicronBETestBEMoMaster.Add(entity.PRODUCT_ID, moMaster);
            }

            MicronBETestBEMoPlan moPlan = new MicronBETestBEMoPlan();
            moPlan.MoMaster = moMaster;
            moPlan.Qty = Convert.ToDouble(entity.QTY);
            moPlan.DueDate = entity.DUE_DATE;
            //moPlan.Priority = i++.ToString();

            moMaster.AddMoPlan(moPlan);
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_ProductMaster(ProductMaster entity)
        {
            MicronBETestProcess process = FindHelper.FindProcess(entity.PROCESS_ID);
            if (process == null)
                return false;

            MicronBETestProduct product = new MicronBETestProduct(entity.PRODUCT_ID, process);
            product.LineID = entity.LINE_ID;
            //product.IsFinal = entity.IS_FINAL == "Y" ? true : false;
            //product.Grade = string.IsNullOrEmpty(entity.GRADE) ? "Z" : entity.GRADE;

            if (InputMart.Instance.MicronBETestProduct.ContainsKey(entity.PRODUCT_ID) == false)
                InputMart.Instance.MicronBETestProduct.Add(entity.PRODUCT_ID, product);
            
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="context"/>
        public void OnAction_ProcessStep(Mozart.Task.Execution.Persists.IPersistContext context)
        {
            InputMart.Instance.ProcessStep.DefaultView.Sort = "SEQUENCE ASC";

            foreach (ProcessStep processStep in InputMart.Instance.ProcessStep.DefaultView)
            {
                MicronBETestProcess process;
                if (InputMart.Instance.MicronBETestProcess.TryGetValue(processStep.PROCESS_ID, out process) == false)
                {
                    process = new MicronBETestProcess(processStep.PROCESS_ID);
                    InputMart.Instance.MicronBETestProcess.Add(process.ProcessID, process);
                }

                MicronBETestBEStep step = new MicronBETestBEStep();
                step.StepID = processStep.STEP_ID;
                step.Sequence = Convert.ToInt32(processStep.SEQUENCE);
                //step.StepType = processStep.STEP_GROUP;

                StepMaster sm = InputMart.Instance.StepMaster.Rows.FirstOrDefault(p => p.STEP_ID == step.StepID);

                //if (sm != null)
                //    step.RefStepID = sm.REF_STEP_ID;

                process.Steps.Add(step);
            }

            foreach (MicronBETestProcess process in InputMart.Instance.MicronBETestProcess.Values)
                process.LinkSteps();
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_Wip(Wip entity)
        {
            MicronBETestProduct product = FindHelper.FindProduct(entity.PRODUCT_ID);

            if (product == null)
                return false;

            MicronBETestProcess process = FindHelper.FindProcess(entity.PROCESS_ID);
            if (process == null)
                return false;

            MicronBETestWipInfo wipInfo = new MicronBETestWipInfo();
            wipInfo.LotID = entity.LOT_ID;
            wipInfo.LineID = entity.LINE_ID;
            wipInfo.Product = product;
            wipInfo.Process = process;

            wipInfo.UnitQty = Convert.ToDouble(entity.LOT_QTY);
            wipInfo.InitialStep = process.FindStep(entity.STEP_ID);
            wipInfo.CurrentState = FindHelper.FindLotState(entity.LOT_STATE);
            

            InputMart.Instance.MicronBETestWipInfo.Add(wipInfo.InitialStep.StepID, wipInfo);

            
            return false;
        }


    }
}
