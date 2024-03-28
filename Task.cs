class TaskTicket : Ticket
{
    public string ProjectName { get; set; }
    public string DueDate { get; set; }

    public TaskTicket(string ticketId, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate)
        : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        ProjectName = projectName;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        return base.ToString() + $",{ProjectName},{DueDate}";
    }
}