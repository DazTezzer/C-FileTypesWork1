using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



namespace C_FileTypesWork1
{
    internal class Xml_part
    {
        public string File_name;
        public string File_path;
        public string File_data;
        public Xml_part(string file_name,string file_data)
        {
            File_name = file_name;
            File_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, File_name);
            File_data = file_data;
            Create();
            Insert();
            Read();
            Delete();
        }

        public void Create()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.CreateElement("Root");

            doc.AppendChild(declaration);
            doc.AppendChild(root);

            doc.Save(File_path);
        }
        public void Insert()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(File_path);

            XmlElement root = doc.DocumentElement;

            XmlElement messageElement = doc.CreateElement("Data");
            messageElement.InnerText = File_data;

            root.AppendChild(messageElement);

            doc.Save(File_path);
        }
        public void Read()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(File_path);

            XmlNodeList messageNodes = doc.GetElementsByTagName("Data");

            foreach (XmlNode node in messageNodes)
            {
                Console.WriteLine(node.InnerText);
            }
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
