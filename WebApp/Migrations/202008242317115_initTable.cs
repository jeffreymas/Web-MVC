namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_m_department",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_m_division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        id_depart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_m_department", t => t.id_depart, cascadeDelete: true)
                .Index(t => t.id_depart);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_m_division", "id_depart", "dbo.tb_m_department");
            DropIndex("dbo.tb_m_division", new[] { "id_depart" });
            DropTable("dbo.tb_m_division");
            DropTable("dbo.tb_m_department");
        }
    }
}
