using System;
using System.IO;
namespace PercentageUsingBinrywriter
{
    class StudentMarks
    {
        FileStream fs;
        internal float percentage;
        internal string name;
        public void calculate()
        {
            Console.WriteLine("Enter name of Student:");
             name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter Marks Of Science:");
            int sc = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine("Enter Marks Of English:");
            int eng = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Marks Of Mathematics:");
            int math = Convert.ToInt32(Console.ReadLine());
            percentage = (sc + eng + math / 300)*100;
            fs = new FileStream(@"E:\example\percentsge.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write("Name Of Student:"+name);
            bw.Write("Percentage:" + percentage);
            Console.WriteLine("Data Saved..");
            bw.Flush();
            bw.Close();
        }

        public void ReadData()
        {
            fs = new FileStream(@"E:\example\percentsge.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            name = br.ReadString();
            percentage = br.ReadSingle();
            Console.WriteLine("Name OF Student:"+name);
            Console.WriteLine("Percentage :{0}", percentage);
            br.Close();
            fs.Close();

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentMarks sc = new StudentMarks();
            sc.calculate();
            sc.ReadData();
        }
    }
}
