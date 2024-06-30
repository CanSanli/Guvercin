using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BireyselKullanici
{
    [Key, ForeignKey("Kullanici")]
    public int KullaniciId { get; set; }

    [Required]
    [StringLength(50)]
    public string Ad { get; set; }

    [Required]
    [StringLength(50)]
    public string Soyad { get; set; }

    [Required]
    public DateTime DogumTarihi { get; set; }

    // Navigation property
    public virtual Kullanici Kullanici { get; set; }
}

