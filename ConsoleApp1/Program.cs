using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> newRow = ListRandom(num);
            List<int> segment1 = new List<int> { };
            segment1.AddRange(newRow.GetRange(0, 3));
            List<int> segment2 = new List<int> { };
            segment2.AddRange(newRow.GetRange(3, 3));
            List<int> segment3 = new List<int> { };
            segment3.AddRange(newRow.GetRange(6, 3));
            CreateGrille(segment1, segment2, segment3);
        }
        static List<int> ListRandom(List<int> row)
        {
            Random rnd = new Random();
            int longRow = row.Count;
            List<int> newRow = new List<int> { };
            for (int i = 0; i < longRow; i++)
            {
                int index = rnd.Next(0, row.Count);
                newRow.Add(row[index]);
                row.RemoveAt(index);
            }
            return newRow;
        }
        static void CreateGrille(List<int> segment1, List<int> segment2, List<int> segment3)
        {
            List<List<int>> grille = new List<List<int>>();
            for (int i = 0; i < 9; i++)
            {
                List<int> concatSeg = new List<int>();
                concatSeg = concatSeg.Concat(segment1).ToList();
                concatSeg = concatSeg.Concat(segment2).ToList();
                concatSeg = concatSeg.Concat(segment3).ToList();
                grille.Add(concatSeg);
                List<int> temp = new List<int>(segment1);
                segment1 = segment2;
                segment2 = segment3;
                segment3 = temp;
                Console.WriteLine(string.Join(", ", grille[i]));
            }
        }
    }
}
