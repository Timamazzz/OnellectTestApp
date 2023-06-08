using OnellectRandomizer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnellectRandomizer.Domain
{
    public class SortingService : ISortingService
    {
        public void Sort(List<int> sequence)
        {
            Random random = new Random();

            List<string> sortingAlgorithms = new List<string> { "BubbleSort", "SelectionSort" };
            string selectedAlgorithm = sortingAlgorithms[random.Next(sortingAlgorithms.Count)];

            switch (selectedAlgorithm)
            {
                case "BubbleSort":
                    BubbleSort(sequence);
                    break;
                case "SelectionSort":
                    SelectionSort(sequence);
                    break;
            }
        }

        private void BubbleSort(List<int> numbers)
        {
            List<int> result = numbers.ToList();

            int n = numbers.Count();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        private void SelectionSort(List<int> numbers)
        {
            int n = numbers.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
        }
    }
}
