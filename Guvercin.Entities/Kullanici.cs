using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Kullanici
{
    [Key]
    public int KullaniciId { get; set; }

    [Required]
    [StringLength(50)]
    public string KullaniciTipi { get; set; } // 'Bireysel' veya 'Kurumsal'

    [Required]
    [StringLength(100)]
    public string KullaniciAdi { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Sifre { get; set; }

    [Required]
    [StringLength(15)]
    public string Telefon { get; set; }

    [Required]
    [StringLength(255)]
    public string Adres { get; set; }

    // Navigation properties
    public virtual BireyselKullanici BireyselKullanici { get; set; }
    public virtual KurumsalKullanici KurumsalKullanici { get; set; }
}

