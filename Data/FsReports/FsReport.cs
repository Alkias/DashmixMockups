using System;
using System.Collections.Generic;
using Microsoft.Net.Http.Headers;

namespace DashmixMockups.Data.FsReports
{
    public class FsReport
    { }

    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }

    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ScientificName { get; set; }

        public bool Bait { get; set; }

        public string Url { get; set; }

        public bool Local { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Spot { get; set; }
    }

    public class EquipmentType
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Equipment
    {
        public int Id { get; set; }

        public int EquipmentTypeId { get; set; }

        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string Features { get; set; }

        public string Url { get; set; }
    }

    public class Technique
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Combo
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public List<Equipment> Equipment { get; set; }

    }

    public class Campaign
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int UsetId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

    }
}