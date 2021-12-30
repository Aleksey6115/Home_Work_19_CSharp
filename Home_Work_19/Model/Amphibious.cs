using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Тип - Земноводные
    /// </summary>
    internal class Amphibious : IAnimal
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }

        public Amphibious()
        {
            this.Type = "Земноводное";
            this.Note = "Может плавать и выходить на сушу";
        }
    }
}
