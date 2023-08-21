namespace OS_Phase_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\arya2\\Documents\\OS_Coursse_Project\\OS_Phase_1\\IO_Files\\INPUT.txt");
            sw.WriteLine("Hello World!!");
            sw.WriteLine("From the StreamWriter class");
            sw.Close();
        }
    }
}


//StreamReader sr = new StreamReader("C:\\Sample.txt");
//line = sr.ReadLine();
//while (line != null)
//{
//    Console.WriteLine(line);
//    line = sr.ReadLine();
//}
//sr.Close();