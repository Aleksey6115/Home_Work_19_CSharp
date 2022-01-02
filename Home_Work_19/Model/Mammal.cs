using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Тип - Млекопетающий
    /// </summary>
    internal class Mammal : IAnimal
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }

        public Mammal()
        {
            this.Type = "Млекопитающие";
            this.Note = "Вскормливает детёнышей молоком";
        }

        public override string ToString()
        {
            return this.Type;
        }
    }
}
