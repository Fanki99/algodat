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

        public int hash(string abbreviation){
            string tmp = abbreviation;
            int h = 0, a = 31415, b = 27183;
            for (int i = 0; i < tmp.Length; i++) {
                h = (a * h + tmp[i]) % maxSize;
                a = a * b % (maxSize - 1); 
            }
            return h;
        }

        public void insert(string name, string abbreviation, string wkn)
        {
            if(!checkOpenSpace())
            {
                Console.WriteLine("table is at full capacity!");
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

        public bool remove(string key)
        {
            Stock stock = this.retrieve(key);
            if(stock == null){
                 Console.WriteLine("There is no such stock. Aborting.");
                return false;
            }
            else if(stock.Abbreviation == null){
                Console.WriteLine("There is no such stock. Aborting.");
                return false;
            }
            else{
                stock.Abbreviation = null;
                Console.WriteLine("Successfully deleted " + stock.Abbreviation);
                return true;
            }
        }

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