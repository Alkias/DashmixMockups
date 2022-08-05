using System;
using Bogus;
using DashmixMockups.Data;

namespace DashmixMockups.Extensions
{
    public static class TicketExtensions
    {
        public static string[] Badge = {
            "badge-secondary,Open",
            "badge-primary,In Progress",
            "badge-success,To UAT",
            "badge-info,Wait CR",
            "badge-warning,Closed",
            "badge-danger,Rejected"
        };

        public static int[] PricePerHour = {40, 50, 60, 70};

        public static string[] Priority = {
            "badge-info,Μικρή",
            "badge-success,Μεσαία",
            "badge-primary,Μεγάλη",
            "badge-danger,Επείγον",
        };

        public static string[] ProblemTypes = {
            "ΔΙΟΡΘΩΣΗ ΔΕΔΟΜΕΝΩΝ",
            "ΕΚΠΑΙΔΕΥΣΗ - ΑΠΟΡΙΕΣ ΕΦΑΡΜΟΓΩΝ",
            "ΛΑΘΟΣ ΕΦΑΡΜΟΓΗΣ",
            "ΠΡΟΤΑΣΗ ΝΕΑΣ ΕΚΔΟΣΗΣ",
            "ΝΕΑ ΑΠΑΙΤΗΣΗ ΠΕΛΑΤΗ",
            "ΕΓΚΑΤΑΣΤΑΣΗ",
            "ΕΡΩΤΗΣΗ ΧΡΗΣΗΣ ΕΦΑΡΜΟΓΩΝ INTELLI",
            "ΕΠΑΝΕΓΚΑΤΑΣΤΑΣΗ ΕΦΑΡΜΟΓΗΣ",
            "ΠΡΟΣΦΟΡΑ - ΜΕΛΕΤΗ",
            "ΕΛΕΓΧΟΣ HARDWARE",
            "ΜΗΝΥΜΑΤΑ ΛΑΘΩΝ ΕΦΑΡΜΟΓΩΝ INTELLI",
            "ΜΥΝΗΜΑΤΑ ΛΑΘΩΝ WINDOWS-OFFICE",
            "ΕΡΩΤΗΣΗ ΧΡΗΣΗΣ WINDOWS-OFFICE",
            "ΕΚΤΕΛΕΣΗ ΔΙΑΔ/ΣΙΑΣ ΓΙΑ ΛΟΓΑΡ. ΠΕΛΑΤ",
            "ΕΦΑΡΜΟΓΕΣ ΤΡΙΤΩΝ",
            "ΠΡΟΒΛΗΜΑΤΑ ΔΙΚΤΥΟΥ",
            "ΤΙΜΟΛΟΓΗΣΗ",
            "ΜΕΛΛΟΝΤΙΚΑ ΣΧΕΔΙΑ",
            "ΑΛΛΟ",

        };

        public static string[] IncomingTypes = {
            "Τηλέφωνο",
            "Email",
            "Fax",
            "Viber"
        };

        public static Faker<Ticket> Tickets (Faker<Client> clients, Faker<Product> product) {
            return Tickets(clients, product, null);
        }

        public static Faker<Ticket> Tickets(Faker<Client> clients, Faker<Product> product, int? id)
        {
            var tickets = new Faker<Ticket>("el")

                //Ensure all properties have rules. By default, StrictMode is false
                //Set a global policy by using Faker.DefaultStrictMode
                //.StrictMode(true)

                //OrderId is deterministic
                .RuleFor(o => o.Id, f => id ?? f.Random.Int(4532,10000))
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.TicketDate, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(o => o.SupportHours, f=> f.Random.Int(4, 12))
                .RuleFor(o => o.FreeSupportHours, f=> f.Random.Int(12, 24))
                .RuleFor(o => o.StatusBadget, f => f.PickRandom(Badge))
                .RuleFor(o => o.ChargePerHour, f => f.PickRandom(PricePerHour))


                .RuleFor(o => o.PriorityId, f => f.Random.Int(1, 4))
                .RuleFor(o => o.Priority, f => f.PickRandom(Priority))

                .RuleFor(o => o.ProblemTypeId, f => f.Random.Int(1, 19))
                .RuleFor(o => o.ProblemType, f => f.PickRandom(ProblemTypes))

                .RuleFor(o => o.IncomingTypeId, f => f.Random.Int(1, 4))
                .RuleFor(o => o.IncomingType, f => f.PickRandom(IncomingTypes))

                //Pick some fruit from a basket
                .RuleFor(o => o.ClientId, f => clients.Generate().Id)
                .RuleFor(o => o.Client, f => clients.Generate())
                .RuleFor(o => o.ProductId, f => product.Generate().Id)
                .RuleFor(o => o.Product, f => product.Generate())

                .RuleFor(o => o.Image, f => f.Internet.Avatar())
                
                ;
            return tickets;
        }

        public static Faker<Product> Products()
        {
            var prdTitles = new FakeData().Products;
            var prdIds = 0;
            var product = new Faker<Product>()
                .RuleFor(O => O.Id, f => prdIds++)
                .RuleFor(O => O.Description, f => f.PickRandom(prdTitles));
            return product;
        }

        public static Faker<Client> Clients()
        {
            var clintIds = 0;
            var clients = new Faker<Client>("el")
                .RuleFor(O => O.Id, f => clintIds++)
                .RuleFor(O => O.ContactName, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(O => O.PhoneNumber1, f => f.Person.Phone)
                .RuleFor(O => O.ContactEmail, f => f.Person.Email)
                
                ;
            return clients;
        }

        public static Faker<Users> Users()
        {
            var clintIds = 0;
            var clients = new Faker<Users>("el")
                .RuleFor(O => O.Id, f => clintIds++)
                .RuleFor(O => O.FirstName, f => f.Person.FirstName )
                .RuleFor(O => O.LastName, f => f.Person.LastName )
                .RuleFor(O => O.LastName, f => f.Person.Email );

            return clients;
        }
    }
}
