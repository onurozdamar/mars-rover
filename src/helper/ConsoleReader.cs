using System;

namespace mars_rower
{
    static class ConsoleReader
    {
        public static Astronaut ReadAstronaut()
        {
            while (true)
            {
                Console.Write("Çıkmak için q'ya basın ya da ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("astronaut girin.");
                Console.ForegroundColor = ConsoleColor.White;
                string move = Console.ReadLine();

                if (move.ToLower().Equals("q"))
                {
                    return null;
                }

                string[] moves = move.Split(" ");
                try
                {
                    int x = Int32.Parse(moves[0]);
                    int y = Int32.Parse(moves[1]);
                    CircularLinkedList direction = Program.CllManager.Get(moves[2].ToUpper());

                    if (direction == null)
                    {
                        throw new System.Exception();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(x + " " + y + " " + direction + " Eklendi.");
                    Console.ForegroundColor = ConsoleColor.White;

                    Astronaut astronaut = new Astronaut(x, y, direction);
                    astronaut.MoveCommand = ConsoleReader.ReadMove(Program.CllManager);

                    return astronaut;
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Doğru formatta giriniz. ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("number + number + (N, S, W, E)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static Bound ReadBound()
        {
            while (true)
            {
                Console.Write("Çıkmak için q'ya basın ya da ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("sınırları girin.");
                Console.ForegroundColor = ConsoleColor.White;
                string boundStr = Console.ReadLine();

                if (boundStr.ToLower().Equals("q"))
                {
                    return null;
                }

                string[] bounds = boundStr.Split(" ");
                try
                {
                    int x = Int32.Parse(bounds[0]);
                    int y = Int32.Parse(bounds[1]);

                    Bound bound = new Bound(x, y);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(bound + " sınır belirlendi.");
                    Console.ForegroundColor = ConsoleColor.White;

                    return bound;
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Doğru formatta giriniz. ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("number + number");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static string ReadMove(CircularLinkedListManager cllManager)
        {
            while (true)
            {
                Console.Write("Çıkmak için q'ya basın ya da ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("moveları girin.");
                Console.ForegroundColor = ConsoleColor.White;
                string moves = Console.ReadLine();

                if (moves.ToLower().Equals("q"))
                {
                    return "";
                }

                string[] movesArr = moves.Split("");
                try
                {
                    foreach (var move in moves)
                    { // move'lar valid mi
                        if (Char.ToUpper(move) != 'L' && Char.ToUpper(move) != 'R' && Char.ToUpper(move) != 'M')
                        {
                            throw new System.Exception();
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(moves + " Eklendi.");
                    Console.ForegroundColor = ConsoleColor.White;

                    return moves;
                }
                catch (System.Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Doğru formatta giriniz. ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("...(L, R, M)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

    }
}