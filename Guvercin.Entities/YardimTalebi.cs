using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class YardimTalebi
{
    [Key]
    public int YardimTalebiId { get; set; }

    [Required]
    [ForeignKey("Kullanici")]
    public int KullaniciId { get; set; }

    [Required]
    [ForeignKey("YardimTuru")]
    public int YardimTuruId { get; set; }

    [Required]
    [StringLength(255)]
    public string Adres { get; set; }

    [Required]
    public string Aciklama { get; set; }

    [Required]
    public double Enlem { get; set; }

    [Required]
    public double Boylam { get; set; }

    [Required]
    public DateTime Tarih { get; set; } = DateTime.Now;

    [Required]
    [StringLength(50)]
    public string Durum { get; set; } // 'Beklemede', 'Onaylandi', 'Reddedildi', 'Tamamlandi'

    // Navigation properties
    public virtual Kullanici Kullanici { get; set; }
    public virtual YardimTuru YardimTuru { get; set; }
}

