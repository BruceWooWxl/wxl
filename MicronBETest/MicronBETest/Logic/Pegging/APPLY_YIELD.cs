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
    public partial class APPLY_YIELD
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public double GET_YIELD0(Mozart.SeePlan.Pegging.PegPart pegPart, ref bool handled, double prevReturnValue)
        {
            MicronBETestBEPegPart pp = pegPart as MicronBETestBEPegPart;
            double yield = FindHelper.FindYield(pp.Product.LineID, pp.Product.ProductID, pp.CurrentStep.StepID);
            
            return yield;
        }
    }
}
