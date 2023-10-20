using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;


namespace C_FileTypesWork1
{
    internal class Zip_part
    {
        public string Arc_name;
        public string Arc_path;
        public string File_name;
        public string File_path;
        
        public Zip_part(string arc_name, string file_name)
        {
            File_name = file_name;
            File_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, File_name);
            Arc_name = arc_name;
            Arc_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Arc_name);
            Create();
            Insert();
            Read();
            Delete();
        }

        public void Create()
        {
            if (!File.Exists(File_path))
            {
                using (ZipArchive zipArchive = ZipFile.Open(File_path, ZipArchiveMode.Create))
                {
                    zipArchive.Dispose();
                }
            }
        }
        public void Insert()
        {
            using (ZipArchive archive = ZipFile.Open(Arc_path, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(File_path, File_name);
            }
        }
        public void Read()
        {
            string destinationFolderPath = "unzip";
            using (ZipArchive archive = ZipFile.Open(Arc_path, ZipArchiveMode.Read))
            {
                ZipArchiveEntry entry = archive.GetEntry(File_name);
                entry.ExtractToFile(Path.Combine(destinationFolderPath, entry.Name));
            }
            string fileContents = File.ReadAllText(Path.Combine(destinationFolderPath, File_name));
            Console.WriteLine(fileContents);
        }
        public void Delete()
        {
            if (File.Exists(Arc_path))
            {
                File.Delete(Arc_path);
                Console.WriteLine("Архив успешно удалён");
            }
            else
            {
                Console.WriteLine("Данного архива не существует");
            }
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