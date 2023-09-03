using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1.Models
{
    public class INputOutput
    {
        public char[] _Buffer;
        public  int _WordLength { get; set; }
        public int _WordsPerBlock { get; set; }
        public readonly string CardReader = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\Input.txt";
        public  readonly string LinePrinters = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\Output.txt";
        int LineNumber = 0;
        public INputOutput(int WordLength,  int WordsPerBlock)
        {
            _Buffer = new char[WordsPerBlock* WordLength];
            _WordLength = WordLength;
            _WordsPerBlock = WordsPerBlock;

        }

        public void WriteTOBuffer(char[,] Data)
        {
            int k = 0;
            for (int i = 0; i < _WordsPerBlock; i++)
            {
                for (int j = 0; j < _WordLength; j++)
                {
                    _Buffer[k] = Data[i, j];
                    k++;
                }
            }
        }
        

        public  void Write()
        {
           // StreamWriter sw = new StreamWriter(LinePrinters);
            String temp = "";
            for (int i = 0; i < _WordsPerBlock * _WordLength; i++)
            {
                temp +=_Buffer[i];
            }
           // sw.Close();
            File.AppendAllText(LinePrinters, temp + Environment.NewLine);
        }

        public void Read()
        {
            StreamReader sr = new StreamReader(CardReader);
            
            String line = File.ReadLines(CardReader).Skip(LineNumber).Take(1).First();
            LineNumber++;

            
            _Buffer = line.ToCharArray();
            sr.Close();
        }
        public void ClearBuffer()
        {
            for (int i = 0; i < _Buffer.Length; i++)
            {
                _Buffer[i] = '*';
            }
        }

    }
}
