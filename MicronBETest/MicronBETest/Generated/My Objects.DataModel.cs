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
using Mozart.SeePlan.SemiBE.DataModel;
using System.ComponentModel;
using Mozart.SeePlan.SemiBE.Pegging;

namespace MicronBETest.DataModel
{
    
    [System.SerializableAttribute()]
    public partial class MicronBETestProcess : Mozart.SeePlan.SemiBE.DataModel.Process, IEntityObject, IEditableObject
    {
        public MicronBETestProcess()
        {
        }
        public MicronBETestProcess(string processID) : 
                base(processID)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestProduct : Mozart.SeePlan.SemiBE.DataModel.Product, IEntityObject, IEditableObject
    {
        public MicronBETestProduct()
        {
        }
        public MicronBETestProduct(string prodCode, Mozart.SeePlan.SemiBE.DataModel.Process proc) : 
                base(prodCode, proc)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestMcpPart : Mozart.SeePlan.SemiBE.DataModel.McpPart, IEntityObject, IEditableObject
    {
        public MicronBETestMcpPart()
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestWipInfo : Mozart.SeePlan.SemiBE.DataModel.IWipInfo
    {
        public virtual string LotID { get; set; }

        public virtual double UnitQty { get; set; }

        public virtual Mozart.SeePlan.SemiBE.DataModel.Product Product { get; set; }

        public virtual Mozart.SeePlan.SemiBE.DataModel.Process Process { get; set; }

        public virtual Mozart.SeePlan.SemiBE.DataModel.BEStep InitialStep { get; set; }

        public virtual Mozart.SeePlan.SemiBE.DataModel.Eqp InitialEqp { get; set; }

        public virtual Mozart.SeePlan.Simulation.EntityState CurrentState { get; set; }

        public virtual string WipProductID { get; set; }

        public virtual string WipProcessID { get; set; }

        public virtual string WipStepID { get; set; }

        public virtual string WipEqpID { get; set; }

        public virtual string WipState { get; set; }

        public virtual DateTime WipStateTime { get; set; }

        public virtual DateTime LastTrackInTime { get; set; }

        public virtual DateTime LastProcessStartTime { get; set; }

        public virtual DateTime LastTrackOutTime { get; set; }

        public virtual string LineID { get; set; }

        public MicronBETestWipInfo ShallowCopy()
        {
			var x = (MicronBETestWipInfo) this.MemberwiseClone();
            return x;
        }
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestBEStep : Mozart.SeePlan.SemiBE.DataModel.BEStep, IEntityObject, IEditableObject
    {
        public MicronBETestBEStep()
        {
        }
        public MicronBETestBEStep(string id) : 
                base(id)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestMcpProduct : Mozart.SeePlan.SemiBE.DataModel.McpProduct, IEntityObject, IEditableObject
    {
        public MicronBETestMcpProduct(string prodCode, Mozart.SeePlan.SemiBE.DataModel.Process proc) : 
                base(prodCode, proc)
        {
        }
        public MicronBETestMcpProduct()
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestBEMoMaster : Mozart.SeePlan.SemiBE.Pegging.BEMoMaster, IEntityObject, IEditableObject
    {
        public MicronBETestBEMoMaster()
        {
        }
        public MicronBETestBEMoMaster(Mozart.SeePlan.SemiBE.DataModel.Product prod, string customer) : 
                base(prod, customer)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestBEPegTarget : Mozart.SeePlan.SemiBE.Pegging.BEPegTarget, IEntityObject, IEditableObject
    {
        public MicronBETestBEPegTarget(Mozart.SeePlan.SemiBE.Pegging.BEPegPart pp, Mozart.SeePlan.SemiBE.Pegging.BEMoPlan mp) : 
                base(pp, mp)
        {
        }
        public MicronBETestBEPegTarget()
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestBEMoPlan : Mozart.SeePlan.SemiBE.Pegging.BEMoPlan, IEntityObject, IEditableObject
    {
        public MicronBETestBEMoPlan()
        {
        }
        public MicronBETestBEMoPlan(Mozart.SeePlan.SemiBE.Pegging.BEMoMaster mm, float qty, System.DateTime dueDate) : 
                base(mm, qty, dueDate)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestPlanWip : Mozart.SeePlan.SemiBE.Pegging.PlanWip, IEntityObject, IEditableObject
    {
        public MicronBETestPlanWip()
        {
        }
        public MicronBETestPlanWip(Mozart.SeePlan.SemiBE.DataModel.IWipInfo wip) : 
                base(wip)
        {
        }
        public virtual Product Product { get; set; }

        public virtual string LotID { get; set; }

        public virtual string LineID { get; set; }

        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class MicronBETestBEPegPart : Mozart.SeePlan.SemiBE.Pegging.BEPegPart, IEntityObject, IEditableObject
    {
        public MicronBETestBEPegPart()
        {
        }
        public MicronBETestBEPegPart(Mozart.SeePlan.SemiBE.Pegging.BEMoMaster moMaster, Mozart.SeePlan.SemiBE.DataModel.Product product) : 
                base(moMaster, product)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
}
