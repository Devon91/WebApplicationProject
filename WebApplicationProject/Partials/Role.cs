using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public partial class Role
    {
        public override bool Equals(object obj)
        {
            return obj is Role role
                && Name.ToLower() == role.Name.ToLower();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
