using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Тип - Птица
    /// </summary>
    internal class Bird : IAnimal
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }

        public Bird()
        {
            this.Type = "Птица";
            this.Note = "Может летать";
        }
    }
}
