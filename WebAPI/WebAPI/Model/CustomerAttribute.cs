using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI
{

    [Table("CustomerAttribute")]
    public class CustomerAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Attribute Master is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Attribute Master from 2 to 50 character")]
        public string attribute_master { get; set; }

        [Required]
        public string attribute_values_code { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Description from 2 to 80 character")]
        public string description { get; set; }

        [Required(ErrorMessage = "Short Name is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Short Name from 2 to 40 character")]
        public string short_name { get; set; }

        [Required(ErrorMessage = "Parent is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Parent from 2 to 50 character")]
        public string parent { get; set; }
        public DateTime effective_date { get; set; }
        public DateTime valid_until { get; set; }
    }
}
