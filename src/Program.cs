using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

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
        //stock.StockEntries.Add()
        static void import(){
            Console.WriteLine("Geben Sie das Kürzel ein:");
             string input = Console.ReadLine();
           string filePath = System.IO.Path.GetFullPath("assets/"+input+".csv");
             StreamReader sr = new StreamReader(filePath);
            var lines = new List<int[]>();
            int Row = 1;
            List<StockEntry> entires = new List<StockEntry>();
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(",");
                if(Row!=1){
                StockEntry entry = new StockEntry();
                entry.Date = Line[0];
                entry.Open = Convert.ToDouble(Line[1], System.Globalization.CultureInfo.InvariantCulture);
                entry.High = Convert.ToDouble(Line[2], new NumberFormatInfo{ NumberDecimalSeparator = "."});
                entry.Low = Convert.ToDouble(Line[3], new NumberFormatInfo{ NumberDecimalSeparator = "."});
                entry.Close = Convert.ToDouble(Line[4], new NumberFormatInfo{ NumberDecimalSeparator = "."});
                entry.Volume = Convert.ToInt32(Line[6]);
                entry.AdjClose = Convert.ToDouble(Line[5], new NumberFormatInfo{ NumberDecimalSeparator = "."});
                entires.Add(entry);
                // Line[0]="0";
                // int[] LineArr = Array.ConvertAll(Line, int.Parse);
                // lines.Add(LineArr);  
                }
                Row++;
                
            }

            (algohash.retrieve(input)).StockEntries = entires;
            menu();
        }

       

        static void graph(){
            // double[] values = { 30.0, 45.69, 42.0};
            double[] values={35,42,34,45,42,41,43,40,31,42,37,44,39,43,37,34,30,34,36,35,43,41,42,37,36,35,32,45,36,42,38,41};
            
            double max = values.Max();
            Console.WriteLine("Graph:");
            Console.WriteLine(max);
            // foreach (int number in values)
            // {
                
            // }
            // double valuetemp=42.12/max*100%60;
            // valuetemp= Math.Round(valuetemp);

            Console.WriteLine("\t^");
            double valuetemp=0;
            for(int i=30; i>=1; i--){
               valuetemp=Math.Round((values[i])/max*80);
                string valuetempoutput="";
                //Console.WriteLine(valuetemp);
                    for(int k=0; k<valuetemp;k++){
                        valuetempoutput=valuetempoutput+"=";
                    }
                    valuetempoutput=valuetempoutput+"I "+values[i]; 
                    Console.WriteLine(i+".04\t|"+valuetempoutput);
                //  else {
                //     Console.WriteLine(i+".04\t|");
                // }
            }
            string line="\tL";
            string value="\t";
            for(int i=1; i<=30; i++){
                line=line+"__ ";
            }
            
            line=line+">";
            Console.WriteLine(line);
            Console.WriteLine(value);
            menu();
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

            algohash.remove(input);
            algohash.print();


            menu();
        }
        static void search(){
            Console.WriteLine("key?");
            string input = Console.ReadLine();
            Stock stock = algohash.retrieve(input);
            if(stock==null){
                Console.WriteLine("No entry found!");
            }
            else{
                Console.WriteLine((algohash.retrieve(input)).latestEntry());
 
            }
            menu();
        }
        static void save(){}
        static void load(){}
    }
}
