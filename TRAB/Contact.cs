using System;

namespace AgendaTelefonica
{
    class Contact
    {
        public string name;
        public string telephone;
        public string email;

        public Contact() {}

        public Contact(string name, string telephone, string email)
        {
            this.name = name;
            this.telephone = telephone;
            this.email = email;
        }

        public void Print()
        {
            Console.WriteLine("Nome: {0}", this.name);
            Console.WriteLine("Telefone: {0}", this.telephone);
            Console.WriteLine("E-mail: {0}", this.email);
        }

        public bool IsEqual(Contact compareContact)
        {
            return this.name == compareContact.name &&
                   this.telephone == compareContact.telephone &&
                   this.email == compareContact.email;
        }
    }
}