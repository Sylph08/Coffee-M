using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Models
{
    public class State
    {
        private bool id;
        public bool Id { get => id; set => id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        private string displayName;
        public State(bool i, string trueValue, string falseValue)
        {
            Id = i;
            if (i == true) DisplayName = trueValue;
            else DisplayName = falseValue;
        }
    }
}
