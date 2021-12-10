namespace mars_rower
{
    class Bound
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Bound(){

        }

        public Bound(int x, int y){
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return "(" + X + ", " + Y + ")";
        }
    }
}