using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс для сохранения/загрузки данных
    /// </summary>
    public class ProjectManager
    {
        //TODO: задавать не полный путь файла
        /// <summary>
        /// Стандартный путь сохранения/загрузки файла
        /// </summary>
        private string _filePathDefault = @"C:\Users\User\Desktop\ТУСУР\НТвП\saveFile\New.txt";

        /// <summary>
        /// Метод сохранения файла
        /// </summary>
        /// <param name="_project">Список контактов для сохрарения</param>
        /// <param name="_filePath">Путь для сохранения файла</param>
        public void SaveFile(Project _project, string _filePath)
        {
            //Если путь не указан, что сохранаем с стандартную директорию
            if (_filePath == String.Empty)
            {
                _filePath = _filePathDefault;
            }
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                //Открываем поток для записи в файл с указанием пути
                using (StreamWriter sw = new StreamWriter(_filePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    //Вызываем сериализацию и передаем объект, который хотим сериализовать
                    serializer.Serialize(writer, _project);
                }
            }
            catch (ArgumentException e)
            {
                
            }
        }

        /// <summary>
        /// Метод загрузки файла
        /// </summary>
        /// <param name="project">Список загружаемых контактов</param>
        /// <param name="_filePath">Путь от куда будут загруженны данные</param>
        /// <returns>Список с контактами</returns>
        public Project LoadFile(Project project, string _filePath)
        {
            //Если путь дериктории не указан, то загружаем из стандартной директории
            if (_filePath == String.Empty)
            {
                _filePath = _filePathDefault;
            }
            
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(_filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project = (serializer.Deserialize<Project>(reader));
                return project;
            }
        }
        
    }
}
