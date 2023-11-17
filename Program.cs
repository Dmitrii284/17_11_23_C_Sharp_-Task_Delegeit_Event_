using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _17_11_23_C_Sharp__Task_Delegeit_Event_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Multi_rotorUAV multirotor = new Multi_rotorUAV()
            {
                Model = "Коптер 4-х винтовой - Квадро",
                Massa = 2.5,
                Speed = 80,
                RotorsCount = 4
            };
            UAV_glider uAV_Glider = new UAV_glider()
            {
                Model = "Планер",
                Massa = 5.8,
                Speed = 160,
                Wingspan = 40
            };

            ControlSystem controlSystem = new ControlSystem();
            controlSystem.AddBPLA(multirotor);
            controlSystem.AddBPLA(uAV_Glider);

            controlSystem.BPLAMoved += BPLAMovement;
            controlSystem.BPLAControl(multirotor, 20, 40, 50);
            controlSystem.BPLAControl(uAV_Glider, 15, 25, 35);

            controlSystem.SaveDataToFile(multirotor, "Коптер 4-х винтовой - Квадро.txt", FileType.TXT);
            controlSystem.SaveDataToFile(multirotor, "Коптер 4-х винтовой - Квадро.json", FileType.JSON);
            controlSystem.SaveDataToFile(multirotor, "Коптер 4-х винтовой - Квадро.xml", FileType.XML);

            controlSystem.SaveDataToFile(uAV_Glider, "Планер.txt", FileType.TXT);
            controlSystem.SaveDataToFile(uAV_Glider, "Планер.json", FileType.JSON);
            controlSystem.SaveDataToFile(uAV_Glider, "Планер.xml", FileType.XML);
        }


        private static void BPLAMovement(BPLA bPLA, double x, double y, double z)
        {
            Console.WriteLine($" БПЛА: {bPLA.Model}\n Координата X = {x}\n Координата Y = {y} \n Координата Z ={z}");
        }

    }
    
}