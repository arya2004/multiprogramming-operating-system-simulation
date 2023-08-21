using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class CPU
    {
        private char[] _Register;
        private char[] _InstructionRegister;
        private char[] _ProgramCounter;
        private char[] _ToggleRegister;

        public CPU(int RegisterSize, int InstructionSIze, int ProgramCOunterSize, int TOggleRegister)
        {
            _Register = new char[RegisterSize];
            _InstructionRegister = new char[InstructionSIze];
            _ProgramCounter = new char[ProgramCOunterSize];
            _ToggleRegister = new char[TOggleRegister];
        }



    }
}
