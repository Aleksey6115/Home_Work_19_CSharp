using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work_19.Model;
using System.Collections.ObjectModel;

namespace Home_Work_19.Services.FileService.UseFileService
{
    internal interface IFileService
    {
        /// <summary>
        /// Открыть файл
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        ObservableCollection<IAnimal> OpenFile(string path);

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="animals"></param>
        /// <param name="path"></param>
        void SaveFile(ObservableCollection<IAnimal> animals, string path);
    }
}
