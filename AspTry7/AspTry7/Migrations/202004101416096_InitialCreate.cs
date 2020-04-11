namespace AspTry7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        idEmp = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        surname = c.String(),
                        lastname = c.String(),
                        gender = c.String(),
                        dateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.idEmp);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        idPost = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPost);
            
            CreateTable(
                "dbo.Regs",
                c => new
                    {
                        idReg = c.Int(nullable: false, identity: true),
                        idEmp = c.Int(nullable: false),
                        idPost = c.Int(nullable: false),
                        dateTake = c.DateTime(nullable: false, storeType: "date"),
                        dateLeave = c.DateTime(nullable: false, storeType: "date"),
                        Price = c.Int(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.idReg);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regs");
            DropTable("dbo.Posts");
            DropTable("dbo.Employees");
        }
    }
}
