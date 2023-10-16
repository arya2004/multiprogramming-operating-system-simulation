using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Disk_Scheduling
{
    public class SSTF
    {
        public int _CurrentHeadPosition { get; set; }
        public int[]? _ProcessQueue { get; set; }
        public int _TotalTrack { get; set; }

        public int _TotalDistance { get; set; }
        public int[]? _Visited { get; set; }

        public SSTF(int CurrentHeadPosition, int[] ProcessQueue, int TotalTrack, int ArryLen)
        {
            _CurrentHeadPosition = CurrentHeadPosition;
            _ProcessQueue = ProcessQueue;
            _TotalTrack = TotalTrack;
            _TotalDistance = 0;
            

        }
        public int FindLowest()
        {
            int lowPos = 0;
            int lowval = int.MaxValue;
            for (int i = 0; i < _ProcessQueue.Length; i++)
            {
                if (_ProcessQueue[i] > lowval)
                {
                    lowPos = i;
                    lowval = _ProcessQueue[i];
                }
            }
            return lowPos;
        }
        public void Algorithm()
        {
            int Lowest_Pos = FindLowest();

        }
    }
}
