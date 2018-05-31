using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Mozart.SeePlan.DataModel;
using Mozart.SeePlan.Pegging;
using MicronBETest.DataModel;

namespace MicronBETest.Logic.Pegging
{
    [FeatureBind()]
    public partial class TestMain
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <returns/>
        public Step GETLASTPEGGINGSTEP(Mozart.SeePlan.Pegging.PegPart pegPart)
        {
            MicronBETestBEPegPart pp = pegPart as MicronBETestBEPegPart;
            MicronBETestProcess process = pp.Product.Process as MicronBETestProcess;

            return process.LastStep;
        }

        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="currentStep"/>
        /// <returns/>
        public Step GETPREVPEGGINGSTEP(PegPart pegPart, Step currentStep)
        {
            return currentStep.GetDefaultPrevStep();
        }
    }
}
