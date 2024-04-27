using System;
using System.Collections.Generic;
using Problem.Stack;

namespace Problem
{
    internal class FindSmallestElement
    {
        public ArrayStack<int> ints { get;private set; }

        public FindSmallestElement(ArrayStack<int> ints)
        {
            this.ints = ints;
        }

        public void ShowStack()
        {
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }
        }
        public int FindTheBiggestElement()
        {
            int currentValue = 0;
            foreach (var item in ints)
            {
                try
                {
                    if (item > currentValue)
                    {
                        currentValue = item;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Done");
                    break;
                }
            }
            return currentValue;
        }
        public int FindTheSmallestElement()
        {
            int currentValue = int.MaxValue;

            foreach (var item in ints)
            {
                try
                {
                    if (item < currentValue)
                    {
                        currentValue = item;
                    }
                }
                catch (StackOverflowException)
                {
                    Console.WriteLine("Done");
                    break;
                }
            }
            return currentValue;
        }
    }
}
