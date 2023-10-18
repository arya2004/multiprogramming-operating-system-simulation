using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.Disk_Scheduling
{
    public class CSCAN
    {
        public int _CurrentHeadPosition { get; set; }
        public int[]? _ProcessQueue { get; set; }
        public int _TotalTrack { get; set; }
        
        public CSCAN(int CurrentHeadPosition, int[] ProcessQueue, int TotalTrack)
        {
            _CurrentHeadPosition = CurrentHeadPosition;
            _ProcessQueue = ProcessQueue;
            _TotalTrack = TotalTrack;
            
        }
        public void Algorithm()
        {
            Array.Sort(_ProcessQueue);
            int _tempPtr = 0;// = _CurrentHeadPosition;
            while(_ProcessQueue[_tempPtr] < _CurrentHeadPosition)
            {
                _tempPtr++;
            }
            int _o = _tempPtr;
            do
            {
                Console.WriteLine(_ProcessQueue[_o]);
                _o = (_o + 1) % _ProcessQueue.Length;   
            } while (_o != _tempPtr);
        }
    }
}
