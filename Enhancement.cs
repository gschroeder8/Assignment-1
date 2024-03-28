class EnhancementTicket : Ticket
{
    public string Software { get; set; }
    public string Cost { get; set; }
    public string Reason { get; set; }
    public string Estimate { get; set; }

    public EnhancementTicket(string ticketId, string summary, string status, string priority, string submitter, string assigned, string watching, string software, string cost, string reason, string estimate)
        : base(ticketId, summary, status, priority, submitter, assigned, watching)
    {
        Software = software;
        Cost = cost;
        Reason = reason;
        Estimate = estimate;
    }

    public override string ToString()
    {
        return base.ToString() + $",{Software},{Cost},{Reason},{Estimate}";
    }
}