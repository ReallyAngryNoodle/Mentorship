using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static int Main(string[] args)
        {
            var startX = 1;
            var startY = 1;

            Console.Write("Enter start x (horizontal) coordinate (1 ≤ x ≤ 8): ");
            var x = int.Parse(Console.ReadLine());

            Console.Write("Enter start y (vertical) coordinate (1 ≤ y ≤ 8): ");
            var y = int.Parse(Console.ReadLine());

            if (x < 1 || x > 8)
            {
                x = startX;
            }

            if (y < 1 || y > 8)
            {
                y = startY;
            }

            startX = x;
            startY = y;

            var movesOrder = string.Empty;

            var desiredX = 0;
            var desiredY = 0;

            Console.Write("Enter desired x (horizontal) coordinate (1 ≤ x ≤ 8): ");
            desiredX = int.Parse(Console.ReadLine());

            Console.Write("Enter desired y (vertical) coordinate (1 ≤ y ≤ 8): ");
            desiredY = int.Parse(Console.ReadLine());

            if (x == desiredX && y == desiredY)
            {
                Console.WriteLine("Same coordinates");
            }

            var i = 1;
            var constant = 1;
            var multiplier = 10;

            bool flag = true;

            while (flag)
            {
                if (constant * multiplier - i >= 2)
                {
                    movesOrder = i.ToString();

                    Move(movesOrder, ref x, ref y);
                    Console.WriteLine($"Move: {movesOrder}, x: {x}, y: {y}");

                    if ((x == desiredX) && (y == desiredY))
                    {
                        break;
                    }

                    x = startX;
                    y = startY;
                }
                else
                {
                    i++;
                    constant++;
                }

                do
                {
                    i++;

                    if (constant * multiplier < i)
                    {
                        constant++;
                    }
                } while (i.ToString().Contains("9") || i.ToString().Contains("0"));

            }

            Console.WriteLine();
            Console.WriteLine($"Target reached, moves: {movesOrder}");

            Console.ReadLine();
            return 0;
        }

        static void Move(string movesOrder, ref int x, ref int y)
        {
            var movesArray = new int[movesOrder.Length];

            for (var i = 0; i < movesOrder.Length; i++)
            {
                movesArray[i] = int.Parse(movesOrder[i].ToString());
            }

            for (var i = 0; i < movesArray.Length; i++)
            {
                switch (movesArray[i])
                {
                    case 1:
                        Move2Up1Right(ref x, ref y);
                        break;
                    case 2:
                        Move1Up2Right(ref x, ref y);
                        break;
                    case 3:
                        Move1Down2Right(ref x, ref y);
                        break;
                    case 4:
                        Move2Down1Right(ref x, ref y);
                        break;
                    case 5:
                        Move2Down1Left(ref x, ref y);
                        break;
                    case 6:
                        Move1Down2Left(ref x, ref y);
                        break;
                    case 7:
                        Move1Up12Left(ref x, ref y);
                        break;
                    case 8:
                        Move2Up1Left(ref x, ref y);
                        break;
                    default:
                        break;
                }
            }
        }

        static bool CheckIfCanMove(int x, int y)
        {
            if ((x < 1) || (x > 8))
            {
                return false;
            }

            if ((y < 1) || (y > 8))
            {
                return false;
            }

            return true;
        }

        #region Moves

        static void Move2Up1Right(ref int x, ref int y)
        {
            var newX = x + 1;
            var newY = y + 2;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move1Up2Right(ref int x, ref int y)
        {
            var newX = x + 2;
            var newY = y + 1;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move1Down2Right(ref int x, ref int y)
        {
            var newX = x + 2;
            var newY = y - 1;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move2Down1Right(ref int x, ref int y)
        {
            var newX = x + 1;
            var newY = y - 2;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move2Down1Left(ref int x, ref int y)
        {
            var newX = x - 1;
            var newY = y - 2;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move1Down2Left(ref int x, ref int y)
        {
            var newX = x - 2;
            var newY = y - 1;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move1Up12Left(ref int x, ref int y)
        {
            var newX = x - 2;
            var newY = y + 1;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        static void Move2Up1Left(ref int x, ref int y)
        {
            var newX = x - 1;
            var newY = y + 2;

            if (CheckIfCanMove(newX, newY))
            {
                x = newX;
                y = newY;
            }
        }

        #endregion
    }
}
