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
                    string ipath = Directory.GetCurrentDirectory();

                    ipath = args[0];

                    int folderNum = 1;

                    string nextFolder = folderNum.ToString();


                    //MOVING START

                    string[] fileDirect = Directory.GetFiles(ipath, "*.*", SearchOption.AllDirectories);

                    DirectoryInfo d = new DirectoryInfo(ipath);

                    FileInfo[] Files = d.GetFiles("*.*");

                    List<string> fileNames = new List<string>();

                    foreach (FileInfo file in Files)
                    {
                        fileNames.Add(file.Name);
                    }

                    //Console.WriteLine(fileNames.Count + " Files");

                    string[] FileNamesAR = fileNames.ToArray();
                    Array.Sort(FileNamesAR);
                    Array.Sort(fileDirect);

                    //moving facs 
                    if (FileNamesAR.Length >= 1)
                    {
                        Console.WriteLine("Fac Scan");
                        for (int k = 0; k < FileNamesAR.Length; k++) //moving the images
                        {


                            if (k % 80 == 0)
                            {
                                Directory.CreateDirectory(folderNum.ToString());

                                File.Move(fileDirect[k], ipath + @"\" + folderNum.ToString() + @"\" + FileNamesAR[k]);
                                folderNum = folderNum + 1;
                                Console.WriteLine(Files[k] + " sorted.");
                            }

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
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
