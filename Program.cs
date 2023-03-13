using NLog;

// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string file = "tickets.txt";
string choice;

do
{
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("Enter any other key to exit.");
    choice = Console.ReadLine();

    if (choice == "1")
    {
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split('|');
                Console.WriteLine("TicketID: {0}, Summary {1}, Status {2}, Priority {3}, Submitter {4}, Assigned {5}, Watching {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    else if (choice == "2")
    {
        List<Ticket> tickets = new List<Ticket>();
        StreamWriter sw = new StreamWriter(file);
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter a ticket (Y/N)?");
            string resp = Console.ReadLine().ToUpper();

            if (resp != "Y") { break; }
            
            Console.WriteLine("Enter the ticket ID.");
            string ticketID = Console.ReadLine();

            Console.WriteLine("Enter the ticket summary.");
            string summary = Console.ReadLine();

            Console.WriteLine("Enter the status.");
            string status = Console.ReadLine();

            Console.WriteLine("Enter the priority.");
            string priority = Console.ReadLine();

            Console.WriteLine("Enter the submitter.");
            string submitter = Console.ReadLine();

            Console.WriteLine("Assigned To: ");
            string assigned = Console.ReadLine();

            Console.WriteLine("Watching: ");
            string watching = Console.ReadLine();

            Ticket ticket = new Ticket(ticketID, summary, status, priority, submitter, assigned, watching);
            tickets.Add(ticket);

            sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", ticket.ticketID, ticket.summary, ticket.status, ticket.priority, ticket.submitter, ticket.assigned, ticket.watching);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");

logger.Info("Program ended");
