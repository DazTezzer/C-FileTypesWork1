using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace C_FileTypesWork1
{
    public class Person
    {

        public string Name { get; }
        public int Age{ get; }
        public string Country { get; }
        public Person(string name, int age, string country)
        {
            Name = name;
            Age = age;  
            Country = country;  
        }
    }
    internal class Json_part
    {
        public string File_name;
        public string File_path;
        public Json_part(string file_name)
        {
            File_name = file_name;
            File_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, File_name);
            Create();
            Insert();
            Read();
            Delete();
        }

        public void Create()
        {
            if (!File.Exists(File_path))
            {
                FileStream fs = File.Create(File_path);
                fs.Dispose();
            }
        }
        public void Insert()
        {
            Console.WriteLine("Введите Имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите страну: ");
            string country = Console.ReadLine();
            Person person = new Person(name, age, country);
            string json = JsonSerializer.Serialize(person);
            File.WriteAllText(File_path, json);
        }
        public void Read()
        {
            string json = File.ReadAllText(File_path);
            Person person = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(person.Name + " " + person.Age + " " + person.Country);
        }
        public void Delete()
        {
            if (File.Exists(File_path))
            {
                File.Delete(File_path);
                Console.WriteLine("Файла успешно удалён");
            }
            else
            {
                Console.WriteLine("Данного файла не существует");
            }
        }
    }
}
