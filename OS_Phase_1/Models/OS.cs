using OS_Phase_1.Models.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class OS : IOS
    {
        private readonly ExternalMemory _externalMemory;
        private readonly INputOutput _io;
        private readonly CPU _cpu;
        public OS()
        {
            _externalMemory = new ExternalMemory(4, 10, 10);

            _io = new INputOutput(4, 10);
            _cpu = new CPU(4, 4, 2, 1);
            _cpu.SetInstructionRegister(new char[] { 'G', 'D', '4', '0' });
        }

        public void EXECUTE()
        {
            throw new NotImplementedException();
        }

        public void LOAD()
        {
            throw new NotImplementedException();
        }
        //hardcoded
        public void READ()
        {
            _io.ClearBuffer();
            //int MemoryLocation = _cpu.ParseIRNum();
            char[] MemoryLocation = _cpu.GetInctructionRegister();
            _io.Read();
            
            _externalMemory.SetBlock(_io._Buffer, MemoryLocation[2] - '0' );
            _io.ClearBuffer();

            
        }

        public void TERMINATE()
        {
            throw new NotImplementedException();
        }

        public void WRITE()
        {
            throw new NotImplementedException();
        }
    }
}
