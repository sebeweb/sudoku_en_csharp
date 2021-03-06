﻿using System;
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
            List<List<int>> grille = CreateGrille(segment1, segment2, segment3);
            List<int> grilleToLine = GrilleToLine(grille);
            List<int> grilleClear = GrilleClear(grilleToLine);
            lineToGrille(grilleClear);
        }
        static List<List<int>> lineToGrille(List<int> line)
        {
           List<List<int>> grille = new List<List<int>>();
           Console.WriteLine("\nSudoku\n");
           for(int i = 0; i < 9; i++){
                grille.Add(line.GetRange(0, 9));
                line.RemoveRange(0,9);
               Console.WriteLine(string.Join(", ", grille[i]));
           }
           return grille;
        }
        static List<int> GrilleClear(List<int> line)
        {
            Random rnd = new Random();           
            for (int i = 0; i < 47;)
            {
                int index = rnd.Next(0, line.Count);
                if(line[index] == 0){
                 index = rnd.Next(0, line.Count);                    
                }else{
                    line[index] = 0;
                    i++;
                }
            }
            return line;
        }

        static List<int> GrilleToLine(List<List<int>> grille)
        {
            List<int> grilleToLine = new List<int>();
            for (int i = 0; i < grille.Count; i++)
            {
                if (i == 0)
                {
                    grilleToLine = grilleToLine.Concat(grille[i]).ToList();
                }
                else
                {
                    grilleToLine = grilleToLine.Concat(grille[i]).ToList();
                }
            }

            return grilleToLine;
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
        static List<List<int>> CreateGrille(List<int> segment1, List<int> segment2, List<int> segment3)
        {
            List<List<int>> grille = new List<List<int>>();
            Console.WriteLine("Solution\n");
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
                if (i % 3 > 1)
                {
                    int firstNum = segment1.First();
                    segment1.RemoveAt(0);
                    segment1.Add(firstNum);
                    firstNum = segment2.First();
                    segment2.RemoveAt(0);
                    segment2.Add(firstNum);
                    firstNum = segment3.First();
                    segment3.RemoveAt(0);
                    segment3.Add(firstNum);
                }
                Console.WriteLine(string.Join(", ", grille[i]));
            }
            return grille;
        }
    }
}
