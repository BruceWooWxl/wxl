using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using MicronBETest.DataModel;
using MicronBETest.Outputs;
using Mozart.SeePlan;
namespace MicronBETest
{
    [FeatureBind()]
    public static partial class WriteHelper
    {
        internal static void WriteStepTarget(Mozart.SeePlan.Pegging.PegPart pegPart, bool isOut)
        {
            MicronBETestBEPegPart pp = pegPart as MicronBETestBEPegPart;

            foreach (MicronBETestBEPegTarget target in pegPart.PegTargetList)
            {
                MicronBETestBEMoPlan moPlan = target.Mo as MicronBETestBEMoPlan;
                MicronBETestBEMoMaster moMaster = moPlan.MoMaster as MicronBETestBEMoMaster;

                StepTarget info = new StepTarget();

                info.LINE_ID = pp.Product.LineID;
                info.PRODUCT_ID = pp.Product.ProductID;
                info.PROCESS_ID = pp.CurrentStep.RouteID;
                info.STEP_ID = pp.CurrentStep.StepID;

                if (isOut)
                    info.OUT_QTY = Convert.ToDecimal(target.Qty);
                else
                    info.IN_QTY = Convert.ToDecimal(target.Qty);

                info.TARGET_DATE = target.DueDate;
                info.MO_PRODUCT_ID = moPlan.ProductID;

                OutputMart.Instance.StepTarget.Add(info);
            }
        }

        internal static void WritePeg(Mozart.SeePlan.Pegging.IMaterial m, double qty)
        {
            MicronBETestPlanWip wip = m as MicronBETestPlanWip;

            PegHistory info = new PegHistory();
            info.LOT_ID = wip.LotID;
            info.LINE_ID = wip.Product.LineID;
            info.PRODUCT_ID = wip.Product.ProductID;
            info.STEP_ID = wip.MapStep.StepID;
            info.MAIN_QTY = Convert.ToDecimal(wip.Wip.UnitQty);
            info.PEG_QTY = Convert.ToDecimal(qty);
            info.LOT_STATE = wip.Wip.CurrentState.ToString();

            OutputMart.Instance.PegHistory.Add(info);
        }
    }
}
