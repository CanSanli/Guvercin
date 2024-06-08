using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class HouseholdMember
    {
        [Key]
        public int HouseholdMemberId { get; set; }

        [MaxLength(100)]
        public string MemberName { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid TCKN")]
        public string MemberID { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime MemberBirthdate { get; set; }

        public string MemberEducation { get; set; }

        public string MemberHealth { get; set; }

        // Foreign key
        public int IndividualMemberId { get; set; }

        // Navigation property
        public IndividualMember IndividualMember { get; set; }
    }



