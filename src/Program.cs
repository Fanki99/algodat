using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
    class Program
    {
        static Hashtable algohash;
        static void Main(string[] args)
        {
            algohash = new Hashtable();

            Console.WriteLine("----------------");
            Console.WriteLine("Willkommen bei dem Aktien-Programm");
            Console.WriteLine("von Thomas & Thomas");
            Console.WriteLine("----------------");
            Console.WriteLine("");
            Console.WriteLine("Menü");
            Console.WriteLine("-ADD: Hinzufügen von Datensätze");
            Console.WriteLine("-DEL: Löschen von Datensätze");
            Console.WriteLine("-IMPORT: Importieren von Daten zu Datensatz");
            Console.WriteLine("-SEARCH: Suche nach Datensätzen");
            Console.WriteLine("-PLOT: Die letzten 30 Tage eines Datensatzes als Graph");
            Console.WriteLine("-SAVE: Speichern der Hashtabelle");
            Console.WriteLine("-LOAD: Laden einer Hashtabelle");
            Console.WriteLine("-QUIT: Programm wird beendet");
            menu();
            
            
            //graph();
        }


        static void menu(){
            Console.WriteLine("----------------");
            Console.WriteLine("Ihre Auswahl:");
            string choice=Console.ReadLine();
            if(string.Equals(choice, "add",  StringComparison.OrdinalIgnoreCase)){
                add();
            } else if (string.Equals(choice, "del",  StringComparison.OrdinalIgnoreCase)){
                del();
            } else if(string.Equals(choice, "import",  StringComparison.OrdinalIgnoreCase)){
                import();
            } else if (string.Equals(choice, "search",  StringComparison.OrdinalIgnoreCase)){
                search();
            } else if (string.Equals(choice, "plot",  StringComparison.OrdinalIgnoreCase)){
                graph();
            } else if (string.Equals(choice, "save",  StringComparison.OrdinalIgnoreCase)){
                save();
            } else if (string.Equals(choice, "load",  StringComparison.OrdinalIgnoreCase)){
                load();
            } else if (string.Equals(choice, "quit",  StringComparison.OrdinalIgnoreCase)){
                Environment.Exit(0);
            } else {
                Console.WriteLine("Bitte gültige Eingabe treffen!");
                menu();
            }
        }
        //geht noch nicht! aber das mach ich nachher fertig!
        static void import(){
           string filePath = @"C:\Users\fankhauser\Downloads\MSFT.csv";
             StreamReader sr = new StreamReader(filePath);
            var lines = new List<int[]>();
            int Row = 1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(",");
                Line[0]="0";
                int[] LineArr = Array.ConvertAll(Line, int.Parse);
                lines.Add(LineArr);
                Row++;
                Console.WriteLine(Row);
            }

            var data = lines.ToArray();
        }



        static void graph(){
            double[] values = { 30.0, 45.69, 42.0};
            double max = values.Max();
            Console.WriteLine("Graph:");
            Console.WriteLine(max);
            // foreach (int number in values)
            // {
                
            // }
            double valuetemp=42.12/max*100%60;
            valuetemp= Math.Round(valuetemp);

            Console.WriteLine("\t^");
            string value1="";
            for(int i=30; i>=1; i--){
                if(i==15){
                
                //Console.WriteLine(valuetemp);
                    for(int k=0; k<valuetemp;k++){
                        value1=value1+"=";
                    }
                    value1=value1+"I 42.12";
                    Console.WriteLine(i+".04\t|"+value1);
                } else {
                    Console.WriteLine(i+".04\t|");
                }
            }
            string line="\tL";
            string value="\t";
            for(int i=1; i<=30; i++){
                line=line+"__ ";
            }
            
            line=line+">";
            Console.WriteLine(line);
            Console.WriteLine(value);
        }
        static void add(){
            string name;
            string abbreviation;
            string wkn;

            Console.WriteLine("Enter a name");
            name = Console.ReadLine();

            Console.WriteLine("Enter an abbreviation");
            abbreviation = Console.ReadLine();

            Console.WriteLine("Enter a WKN");
            wkn = Console.ReadLine();

            algohash.insert(name, abbreviation, wkn);
            algohash.print();
            menu();
        }
        static void del(){
            Console.WriteLine("key?");
            string input = Console.ReadLine();

            algohash.remove(Convert.ToInt32(input));
            algohash.print();


            menu();
        }
        static void search(){
            Console.WriteLine("key?");
            string input = Console.ReadLine();
            int output = algohash.retrieve(input);
            if(output==-1){
                Console.WriteLine("No entry found!");
            }
            else{
                Console.WriteLine(algohash.retrieve(input));
 
            }
            menu();
        }
        static void save(){}
        static void load(){}
    }
}
