using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
    class Hashtable {
        class Stock{
            public string name;
            public string abbreviation;
            public string wkn;
            //string wkn;
            //string abbreviation;

            public Stock(string name, string abbreviation, string wkn)
            {
                this.name = name;
                this.abbreviation = abbreviation;
                this.wkn = wkn;
                //this.wkn = wkn;
                //this.abbreviation = abbreviation;
            }

            public string getName(){
                return this.name;
            }

            public string getAbbreviation(){
                return this.abbreviation;
            }

            public string getWkn(){
                return this.wkn;
            }
/*             public string getwkn(){
                return wkn;
            }
            public string getabbreviation(){
                return abbreviation;
            } */
        }
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

        public int retrieve(string key){
            int hash=this.hash(key);
            int j=0;
            while(table[hash] != null){
                if(table[hash].getName()==key){
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

            if (table[hash] == null)
            {
                table[hash] = new Stock(name, abbreviation, wkn);
                return;
            }
            else{
                while(table[hash] != null)
            {
                j++;
                hash = (hash + j * j) % maxSize;
            }
            table[hash] = new Stock(name, abbreviation, wkn);
            return;
        }
    }

        public bool remove(int key)
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
                    Console.WriteLine("{0}, {1}",i, table[i].getName());
                }
            }
        }
    }
}