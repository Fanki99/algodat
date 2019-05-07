using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

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
        }

    static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { 

                return; 
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    Console.WriteLine("Successfully saved into "+ fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Successfully read from " + fileName);
            return objectOut;
        }

        //Fragt nach der Auswahl des Users und führt gegebenenfalls Funktionen aus
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
        
        //Importet Daten aus CSV File aus dem assets Ordner und kopiert diese zu Objekt in einzelne StockEntries
        static void import(){
            Console.WriteLine("Geben Sie das Kürzel ein:");
             string input = Console.ReadLine();
           string filePath = System.IO.Path.GetFullPath("assets/"+input+".csv");
             StreamReader sr = new StreamReader(filePath);
            var lines = new List<int[]>();
            int Row = 1;
            List<StockEntry> entries = new List<StockEntry>();
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
                entries.Add(entry);
                }
                Row++;   
            }
            (algohash.retrieve(input)).StockEntries = entries;
            menu();
        }

        //gibt Plot aus angegebenen Daten wieder
        static void graph(){
            Console.WriteLine("Geben Sie ein Kürzel ein:");
            string input = Console.ReadLine();
            Stock stock = algohash.retrieve(input);
            List<StockEntry> entries = stock.sortByDateAsc(stock.StockEntries);
            double max = (stock.StockEntries.OrderBy(q => q.Close)).ToList().Last().Close;
            Console.WriteLine("Graph:");
            // Console.WriteLine(max);
            // foreach (int number in values)
            // {
                
            // }
            // double valuetemp=42.12/max*100%60;
            // valuetemp= Math.Round(valuetemp);

            Console.WriteLine("\t\t^");
            double valuetemp=0;
            for(int i=0; i<entries.Count; i++){
               valuetemp=Math.Round((entries[i].Close)/max*80);
                string valuetempoutput="";
                //Console.WriteLine(valuetemp);
                    for(int k=0; k<valuetemp;k++){
                        valuetempoutput=valuetempoutput+"=";
                    }
                    valuetempoutput=valuetempoutput+"I "+entries[i].Close; 
                    Console.WriteLine("    "+entries[i].Date+"\t|"+valuetempoutput);
                //  else {
                //     Console.WriteLine(i+".04\t|");
                // }
            }
            string line="\t\tL";
            string value="\t";
            for(int i=1; i<=30; i++){
                line=line+"__ ";
            }
            
            line=line+">";
            Console.WriteLine(line);
            Console.WriteLine(value);
            menu();
        }
        
        //Fragt nach Eingabe der Daten und fügt diese mithilfe der insert Funktion dann in Hashtable ein
        static void add(){
            string name;
            string abbreviation;
            string wkn;

            Console.WriteLine("Geben Sie einen Namen ein:");
            name = Console.ReadLine();

            Console.WriteLine("Geben Sie ein Kürzel ein:");
            abbreviation = Console.ReadLine();

            Console.WriteLine("Geben Sie eine WKN ein:");
            wkn = Console.ReadLine();

            algohash.insert(name, abbreviation, wkn);
            algohash.print();
            menu();
        }
        //fragt nach Eingabe der Daten und flaggt den jeweiligen Wert mithilfe der remove Funktion
        static void del(){
            Console.WriteLine("Welche Aktie wollen Sie löschen? (Kürzel)");
            string input = Console.ReadLine();

            algohash.remove(input);
            algohash.print();


            menu();
        }
        //Fragt nach Eingabe der Daten und sucht mithilfe der retrieve Funktion nach vorhandenem Eintrag oder leerer Stelle
        static void search(){
            Console.WriteLine("Nach welchem Kürzel wollen Sie suchen?");
            string input = Console.ReadLine();
            Stock stock = algohash.retrieve(input);
            if(stock==null){
                Console.WriteLine("Kein Eintrag gefunden!");
            }
            else{
                Console.WriteLine((algohash.retrieve(input)).latestEntry());
 
            }
            menu();
        }
        static void save(){
            Console.WriteLine("Enter a filename to save to");
            string filename = Console.ReadLine();
            SerializeObject<Hashtable>(algohash, filename);
            menu();
        }
        static void load(){
            Console.WriteLine("Enter a filename to be loaded from");
            string filename = Console.ReadLine();
            algohash = DeSerializeObject<Hashtable>(filename);
            menu();
        }
    }
}
