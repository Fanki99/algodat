using System;
using System.Linq;
using System.IO;

namespace ALGODAT
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("----------------");
            Console.WriteLine("Ihre Auswahl:");
            string choice=Console.ReadLine();
            if(choice=="ADD"||choice=="add"||choice=="Add"){

            } else if (choice=="DEL"||choice=="del"||choice=="Del"){

            } else if(choice=="IMPORT"||choice=="import"||choice=="Import"){

            } else if (choice=="SEARCH"||choice=="search"||choice=="Search"){
                
            } else if (choice=="PLOT"||choice=="plot"||choice=="Plot"){
                graph();
            } else if (choice=="SAVE"||choice=="save"||choice=="Save"){
                
            } else if (choice=="LOAD"||choice=="load"||choice=="Load"){
                
            } else if (choice=="QUIT"||choice=="quit"||choice=="Quit"){
                Environment.Exit(0);
            }
            
            //graph();
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
    }
}
