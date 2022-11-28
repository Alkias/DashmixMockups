using System;
using System.Collections.Generic;
using System.Net;
using Bogus;
using DashmixMockups.Data.FsReports;
using DashmixMockups.Data.Tickets;

namespace DashmixMockups.Factories
{
    public static class FakeFsReportFactory
    {
        #region Fields

        private const int numToSeed = 100;
        private static Randomizer _random = new Randomizer();

        public static List<String> EqTitles = new List<string> { 
            "Shimano Alivio - Vanford",
            "Shimano Pro - Stella",
            "Shimano Allo - Ultegra",
        };

        #endregion

        public static List<Campaign> GenerateCampaigns(int campainsNum) {
            var campaignIds = 1;
            var fakeCampaign = new Faker<Campaign>()
                .StrictMode(false)
                .RuleFor(d => d.Id, f => campaignIds++)
                .RuleFor(d => d.LocationId, f => campaignIds++)
                .RuleFor(d => d.Start,

                    f => {
                        var date = f.Date.PastOffset(3, DateTime.Now).Date;
                        return date.AddMinutes(_random.Number(350));
                    });
            return fakeCampaign.Generate(campainsNum);
        }

        public static List<Equipment> Equipments() {
            var ids = 1;
            var fakeEquipent = new Faker<Equipment>()
                .StrictMode(false)
                .RuleFor(d => d.Id, f => ids++)
                .RuleFor(d => d.Name, f => f.PickRandom(EqTitles))
                .RuleFor(d => d.CompanyId, f => f.Random.Int(1, 10));

            return fakeEquipent.Generate(_random.Number(1, 2));
        }

        
    }
}
