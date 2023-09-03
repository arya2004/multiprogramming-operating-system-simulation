
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class OS 
    {
        private readonly ExternalMemory _externalMemory;
        private readonly INputOutput _io;
        private readonly CPU _cpu;
        int stack_ptr = 0;
        int wrt_ptr = 0;
        public OS()
        {
            _externalMemory = new ExternalMemory(4, 10, 10);

            _io = new INputOutput(4, 10);
            _cpu = new CPU(4, 4, 2, 1);
            _cpu.SetInstructionRegister(new char[] { 'G', 'D', '0', '0' });
        }

        //hardcoded
       public void READ()
        {
            _io.ClearBuffer();
            //int MemoryLocation = _cpu.ParseIRNum();
            char[] MemoryLocation = _cpu.GetInctructionRegister();
            _io.Read();
            if (!(_io._Buffer[0] == '$' && _io._Buffer[1] == 'A' && _io._Buffer[2] == 'M' && _io._Buffer[3] == 'J' ))
            {
                _externalMemory.SetBlock(_io._Buffer, stack_ptr);
                stack_ptr++;
            }
            else
            {
                Console.WriteLine("encountered $AMJ");
            }
            
           
            
            _io.ClearBuffer();


        }

        public void TERMINATE()
        {
            throw new NotImplementedException();
        }
        //again hardcded
        public void WRITE()
        {
            _io.ClearBuffer();
            char[] MemoryLocation = _cpu.GetInctructionRegister();
            //_io.WriteTOBuffer(_externalMemory.GetBlock(MemoryLocation[2] - '0'));
            _io.WriteTOBuffer(_externalMemory.GetBlock(wrt_ptr));
            wrt_ptr++;
            _io.Write();
            _io.ClearBuffer();
        }
        public void MOS()
        {
            if(_cpu._SI == 1)
            {
                READ();
            }
            if (_cpu._SI == 2)
            {
                WRITE();
            }
            if (_cpu._SI == 3)
            {
                TERMINATE();
            }
        }

        public void EXECUTE()
        {
            throw new NotImplementedException();
        }

        public void LOAD()
        {
            Console.WriteLine("Loadin'");
            

             
        }
        

       
    }
}
