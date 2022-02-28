using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fac_sort
{
    class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("please drag and drop folder to sort");
                    Console.ReadKey();
                }
                else
                {
                    
                    Console.Write("Enter number: ");
                    var val = Convert.ToInt32(Console.ReadLine());
                    var path = args[0];

                    //MOVING START

                    var d = new DirectoryInfo(path);
                    var files = d.GetFiles("*.*").OrderBy(file => file.Name).ToList();
                    
                    //moving facs 
                    if (files.Any())
                    {
                        Console.WriteLine("Fac Scan");
                        for (var k = 1; k <= files.Count; k++) //moving the images
                        {

                            var destination = Path.Combine(path, (k % val + 1).ToString(), files[k-1].Name);
                            File.Move(files[k-1].FullName, destination);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not All Images Are Here. Double Check Files Or Please Sort Manually.");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }
    }
}
