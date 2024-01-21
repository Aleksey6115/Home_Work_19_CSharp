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
        private List<IAnimal> animals = new List<IAnimal>()
        {
            new Amphibious(), new Bird(), new Mammal(), new NewTypeAnimal()
        };

        public IAnimal NewAnimal { get => newAnimal; }

        /// <summary>
        /// Работа с фабрикой
        /// </summary>
        public AnimalFactory AnimalFactory = new AnimalFactory();

        public bool OpenAddAnimalWindow()
        {
            AddAnimalWindow AAW = new AddAnimalWindow();
            AAW.animalCombo.ItemsSource = animals;

            if (AAW.ShowDialog() == true)
            {
                newAnimal = AnimalFactory.GetAnimal(AAW.animalCombo.SelectedItem.ToString());
                return true;
            }
            Console.WriteLine("HFHFHFHFH");
            return false;
        }
    }
}
