using System;

namespace workout_tracker.domain
{
    /// <summary>
    /// Entity base class.
    /// 
    /// Source: https://enterprisecraftsmanship.com/2014/11/08/domain-object-base-class/
    /// Original author: Khorikov, Vladimir; @vkhorikov
    /// 
    /// Modified for use in this demo.
    /// </summary>
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
        public virtual bool IsTransient() { return Id == 0; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            // compareTo pointer cannot be null
            if (ReferenceEquals(compareTo, null))
                return false;

            // reference equality
            if (ReferenceEquals(this, compareTo))
                return true;

            if (GetType() != compareTo.GetType())
                return false;

            // identifier equality
            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
                return true;

            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
