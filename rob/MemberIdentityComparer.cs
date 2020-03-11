using System;
using System.Collections.Generic;

namespace rob
{
    public class MemberIdentityComparer : IEqualityComparer<IMemberIdentity>
    {
        public bool Equals(IMemberIdentity x, IMemberIdentity y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            
            return x.id == y.id;
        }

        public int GetHashCode(IMemberIdentity obj)
        {
            return obj.id.GetHashCode();
        }
    }
}