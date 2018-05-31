using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using MicronBETest.DataModel;
using Mozart.Text;
using MicronBETest.Inputs;
using Mozart.SeePlan.Simulation;
namespace MicronBETest
{
    [FeatureBind()]
    public static partial class FindHelper
    {
        internal static MicronBETestProcess FindProcess(string processID)
        {
            MicronBETestProcess process;
            if (InputMart.Instance.MicronBETestProcess.TryGetValue(processID, out process))
                return process;

            return null;
        }

        internal static MicronBETestProduct FindProduct(string productID)
        {
            MicronBETestProduct product;
            if (InputMart.Instance.MicronBETestProduct.TryGetValue(productID, out product))
                return product;

            return null;
        }


        /// <summary>
        /// Demand ProductID가 Wild일 경우 대표 Product를 선정해서 할당
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static MicronBETestProduct FindDemandProduct(string demandProductID)
        {
            foreach (MicronBETestProduct product in InputMart.Instance.MicronBETestProduct.Values)
            {


                if (LikeUtility.Like(product.ProductID, demandProductID) == false)
                    continue;

                return product;
            }

            return null;
        }

        internal static double FindTAT(string lineID, string productID, string stepID, bool isRun)
        {
            foreach (StepTat tat in InputMart.Instance.StepTat.DefaultView)
            {
                if (tat.LINE_ID != lineID)
                    continue;
                
                if (tat.PRODUCT_ID != productID)
                    continue;

                if (tat.STEP_ID != stepID)
                    continue;

                if (isRun)
                    return Convert.ToDouble(tat.RUN_TAT);

                return Convert.ToDouble(tat.WAIT_TAT);
            }

            return 0;
        }

        internal static double FindYield(string lineID, string productID, string stepID)
        {
            foreach (Yield yield in InputMart.Instance.Yield.DefaultView)
            {
                if (yield.LINE_ID != lineID)
                    continue;
                
                if (yield.PRODUCT_ID != productID)
                    continue;

                //if (yield.STEP_ID != stepID)
                    //continue;

                return Convert.ToDouble(yield.YIELD);
            }

            return 1;
        }

        internal static Mozart.SeePlan.Simulation.EntityState FindLotState(string lotState)
        {
            EntityState state;
            if (Enum.TryParse<EntityState>(lotState, true, out state) == false)
                state = EntityState.WAIT;

            return state;
        }
    }
}
