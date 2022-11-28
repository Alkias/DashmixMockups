using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashmixMockups.Data.FsReports;
using DashmixMockups.Data.Tickets;

namespace DashmixMockups.Models
{
    public class TicketListModel
    {
        public List<Ticket> Tickets { get; set; }
    }

    public class CampainsListModel
    {
        public List<Campaign> Campaigns { get; set; }
    }
}
