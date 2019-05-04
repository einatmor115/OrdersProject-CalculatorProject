using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class supplier
    {
        public int supplier_number { get; set; }
        public string user_name { get; set; }
        public int password { get; set; }
        public string company_name { get; set; }
    
        public override int GetHashCode()
        {
            return (int)supplier_number;
        }

        public override string ToString()
        {
            return $"{supplier_number} {user_name} {password} {company_name}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            supplier other = obj as supplier;
            if (other == null)
                return false;

            return this.supplier_number == other.supplier_number;
        }

    }
}
