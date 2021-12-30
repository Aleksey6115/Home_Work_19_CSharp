using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work_19.Model;

namespace Home_Work_19.Services.AddAnimal
{
    internal interface IAddAnimalService
    {
        /// <summary>
        /// Добавленный элемент
        /// </summary>
        IAnimal NewAnimal { get; }

        /// <summary>
        /// Открыть окно добавления
        /// </summary>
        /// <returns></returns>
        bool OpenAddAnimalWindow();
    }
}
