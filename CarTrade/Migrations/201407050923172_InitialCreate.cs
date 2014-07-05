namespace CarTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telephelies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        irSzam = c.Int(nullable: false),
                        cim = c.String(),
                        parkolohely = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        marka = c.String(),
                        tipus = c.String(),
                        evjarat = c.Int(nullable: false),
                        gyartasiIdo = c.DateTime(nullable: false),
                        allapot = c.String(),
                        tulajdonosokSzama = c.Int(nullable: false),
                        telephelyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Autoes");
            DropTable("dbo.Telephelies");
        }
    }
}
