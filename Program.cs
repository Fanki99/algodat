using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



//command to build exe - dotnet publish -c Release -r win10-x64
//run with - dotnet run input
namespace Algodat
{

    class Program
    {
        

        static void Main(string[] args)
        {
            
            
            foreach(string param in args){
               import(param);          
            }
        }

        static void import(string file){
           string filePath = System.IO.Path.GetFullPath(file+".txt");
             StreamReader sr = new StreamReader(filePath);
            var lines = new List<int[]>();
            int Row = 1;
            Tree t = new Tree();
            while (!sr.EndOfStream)
            {
                string entrystring = sr.ReadLine();
                int entry = System.Convert.ToInt32(entrystring);
                t.Add(entry);
                //Console.WriteLine(entry);
                
                Row++;   
            }
            t.parse();
/*          
            List<int> q = entries.Distinct().ToList();
            Console.WriteLine("[{0}]", string.Join(", ", q)); */
        }
    }


}
    
 