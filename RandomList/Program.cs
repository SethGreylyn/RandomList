using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomList
{
    class Program
    {

        //Please write a program that generates a list of 10,000 numbers in random order each time it is run. 
        //Each number in the list must be unique and be between 1 and 10,000 (inclusive)

        //Input: BOUND, an integer representing the maximum value of the list.
        //Output: An integer array of the integers from 1 to BOUND inclusive, in random order with no repeats.
        public static int[] makeRandomList(int BOUND) {
            //The necessary local variables
            int[] list = new int[BOUND];
            Random rand = new Random();
            int randIndex = 0;
            int temp = 0;

            //We first generate a list of integers from 1 to BOUND in order.
            for(int i = 0; i < BOUND; ++i)
            {
                list[i] = i + 1;
            }
            /* Next we 'scramble' the ordered list by randomizing the entries, first assigning
            /  the jth entry to a placeholder, then overwriting the jth entry with a randomly-chosen
            /  kth entry from the j-tail of the list.
            /  This generates all possible permutations from 1 to BOUND with equal probability.
            */
            for (int j = 0; j < BOUND; ++j)
            {
                randIndex = rand.Next(j, BOUND);
                temp = list[j];
                list[j] = list[randIndex];
                list[randIndex] = temp;
            }

            return list;
        }
        //A simple method to print the entries of the list to the console.
        public static void printList(int[] list) {
            int BOUND = list.Length;

            for (int i = 0; i < BOUND; ++i) {
                Console.WriteLine("["+list[i]+"]");
            }
        }


        static void Main(string[] args)
        {
           //The size of the list to be generated.
            int RAND_LIST_SIZE = 10000;

            Console.WriteLine("About to make a random list of size [" + RAND_LIST_SIZE + "]");
            
            int[] randList = makeRandomList(RAND_LIST_SIZE);
            
            Console.WriteLine("Made the random list. Hit 'enter' to print the random list.");
            Console.ReadLine();
            
            printList(randList);
            Console.ReadLine();
        }
    }
}
