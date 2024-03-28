class BugTicket : Ticket
{
    public string Severity { get; set; }

    public BugTicket(string ticketId, string summary, string status, string priority, string submitter, string assigned, string watching, string severity)
    : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        Severity = severity;
    }

    public override string ToString()
    {
        return base.ToString() + $",{Severity}";
    }
}