using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Новый тип животного
    /// </summary>
    internal class NewTypeAnimal : IAnimal
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Note { get; set; }
    }
}
