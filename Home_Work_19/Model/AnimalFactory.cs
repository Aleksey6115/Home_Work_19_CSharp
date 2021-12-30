using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Фабрика для интерфейса IAnimal
    /// </summary>
    internal class AnimalFactory
    {
        public IAnimal GetAnimal(string type)
        {
            switch (type.ToLower())
            {
                case "млекопитающие": return new Mammal();
                case "птица": return new Bird ();
                case "земноводное": return new Amphibious ();
                default: return new NewTypeAnimal { Type = type, Note = "О типе нет сведений" };
            }
        }
    }
}
