using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace C_FileTypesWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file_name;
            string file_data;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    Disk_info info = new Disk_info();
                    info.get_Disk_info();
                    break;
                case 1:
                    Console.WriteLine("Введите название файла");
                    file_name = Console.ReadLine() + ".txt";
                    Console.WriteLine("Введите данные файла");
                    file_data = Console.ReadLine();
                    File_part file = new File_part(file_name, file_data);
                    break; 
                case 2:
                    Console.WriteLine("Введите название файла");
                    file_name = Console.ReadLine() + ".json";
                    Json_part json_file = new Json_part(file_name);
                    break;
                case 3:
                    Console.WriteLine("Введите название файла");
                    file_name = Console.ReadLine() + ".txt";
                    Console.WriteLine("Введите данные файла");
                    file_data = Console.ReadLine();
                    Xml_part xml_file = new Xml_part(file_name, file_data);
                    break;
                case 4:
                    Console.WriteLine("Введите название архива");
                    file_name = Console.ReadLine() + ".zip";
                    Console.WriteLine("Введите название файла");
                    string arc_name = Console.ReadLine();
                    Zip_part zip_file = new Zip_part(file_name, arc_name);
                    break;
                default:
                    Console.WriteLine("Закрытие программы");
                    break;
            }
            Console.ReadLine();

        }
    }
}
