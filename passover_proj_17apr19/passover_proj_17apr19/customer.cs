using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passover_proj_17apr19
{
    class customer
    {
        public int cust_id { get; set; }
        public string user_name { get; set; }
        public int password { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public int cradit_number { get; set; }

        public override int GetHashCode()
        {
            return (int)cust_id;
        }

        public override string ToString()
        {
            return $"{cust_id} {user_name} {password} {first_name} {surname} {cradit_number}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            customer other = obj as customer;
            if (other == null)
                return false;

            return this.cust_id == other.cust_id;
        }
    }
}
