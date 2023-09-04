
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class OS 
    {
        public readonly ExternalMemory _externalMemory;
        public readonly INputOutput _io;
       public readonly CPU _cpu;
        int stack_ptr = 0;
        int wrt_ptr = 0;
        int block_ptr = 0;
        public OS()
        {
            _externalMemory = new ExternalMemory(4, 10, 10);

            _io = new INputOutput(4, 10);
            _cpu = new CPU(4, 4, 2, 1);
          //  _cpu.SetInstructionRegister(new char[] { 'G', 'D', '4', '0' });
        }

        //hardcoded
       public void READ()
        {
            _io.ClearBuffer();
            //int MemoryLocation = _cpu.ParseIRNum();
            char[] MemoryLocation = _cpu.GetInctructionRegister();
            int Memory_Location = _cpu._InstructionRegister[2] - '0';

            _io.Read();

                _externalMemory.SetBlock(_io._Buffer, Memory_Location);
          
            
            
           
            
            _io.ClearBuffer();


        }

        public void TERMINATE()
        {
            _io.ClearBuffer();
            _io.PrintNewLines();
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
            else if (_cpu._SI == 2)
            {
                WRITE();
            }
            else if (_cpu._SI == 3)
            {
                TERMINATE();
            }
        }

        public void EXECUTE()
        {
            Console.WriteLine("cute");
            for (int i = 0; i < 10; i++)
            {
                _cpu.SetInstructionRegister(_externalMemory.GetWord(_externalMemory.Instruction_Counter));
                _externalMemory.Instruction_Counter++;
                Console.WriteLine(_cpu._InstructionRegister);
            }
        }

        public void LOAD()
        {
            Console.WriteLine("Loadin'");
            int a = 0;
            while(_io.Read())
            {
                if (_io.EncounteredAMJ())
                {
                    Console.WriteLine("Saw AMJ");
                   _externalMemory.CLearMemory();
                    _cpu.ClearRegister();
                    _cpu.ClearInstructionRegister();
                    _cpu.C = false;
                    block_ptr = 0;
                }
                else if (_io.EncounteredDTA())
                {
                    Console.WriteLine("SAw DTA");
                    EXECUTE();
                }
                else if (_io.EncounteredEND())
                {
                    Console.WriteLine("SAW END");
                    continue;
                }
                else
                {
                    _externalMemory.SetBlock(_io._Buffer, block_ptr);
                    block_ptr++;
                }
            }
                 

             
        }
        

       
    }
}
