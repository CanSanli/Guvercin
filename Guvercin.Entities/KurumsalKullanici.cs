using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KurumsalKullanici
{
    [Key, ForeignKey("Kullanici")]
    public int KullaniciId { get; set; }

    [Required]
    [StringLength(100)]
    public string KurumAdi { get; set; }

    [Required]
    [StringLength(20)]
    public string VergiNo { get; set; }

    [Required]
    public DateTime KurulusTarihi { get; set; }

    // Navigation property
    public virtual Kullanici Kullanici { get; set; }
}
