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
                if (args.Length != 2)
                {
                    Console.WriteLine("Please enter arugments in form program.exe numberOfFolders folderPath");
                    Console.ReadKey();
                }
                else
                {
                    //var val = 75;
                    // Console.Write("Enter number: ");
                    // var val = Convert.ToInt32(Console.ReadLine());
                    
                    var val = Convert.ToInt32(args[0]);
                    var path = args[1];

                    //MOVING START

                    var d = new DirectoryInfo(path);
                    var files = d.GetFiles("*.*").OrderBy(file => file.Name).ToList();
                    
                    //moving facs 
                    if (files.Any())
                    {
                        Console.WriteLine("Fac Scan");
                        for (var k = 1; k <= files.Count; k++) //moving the images
                        {
                            var folderName = Path.Combine(path, (k % val + 1).ToString());
                            if (!Directory.Exists(folderName))
                            {
                                Directory.CreateDirectory(folderName);
                            }
                            var destination = Path.Combine(folderName, files[k-1].Name);
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
