namespace Sortering;

public class BubbleSort
    {
        private static void Swap(int[] array, int i)
        {
            int temp = array[i + 1];
            array[i + 1] = array[i];
            array[i] = temp;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j);
                    }
                }
            }
        }
    }
