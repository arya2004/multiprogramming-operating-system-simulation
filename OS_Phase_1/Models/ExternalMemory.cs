using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
   

    public class ExternalMemory
    {
        public char[,] Memory { get; set; }
        public int _Blocks { get; set; }
        public int _WordLength { get; set; }
        public int _WordsPerBlock { get; set; }
        public int Instruction_Counter { get; set; }


        public ExternalMemory(int WordLength, int Blocks, int WordsPerBlock)
        {
            Memory = new char[WordsPerBlock * Blocks, WordLength];
            _WordLength = WordLength;
            _Blocks = Blocks;
            _WordsPerBlock = WordsPerBlock;
            Instruction_Counter = 0;
            
        }

        public char[] GetWord(int Address)
        {
            char[] Word = new char[_WordLength];
            for (int i = 0; i < _WordLength; i++)
            {
                Word[i] = Memory[Address, i];
            }
            return Word;
        }
        public void SetWord(int Address, char[] Word)
        {
            for (int i = 0; i < _WordLength; i++)
            {
                Memory[Address,i] = Word[i];
            }
        }

        public char[,] GetBlock(int BlockAddress)
        {
            char[,] Block = new char[_WordsPerBlock, _WordLength];

            for (int i = 0; i < _WordsPerBlock; i++)
            {
                for (int j = 0; j < _WordLength; j++)
                {
                    Block[i,j] = Memory[(BlockAddress* _WordsPerBlock) + i, j];
                }
            }
            return Block;
        }

        public void SetBlock(char[,] GivenBloc, int BlockAddress)
        {
            for (int i = 0; i < _WordsPerBlock; i++)
            {
                for (int j = 0; j < _WordLength; j++)
                {
                    Memory[(BlockAddress * _WordsPerBlock) + i, j] = GivenBloc[i, j];
                }
            }
            
        }
        public void SetBlock(char[] GivenBloc, int BlockAddress)
        {
            int k = 0;
            for (int i = 0; i < _WordsPerBlock; i++)
            {
                for (int j = 0; j < _WordLength; j++)
                {
                    Memory[(BlockAddress * _WordsPerBlock) + i, j] = GivenBloc[k];
                    k++;
                }
            }

        }

        public void CLearBlock(int BlockAddress)
        {
            for (int i = 0; i < _WordsPerBlock; i++)
            {
                for (int j = 0; j < _WordLength; j++)
                {
                    Memory[(BlockAddress * _WordsPerBlock) + i, j] = '*';
                }
            }

        }
        public void CLearMemory()
        {
            for (int i = 0; i < _Blocks; i++)
            {
                
                   CLearBlock (i);
                
            }

        }


    }
}
