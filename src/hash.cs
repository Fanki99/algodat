using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace ALGODAT
{
    class hashtable {
        class hashentry{
            int key;
            string name;
            //string wkn;
            //string abbreviation;

            public hashentry(int key, string name)
            {
                this.key = key;
                this.name = name;
                //this.wkn = wkn;
                //this.abbreviation = abbreviation;
            }

            public int getkey(){
                return key;
            }
            public string getname(){
                return name;
            }
/*             public string getwkn(){
                return wkn;
            }
            public string getabbreviation(){
                return abbreviation;
            } */
        }
        const int maxSize = 10; // table size
        hashentry[] table;
        public hashtable()
        {
            table = new hashentry[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }
        public string retrieve(int key){
            int hash = key % maxSize;

            while(table[hash] !=null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return "nothing found";
            }
            else
            {
                return table[hash].getname();
            }
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
        public void insert(int key, string name)
        {
            if(!checkOpenSpace())
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }

            int j = 0;
            int hash = key % maxSize;
            while(table[hash] != null && table[hash].getkey() != key)
            {
                j++;
                hash = (hash + j * j) % maxSize;
            }
            if (table[hash] == null)
            {
                table[hash] = new hashentry(key, name);
                return;
            }
        }
        public bool remove(int key)
        {
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
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
                    Console.WriteLine("{0}, {1}",table[i].getkey(), table[i].getname());
                }
            }
        }
    }
}