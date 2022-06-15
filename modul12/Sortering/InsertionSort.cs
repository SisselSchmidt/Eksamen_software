namespace Sortering;

 public class InsertionSort
    {

        public static void Sort(int[] array)
        {
            // L�b usorteret del af array igennem
            for (int i = 0; i < array.Length; i++)
            {
                int next = array[i]; // N�ste tal
                // Skub sorterede elementer �n plads op
                int j = i;
                bool found = false;
                while (!found && j > 0)
                {
                    if (next >= array[j - 1])
                    {
                        found = true;
                    }
                    else
                    {
                        array[j] = array[j - 1];
                        j--;
                    }
                }
                array[j] = next; // Tallet inds�ttes p� sin plads
            }
        }
    }