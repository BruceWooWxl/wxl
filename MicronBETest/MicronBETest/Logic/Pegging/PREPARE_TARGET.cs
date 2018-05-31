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

namespace MicronBETest.Logic.Pegging
{
    [FeatureBind()]
    public partial class PREPARE_TARGET
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public PegPart PREPARE_TARGET0(PegPart pegPart, ref bool handled, PegPart prevReturnValue)
        {
            MergedPegPart mp = new MergedPegPart();

            foreach (MicronBETestBEMoMaster moMaster in InputMart.Instance.MicronBETestBEMoMaster.Values)
            {
                MicronBETestBEPegPart pp = new MicronBETestBEPegPart(moMaster, moMaster.Product);

                foreach (MicronBETestBEMoPlan moPlan in moMaster.MoPlanList)
                {
                    MicronBETestBEPegTarget target = new MicronBETestBEPegTarget(pp, moPlan);
                    pp.AddPegTarget(target);
                }

                mp.Merge(pp);
            }
            
            return mp;
        }
    }
}
