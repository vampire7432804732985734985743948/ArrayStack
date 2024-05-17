using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.Set
{
    internal class Set
    {
        public void SortArray(int[] array)
        {
            int temporary = 0;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temporary = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temporary;
                    }
                }
            }
        }
    }
}
