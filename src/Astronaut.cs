using System;
using System.Collections.Generic;


namespace mars_rower
{
    class Astronaut
    {
        public Position Position { get; set; }
        public string MoveCommand { get; set; }
        public Astronaut(int x, int y, CircularLinkedList direction)
        {
            Position = new Position(x, y, direction);
        }
        public void Move(List<Astronaut> astronauts)
        {
            foreach (var item in MoveCommand)
            {
                switch (item)
                {
                    case 'M':
                    case 'm':
                        if (checkCrashAndBounds(astronauts))
                        {
                            return;
                        }
                        Position.X = Position.Target.X;
                        Position.Y = Position.Target.Y;
                        Console.WriteLine("move" + Position);
                        break;
                    case 'L':
                    case 'l':
                        Position.Direction = Program.CllManager.Get(Position.Direction.Data).Next;
                        Console.WriteLine("turn left " + Position);
                        break;
                    case 'R':
                    case 'r':
                        Position.Direction = Program.CllManager.Get(Position.Direction.Data).Prev;
                        Console.WriteLine("turn right " + Position);
                        break;
                    default:
                        break;
                }
            }
        }

        private bool checkCrashAndBounds(List<Astronaut> astronauts)
        {
            if (Position.X > Program.Bound.X || Position.Y > Program.Bound.Y ||
            Position.X < 0 || Position.Y < 0)
            {
                Console.WriteLine("Sınırların dışında!" + this);
                return true;
            }
            foreach (var ast in astronauts)
            {
                if (Position.Target.Equals(ast.Position))
                {
                    Console.WriteLine("Kaza! " + ast + " ile " + this + " çarpıştı.");
                    return true;
                }

            }
            return false;
        }

        public override String ToString()
        {
            return Position.ToString();
        }
    }
}