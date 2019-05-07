using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ALGODAT
{
    [Serializable] 
   public class Hashtable {
        const int maxSize = 1500; // table size
        public Stock[] table;
        public Hashtable()

        {
            table = new Stock[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }

        //hasht die Eingabe und sondiert so lange bis Ergebnis gefunden oder nicht vorhanden (leer);
        public Stock retrieve(string key){
            int hash=this.hash(key);
            int j=0;
            while(table[hash] != null){
                if(table[hash].Abbreviation==key){
                return table[hash];
            }
                else
                {
                    j++;
                    hash = (hash + j * j) % maxSize;
                }
            }
            return null;
        } 


        //checkt ob überhaupt noch freier Platz vorhanden ist
        private bool checkOpenSpace()
        {
            bool isOpen = false;
            for(int i = 0; i < maxSize; i++)
            {
                if (table[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }

        //hasht das Kürzel und returnt den Hash-Wert
        //Jeder Buchstabe des Kürzels wird verwendet um zusammen mit a & h einen gesamten Hashwert h am Ende herauszubekommen
        public int hash(string abbreviation){
            string tmp = abbreviation;
            int h = 0, a = 31415, b = 27183;
            for (int i = 0; i < tmp.Length; i++) {
                h = (a * h + tmp[i]) % maxSize;
                a = a * b % (maxSize - 1); 
            }
            return h;
        }

        //fügt neuen Wert hinzu, nachdem es checkt ob freier Platz vorhanden ist
        //erstellt ein neues Stock-Object welches mit den eingegebenen Daten gefüllt wird
        public void insert(string name, string abbreviation, string wkn)
        {
            if(!checkOpenSpace())
            {
                Console.WriteLine("Hashtable ist leider voll!");
                return;
            }

            int j = 0;
            int hash = this.hash(abbreviation);
            Stock stock = new Stock();

            stock.Name=name;
            stock.Abbreviation=abbreviation;
            stock.Wkn=wkn;

            if (table[hash] == null)
            {
                table[hash] = stock;
                return;
            }
            else if(table[hash].Abbreviation == null){
                table[hash] = stock;
                return;
            }
            else{
                while(table[hash] != null || table[hash].Abbreviation!=null)
            {
                j++;
                hash = (hash + j * j) % maxSize;
            }
            table[hash] = stock;
            return;
        }
    }

        //checkt ob Eingabe vorhanden und wenn, dann wird der Eintrag geflagged, in dem das Kürzel auf null gesetzt wird
        //damit ist es für unsere Funktionen unsichtbar und freigegeben zum Überschreiben!
        public bool remove(string key)
        {
            Stock stock = this.retrieve(key);
            if(stock == null){
                 Console.WriteLine("Abbrechen - kein passender Eintrag gefunden.");
                return false;
            }
            else if(stock.Abbreviation == null){
                Console.WriteLine("Abbrechen - kein passender Eintrag gefunden.");
                return false;
            }
            else{
                stock.Abbreviation = null;
                Console.WriteLine("Erfolgreich gelöscht: " + stock.Abbreviation);
                return true;
            }
        }

        //gibt Daten des Stocks wieder
        public void print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if(table[i] == null && i <= maxSize)
                {
                    continue;
                }
                else if(table[i].Abbreviation == null && i <= maxSize){
                    continue;
                }
                else
                {
                    Console.WriteLine("{0}, {1}",i, table[i].Name);
                }
            }
        }

    }
}