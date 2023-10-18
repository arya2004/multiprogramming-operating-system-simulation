using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithm.SchedulinigAlgo
{
    public class FIFO_Page_Replacement
    {
        public int pageFaults(int[] pages, int n, int capacity)
        {
            // To represent set of current pages. We use  
            // an unordered_set so that we quickly check  
            // if a page is present in set or not  
            HashSet<int> s = new HashSet<int>(capacity);

            // To store the pages in FIFO manner  
            Queue indexes = new Queue();

            // Start from initial page  
            int page_faults = 0;
            for (int i = 0; i < n; i++)
            {
                // Check if the set can hold more pages  
                if (s.Count < capacity)
                {
                    // Insert it into set if not present  
                    // already which represents page fault  
                    if (!s.Contains(pages[i]))
                    {
                        s.Add(pages[i]);

                        // increment page fault  
                        page_faults++;

                        // Push the current page into the queue  
                        indexes.Enqueue(pages[i]);
                    }
                }

                // If the set is full then need to perform FIFO  
                // i.e. Remove the first page of the queue from  
                // set and queue both and insert the current page  
                else
                {
                    // Check if current page is not already  
                    // present in the set  
                    if (!s.Contains(pages[i]))
                    {
                        //Pop the first page from the queue  
                        int val = (int)indexes.Peek();

                        indexes.Dequeue();

                        // Remove the indexes page  
                        s.Remove(val);

                        // insert the current page  
                        s.Add(pages[i]);

                        // push the current page into  
                        // the queue  
                        indexes.Enqueue(pages[i]);

                        // Increment page faults  
                        page_faults++;
                    }
                }
            }

            return page_faults;
        }

        // Driver method  
        //public static void Main(String[] args)
        //{
        //    int[] pages = {7, 0, 1, 2, 0, 3, 0, 4,
        //                2, 3, 0, 3, 2};

        //    int capacity = 4;
        //    Console.Write(pageFaults(pages, pages.Length, capacity));
        //}
    }
}
