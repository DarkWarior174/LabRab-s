using System;
using System.Collections.Generic;

namespace Laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            double delta = 0;
            double startPos = 0;
            double endPos = 0;
            int maxLength = 0;
            List<double> xCoordinates = new List<double>();
            List<double> yCoordinates = new List<double>();
            Console.WriteLine("Введите начальную координату");
            startPos = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.WriteLine("Введите конечную координату");
            endPos = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Console.WriteLine("Введите альфу");
            delta = Convert.ToDouble(Console.ReadLine().Replace('.', ',')); 
            CheckCoordinates(startPos, endPos, delta);
            xCoordinates = ListXGenerate(delta, startPos, endPos);
            yCoordinates = ListYGenerate(xCoordinates);
            int maxLengthX = StringLenght(xCoordinates);
            int maxLengthY = StringLenght(yCoordinates);
            if (maxLengthX > maxLengthY)
                maxLength = maxLengthX;
            else
                maxLength = maxLengthY;
            DrawingTable(xCoordinates, yCoordinates, maxLength);
            Console.ReadKey();
        } 
        static void CheckCoordinates(double startPos, double endPos, double delta)
        {

            if (startPos == endPos || delta == 0)
            {
                Console.WriteLine("Неверно введены координаты");
                Console.ReadKey();
                Environment.Exit(0);
            }
            if ((startPos > endPos && delta > 0) || (startPos < endPos && delta < 0))
            {
                Console.WriteLine("Неверно введен шаг изменения! Невозможно достичь указанного значения!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        static List<double> ListXGenerate(double delta, double startPos, double endPos)
        {
            List<double> xQueue = new List<double>();
            xQueue.Add(startPos);
            int itterations = Convert.ToInt32((endPos - startPos) / delta);
            for (int i = 1; i <= itterations; i++)
            {
                xQueue.Add(startPos + (delta * i));
            }
            return xQueue;
        }
        static List<double> ListYGenerate(List<double> xQueue)
        {
            List<double> yQueue = new List<double>();
            for (int i = 0; i < xQueue.Count; i++)
            {
                yQueue.Add(Math.Cos(xQueue[i]));
            }
            return yQueue;
        }
        static int StringLenght(List<double> coordinates)
        {
            int length;
            int maxLength = 0;
            string stringOfCoordintes;
            for (int i = 0; i < coordinates.Count; i++)
            {
                stringOfCoordintes = Convert.ToString(coordinates[i]);
                length = stringOfCoordintes.Length;
                if (length > maxLength)
                    maxLength = length;
            }
            return maxLength+4;
        }
        static void WiseChoice(char symbol, int itterations)
        {
            for (int i = 0; i < itterations; i++)
            {
                Console.Write(symbol);
            }
        }
        static void DrawingMiddle(double queue, int maxLength)
        {
            string stringOfCoordintes = Convert.ToString(queue);
            int length = stringOfCoordintes.Length;
            int itterations = maxLength - length;
            WiseChoice(' ', itterations / 2);
            if (maxLength % 2 == 0 && length % 2 != 0)
                Console.Write(" ");
            else if (maxLength % 2 != 0 && length % 2 == 0)
                Console.Write(" ");
            Console.Write(queue);
            WiseChoice(' ', itterations / 2);
            Console.Write("|");
        }
        static void DrawingTop(char variable, int maxlength)
        {
            if (maxlength % 2 != 0)
                Console.Write(' ');
            WiseChoice(' ', maxlength / 2 - 1);
            Console.Write(variable);
            WiseChoice(' ', maxlength / 2 - 1);
            Console.Write(" |");
        }        
        static void DrawingTable(List<double> xQueue, List<double> yQueue, int maxlength)
        {
            Console.Write("|");
            for (int i = 0; i < 2; i++)
            {
                WiseChoice('-', maxlength);
                Console.Write("|");
            }
            Console.WriteLine();
            Console.Write("|");
            DrawingTop('x', maxlength);
            DrawingTop('y', maxlength);
            Console.WriteLine();
            for (int i = 0; i < 2 * maxlength + 3; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
            for (int i = 0; i < xQueue.Count; i++)
            {
                Console.Write("|");
                DrawingMiddle(xQueue[i], maxlength);
                DrawingMiddle(yQueue[i], maxlength);
                Console.WriteLine();
            }
            Console.Write("|");
            for (int i = 0; i < 2; i++)
            {
                WiseChoice('-', maxlength);
                Console.Write("|");
            }
        }
    }
}