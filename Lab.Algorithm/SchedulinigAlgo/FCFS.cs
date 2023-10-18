using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.SchedulinigAlgo
{
    /*
    > accept process from user
    > accept AT and BT
    > sort ascending according to AT
    > execute process on cpu based on AT
    > find out CT of each process

    >CT:
    i = 0 -> start time = 0
    i != 0 -> start time = CTC (-1)

    >Find TAT, WT, RT

    >Display gantt chart
    >STOP
     */

    public class Process
    {
        public int PId { get; set; }
        public int AT { get; set; }
        public int BT { get; set; }
        public int CT { get; set; }
        public int TAT { get; set; }
        public int WT { get; set; }
        public int RT { get; set; }
        public Process(int _Pid, int _AT, int _BT)
        {
            PId = _Pid;
            AT = _AT;
            BT = _BT;
        }
        public Process(int _AT, int _BT)
        {
            AT = _AT;
            BT = _BT;
        }

        public void CalculateCT()
        {
            CT = BT + AT;
        }
        public void CalculateTAT()
        {
            TAT = CT - AT;
        }
        public void CalculateWT()
        {
           WT = TAT - BT;
        }
        public void CalculateRT()
        {
            RT = WT;
        }
    }
    public class FCFS
    {
       
        public void Algorithm()
        {
            Console.WriteLine("enter the nunmber of processes");
            int a  = Convert.ToInt32(Console.ReadLine());
            
            Process[] q = new Process[a];
            //q[0] = new Process(0, 1, 4);
            //q[1] = new Process(1, 1, 2);
            //q[2] = new Process(2, 2, 8);

            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Enter Process {0} Arrival Time", i);
                int AT = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Process {0} Burst Time", i);
                int BT = Convert.ToInt32(Console.ReadLine());
                q[i] = new Process(i, AT, BT);
            }

            Process[] sorted = q.OrderBy(i => i.AT).ToArray();
            //assumed sorted



           // time = sorted[0].AT + sorted[0].CT;
            sorted[0].CT =  sorted[0].AT + sorted[0].BT;


            for (int i = 1; i < sorted.Length; i++)
            {

                if (sorted[i].AT < sorted[i -1].CT)
                {
                    sorted[i].CT = sorted[i - 1].CT + sorted[i].BT;
                }
                else
                {
                    sorted[i].CT = sorted[i].AT + sorted[i].BT;
                }

              
            }

            for (int i = 0; i < sorted.Length; i++)
            {
               // sorted[i].CalculateCT();
                sorted[i].CalculateTAT();
                sorted[i].CalculateWT();
                sorted[i].CalculateRT();
            }
       
            Console.WriteLine("Pid\tAT\tBT\tCT\tTAT\tWT\tRT");
            for (int i = 0; i < sorted.Length; i++)
            {


                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", sorted[i].PId, sorted[i].AT, sorted[i].BT, sorted[i].CT, sorted[i].TAT, sorted[i].WT, sorted[i].RT);
            }
        }
    }
}
