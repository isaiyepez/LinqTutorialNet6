﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class ConcatUnion
    {
        //Coding Exercise 1
        /*
        Imagine you are working on a news website. On the main panel of this website, 
        we want to show the most important news, as well as the most recent ones. 

        Implement the SelectRecentAndImportant method which given a collection 
        of news will return the three most recent news, 
        as well as all news with priority set to high.

        For example, for the following collection of news 
        we will return the following news:
            *2021/10/6 and priority high - because it has the high priority (and it's amongst 3 most recent news)
            *2021/10/5 and priority low - because it's amongst 3 most recent news
            *2021/10/4 and priority medium - because it's amongst 3 most recent news
            *2021/10/3 and priority medium - WILL NOT BE INCLUDED IN RESULT
            *2021/10/2 and priority high - because it has the high priority
            *2021/10/1 and priority low - WILL NOT BE INCLUDED IN RESULT
         */
        public static IEnumerable<News> SelectRecentAndImportant(
            IEnumerable<News> newsCollection)
        {
            var newsHighPriority = newsCollection.Where(n => n.Priority == Priority.High);
           
            var newsRecent = newsCollection.OrderByDescending(n => n.PublishingDate).Take(3);
            //TODO your code goes here
            return newsRecent.Union(newsHighPriority);
        }

        //Coding Exercise 2
        /*
         Implement the CleanWord method, which given a string that can consist 
        of letters and non-letter characters, will return a new string, 
        where all letters proceed the non-letter characters. 
        The non-letter characters should be unique in the result.

        For example:
            *for input "f_o!_!x" the result will be "fox_!". 
                Please note that only the first "!" is present in the result 
                according to this rule "The non-letter characters should be unique 
                in the result."
            *for input "d_3uc(k))" the result will be "duck_3()". 
                Please note that only the first ")" is present in the result 
                according to this rule "The non-letter characters should be unique 
                in the result."
         */
        public static string CleanWord(string word)
        {
            var onlyLetters = word.Where(ch => char.IsLetter(ch));
            var otherChars = word.Except(onlyLetters).Distinct();                   

            return new string(onlyLetters.Union(otherChars).ToArray());
        }

        //Refactoring challenge
        //TODO implement this method
        public static IEnumerable<int> GetPerfectSquares_Refactored(
            IEnumerable<int> numbers1, IEnumerable<int> numbers2)
        {
            var list3 = numbers1.Union(numbers2).OrderBy(n => n);              

            return list3.Where(number => Math.Sqrt(number) % 1 == 0);
        }

        //do not modify this method
        public static IEnumerable<int> GetPerfectSquares(IEnumerable<int> numbers1, IEnumerable<int> numbers2)
        {
            var result = new List<int>();
            foreach (var number in numbers1)
            {
                if (Math.Sqrt(number) % 1 == 0 && !result.Contains(number))
                {
                    result.Add(number);
                }
            }
            foreach (var number in numbers2)
            {
                if (Math.Sqrt(number) % 1 == 0 && !result.Contains(number))
                {
                    result.Add(number);
                }
            }
            result.Sort();
            return result;
        }

        public struct News
        {
            public DateTime PublishingDate { get; set; }
            public Priority Priority { get; set; }

            public override string ToString()
            {
                return $"Date: {PublishingDate.ToString("d")}, Priority: {Priority}";
            }
        }

        public enum Priority
        {
            Low,
            Medium,
            High
        }
    }
}
