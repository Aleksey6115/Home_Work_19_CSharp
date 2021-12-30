using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work_19.Model;
using System.Collections.ObjectModel;
using Home_Work_19.Services.AddAnimal;
using Home_Work_19.MVVM;
using Home_Work_19.Services.FileService.DialogFileService;
using Home_Work_19.Services.FileService.UseFileService;
using System.Windows;

namespace Home_Work_19
{
    public class MainWindowVM : ViewModelBase
    {
        #region Поля
        private IAnimal selectedAnimal; // Выбранное животное
        #endregion

        #region Свойства
        /// <summary>
        /// Выбранное животное
        /// </summary>
        public IAnimal SelectedAnimal
        {
            get => selectedAnimal;
            set => Set(ref selectedAnimal, value);
        }

        /// <summary>
        /// Список животных
        /// </summary>
        public ObservableCollection<IAnimal> AnimalList { get; set; }
        #endregion

        #region Сервисы
        private IAddAnimalService addAnimalService; // Сервис добавления нового животного
        private IDialogFileService dialogFileService; // Работа с окнами Открыть/Сохранить
        #endregion

        #region Конструктор
        public MainWindowVM()
        {
            AnimalList = new ObservableCollection<IAnimal>();
            addAnimalService = new AddAnimalService();
            dialogFileService = new DefaultDialogFileService();
        }
        #endregion

        #region Методы
        /// <summary>
        /// Открыть файл
        /// </summary>
        /// <param name="service"></param>
        private void OpenFile(IFileService service)
        {
            try
            {
                if (dialogFileService.OpenFileDialog() == true)
                {
                    ObservableCollection<IAnimal> animals = service.OpenFile(dialogFileService.FilePath);

                    AnimalList.Clear();
                    foreach (var a in animals)
                        AnimalList.Add(a);

                    MessageBox.Show("Файл открыт", "Открытие файла", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Открытие файла", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="service"></param>
        private void SaveFile(IFileService service)
        {
            try
            {
                if (dialogFileService.SaveFileDialog() == true)
                {
                    service.SaveFile(AnimalList, dialogFileService.FilePath);
                    MessageBox.Show("Файл сохранён", "Сохранение файла", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сохранение файла", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #endregion

        #region Комманды
        private RelayCommand addAnimalCommand; // Комманда добавить нового клиента
        private RelayCommand deleteAnimalCommand; // Удалить выбранную запись
        private RelayCommand openJsonFileCommand; // Комманда открыть файл Json
        private RelayCommand saveJsonFileCommand; // Команда сохранить файл Json
        private RelayCommand openXmlFileCommand; // Комманда открыть файл XML
        private RelayCommand saveXmlFileCommand; // Команда сохранить файл XML

        /// <summary>
        /// Комманда добавить нового клиента
        /// </summary>
        public RelayCommand AddAnimalCommand
        {
            get
            {
                return addAnimalCommand ?? (addAnimalCommand = new RelayCommand(obj =>
                {
                    if (addAnimalService.OpenAddAnimalWindow() == true)
                        AnimalList.Add(addAnimalService.NewAnimal);
                }));
            }
        }

        /// <summary>
        /// Удалить выбранную запись
        /// </summary>
        public RelayCommand DeleteAnimalCommand
        {
            get
            {
                return deleteAnimalCommand ?? (deleteAnimalCommand = new RelayCommand(obj =>
                {
                    AnimalList.Remove(SelectedAnimal);
                },
                obj =>
                {
                    return SelectedAnimal != null;
                }));
            }
        }

        /// <summary>
        /// Комманда открыть файл
        /// </summary>
        public RelayCommand OpenJsonFileCommand
        {
            get
            {
                return openJsonFileCommand ?? (openJsonFileCommand = new RelayCommand(obj =>
                {
                    OpenFile(new FileJsonService());
                }));
            }
        }

        /// <summary>
        /// Комманда сохранить файл
        /// </summary>
        public RelayCommand SaveJsonFileCommand
        {
            get
            {
                return saveJsonFileCommand ?? (saveJsonFileCommand = new RelayCommand(obj =>
                {
                    SaveFile(new FileJsonService());
                },
                obj =>
                {
                    return AnimalList.Count > 0;
                }));
            }
        }

        /// <summary>
        /// Комманда открыть файл XML
        /// </summary>
        public RelayCommand OpenXmlFileCommand
        {
            get
            {
                return openXmlFileCommand ?? (openXmlFileCommand = new RelayCommand(obj =>
                {
                    OpenFile(new FileXmlService());
                }));
            }
        }

        /// <summary>
        /// Команда сохранить файл XML
        /// </summary>
        public RelayCommand SaveXmlFileCommand
        {
            get
            {
                return saveXmlFileCommand ?? (saveXmlFileCommand = new RelayCommand(obj =>
                {
                    SaveFile(new FileXmlService());
                },
                obj =>
                {
                    return AnimalList.Count > 0;
                }));
            }
        }

        #endregion
    }
}
