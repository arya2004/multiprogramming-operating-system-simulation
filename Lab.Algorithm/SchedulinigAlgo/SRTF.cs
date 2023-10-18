using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.SchedulinigAlgo
{
    public class Process_SRTF
    {
        public int pid; // Process_SRTF ID 
        public int bt; // Burst Time 
        public int art; // Arrival Time 

        public Process_SRTF(int pid, int bt, int art)
        {
            this.pid = pid;
            this.bt = bt;
            this.art = art;
        }
    }

    public class SRTF
    {
        // Method to find the waiting  
        // time for all Process_SRTFes 
        public static void findWaitingTime(Process_SRTF[] proc, int n,
                                        int[] wt)
        {
            int[] rt = new int[n];

            // Copy the burst time into rt[] 
            for (int i = 0; i < n; i++)
                rt[i] = proc[i].bt;

            int complete = 0, t = 0, minm = int.MaxValue;
            int shortest = 0, finish_time;
            bool check = false;

            // Process_SRTF until all Process_SRTFes gets 
            // completed 
            while (complete != n)
            {

                // Find Process_SRTF with minimum 
                // remaining time among the 
                // Process_SRTFes that arrives till the 
                // current time` 
                for (int j = 0; j < n; j++)
                {
                    if ((proc[j].art <= t) &&
                    (rt[j] < minm) && rt[j] > 0)
                    {
                        minm = rt[j];
                        shortest = j;
                        check = true;
                    }
                }

                if (check == false)
                {
                    t++;
                    continue;
                }

                // Reduce remaining time by one 
                rt[shortest]--;

                // Update minimum 
                minm = rt[shortest];
                if (minm == 0)
                    minm = int.MaxValue;

                // If a Process_SRTF gets completely 
                // executed 
                if (rt[shortest] == 0)
                {

                    // Increment complete 
                    complete++;
                    check = false;

                    // Find finish time of current 
                    // Process_SRTF 
                    finish_time = t + 1;

                    // Calculate waiting time 
                    wt[shortest] = finish_time -
                                proc[shortest].bt -
                                proc[shortest].art;

                    if (wt[shortest] < 0)
                        wt[shortest] = 0;
                }
                // Increment time 
                t++;
            }
        }

        // Method to calculate turn around time 
        public static void findTurnAroundTime(Process_SRTF[] proc, int n,
                                int[] wt, int[] tat)
        {
            // calculating turnaround time by adding 
            // bt[i] + wt[i] 
            for (int i = 0; i < n; i++)
                tat[i] = proc[i].bt + wt[i];
        }

        // Method to calculate average time 
        public static void findavgTime(Process_SRTF[] proc, int n)
        {
            int[] wt = new int[n]; int[] tat = new int[n];
            int total_wt = 0, total_tat = 0;

            // Function to find waiting time of all 
            // Process_SRTFes 
            findWaitingTime(proc, n, wt);

            // Function to find turn around time for 
            // all Process_SRTFes 
            findTurnAroundTime(proc, n, wt, tat);

            // Display Process_SRTFes along with all 
            // details 
            Console.WriteLine("Process_SRTFes " +
                            " Burst time " +
                            " Waiting time " +
                            " Turn around time");

            // Calculate total waiting time and 
            // total turnaround time 
            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
                Console.WriteLine(" " + proc[i].pid + "\t\t"
                                + proc[i].bt + "\t\t " + wt[i]
                                + "\t\t" + tat[i]);
            }

            Console.WriteLine("Average waiting time = " +
                            (float)total_wt / (float)n);
            Console.WriteLine("Average turn around time = " +
                            (float)total_tat / (float)n);
        }

        // Driver Method 
        //public static void Main(String[] args)
        //{
        //    Process_SRTF[] proc = { new Process_SRTF(1, 6, 1),
        //                    new Process_SRTF(2, 8, 1),
        //                    new Process_SRTF(3, 7, 2),
        //                    new Process_SRTF(4, 3, 3)};

        //    findavgTime(proc, proc.Length);
        //}
    }

}