using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Mapping;
using Mozart.Data;
using Mozart.Data.Entity;
using Mozart.Task.Execution;
using MicronBETest.DataModel;
using MicronBETest.Inputs;
using MicronBETest.Outputs;
using Mozart.SeePlan.Pegging;
using Mozart.SeePlan.SemiBE.Pegging;

namespace MicronBETest
{
    
    /// <summary>
    /// Pegging execution model class
    /// </summary>
    public partial class Pegging_Module : ExecutionModule
    {
        public override string Name
        {
            get
            {
                return "Pegging";
            }
        }
        protected override System.Type ExecutorType
        {
            get
            {
                return typeof(Mozart.SeePlan.Pegging.Pegger);
            }
        }
        protected override void Configure()
        {
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ModelBuildImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ModelRunImpl());
            new PegModelsImpl().Configure();
            Mozart.Task.Execution.ServiceLocator.RegisterController(new APPLY_ACTImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new APPLY_YIELDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ASSIGN_KIT_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BIN_BUFFERImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BUILD_INPLANImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new CHANGE_PARTImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FILTER_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new KIT_PEGImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new KIT_PEG2Impl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MANIPULATE_DEMANDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PEG_WIPImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PREPARE_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PREPARE_WIPImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SHIFT_TATImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SMOOTH_DEMANDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WRITE_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WRITE_UNPEGImpl());
            new RulesImpl().Configure();
            new RulePresetsImpl().Configure();
        }
        /// <summary>
        /// ModelBuild execution control implementation
        /// </summary>
        internal partial class ModelBuildImpl : Mozart.SeePlan.Pegging.PeggerModelBuildInterface
        {
        }
        /// <summary>
        /// ModelRun execution control implementation
        /// </summary>
        internal partial class ModelRunImpl : Mozart.SeePlan.Pegging.PeggerModelRunInterface
        {
        }
        internal class PegModelsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Pegging.IPeggerCfg2>(this.BuildCfg());
            }
            private MicronBETest.Logic.Pegging.TestMain fTestMain = new MicronBETest.Logic.Pegging.TestMain();
            /// <summary>
            /// Pegging's Pegger Model
            /// </summary>
            private Mozart.SeePlan.Pegging.IPeggerModel2 BuildPegging()
            {
                Mozart.SeePlan.Pegging.PeggerModelBuilder2 Pegging = new Mozart.SeePlan.Pegging.PeggerModelBuilder2("Pegging");
                Mozart.SeePlan.Pegging.PeggerAreaBuilder2 area0 = new Mozart.SeePlan.Pegging.PeggerAreaBuilder2("Start", false);
                Mozart.SeePlan.Pegging.PeggerAreaBuilder2 area1 = new Mozart.SeePlan.Pegging.PeggerAreaBuilder2("TEST", false);
                Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder node0 = new Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder("TestPre");
                System.Collections.Generic.List<string> stgs0 = new System.Collections.Generic.List<string>();
                stgs0.Add("TestPreStage");
                node0.SetStages(stgs0);
                area1.AddNode(node0);
                Mozart.SeePlan.Pegging.PeggerProcessNodeBuilder node1 = new Mozart.SeePlan.Pegging.PeggerProcessNodeBuilder("TestMain");
                node1.AddBlock("@S", "@S", Mozart.SeePlan.Pegging.BlockType.START);
                node1.AddNextBlockMap("@S", "TestRunStage");
                node1.AddFunction("@S", ((Mozart.SeePlan.Pegging.GetLastPeggingStepDelegate)(this.fTestMain.GETLASTPEGGINGSTEP)));
                node1.AddBlock("TestRunStage", "TestRunStage", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("TestRunStage", "TestWaitStage");
                node1.AddBlock("TestWaitStage", "TestWaitStage", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("TestWaitStage", "@E");
                node1.AddBlock("@E", "@E", Mozart.SeePlan.Pegging.BlockType.END);
                node1.AddFunction("@E", ((Mozart.SeePlan.Pegging.GetPrevPeggingStepDelegate)(this.fTestMain.GETPREVPEGGINGSTEP)));
                area1.AddNode(node1);
                area0.AddNext(area1);
                Pegging.SetStart(area0);
                return Pegging.Build();
            }
            /// <summary>
            /// Pegger Configuration
            /// </summary>
            private Mozart.SeePlan.Pegging.IPeggerCfg2 BuildCfg()
            {
                Mozart.SeePlan.Pegging.PeggerCfgBuilder2 cfg = new Mozart.SeePlan.Pegging.PeggerCfgBuilder2();
                cfg.AddModel(this.BuildPegging(), true);
                return cfg.Build();
            }
        }
        /// <summary>
        /// APPLY_ACT execution control implementation
        /// </summary>
        internal partial class APPLY_ACTImpl : Mozart.SeePlan.Pegging.ApplyActControl
        {
        }
        /// <summary>
        /// APPLY_YIELD execution control implementation
        /// </summary>
        internal partial class APPLY_YIELDImpl : Mozart.SeePlan.Pegging.ApplyYieldControl
        {
            private MicronBETest.Logic.Pegging.APPLY_YIELD fAPPLY_YIELD = new MicronBETest.Logic.Pegging.APPLY_YIELD();
            public override double GetYield(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fAPPLY_YIELD.GET_YIELD0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// ASSIGN_KIT_TARGET execution control implementation
        /// </summary>
        internal partial class ASSIGN_KIT_TARGETImpl : Mozart.SeePlan.SemiBE.Pegging.AssignKitTargetControl
        {
        }
        /// <summary>
        /// BIN_BUFFER execution control implementation
        /// </summary>
        internal partial class BIN_BUFFERImpl : Mozart.SeePlan.SemiBE.Pegging.BinBufferControl
        {
        }
        /// <summary>
        /// BUILD_INPLAN execution control implementation
        /// </summary>
        internal partial class BUILD_INPLANImpl : Mozart.SeePlan.SemiBE.Pegging.BuildInPlanControl
        {
        }
        /// <summary>
        /// CHANGE_PART execution control implementation
        /// </summary>
        internal partial class CHANGE_PARTImpl : Mozart.SeePlan.Pegging.ChangePartControl
        {
        }
        /// <summary>
        /// FILTER_TARGET execution control implementation
        /// </summary>
        internal partial class FILTER_TARGETImpl : Mozart.SeePlan.Pegging.FilterTargetControl
        {
        }
        /// <summary>
        /// KIT_PEG execution control implementation
        /// </summary>
        internal partial class KIT_PEGImpl : Mozart.SeePlan.SemiBE.Pegging.KitPegControl
        {
        }
        /// <summary>
        /// KIT_PEG2 execution control implementation
        /// </summary>
        internal partial class KIT_PEG2Impl : Mozart.SeePlan.SemiBE.Pegging.KitPeg2Control
        {
        }
        /// <summary>
        /// MANIPULATE_DEMAND execution control implementation
        /// </summary>
        internal partial class MANIPULATE_DEMANDImpl : Mozart.SeePlan.SemiBE.Pegging.ManipulateDemandControl
        {
        }
        /// <summary>
        /// PEG_WIP execution control implementation
        /// </summary>
        internal partial class PEG_WIPImpl : Mozart.SeePlan.Pegging.PegWipControl
        {
            private MicronBETest.Logic.Pegging.PEG_WIP fPEG_WIP = new MicronBETest.Logic.Pegging.PEG_WIP();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Pegging.IMaterial> GetWips(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Pegging.IMaterial> returnValue = null;
                returnValue = this.fPEG_WIP.GET_WIPS0(pegPart, isRun, ref handled, returnValue);
                return returnValue;
            }
            public override void WritePeg(Mozart.SeePlan.Pegging.PegTarget target, Mozart.SeePlan.Pegging.IMaterial m, double qty)
            {
                bool handled = false;
                this.fPEG_WIP.WRITE_PEG0(target, m, qty, ref handled);
            }
        }
        /// <summary>
        /// PREPARE_TARGET execution control implementation
        /// </summary>
        internal partial class PREPARE_TARGETImpl : Mozart.SeePlan.SemiBE.Pegging.PrepareTargetControl
        {
            private MicronBETest.Logic.Pegging.PREPARE_TARGET fPREPARE_TARGET = new MicronBETest.Logic.Pegging.PREPARE_TARGET();
            public override Mozart.SeePlan.Pegging.PegPart PrepareTarget(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fPREPARE_TARGET.PREPARE_TARGET0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// PREPARE_WIP execution control implementation
        /// </summary>
        internal partial class PREPARE_WIPImpl : Mozart.SeePlan.SemiBE.Pegging.PrepareWipControl
        {
            private MicronBETest.Logic.Pegging.PREPARE_WIP fPREPARE_WIP = new MicronBETest.Logic.Pegging.PREPARE_WIP();
            public override Mozart.SeePlan.Pegging.PegPart PrepareWip(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fPREPARE_WIP.PREPARE_WIP0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// SHIFT_TAT execution control implementation
        /// </summary>
        internal partial class SHIFT_TATImpl : Mozart.SeePlan.Pegging.ShiftTatControl
        {
            private MicronBETest.Logic.Pegging.SHIFT_TAT fSHIFT_TAT = new MicronBETest.Logic.Pegging.SHIFT_TAT();
            public override System.TimeSpan GetTat(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun)
            {
                bool handled = false;
                System.TimeSpan returnValue = default(System.TimeSpan);
                returnValue = this.fSHIFT_TAT.GET_TAT0(pegPart, isRun, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// SMOOTH_DEMAND execution control implementation
        /// </summary>
        internal partial class SMOOTH_DEMANDImpl : Mozart.SeePlan.Pegging.SmoothDemandControl
        {
            private Mozart.SeePlan.Pegging.PreRuleLogic fpPreRuleLogic = new Mozart.SeePlan.Pegging.PreRuleLogic();
            public override Mozart.SeePlan.Pegging.IInnerBucket CreateInnerBucket(string key, Mozart.SeePlan.Pegging.MoPlan moPlan, System.DateTime weekStartDate, bool isW00)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.IInnerBucket returnValue = null;
                returnValue = this.fpPreRuleLogic.CREATE_INNER_BUCKET_DEF(key, moPlan, weekStartDate, isW00, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Pegging.IOuterBucket CreateOuterBucket(string key)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.IOuterBucket returnValue = null;
                returnValue = this.fpPreRuleLogic.CREATE_OUTER_BUCKET_DEF(key, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// WRITE_TARGET execution control implementation
        /// </summary>
        internal partial class WRITE_TARGETImpl : Mozart.SeePlan.Pegging.WriteTargetControl
        {
            private MicronBETest.Logic.Pegging.WRITE_TARGET fWRITE_TARGET = new MicronBETest.Logic.Pegging.WRITE_TARGET();
            public override void WriteTarget(Mozart.SeePlan.Pegging.PegPart pegPart, bool isOut)
            {
                bool handled = false;
                this.fWRITE_TARGET.WRITE_TARGET0(pegPart, isOut, ref handled);
            }
        }
        /// <summary>
        /// WRITE_UNPEG execution control implementation
        /// </summary>
        internal partial class WRITE_UNPEGImpl : Mozart.SeePlan.Pegging.WriteUnpegControl
        {
        }
        internal class RulesImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
            }
        }
        internal class RulePresetsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateTestPreStage());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateTestRunStage());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateTestWaitStage());
            }
            /// <summary>
            /// TestPreStage's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateTestPreStage()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("PREPARE_TARGET");
                list.Add("PREPARE_WIP");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                return new Mozart.RuleFlow.RulePreset("TestPreStage", list, props);
            }
            /// <summary>
            /// TestRunStage's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateTestRunStage()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("WRITE_TARGET");
                list.Add("PEG_WIP");
                list.Add("SHIFT_TAT");
                list.Add("APPLY_YIELD");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", true);
                return new Mozart.RuleFlow.RulePreset("TestRunStage", list, props);
            }
            /// <summary>
            /// TestWaitStage's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateTestWaitStage()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("WRITE_TARGET");
                list.Add("PEG_WIP");
                list.Add("SHIFT_TAT");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", false);
                return new Mozart.RuleFlow.RulePreset("TestWaitStage", list, props);
            }
        }
    }
}
