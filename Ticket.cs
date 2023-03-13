using NLog;

public class Ticket
{
    public string ticketID {get;set;}
    public string summary {get;set;}
    public string status {get;set;}
    public string priority {get;set;}
    public string submitter {get;set;}
    public string assigned {get;set;}
    public string watching {get;set;}

    public Ticket(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching)
    {
        this.ticketID = ticketID;
        this.summary = summary;
        this.status = status;
        this.priority = priority;
        this.submitter = submitter;
        this.assigned = assigned;
        this.watching = watching;
    }

    public string Display()
    {
        return $"Ticket ID: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}";
    }
}
