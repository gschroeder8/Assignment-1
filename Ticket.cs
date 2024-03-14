class Ticket
{
    public string TicketId { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    
    public Ticket(string ticketId, string summary, string status, string priority, string submitter, string assigned, string watching)
    {
        TicketId = ticketId;
        Summary = summary;
        Status = status;
        Priority = priority;
        Submitter = submitter;
        Assigned = assigned;
        Watching = watching;
    }
}