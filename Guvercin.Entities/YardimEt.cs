using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class YardimEt
{
    [Key]
    public int YardimEtId { get; set; }

    [Required]
    public int YardimTalebiId { get; set; }

    [Required]
    public int YardimEdenKullaniciId { get; set; }

    [Required]
    public int KurumId { get; set; }

    [Required]
    [StringLength(50)]
    public string OnayDurumu { get; set; } // 'Beklemede', 'Onaylandi', 'Reddedildi', 'Tamamlandi'

    public DateTime? OnayTarihi { get; set; }
    public DateTime? TamamlanmaTarihi { get; set; }

    // Navigasyon özellikleri
    [ForeignKey("YardimTalebiId")]
    public virtual YardimTalebi YardimTalebi { get; set; }

    [ForeignKey("YardimEdenKullaniciId")]
    public virtual Kullanici YardimEdenKullanici { get; set; }

    [ForeignKey("KurumId")]
    public virtual KurumsalKullanici KurumsalKullanici { get; set; }
}
