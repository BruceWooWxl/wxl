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
    public partial class SHIFT_TAT
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="isRun"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public TimeSpan GET_TAT0(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun, ref bool handled, TimeSpan prevReturnValue)
        {
            MicronBETestBEPegPart pp = pegPart as MicronBETestBEPegPart;
            double tat = FindHelper.FindTAT(pp.Product.LineID, pp.Product.ProductID, pp.CurrentStep.StepID, isRun);
            return TimeSpan.FromSeconds(tat);
        }
    }
}
