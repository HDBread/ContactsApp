using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {
        public void SaveFile(Project _project, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                //Открываем поток для записи в файл с указанием пути
                using (StreamWriter sw = new StreamWriter(filePath))
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

        public Project LoadFile(Project project, string filePath)
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(filePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
               project = (serializer.Deserialize<Project>(reader));
                return project;
            }
        }
        
    }
}
