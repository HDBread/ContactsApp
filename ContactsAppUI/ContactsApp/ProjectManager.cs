using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {
        private string _filePathDefault = @"C:\Users\User\Desktop\ТУСУР\НТвП\saveFile\Contacts.txt";

        public void SaveFile(Project _project, string _filePath)
        {
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

        public Project LoadFile(Project project, string _filePath)
        {
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
