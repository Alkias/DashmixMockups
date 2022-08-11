using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using DashmixMockups.Data;

namespace DashmixMockups.Factories
{
    public static class FakeTicketFactory
    {
        private const int numToSeed = 100;
        private static Randomizer _random = new Randomizer();

        #region Custom Lists

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
            "badge-info,Μικρή,yellow",
            "badge-success,Μεσαία,green",
            "badge-primary,Μεγάλη,blue",
            "badge-danger,Επείγον,red",
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
            "Τηλέφωνο,si si-call-in",
            "Email,si si-envelope",
            "Fax,fa fa-fax",
            "Viber,fab fa-viber"
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

        public static string[] PostStatus = {
            "badge-info,Open",
            "badge-success,Wait Client",
            "badge-primary,Closed"
        };

        #endregion

        public static List<Store> ClientStores (int clientId) {
            var storeIds = 1;
            var storeFaker = new Faker<Store>("el")
                .StrictMode(false)
                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => storeIds++)
                .RuleFor(d => d.ClientId, f => clientId)
                .RuleFor(d => d.IsPrime, f => storeIds - 1 == 1)
                .RuleFor(d => d.Description, f => f.Company.CompanyName())
                .RuleFor(d => d.IsActive, f => true)
                .RuleFor(d => d.EasyComId, f => f.Random.Int(400, 500));

            //Stores = 
            return storeFaker.Generate(_random.Number(1, 5));
        }

        public static void ClientProducts (Client client) {
            var clientProductIds = 1;
            var clientProducts = new List<ClientProduct>();

            var productIds = 1;
            var prdTitles = new FakeData().Products;
           var productFaker = new Faker<Product>("el")
                .StrictMode(false)
                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => productIds++)
                .RuleFor(d => d.Description, f => f.PickRandom(prdTitles));

            var products = productFaker.Generate(_random.Number(1, 5));

            foreach (var prd in products) {
                clientProducts.Add(
                    new ClientProduct {
                        Id = clientProductIds++,
                        ClientId = client.Id,
                        ProductId = prd.Id
                    });
            }

            client.Products = products;
        }

        public static Client GetClient() {
            var clientIds = 1;
            var clientFaker = new Faker<Client>("el")
                .StrictMode(false)
                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => clientIds++)
                .RuleFor(d => d.Name, f => f.Company.CompanyName())
                .RuleFor(d => d.ContactName, f => f.Person.FirstName + " " + f.Person.LastName)
                .RuleFor(d => d.PhoneNumber1, f => f.Person.Phone)
                .RuleFor(d => d.ContactEmail, f => f.Person.Email)
                .RuleFor(d => d.Stores, f => ClientStores(clientIds - 1))
                .RuleFor(o => o.Image, f => f.Internet.Avatar());

            var clients = clientFaker.Generate();
            ClientProducts(clients);
            ClientUsers(clients.Id);

            return clients;
        }

        private static List<User> ClientUsers (int id) {
           return SetUsers(1, _random.Number(2, 5), id);
        }

        private static List<User> TicketUsers(int id)
        {
            return SetUsers(5, _random.Number(6, 15), id);
        }

        public static Contract ClientProductContract (int clientId, int productId) {
            var contractIds = 1;
            var contractFaker = new Faker<Contract>("el")
                .StrictMode(false)
                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => contractIds++)
                .RuleFor(d => d.ClientId, f => clientId)
                .RuleFor(d => d.ProductId, f => productId)
                .RuleFor(d => d.Description, f => f.PickRandom(IntelliContracts))
                .RuleFor(d => d.FromDate, f => f.Date.PastOffset(1, DateTime.Now).Date)
                .RuleFor(d => d.ToDate, f => f.Date.FutureOffset(1, DateTime.Now).Date)
                .RuleFor(d => d.FreeHours, f => f.Random.Int(1, 6))
                .RuleFor(d => d.ChargePerHour, f => f.Random.Int(50, 80))
                .RuleFor(d => d.IsActive, f => true)
                .RuleFor(d => d.EasyComId, f => f.Random.Int(400, 500));

            return contractFaker.Generate();
        }

        public static List<Post> SetTicketPosts(int ticketId)
        {
            var postIds = 1;
            var postFake = new Faker<Post>("el")
                .StrictMode(false)

                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => postIds++)
                .RuleFor(d => d.TicketId, f => ticketId)
                .RuleFor(d => d.StatusBadge, f => f.PickRandom(PostStatus))
                .RuleFor(d => d.CreatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.UpdatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.ContactDate, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.NextContactDate, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.SolutionNotes, f => f.Lorem.Paragraphs(_random.Number(1, 3)))
                .RuleFor(d => d.SolutionRealTime, f => _random.Double(1, 6));
            return postFake.Generate(_random.Number(3, 15));
        }

        public static List<User> SetUsers(int min=1, int max=15, int? clientId=null)
        {
            var userIds = 1;
            var userFaker = new Faker<User>("el")
                .StrictMode(false)

                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => userIds++)
                .RuleFor(d => d.ClientId, f => clientId)
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.Email, f => f.Person.Email)
                .RuleFor(d => d.LoginName, f => f.Person.UserName)
                .RuleFor(d => d.IsActive, true)
                .RuleFor(d => d.Image, f => f.Internet.Avatar())

                .RuleFor(d => d.CreatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.UpdatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date);

            return userFaker.Generate(_random.Number(min, max));
        }

        public static Faker<User> SetUser(int? clientId = null)
        {
            var userIds = 1;
            var userFaker = new Faker<User>("el")
                .StrictMode(false)

                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => userIds++)
                .RuleFor(d => d.ClientId, f => clientId)
                .RuleFor(d => d.FirstName, f => f.Person.FirstName)
                .RuleFor(d => d.LastName, f => f.Person.LastName)
                .RuleFor(d => d.Email, f => f.Person.Email)
                .RuleFor(d => d.LoginName, f => f.Person.UserName)
                .RuleFor(d => d.IsActive, true)
                .RuleFor(d => d.Image, f => f.Internet.Avatar())

                .RuleFor(d => d.CreatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.UpdatedOnUtc, f => f.Date.PastOffset(3, DateTime.Now).Date);

            return userFaker;
        }

        public static List<Ticket> GenerateTickets (int ticketNum) {
            var ticketIds = 1;
            var ticketFaker = new Faker<Ticket>("el")
                .StrictMode(false)

                //.UseSeed(1122)
                .RuleFor(d => d.Id, f => ticketIds++)
                .RuleFor(d => d.Title, f => f.Commerce.ProductName())
               // .RuleFor(d => d.TicketDate, f => f.Date.PastOffset(3, DateTime.Now).Date)
                .RuleFor(d => d.TicketDate, f => {
                    var date = f.Date.PastOffset(3, DateTime.Now).Date;
                    return date.AddMinutes(_random.Number(350));
                })
                .RuleFor(d => d.SupportHours, f => f.Random.Int(4, 12))
                .RuleFor(d => d.FreeSupportHours, f => f.Random.Int(1, 12))
                .RuleFor(d => d.StatusBadget, f => f.PickRandom(Badge))
                .RuleFor(d => d.ChargePerHour, f => f.PickRandom(PricePerHour))
                .RuleFor(d => d.PriorityId, f => f.Random.Int(1, 4))
                .RuleFor(d => d.Priority, f => f.PickRandom(Priority))
                .RuleFor(d => d.ProblemTypeId, f => f.Random.Int(1, 19))
                .RuleFor(d => d.ProblemType, f => f.PickRandom(ProblemTypes))
                .RuleFor(d => d.IncomingTypeId, f => f.Random.Int(1, 4))
                .RuleFor(d => d.IncomingType, f => f.PickRandom(IncomingTypes));
                

            return ticketFaker.Generate(ticketNum);
        }

        public static List<Ticket> GetSomeTickets (int num) {
            var random = new Random();
            var tickets = GenerateTickets(num);

            foreach (var tic in tickets) {
                var client = GetClient();
                tic.ClientId = client.Id;
                tic.Client = client;

                var clientUsers = TicketUsers(client.Id);
                tic.Client.Users = clientUsers;

                int productIndex = random.Next(tic.Client.Products.Count);
                var product = client.Products[productIndex];
                tic.Product = product;
                tic.ProductId = product.Id;

                var contract = ClientProductContract(tic.ClientId, tic.ProductId);
                tic.ContractId = contract.Id;
                tic.Contract = contract;

                int storeIndex = random.Next(tic.Client.Stores.Count);
                var store = client.Stores[storeIndex];

                tic.StoreId = store.Id;
                tic.Store = store;

                var posts = SetTicketPosts(tic.Id);
                tic.Posts = posts;

                var users = TicketUsers(tic.Id);
                tic.Users = users;
                tic.SolutionUser = users.FirstOrDefault();
                tic.SolutionUserId = users.FirstOrDefault()?.Id;
            }

            return tickets;
        }
    }
}