using System;

namespace mars_rower
{
    public enum Direction
    {
        N = 6,
        S = 9,
        E = 15,
        W = 29,
    }

    public enum Move
    {
        M = 10,
        L = 12,
        R = 15,
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public Position(){

        }

        public Position(int x, int y, Direction direction){
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override String ToString() {
            return "(" + X + ", " + Y + ", " + Direction + ")";
        }
    }

    public class Astronaut
    {
        private Position Position { get; set; }
        private int directionIndex = 0;

        public Astronaut(int x, int y, Direction direction) {
            Position = new Position(x,y,direction);
        }

        public void Move(String moveCommand) {
            foreach (var item in moveCommand)
            {
                switch (item)
                {
                    case 'M':
                    case 'm':
                        Move();
                        break;
                    case 'L':
                    case 'l':
                        Rotate(-1);
                        break;
                    case 'R':
                    case 'r':
                        Rotate(1);
                        break;
                    default:
                        break;
                }
            }
            
        }

        private void Move() {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.X++;
                    break;
                case Direction.S:
                    Position.X--;
                    break;
                case Direction.W:
                    Position.Y++;
                    break;
                case Direction.E:
                    Position.Y--;
                    break;
                default:
                    break;
            }
        }

        private void Rotate(int right) {
            directionIndex += right;
            Position.Direction = GetDirection<Direction>(directionIndex);
        }

         private T GetDirection<T>(int index){
            var valuesAsArray = (T[])Enum.GetValues(typeof(T));
            int length = valuesAsArray.Length;
            int shrinkIndex = index >= 0 ? index % length: length - 1 - Math.Abs(index) % length;
            return (T)valuesAsArray[shrinkIndex];
        }
        
        public override String ToString() {
            return Position.ToString() + "";
        }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Program p = new Program();

            String move = "";

            Astronaut astronaut = new Astronaut(1, 2, Direction.N);

            Console.WriteLine("ilk konum:" + astronaut);

            while (!move.Equals("Q") && !move.Equals("q"))
            {
                Console.WriteLine("Çıkmak için q'ya basın ya da hareket komutu girin.");
                move = Console.ReadLine();
                Console.WriteLine(move + " bastınız.");
                astronaut.Move(move);
                Console.WriteLine("son konum:" + astronaut);
            }

            Console.WriteLine("son");
        }
    }
}
