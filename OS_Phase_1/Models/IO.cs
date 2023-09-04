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
        int LineNumber { get; set; }
        StreamReader sr { get; set; }
        public INputOutput(int WordLength,  int WordsPerBlock)
        {
            _Buffer = new char[WordsPerBlock* WordLength];
            _WordLength = WordLength;
            _WordsPerBlock = WordsPerBlock;
            LineNumber = 0;
             sr = new StreamReader(CardReader);


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

        public void PrintNewLines()
        {
           // String temp = "\n";
            File.AppendAllText(LinePrinters, Environment.NewLine);
            File.AppendAllText(LinePrinters, Environment.NewLine);
        }

        public bool Read()
        {
            StreamReader sr = new StreamReader(CardReader);
            String line = "";
            try
            {
                 line = File.ReadLines(CardReader).Skip(LineNumber).Take(1).First();
            }
            catch (Exception)
            {

                return false;
            }
            
            LineNumber++;
            
           // Console.WriteLine(line);
            _Buffer = line.ToCharArray();
            sr.Close();
            return true;
           
        }
        public void ClearBuffer()
        {
            for (int i = 0; i < _Buffer.Length; i++)
            {
                _Buffer[i] = '*';
            }
        }

        public bool IsBufferEmpty()
        {
            bool a = false;
            for (int i = 0; i < _Buffer.Length; i++)
            {
                if (_Buffer[i] == '\0')
                {
                    a = true;
                    return a;
                }
            }
            return a;
        }


        public bool EncounteredAMJ()
        {
            return (_Buffer[0] == '$' && _Buffer[1] == 'A' && _Buffer[2] == 'M' && _Buffer[3] == 'J');
        }
        public bool EncounteredDTA()
        {
            return (_Buffer[0] == '$' && _Buffer[1] == 'D' && _Buffer[2] == 'T' && _Buffer[3] == 'A');
        }
        public bool EncounteredEND()
        {
            return (_Buffer[0] == '$' && _Buffer[1] == 'E' && _Buffer[2] == 'N' && _Buffer[3] == 'D');
        }


    }
}
