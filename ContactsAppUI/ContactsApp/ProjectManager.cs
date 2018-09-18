using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {
        public void SaveFile(Project _project)
        {
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\ТУСУР\НТвП\saveFile\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, _project);
            }
        }

        public Project LoadFile(Project project)
        {
            //Создаём переменную, в которую поместим результат десериализации
            project = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\ТУСУР\НТвП\saveFile\json.txt"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                return project = (Project)serializer.Deserialize(reader);
            }
        }
        
    }
}
