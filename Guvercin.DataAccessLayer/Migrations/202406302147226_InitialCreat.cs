namespace Guvercin.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BireyselKullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        DogumTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciId)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        KullaniciTipi = c.String(nullable: false, maxLength: 50),
                        KullaniciAdi = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Sifre = c.String(nullable: false, maxLength: 100),
                        Telefon = c.String(nullable: false, maxLength: 15),
                        Adres = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
            CreateTable(
                "dbo.KurumsalKullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false),
                        KurumAdi = c.String(nullable: false, maxLength: 100),
                        VergiNo = c.String(nullable: false, maxLength: 20),
                        KurulusTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciId)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.HouseholdMembers",
                c => new
                    {
                        HouseholdMemberId = c.Int(nullable: false, identity: true),
                        MemberName = c.String(maxLength: 100),
                        MemberID = c.String(nullable: false, maxLength: 11),
                        MemberBirthdate = c.DateTime(nullable: false, storeType: "date"),
                        MemberEducation = c.String(),
                        MemberHealth = c.String(),
                        IndividualMemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HouseholdMemberId)
                .ForeignKey("dbo.IndividualMembers", t => t.IndividualMemberId, cascadeDelete: true)
                .Index(t => t.IndividualMemberId);
            
            CreateTable(
                "dbo.IndividualMembers",
                c => new
                    {
                        IndividualMemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Birthdate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TCKimlikNumarasi = c.String(nullable: false, maxLength: 11),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        TelefonNumarasi = c.String(),
                        EpostaAdresi = c.String(),
                        EvAdresi = c.String(),
                        HouseholdSize = c.Int(nullable: false),
                        MonthlyIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IndividualMemberId);
            
            CreateTable(
                "dbo.YardimEts",
                c => new
                    {
                        YardimEtId = c.Int(nullable: false, identity: true),
                        YardimTalebiId = c.Int(nullable: false),
                        YardimEdenKullaniciId = c.Int(nullable: false),
                        KurumId = c.Int(nullable: false),
                        OnayDurumu = c.String(nullable: false, maxLength: 50),
                        OnayTarihi = c.DateTime(),
                        TamamlanmaTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.YardimEtId)
                .ForeignKey("dbo.KurumsalKullanicis", t => t.KurumId, cascadeDelete: true)
                .ForeignKey("dbo.Kullanicis", t => t.YardimEdenKullaniciId, cascadeDelete: true)
                .ForeignKey("dbo.YardimTalebis", t => t.YardimTalebiId, cascadeDelete: true)
                .Index(t => t.KurumId)
                .Index(t => t.YardimEdenKullaniciId)
                .Index(t => t.YardimTalebiId);
            
            CreateTable(
                "dbo.YardimTalebis",
                c => new
                    {
                        YardimTalebiId = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        YardimTuruId = c.Int(nullable: false),
                        Adres = c.String(nullable: false, maxLength: 255),
                        Aciklama = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Durum = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.YardimTalebiId)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId, cascadeDelete: false)
                .ForeignKey("dbo.YardimTurus", t => t.YardimTuruId, cascadeDelete: false)
                .Index(t => t.KullaniciId)
                .Index(t => t.YardimTuruId);
            
            CreateTable(
                "dbo.YardimTurus",
                c => new
                    {
                        YardimTuruId = c.Int(nullable: false, identity: true),
                        YardimTuruAdi = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.YardimTuruId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YardimEts", "YardimTalebiId", "dbo.YardimTalebis");
            DropForeignKey("dbo.YardimTalebis", "YardimTuruId", "dbo.YardimTurus");
            DropForeignKey("dbo.YardimTalebis", "KullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.YardimEts", "YardimEdenKullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.YardimEts", "KurumId", "dbo.KurumsalKullanicis");
            DropForeignKey("dbo.HouseholdMembers", "IndividualMemberId", "dbo.IndividualMembers");
            DropForeignKey("dbo.BireyselKullanicis", "KullaniciId", "dbo.Kullanicis");
            DropForeignKey("dbo.KurumsalKullanicis", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.YardimEts", new[] { "YardimTalebiId" });
            DropIndex("dbo.YardimTalebis", new[] { "YardimTuruId" });
            DropIndex("dbo.YardimTalebis", new[] { "KullaniciId" });
            DropIndex("dbo.YardimEts", new[] { "YardimEdenKullaniciId" });
            DropIndex("dbo.YardimEts", new[] { "KurumId" });
            DropIndex("dbo.HouseholdMembers", new[] { "IndividualMemberId" });
            DropIndex("dbo.BireyselKullanicis", new[] { "KullaniciId" });
            DropIndex("dbo.KurumsalKullanicis", new[] { "KullaniciId" });
            DropTable("dbo.YardimTurus");
            DropTable("dbo.YardimTalebis");
            DropTable("dbo.YardimEts");
            DropTable("dbo.IndividualMembers");
            DropTable("dbo.HouseholdMembers");
            DropTable("dbo.KurumsalKullanicis");
            DropTable("dbo.Kullanicis");
            DropTable("dbo.BireyselKullanicis");
        }
    }
}
