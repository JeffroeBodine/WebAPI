using System;
using NHibernate;
using NHibernate.Event;
using ObjectLibrary;
using NHibernate.Type;

namespace DataAccess
{
    public class AuditInterceptor : EmptyInterceptor, IPreInsertEventListener, IPreUpdateEventListener, IPreDeleteEventListener
    {
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types)
        {
            var auditableObject = entity as IAuditableBaseObject;
            if (auditableObject != null)
            {

            }

            return false;
        }

        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            var auditableObject = entity as IAuditableBaseObject;
            if (auditableObject != null)
            {

            }

            return false;
        }

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            var auditableObject = entity as IAuditableBaseObject;
            if (auditableObject != null)
            {

            }
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var auditableObject = @event.Entity as IAuditableBaseObject;
            if (auditableObject != null)
            {
           
            }

            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var auditableObject = @event.Entity as IAuditableBaseObject;
            if (auditableObject != null)
            {

            }
            return false;
        }

        public bool OnPreDelete(PreDeleteEvent @event)
        {
            var auditableObject = @event.Entity as IAuditableBaseObject;
            if (auditableObject != null)
            {

            }
            return false;
        }
    }
}
