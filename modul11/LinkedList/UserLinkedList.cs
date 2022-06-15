namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        public void AddLast(User user)
        {
            Node node = first;

            while (node is not null)
            {
                if (node.Next is not null)
                {
                    // Gå videre til næste node
                    node = node.Next;
                }
                else
                {
                    // Hvis den finder den sidste node
                    node.Next = new(user, null!);
                    break;
                }
            }
        }

        public User RemoveFirst()
        {
            Node node = first;
            first = node.Next;

            Console.WriteLine($"{node.Data.Name} er blevet fjernet.");
            return node.Data;
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (found is false && node is not null)
            {
                // Hvis user findes
                if (node.Data.Name == user.Name)
                {
                    // Hvis user er den første i listen
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        Console.WriteLine($"{node.Data.Name} er blevet fjernet.");
                        previous.Next = node.Next;
                    }
                    found = true;
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            Node node = first;

            while (node is not null)
            {
                if (node.Next is not null)
                {
                    // Gå videre til næste node
                    node = node.Next;
                }
                else
                {
                    // Hvis den finder den sidste node
                    Console.WriteLine($"{node.Data.Name} er den sidste på listen.");
                    return node.Data;
                }
            }
            return null!;
        }

        public int CountUsers()
          {
            Node node = first;
            bool last = false;

            int count = 0;

            while (last is false)
            {
                // Hvis det ikke er den sidste node i listen
                if (node.Next is not null)
                {
                    // Hvis denne node har en user
                    if (node.Data is not null)
                    {
                        count++;
                    }
                    // Gå videre til næste node
                    node = node.Next;
                }

                // Hvis det er den sidste node i listen
                else
                {
                    // Hvis denne node har en user
                    if (node.Data is not null)
                    {
                        count++;
                    }
                    // Stopper loopet
                    last = true;
                }
            }
            return count;
        }

        public bool Contains(User user)
        {
            Node node = first;
            bool last = false;

            while (last is false)
            {
                // Hvis det ikke er den sidste node i listen
                if (node.Next is not null)
                {
                    // Hvis denne node har den ønskede user
                    if (node.Data == user)
                    {
                        Console.WriteLine($"{node.Data.Name} findes på listen med id {node.Data.Id}.");
                        return true;
                    }
                    // Gå videre til næste node
                    node = node.Next;
                }

                // Hvis det er den sidste node i listen
                else
                {
                    if (node.Data == user)
                    {
                        // Hvis denne node indeholder den ønskede user
                        Console.WriteLine($"{node.Data.Name} findes på listen med id {node.Data.Id}.");
                        return true;
                    }
                    // Afslut while-loopet
                    last = true;
                }
            }
            // Hvis den ønskede bruger ikke findes
            Console.WriteLine($"{user.Name} findes på ikke på listen.");
            return false;
        }
        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
    }


}