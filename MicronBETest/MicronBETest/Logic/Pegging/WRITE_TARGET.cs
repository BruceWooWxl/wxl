using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Mozart.SeePlan.Pegging;

namespace MicronBETest.Logic.Pegging
{
    [FeatureBind()]
    public partial class WRITE_TARGET
    {
        /// <summary>
        /// </summary>
        /// <param name="pegPart"/>
        /// <param name="isOut"/>
        /// <param name="handled"/>
        public void WRITE_TARGET0(Mozart.SeePlan.Pegging.PegPart pegPart, bool isOut, ref bool handled)
        {
            WriteHelper.WriteStepTarget(pegPart, isOut);
        }
    }
}
