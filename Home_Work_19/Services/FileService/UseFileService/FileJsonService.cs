using Home_Work_19.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Home_Work_19.Services.FileService.UseFileService
{
    internal class FileJsonService : IFileService
    {
        /// <summary>
        /// Настройки для сериализации и десериализации
        /// </summary>
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        public ObservableCollection<IAnimal> OpenFile(string path)
        {
            ObservableCollection<IAnimal> animals;
            animals = JsonConvert.DeserializeObject<ObservableCollection<IAnimal>>(File.ReadAllText(path), settings);
            return animals;
        }

        public void SaveFile(ObservableCollection<IAnimal> animals, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(animals, settings));
        }
    }
}
