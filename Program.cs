class Program
{
    static void Main()
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

        Console.WriteLine("Do you want to enter a ticket? (Y/N)");
        string addQuestion = Console.ReadLine().ToUpper();

        if (addQuestion == "Y")
        {
            Console.WriteLine("Enter Ticket ID:");
            string? ticketId = Console.ReadLine();

            Console.WriteLine("Enter Summary:");
            string? summary = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            string? status = Console.ReadLine();

            Console.WriteLine("Enter Priority:");
            string? priority = Console.ReadLine();

            Console.WriteLine("Enter Submitter:");
            string? submitter = Console.ReadLine();

            Console.WriteLine("Enter Assigned:");
            string? assigned = Console.ReadLine();

            Console.WriteLine("Enter Watching:");
            string? watching = Console.ReadLine();

            string csvOutput;
            Ticket newTicket;

            switch (ticketTypeChoice)
            {
                case 1: // Bug
                    Console.WriteLine("Enter Severity:");
                    string severity = Console.ReadLine();
                    newTicket = new BugTicket(ticketId, summary, status, priority, submitter, assigned, watching, severity);
                    csvOutput = newTicket.ToString();
                    break;
                case 2: // Enhancement
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
                case 3: // Task
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
        else
        {
            Console.WriteLine("Application ended.");
        }
    }

}
