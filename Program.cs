using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

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
            menu();
            
            
            //graph();
        }


        static void menu(){
            Console.WriteLine("----------------");
            Console.WriteLine("Ihre Auswahl:");
            string choice=Console.ReadLine();
            if(choice=="ADD"||choice=="add"||choice=="Add"){
                add();
            } else if (choice=="DEL"||choice=="del"||choice=="Del"){
                del();
            } else if(choice=="IMPORT"||choice=="import"||choice=="Import"){
                import();
            } else if (choice=="SEARCH"||choice=="search"||choice=="Search"){
                search();
            } else if (choice=="PLOT"||choice=="plot"||choice=="Plot"){
                graph();
            } else if (choice=="SAVE"||choice=="save"||choice=="Save"){
                save();
            } else if (choice=="LOAD"||choice=="load"||choice=="Load"){
                load();
            } else if (choice=="QUIT"||choice=="quit"||choice=="Quit"){
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
                int[] LineArr = Line;
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
        static void add(){}
        static void del(){}
        static void search(){}
        static void save(){}
        static void load(){}
    }
}
