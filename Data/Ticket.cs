using System;
using System.Collections.Generic;

namespace DashmixMockups.Data
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime TicketDate { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        /// <summary>
        /// Προηγουμένως ClientBranchId
        /// </summary>
        public int StoreId { get; set; }
        public int? ContractId { get; set; }
        

        public byte Status { get; set; }
        public string StatusBadget { get; set; }

        public bool HasContract { get; set; }

        public double FreeSupportHours { get; set; }

        public double SupportHours { get; set; }

        public double ChargePerHour { get; set; }

        public bool InformBalance { get; set; }

        public string SecretaryNotes { get; set; }

        public string ContactName { get; set; }

        public string Notes { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public int? AboutUserId { get; set; }

        public int? PriorityId { get; set; }
        public string Priority { get; set; }

        public int? ProblemTypeId { get; set; }
        public string ProblemType { get; set; }

        public int? IncomingTypeId { get; set; }
        public string IncomingType { get; set; }

        public DateTime? ExpectedSolutionDate { get; set; }

        public string SolutionNotes { get; set; }

        public byte? ChargeStatus { get; set; }

        public bool? IsOpenTask { get; set; }

        public double? SolutionTime { get; set; }

        public double? SolutionRealTime { get; set; }

        public DateTime? SolutionDate { get; set; }

        public int? SolutionUserId { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public int? Licenses { get; set; }

        public int? Cars { get; set; }

        

        public bool IsInitial { get; set; }

        public bool IsChecked { get; set; }

        //public byte[]? Concurrency { get; set; }

        public int? EasyComId { get; set; }

        public bool NoContract { get; set; }

        public Client Client { get; set; }
        public Product Product { get; set; }
        public Store Store { get; set; }
        public Contract Contract { get; set; }
    }

    public class Client : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Afm { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public int? EasyComId { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public bool? InformBalance { get; set; }

        public List<Store> Stores { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Store : BaseEntity
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string Description { get; set; }

        public bool IsPrime { get; set; }
        public bool IsActive { get; set; }

        public int? EasyComId { get; set; }
    }

    public class Product : BaseEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public int? EasyComId { get; set; }
    }

    public class ClientProduct
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
    }

    public class Users : BaseEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public int PasswordFormatId { get; set; }

        public string PasswordSalt { get; set; }

        public int AreaId { get; set; }

        public string Notes { get; set; }

        public bool IsActive { get; set; }

        public bool IsSystemAccount { get; set; }

        public string SystemName { get; set; }

        public int? CreateUserId { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public DateTime LastActivityDateUtc { get; set; }

        public int? EasyComId { get; set; }

        public string NewPassword { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        public bool? IsAdmin { get; set; }

        public DateTime? DeactivationDate { get; set; }
    }

    public class Contract : BaseEntity
    {
        public int Id { get; set; }


        public int ClientId { get; set; }


        public int ProductId { get; set; }


        public string Description { get; set; }


        public bool IsActive { get; set; }


        public int EasyComId { get; set; }


        public DateTime FromDate { get; set; }


        public DateTime ToDate { get; set; }


        public bool IsInitial { get; set; }


        public double FreeHours { get; set; }


        public double ChargePerHour { get; set; }


        public int? UserId { get; set; }
    }

    public class Post : BaseEntity
    {
        public int Id { get; set; }


        public int TicketId { get; set; }


        public byte Status { get; set; }


        public DateTime ContactDate { get; set; }


        public DateTime? NextContactDate { get; set; }


        public string SolutionNotes { get; set; }


        public int SolutionUserId { get; set; }


        public int? CreateUserId { get; set; }


        public DateTime? CreatedOnUtc { get; set; }


        public int? UpdateUserId { get; set; }


        public DateTime? UpdatedOnUtc { get; set; }


        public double? SolutionRealTime { get; set; }


        public bool IsRemote { get; set; }
    }

}