using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Mozart.SeePlan.SemiBE.DataModel;
using Mozart.SeePlan.SemiBE.Pegging;
using MicronBETest.DataModel;
namespace MicronBETest
{
    [FeatureBind()]
    public static partial class PrepareWipRuleHelper
    {
        internal static List<IWipInfo> GetWipInfoList()
        {
            List<IWipInfo> wipInfoList = new List<IWipInfo>(InputMart.Instance.MicronBETestWipInfo.Values);

            return wipInfoList;
        }

        internal static List<PlanWip> GetPlanWips(IWipInfo wipInfo)
        {
            List<PlanWip> wips = new List<PlanWip>();

            PlanWip planWip = PrepareWipRuleHelper.CreatePlanWip(wipInfo);

            
            wips.Add(planWip);

            return wips;
        }

        private static PlanWip CreatePlanWip(IWipInfo wip)
        {
            MicronBETestWipInfo wipInfo = wip as MicronBETestWipInfo;
            MicronBETestPlanWip planWip = new MicronBETestPlanWip(wipInfo);

            planWip.MapStep = wipInfo.InitialStep;
            //planWip.AvailableTime = FindHelper.GetEngineStartTime();
            planWip.Product = wipInfo.Product;
            planWip.LotID = wipInfo.LotID;

            return planWip;
        }

        internal static void RegisterInputMart(List<PlanWip> planWips)
        {
            foreach (MicronBETestPlanWip wip in planWips)
            {
                InputMart.Instance.MicronBETestPlanWip.Add(wip.MapStep.StepID, wip);
            }
        }
    }
}
