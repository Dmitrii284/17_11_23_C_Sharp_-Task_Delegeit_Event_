using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace _17_11_23_C_Sharp__Task_Delegeit_Event_
{

    public enum FileType // типы файлов
    {
        TXT,
        JSON,
        XML
    }

    public class ControlSystem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public delegate void BPLAMovementHandler(BPLA bpla, double x, double y, double z); //Обработчик движения БПЛА
        public event BPLAMovementHandler BPLAMoved;

        List<BPLA> bpla = new List<BPLA>();
        public void AddBPLA(BPLA bPLA) 
        {
            bpla.Add(bPLA);
        }

        public void RemoveBPLA(BPLA bPLA)
        {
            bpla.Remove(bPLA);
        }
        public void BPLAControl(BPLA bPLA, double x, double y, double z)// Переместить БПЛА в Местоположение
        {               
            BPLAMoved.Invoke(bPLA, x, y, z); // Логика перемещения БПЛА в указанное место
        }
         public void SaveDataToFile(BPLA bPLA, string filePath, FileType type) // Запись в файлы.
         {
            switch(type)
            {
                case FileType.TXT: SaveBPLADataToTxtFile(bPLA, filePath); break;
                case FileType.JSON: SaveBPLADataToJsonFile(bPLA, filePath); break;
                case FileType.XML: SaveBPLADataXmlFile(bPLA, filePath); break;
            }
         }
        private void SaveBPLADataToTxtFile(BPLA bPLAv, string filePath)
        {            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Model: {bPLAv.Model}");
                writer.WriteLine($"Mass: {bPLAv.Massa}");
                writer.WriteLine($"Speed: {bPLAv.Speed}");
            }
        }

        private void SaveBPLADataToJsonFile(BPLA bPLAv, string filePath)
        {            
            string json = JsonConvert.SerializeObject(bPLAv); //Логика сохранения данных БПЛА в файл JSON
            File.WriteAllText(filePath, json);
        }

        private void SaveBPLADataXmlFile(BPLA bPLAv, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(bPLAv.GetType());
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, bPLAv);
            }
        }
                
    }
}
