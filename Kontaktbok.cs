using System;
using System.Collections.Generic;
using System.Linq;

// Velkommen til rykende fersk copilot søppel
// Dette er en enkel kontaktbok-app som lar deg legge til, fjerne, liste og søke etter kontakter.

// Den bruker en enkel konsollgrensesnitt for å samhandle med brukeren.

//@author Thomas Andreassen & CoPilot
//@date 04.04.2025
namespace ContactBookApp
{
    class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nPhone: {PhoneNumber}\nEmail: {Email}";
        }
    }

    class ContactBook
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully!");
        }

        public bool RemoveContact(string name)
        {
            Contact contactToRemove = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); //Nope, no clue what tf this is, but it works
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                return true;
            }
            return false;
        }

        public void ListAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.WriteLine("All Contacts:");
            Console.WriteLine("-------------");
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                Console.WriteLine(contacts[i]);
                Console.WriteLine("-------------");
            }
        }

        public List<Contact> SearchContacts(string searchTerm)
        {
            return contacts.Where(c => // No clue what this is, but it works
                c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || //Nope, no clue
                c.PhoneNumber.Contains(searchTerm) || // Nuh,uh
                c.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) // Nope
            ).ToList(); // Dont remove. The app implodes if you do.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ContactBook contactBook = new ContactBook();
            bool exit = false;

            Console.WriteLine("Welcome to Contact Book App!");

            while (!exit)
            {
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. Add a new contact");
                Console.WriteLine("2. Remove a contact");
                Console.WriteLine("3. List all contacts");
                Console.WriteLine("4. Search contacts");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice (1-5): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddContact(contactBook);
                            break;
                        case 2:
                            RemoveContact(contactBook);
                            break;
                        case 3:
                            contactBook.ListAllContacts();
                            break;
                        case 4:
                            SearchContacts(contactBook);
                            break;
                        case 5:
                            exit = true;
                            Console.WriteLine("Thank you for using Contact Book App. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }

        static void AddContact(ContactBook contactBook)
        {
            Contact newContact = new Contact();

            Console.Write("Enter name: ");
            newContact.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter phone number: ");
            newContact.PhoneNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter email: ");
            newContact.Email = Console.ReadLine() ?? string.Empty;

            contactBook.AddContact(newContact);
        }

        static void RemoveContact(ContactBook contactBook)
        {
            Console.Write("Enter the name of the contact to remove: ");
            string name = Console.ReadLine() ?? string.Empty;

            if (contactBook.RemoveContact(name))
            {
                Console.WriteLine("Contact removed successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void SearchContacts(ContactBook contactBook)
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine() ?? string.Empty;

            List<Contact> results = contactBook.SearchContacts(searchTerm);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching contacts found.");
                return;
            }

            Console.WriteLine($"Found {results.Count} matching contacts:");
            Console.WriteLine("-------------");
            foreach (var contact in results)
            {
                Console.WriteLine(contact);
                Console.WriteLine("-------------");
            }
        }
    }
}
