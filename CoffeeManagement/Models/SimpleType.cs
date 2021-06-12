using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Models
{
    public class SimpleType
    {
        private int? id;
        public int? Id { get => id; set => id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        private string displayName;
        public SimpleType(int? _id, string name)
        {
            Id = _id;
            if (id != null) DisplayName = name;
            else DisplayName = "";
        }
        public SimpleType()
        {

        }
    }
}
