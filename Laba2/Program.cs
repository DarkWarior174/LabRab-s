using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {            
            while (true)
            {
                string figureCoordinates;
                bool isCorrect;
                bool yourChoise;
                int figure = 0;
                string figureChoosing;

                metka2:
                Console.WriteLine("Пожалуйста, выбереите фигуру, где '1' - пешка, '2' - конь, \n" +
                    "'3' - слон, '4' - ладья, '5' - король, '6' - ферзь.");
                figureChoosing = Console.ReadLine();
                int.TryParse(figureChoosing, out figure);

                metka1:
                Console.WriteLine("Пожалуйста, введите координаты фигуры до хода и после разделяя их пробелом");
                figureCoordinates = Console.ReadLine();
                isCorrect = IsEnterFigureCorrect(figureChoosing);
                if (isCorrect)
                {
                    if (figure == 1)
                    {
                        figureChoosing = "пешкой";
                    }
                    else if (figure == 2)
                    {
                        figureChoosing = "конём";
                    }
                    else if (figure == 3)
                    {
                        figureChoosing = "слоном";
                    }
                    else if (figure == 4)
                    {
                        figureChoosing = "ладьёй";
                    }
                    else if (figure == 5)
                    {
                        figureChoosing = "королём";
                    }
                    else if (figure == 6)
                    {
                        figureChoosing = "ферзём";
                    }

                    isCorrect = IsEnteringCoordinatesCorrect(figureCoordinates);
                    if (isCorrect)
                    {
                        yourChoise = ChoosingFigure(figureCoordinates, figure);
                        if (yourChoise)
                        {
                            Console.WriteLine("А Вы мне нравитесь, такой ход " + figureChoosing + " возможен :)");
                        }
                        else
                        {
                            Console.WriteLine("К сожалению такой ход " + figureChoosing + " невозможен :(");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы неверно ввели координаты :(\nДавайте попробуем ещё раз :)\n");
                        goto metka1;
                    }
                }
                else
                {
                    Console.WriteLine("Вы не верно выбрали фигуру :(\nДавайте попробуем ещё раз :)\n");
                    goto metka2;
                }
                Console.WriteLine("Просто нажмите любую кнопку, и мы попробуем ещё раз :)");
                Console.ReadKey();
                Console.Clear();
            }

        }

        static bool IsEnteringCoordinatesCorrect(string strings)
        {
            byte lettersResult = 0;
            bool nums = false;
            bool result = false;
            string lettersOnBoard = "ABCDEFGH";
            char[] lettersChar = lettersOnBoard.ToCharArray();
            if (strings.Length >= 5)
            {
                if (char.IsDigit(strings[1]) && char.IsDigit(strings[4]))
                {
                    if (char.GetNumericValue(strings[1]) <= 8 &&
                        char.GetNumericValue(strings[4]) <= 8 &&
                        char.GetNumericValue(strings[1]) != 0 &&
                        char.GetNumericValue(strings[4]) != 0)
                    {
                        nums = true;
                    }
                }
                for (int i = 0; i < 4;)
                {
                    for (int y = 0; y < 8;)
                    {
                        if (lettersChar[y] == strings[i])
                        {
                            lettersResult++;
                        }
                        y++;
                    }
                    i = i + 3;
                }
            }
            if (nums && lettersResult == 2)
            {
                result = true;
            }
            return (result);
        }

        static bool IsEnterFigureCorrect(string strings)
        {
            bool result = false;
            int figure;
            int.TryParse(strings, out figure);
            if (figure > 0 && figure < 7)
            {
                result = true;
            }
            return (result);
        }
        static int GetFigureCoordinates(string strings, int ID)
        {
            string lettersOnBoard = "ABCDEFGHIJ";
            char[] lettersChar = lettersOnBoard.ToCharArray();
            int coordinates = 0;
            for (int y = 0; y <= 9;)
            {
                if (lettersChar[y] == strings[ID])
                {
                    coordinates = y;
                }
                y++;
            }
            return (coordinates);
        }
        static int GetFigureDelta(int a, int b)
        {
            int result = a - b;
            return (Math.Abs(result));
        }

        static bool ChoosingFigure(string strings, int figureNumber)
        {
            bool result = false;
            if (figureNumber == 1)
            {
                result = IsPawnMoveCorrect(strings);
            }
            else if (figureNumber == 2)
            {
                result = IsKnightMoveCorrect(strings);
            }
            else if (figureNumber == 3)
            {
                result = IsElephantMoveCorrect(strings);
            }
            else if (figureNumber == 4)
            {
                result = IsRookMoveCorrect(strings);
            }
            else if (figureNumber == 5)
            {
                result = IsKingMoveCorrect(strings);
            }
            else if (figureNumber == 6)
            {
                result = IsRookMoveCorrect(strings) || IsElephantMoveCorrect(strings);
            }
            return (result);
        }

        static bool IsRookMoveCorrect(string strings)
        {
            bool result = false;
            int numberPCoordinate = Convert.ToInt32(strings[1]);
            int numberACoordinate = Convert.ToInt32(strings[4]);
            int letterPCoordinate = GetFigureCoordinates(strings, 0);
            int letterACoordinate = GetFigureCoordinates(strings, 3);
            int letterDelta = GetFigureDelta(letterPCoordinate, letterACoordinate);
            int numberDelta = GetFigureDelta(numberPCoordinate, numberACoordinate);
            if (letterDelta > 0 ^ numberDelta > 0)
            {
                result = true;
            }
            return (result);
        }

        static bool IsElephantMoveCorrect(string strings)
        {
            bool result = false;
            int numberPCoordinate = Convert.ToInt32(strings[1]);
            int numberACoordinate = Convert.ToInt32(strings[4]);
            int letterPCoordinate = GetFigureCoordinates(strings, 0);
            int letterACoordinate = GetFigureCoordinates(strings, 3);
            int letterDelta = GetFigureDelta(letterPCoordinate, letterACoordinate);
            int numberDelta = GetFigureDelta(numberPCoordinate, numberACoordinate);
            if (letterDelta == numberDelta)
            {
                result = true;
            }
            return (result);
        }

        static bool IsKnightMoveCorrect(string strings)
        {
            bool result = false;
            int numberPCoordinate = Convert.ToInt32(strings[1]);
            int numberACoordinate = Convert.ToInt32(strings[4]);
            int letterPCoordinate = GetFigureCoordinates(strings, 0);
            int letterACoordinate = GetFigureCoordinates(strings, 3);
            int letterDelta = GetFigureDelta(letterPCoordinate, letterACoordinate);
            int numberDelta = GetFigureDelta(numberPCoordinate, numberACoordinate);
            if (letterDelta <= 2 && numberDelta <= 2 && (letterDelta + numberDelta) == 3 )
            {
                result = true;
            }
            return (result);
        }

        static bool IsPawnMoveCorrect(string strings)
        {
            bool result = false;
            int numberPCoordinate = Convert.ToInt32(strings[1]);
            int numberACoordinate = Convert.ToInt32(strings[4]);
            int letterPCoordinate = GetFigureCoordinates(strings, 0);
            int letterACoordinate = GetFigureCoordinates(strings, 3);
            int letterDelta = GetFigureDelta(letterPCoordinate, letterACoordinate);
            int numberDelta = GetFigureDelta(numberPCoordinate, numberACoordinate);
            if (letterDelta == 0 && numberDelta == 1)
            {
                result = true;
            }
            return (result);
        }

        static bool IsKingMoveCorrect(string strings)
        {
            bool result = false;
            int numberPCoordinate = Convert.ToInt32(strings[1]);
            int numberACoordinate = Convert.ToInt32(strings[4]);
            int letterPCoordinate = GetFigureCoordinates(strings, 0);
            int letterACoordinate = GetFigureCoordinates(strings, 3);
            int letterDelta = GetFigureDelta(letterPCoordinate, letterACoordinate);
            int numberDelta = GetFigureDelta(numberPCoordinate, numberACoordinate);
            if (letterDelta <= 1 && numberDelta <= 1 && (letterDelta + numberDelta) == 1 || (letterDelta + numberDelta) == 2)
            {
                result = true;
            }
            return (result);
        }
    }
}
