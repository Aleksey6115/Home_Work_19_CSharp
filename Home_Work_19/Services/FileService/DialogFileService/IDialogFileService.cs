using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_19.Services.FileService.DialogFileService
{
    /// <summary>
    /// Интерфейс для диалоговых окон Сохранить/Открыть
    /// </summary>
    public interface IDialogFileService
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Открыть диалоговое окно для открытие файла
        /// </summary>
        bool OpenFileDialog();

        /// <summary>
        /// Открыть диалоговое окно для сохранения файла
        /// </summary>
        bool SaveFileDialog();
    }
}
