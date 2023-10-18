using System;
using System.Collections.Generic;

namespace Script.Util
{
    public class ListUtil
    {
        private static Random r;

        public static void Shuffle<T>(List<T> list)
        {
            Random rnd = r;
            if (rnd == null)
            {
                r = rnd = new Random();
            }
            Shuffle(list,rnd);
        }

        public static void Shuffle<T>(List<T> list, Random rnd)
        {
            int size = list.Count;
            T[] arr = list.ToArray();
            for (int i = size; i > 1; i--)
            {
                Swap(arr, i-1, rnd.Next(i));
            }
            
            for (int i = 0; i < arr.Length; i++)
            {
                list[i] = arr[i];
            }
        }
        
        private static void Swap<T>(T[] arr, int i, int j) {
            T tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}