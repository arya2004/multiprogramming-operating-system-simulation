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
        public int _ProgramCounter; //instrcuction counter
        public char[] _ToggleRegister;
        public int _SI; //interrupt
        public bool C { get; set; }


        public CPU(int RegisterSize, int InstructionSIze, int ProgramCOunterSize, int TOggleRegister)
        {
            _Register = new char[RegisterSize];
            _InstructionRegister = new char[InstructionSIze];
            _ProgramCounter = 0;
            _ToggleRegister = new char[TOggleRegister];
            C = false;
            

          
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
        public void ClearRegister()
        {
            for (int i = 0; i < _Register.Length; i++)
            {
                _Register[i] = '\0';
            }
        }
        //hardcoded
        public int ParseIRNum()
        {
            return (_InstructionRegister[2] - '0') * 10 + (_InstructionRegister[3] - '0');
        }

        
        
    }
}
