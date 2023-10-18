using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.Disk_Scheduling
{
    public class FCFS
    {
        public int _CurrentHeadPosition { get; set; }
        public int[]? _ProcessQueue { get; set; }
        public int _TotalTrack { get; set; }

        public int _TotalDistance { get; set; }

        public FCFS(int CurrentHeadPosition, int[] ProcessQueue, int TotalTrack)
        {
            _CurrentHeadPosition = CurrentHeadPosition;
            _ProcessQueue = ProcessQueue;
            _TotalTrack = TotalTrack;
            _TotalDistance = 0;

        }

        public void Algorithm()
        {
            for (int i = 0; i < _ProcessQueue.Length; i++)
            {
                int Curr_Track = _ProcessQueue[i];
                int distance = Math.Abs(Curr_Track - _CurrentHeadPosition);
                Console.WriteLine(Curr_Track + "\t" + distance);
                _TotalDistance += distance;
                _CurrentHeadPosition = Curr_Track;

            }
            Console.WriteLine(_TotalDistance);
        }
    }
}
