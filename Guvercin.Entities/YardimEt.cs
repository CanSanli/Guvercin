using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class YardimEt
{
    [Key]
    public int YardimEtId { get; set; }

    [Required]
    [ForeignKey("YardimTalebi")]
    public int YardimTalebiId { get; set; }

    [Required]
    [ForeignKey("Kullanici")]
    public int YardimEdenKullaniciId { get; set; }

    [Required]
    [ForeignKey("KurumsalKullanici")]
    public int KurumId { get; set; }

    [Required]
    [StringLength(50)]
    public string OnayDurumu { get; set; } // 'Beklemede', 'Onaylandi', 'Reddedildi', 'Tamamlandi'

    public DateTime? OnayTarihi { get; set; }
    public DateTime? TamamlanmaTarihi { get; set; }

    // Navigation properties
    public virtual YardimTalebi YardimTalebi { get; set; }
    public virtual Kullanici YardimEdenKullanici { get; set; }
    public virtual KurumsalKullanici KurumsalKullanici { get; set; }
}

