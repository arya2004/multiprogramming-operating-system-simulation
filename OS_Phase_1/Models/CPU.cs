using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class CPU
    {
        public char[] _Register;
        public char[] _InstructionRegister;
        public char[] _ProgramCounter;
        public char[] _ToggleRegister;


        public CPU(int RegisterSize, int InstructionSIze, int ProgramCOunterSize, int TOggleRegister)
        {
            _Register = new char[RegisterSize];
            _InstructionRegister = new char[InstructionSIze];
            _ProgramCounter = new char[ProgramCOunterSize];
            _ToggleRegister = new char[TOggleRegister];
            for (int i = 0; i < ProgramCOunterSize; i++)
            {
                _ProgramCounter[i] = '0';
            }

          
        }

        public void SetRegiset(char[] Register)
        {
            _Register = Register;
        }

        public char[] GetRegiset()
        {
            return _Register;
        }

        public void SetInstructionRegister(char[] InstructionRegister)

        { 
            _InstructionRegister = InstructionRegister; 
        }

        public char[] GetInctructionRegister()
        {

            return _InstructionRegister;
        }

        public void ClearInstructionRegister()
        {
            for (int i = 0; i < _InstructionRegister.Length; i++)
            {
                _InstructionRegister[i]= '\0';
            }
        }
        //hardcoded
        public int ParseIRNum()
        {
            return (_InstructionRegister[2] - '0') * 10 + (_InstructionRegister[3] - '0');
        }

        
        
    }
}
