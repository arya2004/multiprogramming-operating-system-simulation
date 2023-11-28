using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_1
{
    public class SOS
    {
        public char[,]? M { get; set; }
        public char[]? IR { get; set; }
        public char[]? R { get; set; }
        public int  IC { get; set; }
        public int SI { get; set; }
        public bool  T { get; set; }
        public char[]? Buffer { get; set; }

        public readonly string ip = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\Input.txt";
        public readonly string op = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\Output.txt";
        int LineNumber { get; set; } = 0;
        StreamReader? sr { get; set; }

        public  SOS()
        {
            M = new char[100,4];
            IR = new char[4];
            R = new char[4];
            IC = 0;
            SI = 0;
            T = false;
            Buffer = new char[40];
            sr = new StreamReader(ip);
           LineNumber = 0;


        }
        public void INIT()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    M[i,j] = ' ';

                }

            }
            IR[0] = ' ';
            R[0] = ' ';
            IC = 0;
            SI = 0;
            T = false;
            
            for (int j = 0; j < 40; j++)
            {
                Buffer[j] = ' ';

            }
            //sr = new StreamReader(ip);
            // LineNumber = 0;

        }
        public void READ()
        {
            for (int p = 0; p < 40; p++)
            {
                Buffer[p] = ' ';
            }
            string line = File.ReadLines(ip).Skip(LineNumber).Take(1).First();
            LineNumber++;
            for (int ii = 0; ii < line.Length; ii++)
            {
                Buffer[ii] = line[ii];
            }

            int k = 0;
            int i = IR[2] - '0';
            i = i * 10;


            for (int l = 0; l < 10; l++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (k < 40)
                    {
                        M[i, j] = Buffer[k];
                        k++;
                    }
                   
                    
                }
               
                i++;
            }

        }
        public void WRITE()
        {
            for (int p = 0; p < 40; p++)
            {
                Buffer[p] = ' ';
            }

            int k = 0;
            int i = IR[2] - 48;
            i = i * 10;


            for (int l = 0; l < 10; ++l)
            {
                for (int j = 0; j < 4; ++j)
                {
                    Buffer[k] = M[i,j];
                    

                    k++;
                }
                if (k == 40)
                {
                    break;
                }
                i++;
            }
            string temp = new string(Buffer);
            File.AppendAllText(op, temp + Environment.NewLine);

        }

        public void TERMINATE()
        {
            File.AppendAllText(op, Environment.NewLine);
            File.AppendAllText(op, Environment.NewLine);
        }

        public void MOS()
        {
            if(SI == 1)
            {
                READ();
            }
            else if(SI == 2)
            {
                WRITE();
                
            }
            else if(SI ==3)
            {
                TERMINATE();
            }
        }

        public void EXECUTE()
        {
            while (true)
            {
                for (int i = 0; i < 4; i++)        //Load in register
                {
                    IR[i] = M[IC, i];
                }
                IC++;
                if (IR[0] == 'G' && IR[1] == 'D')    //GD
                {
                    SI = 1;
                    MOS();
                }
                else if (IR[0] == 'P' && IR[1] == 'D')       //PD
                {
                    SI = 2;
                    MOS();
                }
                else if (IR[0] == 'H')      //H
                {
                    SI = 3;
                    MOS();
                    break;
                }
                else if (IR[0] == 'L' && IR[1] == 'R')       //LR
                {
                    int i = IR[2] - 48;
                    i = i * 10 + (IR[3] - 48);

                    for (int j = 0; j <= 3; j++)
                        R[j] = M[i, j];

                   
                }
                else if (IR[0] == 'S' && IR[1] == 'R')       //SR
                {
                    int i = IR[2] - 48;
                    i = i * 10 + (IR[3] - 48);
                    
                    for (int jj = 0; jj < 4; jj++)
                    {
                  
                        M[i, jj] = R[jj];
                    }


                }
                else if (IR[0] == 'C' && IR[1] == 'R')       //CR
                {
                    int i = IR[2] - 48;
                    i = i * 10 + (IR[3] - 48);
                    
                    int count = 0;

                    for (int j = 0; j <= 3; j++)
                        if (M[i, j] == R[j])
                            count++;

                    if (count == 4)
                        T = true;

                    //cout<<C;
                }
                else if (IR[0] == 'B' && IR[1] == 'T')       //BT
                {
                    if (T == true)
                    {
                        int i = IR[2] - 48;
                        i = i * 10 + (IR[3] - 48);

                        IC = i;

                    }
                }
            }

        }
        public void LOAD()
        {
            try
            {

           
            int x = 0;
            while (true) 
            {
                for (int i = 0; i <= 39; i++)      //clear buffer
                    Buffer[i] = ' ';

                
                
        
                    string? line = File.ReadLines(ip).Skip(LineNumber).Take(1).First();
                
                
                if(line == null)
                {
                    break;
                }
                LineNumber++;
                for (int ii = 0; ii < line.Length; ii++)
                {
                    Buffer[ii] = line[ii];
                }



                if (Buffer[0] == '$' && Buffer[1] == 'A' && Buffer[2] == 'M' && Buffer[3] == 'J')
                {
                    INIT();

                }
                else if (Buffer[0] == '$' && Buffer[1] == 'D' && Buffer[2] == 'T' && Buffer[3] == 'A')
                {
                    IC = 00;
                   EXECUTE();

                }
                else if (Buffer[0] == '$' && Buffer[1] == 'E' && Buffer[2] == 'N' && Buffer[3] == 'D')
                {
                    x = 0;
                    continue;
                }
                else
                {
                    int k = 0;

                    for (; x < 100; x++)
                    {
                        for (int j = 0; j < 4; j++)
                        {

                            M[x,j] = Buffer[k];
                            k++;
                        }

                        if (k == 40 || Buffer[k] == '\0' || Buffer[k] == '\n')
                        {
                            break;
                        }

                    }

                }

            }
            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.ToString());
            }
        }

        
    }
}
