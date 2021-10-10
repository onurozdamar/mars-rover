using System;

namespace mars_rower
{
    class CircularLinkedListManager
    {

        public CircularLinkedList node { get; set; }

        public CircularLinkedListManager()
        {
        }

        public CircularLinkedList Add(string data, Func<Position, Position> Invocation = null)
        {
            CircularLinkedList newNode = new CircularLinkedList(data, Invocation);

            if (node == null)
            {
                node = newNode;
                node.Next = node;
                node.Prev = node;
                return node;
            }

            CircularLinkedList iterator = node;

            while (iterator.Next != node)
            {
                iterator = iterator.Next;
            }

            iterator.Next = newNode;
            newNode.Prev = iterator;
            newNode.Next = node;
            node.Prev = newNode;

            return node;
        }

        public CircularLinkedList Get(string data)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Data.Equals(data))
            {
                return node;
            }

            CircularLinkedList iterator = node;

            while (iterator.Next != node && !iterator.Next.Data.Equals(data))
            {
                iterator = iterator.Next;
            }

            if (iterator.Next == node)
            {
                return null;
            }

            return iterator.Next;
        }

        public CircularLinkedList Next()
        {
            return node.Next;
        }

        public CircularLinkedList Prev() 
        {
            return node.Prev;
        }
    }
}