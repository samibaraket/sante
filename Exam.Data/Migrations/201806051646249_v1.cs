namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCretion = c.DateTime(nullable: false, precision: 0),
                        DateExpiration = c.DateTime(nullable: false, precision: 0),
                        TypeAbonnement = c.String(unicode: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Prenom = c.String(unicode: false),
                        Mail = c.String(unicode: false),
                        Num_Tel = c.Int(nullable: false),
                        Sexe = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        Date_Inscription = c.DateTime(nullable: false, precision: 0),
                        Actif = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
                        FormationsId = c.Int(),
                        PrdtMedicsId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        categorie_IdCategorieProfilSante = c.Int(),
                        Formation_IDFormation = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorie_Profil_Santé", t => t.categorie_IdCategorieProfilSante)
                .ForeignKey("dbo.Formations", t => t.Formation_IDFormation)
                .Index(t => t.categorie_IdCategorieProfilSante)
                .Index(t => t.Formation_IDFormation);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        UserId = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(),
                        CustomRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .ForeignKey("dbo.CustomRoles", t => t.CustomRole_Id)
                .Index(t => t.Utilisateur_Id)
                .Index(t => t.CustomRole_Id);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        IDFormation = c.Int(nullable: false, identity: true),
                        NomFormation = c.String(unicode: false),
                        DatetFormation = c.DateTime(nullable: false, precision: 0),
                        Capacite = c.String(unicode: false),
                        AdresseLocal = c.String(unicode: false),
                        Admin_Id = c.Int(),
                        categorie_IDCategorieFormation = c.Int(),
                        Profil_Santé_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IDFormation)
                .ForeignKey("dbo.Utilisateurs", t => t.Admin_Id)
                .ForeignKey("dbo.Categorie_Formation", t => t.categorie_IDCategorieFormation)
                .ForeignKey("dbo.Utilisateurs", t => t.Profil_Santé_Id)
                .Index(t => t.Admin_Id)
                .Index(t => t.categorie_IDCategorieFormation)
                .Index(t => t.Profil_Santé_Id);
            
            CreateTable(
                "dbo.Categorie_Formation",
                c => new
                    {
                        IDCategorieFormation = c.Int(nullable: false, identity: true),
                        NomCategorieFormation = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IDCategorieFormation);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        IDPatient = c.Int(nullable: false),
                        IDProduit_Medicaux = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        datecommentaire = c.DateTime(nullable: false, precision: 0),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.IDPatient, t.IDProduit_Medicaux, t.Description })
                .ForeignKey("dbo.Utilisateurs", t => t.Patient_Id)
                .ForeignKey("dbo.Produit_Medicaux", t => t.IDProduit_Medicaux, cascadeDelete: true)
                .Index(t => t.IDProduit_Medicaux)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Produit_Medicaux",
                c => new
                    {
                        IDProduit_Medicaux = c.Int(nullable: false, identity: true),
                        NomProduit_Medicaux = c.String(unicode: false),
                        Qantite = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Prix = c.Single(nullable: false),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.IDProduit_Medicaux)
                .ForeignKey("dbo.Utilisateurs", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.RDVs",
                c => new
                    {
                        DateRdv = c.DateTime(nullable: false, precision: 0),
                        IDProfilSanté = c.Int(nullable: false),
                        IDPatient = c.Int(nullable: false),
                        DatePriseRdv = c.DateTime(nullable: false, precision: 0),
                        Patient_Id = c.Int(),
                        Profil_Santé_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.DateRdv, t.IDProfilSanté, t.IDPatient })
                .ForeignKey("dbo.Utilisateurs", t => t.Patient_Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Profil_Santé_Id)
                .Index(t => t.Patient_Id)
                .Index(t => t.Profil_Santé_Id);
            
            CreateTable(
                "dbo.Categorie_Profil_Santé",
                c => new
                    {
                        IdCategorieProfilSante = c.Int(nullable: false, identity: true),
                        NomCategorieProfilSante = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.IdCategorieProfilSante);
            
            CreateTable(
                "dbo.Avis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvisContent = c.String(unicode: false),
                        AvisValue = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        IdEvenement_Id = c.Int(),
                        IdFormation_IDFormation = c.Int(),
                        IdProduit_Medicaux_IDProduit_Medicaux = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evenements", t => t.IdEvenement_Id)
                .ForeignKey("dbo.Formations", t => t.IdFormation_IDFormation)
                .ForeignKey("dbo.Produit_Medicaux", t => t.IdProduit_Medicaux_IDProduit_Medicaux)
                .ForeignKey("dbo.Utilisateurs", t => t.User_Id)
                .Index(t => t.IdEvenement_Id)
                .Index(t => t.IdFormation_IDFormation)
                .Index(t => t.IdProduit_Medicaux_IDProduit_Medicaux)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomEvenement = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Actif = c.Boolean(nullable: false),
                        DateEvenement = c.DateTime(nullable: false, precision: 0),
                        DateCreation = c.DateTime(nullable: false, precision: 0),
                        NbrParticipants = c.Int(nullable: false),
                        IdProfilSante_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.IdProfilSante_Id)
                .Index(t => t.IdProfilSante_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DatePublication = c.DateTime(nullable: false, precision: 0),
                        IdPatient_Id = c.Int(),
                        IdProfilSante_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.IdPatient_Id)
                .ForeignKey("dbo.Utilisateurs", t => t.IdProfilSante_Id)
                .Index(t => t.IdPatient_Id)
                .Index(t => t.IdProfilSante_Id);
            
            CreateTable(
                "dbo.Participations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateValidation = c.DateTime(nullable: false, precision: 0),
                        Etat = c.Boolean(nullable: false),
                        IdEvenement_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evenements", t => t.IdEvenement_Id)
                .ForeignKey("dbo.Utilisateurs", t => t.User_Id)
                .Index(t => t.IdEvenement_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CustomRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "CustomRole_Id", "dbo.CustomRoles");
            DropForeignKey("dbo.Participations", "User_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Participations", "IdEvenement_Id", "dbo.Evenements");
            DropForeignKey("dbo.Documents", "IdProfilSante_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Documents", "IdPatient_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Avis", "User_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Avis", "IdProduit_Medicaux_IDProduit_Medicaux", "dbo.Produit_Medicaux");
            DropForeignKey("dbo.Avis", "IdFormation_IDFormation", "dbo.Formations");
            DropForeignKey("dbo.Avis", "IdEvenement_Id", "dbo.Evenements");
            DropForeignKey("dbo.Evenements", "IdProfilSante_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Abonnements", "User_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Formations", "Profil_Santé_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "Formation_IDFormation", "dbo.Formations");
            DropForeignKey("dbo.RDVs", "Profil_Santé_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "categorie_IdCategorieProfilSante", "dbo.Categorie_Profil_Santé");
            DropForeignKey("dbo.RDVs", "Patient_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Commentaires", "IDProduit_Medicaux", "dbo.Produit_Medicaux");
            DropForeignKey("dbo.Produit_Medicaux", "Admin_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Commentaires", "Patient_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Formations", "categorie_IDCategorieFormation", "dbo.Categorie_Formation");
            DropForeignKey("dbo.Formations", "Admin_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.CustomUserRoles", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.CustomUserLogins", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.CustomUserClaims", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.Participations", new[] { "User_Id" });
            DropIndex("dbo.Participations", new[] { "IdEvenement_Id" });
            DropIndex("dbo.Documents", new[] { "IdProfilSante_Id" });
            DropIndex("dbo.Documents", new[] { "IdPatient_Id" });
            DropIndex("dbo.Evenements", new[] { "IdProfilSante_Id" });
            DropIndex("dbo.Avis", new[] { "User_Id" });
            DropIndex("dbo.Avis", new[] { "IdProduit_Medicaux_IDProduit_Medicaux" });
            DropIndex("dbo.Avis", new[] { "IdFormation_IDFormation" });
            DropIndex("dbo.Avis", new[] { "IdEvenement_Id" });
            DropIndex("dbo.RDVs", new[] { "Profil_Santé_Id" });
            DropIndex("dbo.RDVs", new[] { "Patient_Id" });
            DropIndex("dbo.Produit_Medicaux", new[] { "Admin_Id" });
            DropIndex("dbo.Commentaires", new[] { "Patient_Id" });
            DropIndex("dbo.Commentaires", new[] { "IDProduit_Medicaux" });
            DropIndex("dbo.Formations", new[] { "Profil_Santé_Id" });
            DropIndex("dbo.Formations", new[] { "categorie_IDCategorieFormation" });
            DropIndex("dbo.Formations", new[] { "Admin_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "CustomRole_Id" });
            DropIndex("dbo.CustomUserRoles", new[] { "Utilisateur_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Utilisateur_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Utilisateurs", new[] { "Formation_IDFormation" });
            DropIndex("dbo.Utilisateurs", new[] { "categorie_IdCategorieProfilSante" });
            DropIndex("dbo.Abonnements", new[] { "User_Id" });
            DropTable("dbo.CustomRoles");
            DropTable("dbo.Participations");
            DropTable("dbo.Documents");
            DropTable("dbo.Evenements");
            DropTable("dbo.Avis");
            DropTable("dbo.Categorie_Profil_Santé");
            DropTable("dbo.RDVs");
            DropTable("dbo.Produit_Medicaux");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Categorie_Formation");
            DropTable("dbo.Formations");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Abonnements");
        }
    }
}
