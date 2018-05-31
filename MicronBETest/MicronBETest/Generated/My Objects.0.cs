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

namespace MicronBETest
{
    
    /// <summary>
    /// DataModel part 
    /// </summary>
    public partial class InputMart : InputRepository
    {
        private Dictionary<string, MicronBETestProcess> _MicronBETestProcess;
        public Dictionary<string, MicronBETestProcess> MicronBETestProcess
        {
            get
            {
                if ((this._MicronBETestProcess == null))
                {
                    this._MicronBETestProcess = new Dictionary<string, MicronBETestProcess>();
                }
                return this._MicronBETestProcess;
            }
        }
        private Dictionary<string, MicronBETestProduct> _MicronBETestProduct;
        public Dictionary<string, MicronBETestProduct> MicronBETestProduct
        {
            get
            {
                if ((this._MicronBETestProduct == null))
                {
                    this._MicronBETestProduct = new Dictionary<string, MicronBETestProduct>();
                }
                return this._MicronBETestProduct;
            }
        }
        private MultiDictionary<string, MicronBETestWipInfo> _MicronBETestWipInfo;
        public MultiDictionary<string, MicronBETestWipInfo> MicronBETestWipInfo
        {
            get
            {
                if ((this._MicronBETestWipInfo == null))
                {
                    this._MicronBETestWipInfo = new MultiDictionary<string, MicronBETestWipInfo>();
                }
                return this._MicronBETestWipInfo;
            }
        }
        private Dictionary<string, MicronBETestBEMoMaster> _MicronBETestBEMoMaster;
        public Dictionary<string, MicronBETestBEMoMaster> MicronBETestBEMoMaster
        {
            get
            {
                if ((this._MicronBETestBEMoMaster == null))
                {
                    this._MicronBETestBEMoMaster = new Dictionary<string, MicronBETestBEMoMaster>();
                }
                return this._MicronBETestBEMoMaster;
            }
        }
        private MultiDictionary<string, MicronBETestPlanWip> _MicronBETestPlanWip;
        public MultiDictionary<string, MicronBETestPlanWip> MicronBETestPlanWip
        {
            get
            {
                if ((this._MicronBETestPlanWip == null))
                {
                    this._MicronBETestPlanWip = new MultiDictionary<string, MicronBETestPlanWip>();
                }
                return this._MicronBETestPlanWip;
            }
        }
        protected override void ClearMyObjects()
        {
            base.ClearMyObjects();
            this.DisposeIfNeeds(this._MicronBETestProcess);
            this._MicronBETestProcess = null;
            this.DisposeIfNeeds(this._MicronBETestProduct);
            this._MicronBETestProduct = null;
            this.DisposeIfNeeds(this._MicronBETestWipInfo);
            this._MicronBETestWipInfo = null;
            this.DisposeIfNeeds(this._MicronBETestBEMoMaster);
            this._MicronBETestBEMoMaster = null;
            this.DisposeIfNeeds(this._MicronBETestPlanWip);
            this._MicronBETestPlanWip = null;
        }
    }
}
