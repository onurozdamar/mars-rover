namespace mars_rower
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Position target;
        public Position Target
        {
            get
            {
                target = new Position();
                target.X = X;
                target.Y = Y;
                Direction.Invocation(target);
                return target;
            }
        }
        public CircularLinkedList Direction { get; set; }

        public Position()
        {

        }

        public Position(int x, int y, CircularLinkedList direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Direction + ")";
        }

        public bool Equals(Position other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}