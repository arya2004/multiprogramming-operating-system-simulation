using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Phase_2
{

    public class Pcb
    {
        public int _JobId { get; set; }
        public int _TTL { get; set; }
        public int _TLL { get; set; }
        public int _LLC { get; set; }
        public int _TTC { get; set; }
        public Pcb()
        {
            
        }
        public Pcb(int JobId, int TTL, int TLL)
        {
            _LLC = 0;
            _TTC = 0;
            _JobId = JobId;
            _TTL = TTL;
            _TLL = TLL;
        }
    }
    public class OS
    {
        //system
        public char[,]? M { get; set; }
        public char[]? IR { get; set; }
        public char[]? R { get; set; }
        public int IC { get; set; }
        public bool T { get; set; }
        public char[]? Buffer { get; set; }
        public int PTR { get; set; }
        Pcb PCB { get; set; }


        public int SI { get; set; }
        public int TI { get; set; }
        public int PI { get; set; }

        //helper

        public bool[] isAllocated { get; set; }
        public int LoadIC { get; set; }



        public readonly string ip = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_2\\IO_Files\\Input.txt";
        public readonly string op = "C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_2\\IO_Files\\Output.txt";

        public int LineNumber { get; set; }
        StreamReader? StreamReader { get; set; }

        public OS()
        {
            M = new char[300, 4];
            IR = new char[4];
            R = new char[4];
            IC = 0;
            T = false;
            Buffer = new char[40];
            StreamReader = new StreamReader(ip);
            LineNumber = 0;

            SI = 0;
            TI = 0;
            PI = 0;

            PCB = new Pcb();

            isAllocated = new bool[30];
            LoadIC = 0;
        }

        public void INIT(int PageTable)
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    M[i, j] = ' ';

                }

            }
            IR[0] = ' ';
            R[0] = ' ';
            IC = 0;
            
            T = false;

            SI = 0;
            TI = 0;
            PI = 0;

            for (int j = 0; j < 40; j++)
            {
                Buffer[j] = ' ';

            }
            for (int j = 0;j < 30;  j++)
            {
                isAllocated[j] = false;
            }
            isAllocated[PageTable] = true;


            //sr = new StreamReader(ip);
            // LineNumber = 0;

        }


        public int AddressMap(int VirtualAddress)
        {
            int PageTableEntry = PTR + (VirtualAddress / 10);
            int M_of_PTE = (M[PageTableEntry, 2] - '0') * 10 + (M[PageTableEntry, 3] - '0');
            int RealAddress = M_of_PTE * 10 + (VirtualAddress % 10);
            return RealAddress;
        }

        

        public int ALLOCATE()
        {
            Random random = new Random();
            int randomNumber = random.Next(30);
            while(isAllocated[randomNumber] == true  )
            {
                randomNumber = random.Next(30);
            }
            isAllocated[randomNumber] = true;
            return randomNumber;

        }

        public void TERMINATE(params int[] EM)
        {


            File.AppendAllText(op, "JOB ID\t:\t" + PCB._JobId + Environment.NewLine);
            for (int i = 0; i < EM.Length; i++)
            {
                string message = "";
                if (EM[i] == 0)
                {
                    message = "No Error";
                }
                else if (EM[i] == 1)
                {
                    message = "Out of Data";
                }
                else if (EM[i] == 2)
                {
                    message = "Line Limit Exceeded";
                }
                else if (EM[i] == 3)
                {
                    message = "Time Limit Exceeded";
                }
                else if (EM[i] == 4)
                {
                    message = "Operation Code Error";
                }
                else if (EM[i] == 5)
                {
                    message = "Operand Error";
                }
                else if (EM[i] == 6)
                {
                    message = "Invalid Page Fault";
                }
                File.AppendAllText(op, message + Environment.NewLine);
            }

            File.AppendAllText(op, "IC\t:\t" + IC.ToString() + Environment.NewLine);
            File.AppendAllText(op, "IR\t:\t" + IR + Environment.NewLine);
            File.AppendAllText(op, "TTC\t:\t" + PCB._TTC + Environment.NewLine);
            File.AppendAllText(op, "LLC\t:\t" + PCB._LLC + Environment.NewLine);

            File.AppendAllText(op, Environment.NewLine);
            File.AppendAllText(op, Environment.NewLine);
        }

        public void READ(int _RealAddress)
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
           if (Buffer[0] == '$' && Buffer[1] == 'E' && Buffer[2] == 'N' && Buffer[3] == 'D')
            {
                TERMINATE(1);
               
            }

            int k = 0;
            int i = IR[2] - '0';
            i = i * 10;
            i += IR[3] - '0';

            //int RealAddress = AddressMap(i);


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

        public void WRITE(int _RealAddress)
        {
            PCB._LLC++;
            if(PCB._LLC >= PCB._TTL)
            {
                TERMINATE(2);
            }

            for (int p = 0; p < 40; p++)
            {
                Buffer[p] = ' ';
            }

            int k = 0;
            int i = IR[2] - '0';
            i = i * 10;
            i += IR[3] - '0';



            for (int l = 0; l < 10; ++l)
            {
                for (int j = 0; j < 4; ++j)
                {
                    Buffer[k] = M[i, j];


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

       


        public void MOS(int _RA)
        {   
            //SI 

            if (TI == 0 && SI == 1)
            {

                READ(_RA);
            }
            else if (TI == 0 && SI == 2)
            {
                WRITE(_RA);

            }
            else if (TI == 0 && SI == 3)
            {
                TERMINATE(0);
            }
            else if (TI == 2 && SI == 1)
            {
                TERMINATE(3);

            }
            else if (TI == 2 && SI == 2)
            {
                TERMINATE(3);
            }
            else if (TI == 3 && SI == 3)
            {
                TERMINATE(0);
            }

            //PI 

            if (TI == 0 && PI == 1)
            {
                TERMINATE(4);
            }
            else if (TI == 0 && PI == 2)
            {
                TERMINATE(5);

            }
            else if (TI == 0 && PI == 3)
            {
                /*
                 If Page Fault Valid, ALLOCATE, update page Table, Adjust IC if necessary,
EXECUTE USER PROGRAM OTHERWISE TERMINATE (6)
                 */
                TERMINATE(6);
            }
            else if (TI == 2 && PI == 1)
            {
                TERMINATE(3,4);

            }
            else if (TI == 2 && PI == 2)
            {
                TERMINATE(3,5);
            }
            else if (TI == 3 && PI == 3)
            {
                TERMINATE(3);
            }
        }

        public void EXECUTE()
        {
            while (true)
            {
                int RealAddress = AddressMap(IC);
                for (int i = 0; i < 4; i++)        //Load in register
                {
                    IR[i] = M[RealAddress, i];
                }
                IC++;

                if (IR[2] == '*' && IR[3] == '*')
                {
                    Console.WriteLine("sexsex");
                }

                int Operand = ( (IR[2] - '0') * 10 ) + (IR[3] - '0');
                int RealOperand = AddressMap(Operand);

                if (IR[0] == 'G' && IR[1] == 'D')    //GD
                {
                    SI = 1;
                    MOS(Operand);
                }
                else if (IR[0] == 'P' && IR[1] == 'D')       //PD
                {
                    SI = 2;
                    MOS(Operand);
                }
                else if (IR[0] == 'H')      //H
                {
                    SI = 3;
                    MOS(Operand);
                    break;
                }
                else if (IR[0] == 'L' && IR[1] == 'R')       //LR
                {
                    int i = IR[2] - 48;
                    i = i * 10 + (IR[3] - 48);

                    int RA = AddressMap(i);


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


                PCB._TTC++;



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


                    if (line == null)
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
                        int Random = ALLOCATE();
                        
                        PCB._JobId = (Buffer[4] - '0') * 1000 + (Buffer[5] - '0') * 100+ (Buffer[6] - '0') * 10 + (Buffer[7] - '0');
                        PCB._TTL = (Buffer[8] - '0') * 1000 + (Buffer[9] - '0') * 100 + (Buffer[10] - '0') * 10 + (Buffer[11] - '0');
                        PCB._TLL = (Buffer[12] - '0') * 1000 + (Buffer[13] - '0')    * 100 + (Buffer[14] - '0') * 10 + (Buffer[15] - '0');

                        PTR = Random * 10;

                        INIT(Random);
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                M[PTR + i, j] = '*';
                            }
                        }

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

                        int VirtualAddress = ALLOCATE();
                        M[PTR + LoadIC, 2] = (char)((VirtualAddress / 10) + '0');
                        M[PTR + LoadIC, 3] = (char)((VirtualAddress % 10) + '0');
                        //int RealAddr = AddressMap(LoadIC);

                        LoadIC = LoadIC + 1 ;
                        VirtualAddress = VirtualAddress * 10;

                        int k = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                M[VirtualAddress + i, j] = Buffer[k];
                                k++;
                            }
                        }
                        Console.WriteLine("siufuhisuhfhwue");
                        //int k = 0;

                        //for (; x < 100; x++)
                        //{
                        //    for (int j = 0; j < 4; j++)
                        //    {

                        //        M[x, j] = Buffer[k];
                        //        k++;
                        //    }

                        //    if (k == 40 || Buffer[k] == '\0' || Buffer[k] == '\n')
                        //    {
                        //        break;
                        //    }

                        //}

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
