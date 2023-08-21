using OS_Phase_1.Models;

namespace OS_Phase_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] charMatrix = new char[,]
        {
            { 'A', 'B', 'C', 'D' },
            { 'E', 'F', 'G', 'H' },
            { 'I', 'J', 'K', 'L' },
            { 'M', 'N', 'O', 'P' },
            { 'Q', 'R', 'S', 'T' },
            { 'U', 'V', 'W', 'X' },
            { 'Y', 'Z', 'A', 'B' },
            { 'C', 'D', 'E', 'F' },
            { 'G', 'H', 'I', 'J' },
            { 'K', 'L', 'M', 'N' }
        };
            ExternalMemory externalMemory = new ExternalMemory(4, 10, 10);
            INputOutput io = new INputOutput(4, 10);
            io.Read();
            externalMemory.SetBlock(io._Buffer, 0);
            io.ClearBuffer();
            io.WriteTOBuffer(externalMemory.GetBlock(0));
            io.Write();
            Console.Write("dotnet mwoe");
        }
    }
}

//"C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\INPUT.txt"
//StreamReader sr = new StreamReader("C:\\Sample.txt");
//line = sr.ReadLine();
//while (line != null)
//{
//    Console.WriteLine(line);
//    line = sr.ReadLine();
//}
//sr.Close();