using Home_Work_19.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Home_Work_19.Model;

namespace Home_Work_19.Services.FileService.UseFileService
{
    internal class FileXmlService : IFileService
    {
        public ObservableCollection<IAnimal> OpenFile(string path)
        {
            IAnimal animal = null;
            AnimalFactory animalFactory = new AnimalFactory();
            ObservableCollection<IAnimal> result = new ObservableCollection<IAnimal>();
            XDocument xDocument = XDocument.Load(path);

            foreach (var a in xDocument.Element("animals").Elements("animal"))
            {
                XAttribute type = a.Attribute("type");
                XAttribute name = a.Attribute("name");
                XAttribute color = a.Attribute("color");
                XAttribute note = a.Attribute("note");

                animal = animalFactory.GetAnimal(type.Value);

                animal.Type = type.Value;
                animal.Name = name.Value;
                animal.Color = color.Value;
                animal.Note = note.Value;

                result.Add(animal);
            }
            return result;
        }

        public void SaveFile(ObservableCollection<IAnimal> animals, string path)
        {
            XDocument xDocument = new XDocument();
            XElement xAnimals = new XElement("animals");

            for (int i = 0; i < animals.Count; i++)
            {
                XElement animal = new XElement("animal");

                XAttribute type = new XAttribute("type", Input(animals[i].Type));
                animal.Add(type);

                XAttribute name = new XAttribute("name", Input(animals[i].Name));
                animal.Add(name);

                XAttribute color = new XAttribute("color", Input(animals[i].Color));
                animal.Add(color);

                XAttribute note = new XAttribute("note", Input(animals[i].Note));
                animal.Add(note);

                xAnimals.Add(animal);
            }

            xDocument.Add(xAnimals);
            xDocument.Save(path);
        }

        /// <summary>
        /// Обработка нулевых значений
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Input(string val)
        {
            if (val == null) return " ";
            else return val;
        }
    }
}
