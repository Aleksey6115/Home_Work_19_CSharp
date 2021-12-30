using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work_19.Model;

namespace Home_Work_19.Services.AddAnimal
{
    /// <summary>
    /// Логика для окна добавить животного
    /// </summary>
    internal class AddAnimalService : IAddAnimalService
    {
        private IAnimal newAnimal; // Добавленное животное

        public IAnimal NewAnimal { get => newAnimal; }

        /// <summary>
        /// Работа с фабрикой
        /// </summary>
        public AnimalFactory AnimalFactory = new AnimalFactory();

        public bool OpenAddAnimalWindow()
        {
            AddAnimalWindow AAW = new AddAnimalWindow();

            if (AAW.ShowDialog() == true)
            {
                newAnimal = AnimalFactory.GetAnimal(AAW.txtAnimal.Text);
                return true;
            }
            return false;
        }
    }
}
