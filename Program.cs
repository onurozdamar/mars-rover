using System;
using System.Collections.Generic;

namespace mars_rower
{
    class Program
    {
        public static CircularLinkedListManager CllManager = new CircularLinkedListManager();
        public static Bound Bound;

        static void Main(string[] args)
        {

            Program p = new Program();

            CllManager.Add("N", pos =>
            {
                pos.Y++;
                return pos;
            });
            CllManager.Add("S", pos =>
            {
                pos.Y--;
                return pos;
            });
            CllManager.Add("W", pos =>
            {
                pos.X++;
                return pos;
            });
            CllManager.Add("E", pos =>
            {
                pos.X--;
                return pos;
            });

            Bound = ConsoleReader.ReadBound();

            if (Bound == null)
            {
                return;
            }

            List<Astronaut> astronauts = new List<Astronaut>();
            Astronaut astronaut;

            while ((astronaut = ConsoleReader.ReadAstronaut()) != null)
            {
                astronaut.Move(astronauts);
                astronauts.Add(astronaut);
            }

            Console.WriteLine("son konumlar");

            foreach (var ast in astronauts)
            {
                Console.WriteLine(ast);
            }

            Console.WriteLine("son");
        }
    }
}
