using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DashmixMockups.Data
{
    public class EkdilosiEndiaferontsModel : BaseEntity
    {

        [Required(ErrorMessage = "Το Όνομα είναι απαραίτητο")]
        [DisplayName("Όνομα")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Το Επώνυμο είναι απαραίτητο")]
        [DisplayName("Επώνυμο")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Το Email είναι απαραίτητο")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Το Τηλέφωνο είναι απαραίτητο")]
        [DisplayName("Τηλέφωνο")]
        public string Phone { get; set; }

        [DisplayName("Αίτημα")]
        [Required(ErrorMessage = "Το Αίτημα είναι απαραίτητο")]
        public string Issue { get; set; }
    }
}
