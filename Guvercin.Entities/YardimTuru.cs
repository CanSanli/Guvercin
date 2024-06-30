using System.ComponentModel.DataAnnotations;


public class YardimTuru
{
    [Key]
    public int YardimTuruId { get; set; }

    [Required]
    [StringLength(100)]
    public string YardimTuruAdi { get; set; }
}
