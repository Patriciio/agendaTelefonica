using System;

namespace AgendaTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            string option;
            int index;

            do
            {
                Console.WriteLine("A: Adicionar");
                Console.WriteLine("B: Remover");
                Console.WriteLine("C: Atualizar");
                Console.WriteLine("D: Recuperar");
                Console.WriteLine("E: Ordenar por Nome");
                Console.WriteLine("F: Ordenar por E-mail");
                Console.WriteLine("G: Listar Agenda");
                Console.WriteLine("H: Salvar em Arquivo");
                Console.WriteLine("I: Navegação");
                Console.WriteLine("Z: Sair");
                option = Console.ReadLine();
                Console.Clear();

                switch(option)
                {
                    case "A":
                    case "a":
                        Console.WriteLine("Novo Contato.");

                        Contact newContact = new Contact();

                        Console.Write("Nome = ");
                        newContact.name = Console.ReadLine();

                        Console.Write("E-mail = ");
                        newContact.email = Console.ReadLine();

                        Console.Write("Telefone = ");
                        newContact.telephone = Console.ReadLine();

                        list.Add(newContact);

                        Console.WriteLine("Contato criado.");
                        break;
                    case "B":
                    case "b":
                        Console.WriteLine("Índice = ");
                        index = Convert.ToInt32(Console.ReadLine());

                        list.DeleteNode(index);
                        break;
                    case "C":
                    case "c":
                        Console.WriteLine("Índice = ");
                        index = Convert.ToInt32(Console.ReadLine());

                        Contact foundContact = list.Find(index);

                        if (foundContact != null)
                        {
                            Console.Write("Nome = ");
                            foundContact.name = Console.ReadLine();

                            Console.Write("E-mail = ");
                            foundContact.email = Console.ReadLine();

                            Console.Write("Telefone = ");
                            foundContact.telephone = Console.ReadLine();
                        }

                        break;
                    case "D":
                    case "d":
                        Console.WriteLine("Recuperando do arquivo.");
                        list.LoadFile();

                        break;
                    case "E":
                    case "e":
                        Console.WriteLine("Ordenando por nome");
                        list.Sort("Name");

                        break;
                    case "F":
                    case "f":
                        Console.WriteLine("Ordenando por e-mail");
                        list.Sort("Email");

                        break;
                    case "G":
                    case "g":
                        Console.WriteLine("Listando Agenda.");
                        list.Print();

                        break;
                    case "H":
                    case "h":
                        Console.WriteLine("Salvando no arquivo.");
                        list.SaveFile();

                        break;
                    case "I":
                    case "i":
                        Console.WriteLine(list.head == list.head);
                        list.Navigate();

                        break;
                    case "Z":
                    case "z":
                        Console.WriteLine("Fim da execução");
                        break;
                    default:

                        break;
                }
            } while (option != "Z" && option != "z");
        }
    }
}
