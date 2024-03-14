string file = "Tickets.txt";

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

    //creating a new ticket object
    Ticket newTicket = new Ticket(ticketId, summary, status, priority, submitter, assigned, watching);
    //converting the ticket object to a string
    string csvOutput = newTicket.ToString();

    //appending the newly added data to the CSV file
    //https://www.tutorialspoint.com/chash-program-to-append-text-to-an-existing-file
    using (StreamWriter sw = File.AppendText(file))
    {
        sw.WriteLine(csvOutput);
    }

    Console.WriteLine("Data added to the .txt file.");
}
    else 
{
    Console.WriteLine("Application ended.");
}
