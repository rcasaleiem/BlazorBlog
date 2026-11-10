using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_newgat_commesse.Attributes
{
    public class CacheableAttribute : Attribute
    {
        public CacheableAttribute(int minutes)
        {
            this.ExpirationTime = TimeSpan.FromMinutes(minutes);
        }
        public TimeSpan ExpirationTime { get; private set; }
    }
}
