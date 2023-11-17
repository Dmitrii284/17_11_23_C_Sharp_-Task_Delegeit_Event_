using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_11_23_C_Sharp__Task_Delegeit_Event_
{
    public abstract class BPLA
    {
        public string Model { get; set; }
        public double Massa { get; set; }
        public double Speed { get; set; }

        public virtual void Fly()
        {
            Console.WriteLine("!!!!!!!!!!!БПЛА летит!!!!!!!");
        }

    }
}
