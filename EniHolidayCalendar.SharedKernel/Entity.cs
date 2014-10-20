using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniCalendar.SharedKernel
{
    public class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        protected Entity(TId pId)
        {
            if (object.Equals(pId, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value", "id");
            }

            this.Id = pId;
        }

        public override bool Equals(object pObj)
        {
            var lEntity = pObj as Entity<TId>;
            if (lEntity != null)
            {
                return this.Equals(lEntity);
            }
            return base.Equals(pObj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<TId> pOther)
        {
            if (pOther == null)
            {
                return false;
            }
            return this.Id.Equals(pOther.Id);
        }
    }
}
