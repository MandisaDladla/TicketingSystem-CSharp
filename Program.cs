using System;
using System.Collections.Generic;

class Ticket {
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsResolved { get; set; }

    public Ticket(int id, string description) {
        Id = id;
        Description = description;
        IsResolved = false;
    }
}

class Program {
    static List<Ticket> tickets = new List<Ticket>();
    static int nextId = 1;

    static void Main(string[] args) {
        while (true) {
            Console.WriteLine("\n=== Ticketing System ===");
            Console.WriteLine("1. Add Ticket");
            Console.WriteLine("2. View Tickets");
            Console.WriteLine("3. Resolve Ticket");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1": AddTicket(); break;
                case "2": ViewTickets(); break;
                case "3": ResolveTicket(); break;
                case "4": return;
                default: Console.WriteLine("Invalid option, try again."); break;
            }
        }
    }

    static void AddTicket() {
    Console.Write("Enter ticket description: ");
    string desc = Console.ReadLine();
    if (string.IsNullOrEmpty(desc)) {
        Console.WriteLine("Description cannot be empty!");
        return;
    }
    // Check for existing ID
    if (tickets.Any(t => t.Id == nextId)) {
        Console.WriteLine("Duplicate ID detected—fixing by incrementing...");
        nextId++; // Simple fix: increment if duplicate
    }
    tickets.Add(new Ticket(nextId++, desc));
    Console.WriteLine("Ticket added successfully!");
}

    static void ViewTickets() {
        if (tickets.Count == 0) {
            Console.WriteLine("No tickets found.");
            return;
        }
        foreach (var ticket in tickets) {
            Console.WriteLine($"ID: {ticket.Id}, Desc: {ticket.Description}, Resolved: {ticket.IsResolved}");
        }
    }

    static void ResolveTicket() {
        Console.Write("Enter ticket ID to resolve: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) {
            Console.WriteLine("Invalid ID!");
            return;
        }
        var ticket = tickets.Find(t => t.Id == id);
        if (ticket == null) {
            Console.WriteLine("Ticket not found!");
        } else {
            ticket.IsResolved = true;
            Console.WriteLine("Ticket resolved!");
        }
    }
}

