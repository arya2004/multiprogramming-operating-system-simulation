using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.SchedulinigAlgo
{   
    public class Proc
    {
        public int PId { get; set; }
        public int AT { get; set; }
        public int BT { get; set; }

        public int CT { get; set; }
        public int TAT { get; set; }
        public int WT { get; set; }
        public int RT { get; set; }
        public int RemainingBt { get; set; }
        public Proc(int _Pid, int _AT, int _BT)
        {
            PId = _Pid;
            AT = _AT;
            BT = _BT;
            RemainingBt = _BT;
        }
        public Proc(int _AT, int _BT)
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
        
    }
    public class RoundRobin
    {   
        
        public void Algorithm()
        {   

            Proc[] u = new Proc[4];
            u[0] = new Proc(0, 0, 3);
            u[1] = new Proc(1, 0, 6);
            u[2] = new Proc(2, 0, 4);
            u[3] = new Proc(3, 0, 5);


            int[] isComplete = new int[4];
            int[] isScheduled = new int[4];
            int kkk = 0;
            int TQ = 2;
            int currentTime = 0;
            Console.WriteLine("Gantt Cgart");
            while (!(isComplete.Sum() == isComplete.Length))
            {
                if (isComplete[kkk] != 1)
                {


                    if (isScheduled[kkk] == 0 )
                    {
                        isScheduled[kkk] = 1;
                        u[kkk].RT = currentTime - u[kkk].AT;
                    }
                    Console.Write("schedule {0} ", kkk + 1);
                    if (u[kkk].RemainingBt >= TQ)
                    {
                        currentTime += TQ;
                        u[kkk].RemainingBt -= TQ;

                        if (u[kkk].RemainingBt == 0)
                        {
                            u[kkk].CT = currentTime;
                            isComplete[kkk] = 1;
                            Console.Write("conpmeted {0} ", kkk + 1);
                        }
                        else
                        {
                            Console.Write("queued {0} ", kkk + 1);
                        }
                    }
                    else
                    {
                        currentTime += u[kkk].RemainingBt;
                        u[kkk].RemainingBt = 0;
                        u[kkk].CT = currentTime;
                        isComplete[kkk] = 1;
                        Console.Write("complweted {0} ", kkk + 1);
                    }
                }
                kkk = (kkk + 1)%4;

            }

            for (int i = 0; i < u.Length; i++)
            {
                // sorted[i].CalculateCT();
                u[i].CalculateTAT();
                u[i].CalculateWT();

            }
            Console.WriteLine("\n");
            Console.WriteLine("Pid\tAT\tBT\tCT\tTAT\tWT\tRT");
            for (int i = 0; i < u.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", u[i].PId, u[i].AT, u[i].BT, u[i].CT, u[i].TAT, u[i].WT, u[i].RT);
            }

           

        }
    }
}
