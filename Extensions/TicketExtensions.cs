using System;
using System.Linq;
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

        public static string[] IntelliContracts = {
            "Συμβόλαιο Συντήρησης - ΚΟΥΚΟΓΙΑΝΝΗ ΜΑΓΔΑΛΗΝΗ",
            "Συμβόλαιο Συντήρησης - ΤΣΕΧΙΑ",
            "Web Site Hosting - Hosting b2c",
            "Web Site Hosting - ΣΥΜΒΑΣΗ 5860 23-02-2016 PRESCHOOL ΚΑΙ ΑΠΟΘΗΚΗ",
            "Συμβόλαιο Συντήρησης - Mmanager",
            "Συμβόλαιο Συντήρησης - TEXTIL COMMERCE 2 - Initial",
            "Συμβόλαιο Συντήρησης - ΣΛΟΥΜΑΤΗΣ ΙΓΝΑΤΙΟΣ",
            "Συμβόλαιο Συντήρησης - ΡΟΖΑΚΗΣ ΙΩΑΝΝΗΣ",
            "Συμβόλαιο Συντήρησης - www.mavrikosimports.gr",
            "Συμβόλαιο Συντήρησης - ΙΣΠΑΝΙΑ ΚΕΝΤΡΙΚΟ",
            "Συμβόλαιο Συντήρησης - Γκατζούνη Γεωργία & ΣΙΑ ΟΕ",
            "Συμβόλαιο Συντήρησης - TEXTIL COMMERCE 2",
            "Συμβόλαιο Συντήρησης - Forum",
            "Συμβόλαιο Συντήρησης",
            "Συμβόλαιο Συντήρησης - SITE B2B",
            "Συμβόλαιο Συντήρησης - MASTERETAIL Α.Ε.Ε - ΠΑΤΗΣΙΩΝ",
            "Συμβόλαιο Συντήρησης - KURO ENIDA",
            "Συμβόλαιο Συντήρησης - ILIADA LIMITED    ",
            "Domain Name",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 312,278,261,352 7/9/2012 (688€)",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 217, 253 1/9/2012 (4.443€)",
            "Web Site Hosting",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 317,302,339,336,305,341,338,335",
            "Συμβόλαιο Συντήρησης - ESTAYOR LIMITED",
            "Web Site Hosting - Initial",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 286,288,289,290,292,280,299,297,285,311,322",
            "Συμβόλαιο Συντήρησης - KURO PETRAQ",
            "Web Site Hosting - ΣΥΜΒΑΣΗ 12-12-2016 \"ΝΟΙΑΖΟΜΑΙ\"",
            "Συμβόλαιο Συντήρησης - Φάση Έργου Α, Β, Γ με βάση την αρχική προσφορά 14/03/2016",
            "Συμβόλαιο Συντήρησης - ΒΕΛΩΝΗ ΝΙΚΟΛΕΤΤΑ",
            "Νέα Σύμβαση",
            "Συμβόλαιο Συντήρησης - Initial",
            "Συμβόλαιο Συντήρησης - SIMPLEMENTE FRESCO ΙΣΠΑΝΙΑ ΥΠΟΚΑΤΑΣΤΗΜΑ",
            "Συμβόλαιο Συντήρησης - ΠΕΤΡΑΚΗΣ ΝΙΚΟΛΑΟΣ & ΣΙΑ ΕΕ  - ΗΓ. ΓΑΒΡΙΗΛ ",
            "Web Site Hosting - SITE B2B",
            "Συμβόλαιο Συντήρησης - SKLM GmbH",
            "Web Site Hosting - Forum",
            "SSL",
            "Web Site Hosting - SIMPLE SITE",
            "Συμβόλαιο Συντήρησης - ΠΕΤΡΑΚΗΣ ΝΙΚΟΛΑΟΣ & ΣΙΑ Ε.Ε. - ΡΕΘΥΜΝΟ",
            "Συμβόλαιο Συντήρησης - Επιπλέον 2ης Σύμβασης, Ρήτρες, 14/03/2011 (6.446,50€)",
            "Συμβόλαιο Συντήρησης - ΤΣΟΥΚΑΤΟΣ ΧΑΡΑΛΑΜΠΟΣ",
            "Συμβόλαιο Συντήρησης - SIMPLE SITE",
            "SSL - Initial",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες  202,203,207,211,212,214,215",
            "Web Site Hosting - www.mavrikosimports.gr",
            "Συμβόλαιο Συντήρησης - MASTERETAIL A.E.E - ΥΠΟΚΑΤΑΣΤΗΜΑ ΗΡΑΚΛΕΙΟΥ ΚΡΗΤΗΣ",
            "Συμβόλαιο τηλεφωνικής υποστήριξης",
            "Web Site Hosting - Mmanager",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 227,228, 243, 263, 280, 268",
            "Web Site Hosting - ship-suppliers.gr",
            "Domain Name - Initial",
            "Συμβόλαιο Συντήρησης - ΙΣΠΑΝΙΑ ΥΠΟΚΑΤΑΣΤΗΜΑ",
            "Συμβόλαιο Συντήρησης - SIMPLEMENTE FRESCO ΙΣΠΑΝΙΑ",
            "Συμβόλαιο Συντήρησης - ΠΟΛΥΖΟΥΛΗΣ ΠΕΤΡΟΣ",
            "Web Site Hosting - ΣΥΜΒΑΣΗ 25/04/2016 PRESCHOOL",
            "Συμβόλαιο Συντήρησης - Για τις εργασίες 255,262,269,272,276,275",
            "Συμβόλαιο Συντήρησης - SITE B2C-E-shop",
            "Συμβόλαιο Συντήρησης - MASTERETAIL ΥΠ/ΜΑ Ν. ΣΜΥΡΝΗΣ",
            "Συμβόλαιο Συντήρησης - MASTERETAIL Α.Ε.Ε - ΑΙΟΛΟΥ",
            "Συμβόλαιο Συντήρησης - CROKS s.r.o. -",
            "Συμβόλαιο Συντήρησης - ΜΠΑΚΑΣ ΑΘΑΝΑΣΙΟΣ"
        };

        public static Faker<Ticket> Tickets (Faker<Client> clients, Faker<Product> product) {
            return Tickets(clients, product, null);
        }

        public static Faker<Ticket> Tickets(Faker<Client> clients, Faker<Product> product, int? id) {
            var random = new Random();

            var client = clients.Generate();
            var storesIds = client.Stores.Select(s => s.Id).ToList();
            int storeId = random.Next(storesIds.Count);

            var productsIds = client.Products.Select(s => s.Id).ToList();
            int productId = random.Next(productsIds.Count);

            var contract = Contracts(client.Id,productId).Generate();

            var tickets = new Faker<Ticket>("el")

                //Ensure all properties have rules. By default, StrictMode is false
                //Set a global policy by using Faker.DefaultStrictMode
                //.StrictMode(true)

                //OrderId is deterministic
                .RuleFor(o => o.Id, f => id ?? f.Random.Int(4532,10000))
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.TicketDate, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(o => o.SupportHours, f=> f.Random.Int(4, 12))
                .RuleFor(o => o.FreeSupportHours, f=> f.Random.Int(1, 12))
                .RuleFor(o => o.StatusBadget, f => f.PickRandom(Badge))
                .RuleFor(o => o.ChargePerHour, f => f.PickRandom(PricePerHour))


                .RuleFor(o => o.PriorityId, f => f.Random.Int(1, 4))
                .RuleFor(o => o.Priority, f => f.PickRandom(Priority))

                .RuleFor(o => o.ProblemTypeId, f => f.Random.Int(1, 19))
                .RuleFor(o => o.ProblemType, f => f.PickRandom(ProblemTypes))

                .RuleFor(o => o.IncomingTypeId, f => f.Random.Int(1, 4))
                .RuleFor(o => o.IncomingType, f => f.PickRandom(IncomingTypes))

                .RuleFor(o => o.ClientId, f => clients.Generate().Id)
                .RuleFor(o => o.Client, f => client)

                .RuleFor(o => o.ProductId, f => client.Products[productId].Id)
                .RuleFor(o => o.Product, f => f.PickRandom(client.Products[productId]))

                .RuleFor(o => o.StoreId, f => client.Stores[storeId].Id)
                .RuleFor(o => o.Store, f => f.PickRandom(client.Stores[storeId]))

                .RuleFor(o => o.ContractId, f => contract.Id)
                .RuleFor(o => o.Contract, f => contract)

                .RuleFor(o => o.Image, f => f.Internet.Avatar())
                
                ;
            return tickets;
        }

        public static Faker<Product> Products()
        {
            var prdTitles = new FakeData().Products;
            var prdIds = 1;
            var product = new Faker<Product>()
                .RuleFor(O => O.Id, f => prdIds++)
                .RuleFor(O => O.Description, f => f.PickRandom(prdTitles));
            return product;
        }

        public static Faker<Client> Clients() {
            var random = new Randomizer();
            var clintIds = 1;
            var clients = new Faker<Client>("el")
                .RuleFor(O => O.Id, f => clintIds++)
                .RuleFor(O => O.Name, f => f.Company.CompanyName())
                .RuleFor(O => O.ContactName, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(O => O.PhoneNumber1, f => f.Person.Phone)
                .RuleFor(O => O.ContactEmail, f => f.Person.Email)
                .RuleFor(O => O.Stores, f=> Stores(clintIds).Generate(random.Number(1, 10)))
                .RuleFor(O => O.Products, f=> Products().Generate(random.Number(1, 5)))
                ;
            return clients;
        }

        public static Faker<Users> Users()
        {
            var ids = 1;
            var users = new Faker<Users>("el")
                .RuleFor(O => O.Id, f => ids++)
                .RuleFor(O => O.FirstName, f => f.Person.FirstName )
                .RuleFor(O => O.LastName, f => f.Person.LastName )
                .RuleFor(O => O.LastName, f => f.Person.Email );

            return users;
        }

        public static Faker<Store> Stores(int clientId) {
            var ids = 1;
            var clients = new Faker<Store>("el")
                    .RuleFor(o => o.Id, f => ids++)
                    .RuleFor(o => o.ClientId, f => clientId)
                    .RuleFor(o => o.IsPrime, f => (ids-1) == 1)
                    .RuleFor(o => o.Description, f => f.Company.CompanyName())
                    .RuleFor(o => o.IsActive, f => true)
                    .RuleFor(o => o.EasyComId, f => f.Random.Int(400, 500))
                ;

            return clients;
        }

        public static Faker<Contract> Contracts(int clientId, int productId)
        {
            var ids = 1;
            var clients = new Faker<Contract>("el")
                    .RuleFor(o => o.Id, f => ids++)
                    .RuleFor(o => o.ClientId, f => clientId)
                    .RuleFor(o => o.ProductId, f => productId)
                    .RuleFor(o => o.Description, f => f.PickRandom(IntelliContracts))
                    .RuleFor(o => o.FromDate, f => f.Date.PastOffset(1, DateTime.Now).Date)
                    .RuleFor(o => o.ToDate, f => f.Date.FutureOffset(1, DateTime.Now).Date)
                    .RuleFor(o => o.FreeHours, f => f.Random.Int(1, 6))
                    .RuleFor(o => o.ChargePerHour, f => f.Random.Int(50, 80))
                    .RuleFor(o => o.IsActive, f => true)
                    .RuleFor(o => o.EasyComId, f => f.Random.Int(400, 500))
                ;

            return clients;
        }
    }
}
