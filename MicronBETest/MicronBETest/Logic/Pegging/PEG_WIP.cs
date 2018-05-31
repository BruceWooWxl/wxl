using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Mozart.SeePlan.Pegging;
using MicronBETest.DataModel;
using Mozart.SeePlan.Simulation;

namespace MicronBETest.Logic.Pegging
{
    [FeatureBind()]
    public partial class PEG_WIP
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="isRun"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IList<Mozart.SeePlan.Pegging.IMaterial> GET_WIPS0(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun, ref bool handled, IList<IMaterial> prevReturnValue)
        {
            MicronBETestBEPegPart pp = pegPart as MicronBETestBEPegPart;

            List<IMaterial> wips = new List<IMaterial>();

            ICollection<MicronBETestPlanWip> wipList;
            if (InputMart.Instance.MicronBETestPlanWip.TryGetValue(pegPart.CurrentStep.StepID, out wipList))
            {
                foreach (MicronBETestPlanWip wip in wipList)
                {
                    if (wip.Qty <= 0)
                        continue;


                    if (pp.Product.ProductID != wip.Product.ProductID)
                        continue;


                    if (isRun)
                    {
                        if (wip.Wip.CurrentState != EntityState.RUN)
                            continue;
                    }
                    else
                    {
                        if (wip.Wip.CurrentState != EntityState.WAIT)
                            continue;
                    }

                    wips.Add(wip);

                    wip.MapCount++;
                }
            }

            return wips;
        }

        /// <summary>
        /// </summary>
        /// <param name="target"/>
        /// <param name="m"/>
        /// <param name="qty"/>
        /// <param name="handled"/>
        public void WRITE_PEG0(PegTarget target, IMaterial m, double qty, ref bool handled)
        {
            WriteHelper.WritePeg(m, qty);
        }
    }
}
