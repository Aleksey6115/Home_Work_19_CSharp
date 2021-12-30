using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Model
{
    /// <summary>
    /// Интерфейс отображает сущность животного
    /// </summary>
    public interface IAnimal
    {
        /// <summary>
        /// Тип животного
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Название вида
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Окрас животного
        /// </summary>
        string Color { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        string Note { get; set; }
    }
}
