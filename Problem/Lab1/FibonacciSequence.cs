using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Lab1
{
    public  class FibonacciSequence
    {
        public List<int> GenerateSequence(int numberOfElements)
        {
            List<int> numbers = new List<int>();
            if (numberOfElements >= 1) numbers.Add(0);
            if (numberOfElements >= 2) numbers.Add(1);

            for (int i = 2; i < numberOfElements; i++)
            {
                int nextValue = numbers[i - 1] + numbers[i - 2];
                numbers.Add(nextValue);
            }

            return numbers;
        }
        public List<int> GenerateSequenceWithCustomStartingPoint(int numberOfElements, int startPosition)
        {
            if (numberOfElements <= 0)
                throw new ArgumentException("The number of iterations must be positive");
            if (startPosition <= 0)
                throw new ArgumentException("The start position must be positive");

            int totalNeeded = startPosition + numberOfElements - 1;
            List<int> fullSequence = GenerateSequence(totalNeeded);
            return fullSequence.GetRange(startPosition - 1, numberOfElements);
        }
        public void DisplaySequence(List<int> ints)
        {
            char coma = ',';
            for (int i = 0; i < ints.Count; i++)
            {
                if (i >= ints.Count - 1)
                {
                    coma = ' ';
                }
                Console.Write($"{ints[i]}"+coma);
            }
        }
    }
}
