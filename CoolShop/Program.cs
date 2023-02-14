using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoolShop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String fileP;
            int col;
            String name;

            if (args.Length < 1)
            {
                Console.WriteLine("Insert file path");
                fileP = Console.ReadLine();
            }
            else
            {
                fileP = args[0];
            }

            if (args.Length < 2)
            {
                Console.WriteLine("Insert Column number");
                col = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                col = Convert.ToInt32(args[1]);
            }

            if (args.Length < 3)
            {
                Console.WriteLine("Insert Research key");
                name = Console.ReadLine();
            }
            else
            {
                name = args[2];
            }

            String line = GetLine(name, col, fileP);

            Console.WriteLine(line);
        }

        //Get the requested line from the file
        static String GetLine(String Name, int Column, String filePath)
        {
            var strLines = File.ReadLines(filePath);

            int colNum = getColumns(filePath);

            if (Column > colNum)
            {
                return "Index out of bound";
            }
            else
            {
                foreach (var line in strLines)
                {
                    if (line.Split(',')[Column].Equals(Name))
                        return line;
                }

                return "Name not Found";
            }

        }

        //Counts the number of Columns
        static int getColumns(String filePath)
        {
            var lines = File.ReadLines(filePath);

            var totalcols = lines.ToList()[0].Split(',').Length;

            return Convert.ToInt32(totalcols);
        }
    }
}
