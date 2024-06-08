using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IndividualMember
{
    [Key]
    public int IndividualMemberId { get; set; }

    //[Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    //[Required]
    [MaxLength(100)]
    public string LastName { get; set; }

   
    [DataType(DataType.Date)]
    [Column(TypeName = "datetime2")]
    public DateTime Birthdate { get; set; }

    [Required]
    [MaxLength(11)]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid TCKN")]
    public string TCKimlikNumarasi { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    public string Gender { get; set; }

    public string MaritalStatus { get; set; }

    //[Required]
    [DataType(DataType.PhoneNumber)]
    public string TelefonNumarasi { get; set; }

    //[Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string EpostaAdresi { get; set; }

    public string EvAdresi { get; set; }

    public int HouseholdSize { get; set; }

    [DataType(DataType.Currency)]
    public decimal MonthlyIncome { get; set; }
    
}
