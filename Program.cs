using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add a ticket");
        Console.WriteLine("2. Search for tickets");
        Console.Write("Enter your choice (1 or 2): ");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid choice. Application ended.");
            return;
        }

        switch (choice)
        {
            case 1:
                AddTicket();
                break;
            case 2:
                SearchTickets();
                break;
            default:
                Console.WriteLine("Invalid choice. Application ended.");
                break;
        }
    }

    static void AddTicket()
    {
        int ticketTypeChoice;
        Console.WriteLine("Select Ticket Type:");
        Console.WriteLine("1. Bug");
        Console.WriteLine("2. Enhancement");
        Console.WriteLine("3. Task");
        Console.Write("Enter your choice (1-3): ");

        if (!int.TryParse(Console.ReadLine(), out ticketTypeChoice) || ticketTypeChoice < 1 || ticketTypeChoice > 3)
        {
            Console.WriteLine("Invalid choice. Application ended.");
            return;
        }

        string file;
        switch (ticketTypeChoice)
        {
            case 1:
                file = "Bugs.csv";
                break;
            case 2:
                file = "Enhancements.csv";
                break;
            case 3:
                file = "Tasks.csv";
                break;
            default:
                Console.WriteLine("Invalid choice. Application ended.");
                return;
        }

        Console.WriteLine("Enter Ticket ID:");
        string ticketId = Console.ReadLine();

        Console.WriteLine("Enter Summary:");
        string summary = Console.ReadLine();

        Console.WriteLine("Enter Status:");
        string status = Console.ReadLine();

        Console.WriteLine("Enter Priority:");
        string priority = Console.ReadLine();

        Console.WriteLine("Enter Submitter:");
        string submitter = Console.ReadLine();

        Console.WriteLine("Enter Assigned:");
        string assigned = Console.ReadLine();

        Console.WriteLine("Enter Watching:");
        string watching = Console.ReadLine();

        string csvOutput;
        Ticket newTicket;

        switch (ticketTypeChoice)
        {
            case 1: //bug
                Console.WriteLine("Enter Severity:");
                string severity = Console.ReadLine();
                newTicket = new BugTicket(ticketId, summary, status, priority, submitter, assigned, watching, severity);
                csvOutput = newTicket.ToString();
                break;
            case 2: //enhancement
                Console.WriteLine("Enter Software:");
                string software = Console.ReadLine();
                Console.WriteLine("Enter Cost:");
                string cost = Console.ReadLine();
                Console.WriteLine("Enter Reason:");
                string reason = Console.ReadLine();
                Console.WriteLine("Enter Estimate:");
                string estimate = Console.ReadLine();
                newTicket = new EnhancementTicket(ticketId, summary, status, priority, submitter, assigned, watching, software, cost, reason, estimate);
                csvOutput = newTicket.ToString();
                break;
            case 3: //task
                Console.WriteLine("Enter Project Name:");
                string projectName = Console.ReadLine();
                Console.WriteLine("Enter Due Date:");
                string dueDate = Console.ReadLine();
                newTicket = new TaskTicket(ticketId, summary, status, priority, submitter, assigned, watching, projectName, dueDate);
                csvOutput = newTicket.ToString();
                break;
            default:
                Console.WriteLine("Invalid choice. Application ended.");
                return;
        }

        using (StreamWriter sw = File.AppendText(file))
        {
            sw.WriteLine(csvOutput);
        }

        Console.WriteLine("Data added to the CSV file.");
    }

    static void SearchTickets()
    {
        Console.WriteLine("Choose search criteria:");
        Console.WriteLine("1. Search by status");
        Console.WriteLine("2. Search by priority");
        Console.WriteLine("3. Search by submitter");
        Console.WriteLine("4. Search all");
        Console.Write("Enter your choice (1-4): ");

        int searchChoice;
        if (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice < 1 || searchChoice > 4)
        {
            Console.WriteLine("Invalid choice. Application ended.");
            return;
        }

        string[] files = {"Bugs.csv", "Enhancements.csv", "Tasks.csv"};

        Console.WriteLine("Enter search keyword:");
        string searchKeyword = Console.ReadLine();

        int matchCount = 0;
        Console.WriteLine("Search Results:");
        foreach (string file in files)
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                switch (searchChoice)
                {
                    case 1: //status
                        if (line.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(line);
                            matchCount++;
                        }
                        break;
                    case 2: //priority
                        if (line.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(line);
                            matchCount++;
                        }
                        break;
                    case 3: //submitter
                        if (line.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(line);
                            matchCount++;
                        }
                        break;
                    case 4: //all
                        if (line.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(line);
                            matchCount++;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Application ended.");
                        return;
                }
            }
        }
        Console.WriteLine($"Number of matches: {matchCount}");
    }
}