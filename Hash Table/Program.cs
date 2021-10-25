using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Hash_Table
{
    class Program
    {
        static void Main(string[] args)

        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\Text.txt"); //read the text file
            Hashtable hasht = new Hashtable(); //create hashtable
            int i = 0;
            //This loop is O(n)
            foreach (String line in lines) //loops to add string to hashtable
            {

                hasht.Add(i, line);
                i++;
            }

            Console.WriteLine("Key and Value pairs :");
            //This loop is O(n)
            foreach (DictionaryEntry elem in hasht) //Dictionary to add to hashtable
            {
                Console.WriteLine("{0} : {1}", elem.Key, elem.Value);
            }

            Console.WriteLine("Total number of elements present" +
                     " in hashtable:{0}", hasht.Count);

            List<string> AlreadyChecked = new List<string>(); //list that contains all already checked values
            int highestfrequency = 0;
            string highestvalue = "";
            //This loop is O(n2)
            foreach (DictionaryEntry elem in hasht) //for loop to check each element in the hashtable
            {
                int key = (int)elem.Key;
                string value = (string)elem.Value;
                int frequency = 0;
                if (!AlreadyChecked.Contains(value)) //checks if the frequency has not already been got for an element
                {
                    //This loop is O(n)
                    foreach (DictionaryEntry elem2 in hasht) //for loop to compare each element against the current element
                    {
                        string value2 = (string)elem2.Value;
                        if (value.CompareTo(value2) == 0) //if both values are the same, increase frequency
                        {
                            frequency++;
                        }
                    }
                    Console.WriteLine(value + " : " + frequency);
                    if (frequency > highestfrequency) //if the frequency of this object is greater than the current largest frequency
                    {
                        highestfrequency = frequency;
                        highestvalue = value;
                    }
                    AlreadyChecked.Add(value);
                }    
            }
            Console.WriteLine("Highest frequency was " + highestvalue + " with a frequency of " + highestfrequency);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}

