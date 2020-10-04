using System;
using System.IO;
using System.Text;

namespace AgendaTelefonica
{
    class LinkedList
    {
        public Node head { get; set; }
        public string path { get; set; }

        public LinkedList()
        {
            this.head = null;
            this.path = "lista.txt";
        }

        public LinkedList(string path)
        {
            this.head = null;
            this.path = path;
        }

        public void Add(Contact contact)
        {
            Node newNode = new Node(contact);

            if (this.head == null)
            {
                newNode.next = null;
                this.head = newNode;
            }
            else
            {
                Node aux = this.head;
                while (aux.next != null)
                {
                    aux = aux.next;
                }

                aux.next = newNode;
            }
        }

        public void DeleteNode(int index)
        {
            if (this.head == null)
            {
                Console.WriteLine("Lista Vazia.");
            }
            else if (index == 0)
            {
                this.head = this.head.next;
                Console.WriteLine("Contato deletado.");
            }
            else
            {
                Node aux = this.head;
                Node prev = null;
                int i;

                for (i = 0; i < index && aux != null; i++)
                {
                    prev = aux;
                    aux = aux.next;
                }

                if (i < index || aux == null)
                {
                    Console.WriteLine("Índice não encontrado.");
                }
                else
                {
                    prev.next = aux.next;
                    Console.WriteLine("Contato deletado.");
                }
            }
        }

        public Contact Find(int index)
        {

            if (this.head == null)
            {
                Console.WriteLine("Lista Vazia.");

                return null;
            }
            else
            {
                Node aux = this.head;
                int i;

                for (i = 0; i < index && aux != null; i++)
                {
                    aux = aux.next;
                }

                if (i < index)
                {
                    Console.WriteLine("Índice não encontrado.");

                    return null;
                }
                else
                {
                    return aux.data;
                }
            }
        }

        public void SaveFile()
        {
            if (this.head == null)
            {
                Console.WriteLine("Lista Vazia.");
            }
            else
            {
                if (File.Exists(this.path))
                {
                    File.Delete(this.path);
                }

                using (FileStream fs = File.Create(this.path))
                {

                    Node aux = this.head;
                    while (aux != null)
                    {
                        AddText(fs, aux.data.name);
                        AddText(fs, aux.data.telephone);
                        AddText(fs, aux.data.email);
                        aux = aux.next;
                    }
                }

                Console.WriteLine("Salvo no arquivo.");
            }
        }

        public void LoadFile()
        {
            if (!File.Exists(path))
            {
                File.Create(this.path);
            }

            string[] lines = File.ReadAllLines(this.path);

            int i = 0;
            while (i < lines.Length)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    break;
                }
                else
                {
                    Contact newContact = new Contact();

                    newContact.name = lines[i++];
                    newContact.telephone = lines[i++];
                    newContact.email = lines[i++];

                    this.Add(newContact);
                }
            }

            Console.WriteLine("Arquivo carregado.");
        }

        public void Print()
        {
            if(this.head == null)
            {
                Console.WriteLine("Lista Vazia.");
            }
            else
            {
                Node aux = this.head;

                while(aux != null)
                {
                    aux.data.Print();
                    Console.WriteLine();
                    aux = aux.next;
                }
            }
        }

        public void Sort(string sortBy)
        {
            bool swapped;
            Node aux;
            Node prev = null;

            if(this.head == null)
            {
                Console.WriteLine("Lista Vazia.");
            }

            else if (this.head.next == null)
            {
                Console.WriteLine("Lista com 1 elemento.");
            }
            else
            {
                do
                {
                    swapped = false;
                    aux = this.head;

                    while (aux.next != prev)
                    {
                        if (sortBy == "Name" && String.Compare(aux.data.name, aux.next.data.name) > 0)
                        {
                            this.swap(aux, aux.next);
                            swapped = true;
                        }
                        else if (sortBy == "Email" && String.Compare(aux.data.email, aux.next.data.email) > 0)
                        {
                            this.swap(aux, aux.next);
                            swapped = true;
                        }
                        aux = aux.next;
                    }
                    prev = aux;
                } while (swapped);
            }
        }

        public void Navigate()
        {
            if (this.head == null)
            {
                Console.WriteLine("Lista vazia.");
                return;
            }

            Node aux = this.head;

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Menu Navegação:");
                Console.WriteLine("Setas direcionais para andar");
                Console.WriteLine("Qualquer outra tecla para sair");
                aux.data.Print();

                string key = Console.ReadKey().Key.ToString();

                if (key == "LeftArrow")
                {
                    Node prev = null;
                    Node temp = this.head;
                    while (temp != null)
                    {
                        if (aux.data.IsEqual(temp.data) && aux != this.head)
                        {
                            break;
                        }

                        prev = temp;
                        temp = temp.next;
                    }

                    if (prev != null)
                    {
                        aux = prev;
                    }
                    else
                    {
                        Console.WriteLine("NULL");
                    }

                }
                else if (key == "RightArrow")
                {
                    if (aux.next == null)
                    {
                        aux = this.head;
                    }
                    else
                    {
                        aux = aux.next;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void swap(Node a, Node b)
        {
            Contact aux = a.data;
            a.data = b.data;
            b.data = aux;
        }

        public static void AddText(FileStream fs, string value)
        {
            value += "\n";
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}