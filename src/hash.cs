using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
    class Hashtable {
        const int maxSize = 1500; // table size
        Stock[] table;
        public Hashtable()
        {
            table = new Stock[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }

        public int retrieve(string key){ //TODO: only by name; Fabian/Paul fragen
            int hash=this.hash(key);
            int j=0;
            while(table[hash] != null){
                if(table[hash].Name==key){
                return hash;
            }
                else
                {
                    j++;
                    hash = (hash + j * j) % maxSize;
                }
            }
            return -1;
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

        public int hash(string name){
            string tmp = name;
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
            int hash = this.hash(name);
            Stock stock = new Stock();

            stock.Name=name;
            stock.Abbreviation=abbreviation;
            stock.Wkn=wkn;

            if (table[hash] == null)
            {
                table[hash] = stock;
                return;
            }
            else{
                while(table[hash] != null)
            {
                j++;
                hash = (hash + j * j) % maxSize;
            }
            table[hash] = stock;
            return;
        }
    }

        public bool remove(int key) //TODO: Fabian/Paul fragen
        {
            int hash = key % maxSize;
            while (table[hash] != null)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return false;
            }
            else
            {
                table[hash] = null;
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
                else
                {
                    Console.WriteLine("{0}, {1}",i, table[i].Name);
                }
            }
        }
    }
}