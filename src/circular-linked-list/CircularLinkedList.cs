using System;

namespace mars_rower
{
    class CircularLinkedList
    {
        public string Data { get; set; } // direction
        public Func<Position, Position> Invocation { get; set; } //direction move func
        public CircularLinkedList Next { get; set; }
        public CircularLinkedList Prev { get; set; }

        public CircularLinkedList(string data, Func<Position, Position> Invocation)
        {
            this.Data = data;
            this.Invocation = Invocation;
        }

        public CircularLinkedList()
        {
        }

        public override String ToString()
        {
            return Data;
        }
    }
}