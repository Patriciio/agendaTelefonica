namespace AgendaTelefonica
{
    class Node
    {
        public Contact data;
        public Node next;

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(Contact contact)
        {
            data = contact;
            next = null;
        }
    }
}