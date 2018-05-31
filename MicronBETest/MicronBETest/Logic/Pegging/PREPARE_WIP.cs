using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Mozart.SeePlan.Pegging;
using Mozart.SeePlan.SemiBE.DataModel;
using Mozart.SeePlan.SemiBE.Pegging;

namespace MicronBETest.Logic.Pegging
{
    [FeatureBind()]
    public partial class PREPARE_WIP
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public PegPart PREPARE_WIP0(PegPart pegPart, ref bool handled, PegPart prevReturnValue)
        {
            List<IWipInfo> wipInfoList = PrepareWipRuleHelper.GetWipInfoList();

            List<PlanWip> planWips = new List<PlanWip>();
            foreach (IWipInfo wipInfo in wipInfoList)
            {
                List<PlanWip> planWipList = PrepareWipRuleHelper.GetPlanWips(wipInfo);

                if (planWipList != null && planWipList.Count > 0)
                    planWips.AddRange(planWipList);
            }

            PrepareWipRuleHelper.RegisterInputMart(planWips);

            return pegPart;
        }
    }
}
