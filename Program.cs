using System;

namespace mars_rower
{
    public enum Direction
    {
        N = 6,
        E = 5,
        S = 3,
        W = 0,
    }

    public enum Move
    {
        M = 10,
        L = 12,
        R = 15,
    }

    class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Direction direction { get; set; }
    }

    class Program
    {
        

        public T GetDirection<T>(int index){
            var valuesAsArray = (T[])Enum.GetValues(typeof(T));
            int length = valuesAsArray.Length;
            int shrinkIndex = index >= 0 ? index % length: (length - Math.Abs(index)) % length;
            return (T)valuesAsArray[shrinkIndex];
        }
       
        static void Main(string[] args)
        {
            Program p = new Program();

            Console.WriteLine(p.GetDirection<Direction>(-1));
        }
    }
}
