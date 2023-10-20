using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace C_FileTypesWork1
{
    internal class File_part
    {
        public string File_name;
        public string File_data;
        public string File_path;
        public File_part(string file_name, string file_data)
        {
            File_name = file_name;
            File_data = file_data;
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
            File.WriteAllText(File_path, File_data);
        }
        public void Read()
        {
            string text = File.ReadAllText(File_path);
            Console.WriteLine(text);
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
