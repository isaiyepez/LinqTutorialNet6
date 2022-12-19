using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace Exercises
{
    public static class OrderBy
    {
        //Coding Exercise 1
        /*
         Using LINQ, implement the OrderFromLongestToShortest method, which takes 
        a collection of strings, and returns those strings ordered from 
        longest to shortest.
        For example, for {"bb", "a", "ccc"} the result should be {"ccc", "bb", "a"}
         */
        public static IEnumerable<string> OrderFromLongestToShortest(
            IEnumerable<string> words)
        {
            //TODO your code goes here
            return words.OrderBy(w => w.Length).Reverse();
            //OR words.OrderByDescending(w => w.Length);
        }

        //Coding Exercise 2
        /*
         Using LINQ, implement the FirstEvenThenOddDescending method, 
         which orders numbers like this:
            *first, the even numbers
            *then, the odd numbers
         Then the numbers should be ordered descending. 
         For example, for numbers {1,2,3,4,5,6,7} the result should be: {6,4,2,7,5,3,1}.
         */
        public static IEnumerable<int> FirstEvenThenOddDescending(
            IEnumerable<int> numbers)
        {
            //TODO your code goes here
            var evenNumbers = numbers.Where(n => n % 2 == 0);
           
            var oddNumbers = numbers.Where(oddN=> oddN % 2 != 0);
            oddNumbers = oddNumbers.Reverse();

            IEnumerable<int> results = evenNumbers.OrderByDescending(n => n);
            
            return results.Concat(oddNumbers.OrderByDescending(n => n)).ToList();
        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<DateTime> OrderByMonth_Refactored(List<DateTime> dates)
        {
            //TODO your code goes here
            return dates.OrderBy(dt => dt.Month);
        }

        //do not modify this method
        public static IEnumerable<DateTime> OrderByMonth(List<DateTime> dates)
        {
            dates.Sort((left, right) =>
            {
                return left.Month.CompareTo(right.Month);
            });
            return dates;
        }
    }
}
