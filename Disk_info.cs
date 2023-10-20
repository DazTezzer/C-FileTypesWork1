using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_FileTypesWork1
{
    internal class Disk_info
    {
        public void get_Disk_info()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                Console.WriteLine("Диск {0}", drive.Name);
                Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);
                Console.WriteLine("Тип файловой системы: {0}", drive.DriveFormat);
                Console.WriteLine("Использовано места: {0} Gb", ((drive.TotalSize - drive.AvailableFreeSpace) / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine("Свободно: {0} Gb", (drive.AvailableFreeSpace / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine("Всего: {0} Gb", (drive.TotalSize / 1024 / 1024 / 1024).ToString("N2"));
                Console.WriteLine();
            }

        }
    }
}
