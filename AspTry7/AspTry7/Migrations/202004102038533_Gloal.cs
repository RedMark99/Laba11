namespace AspTry7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gloal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Regs", "dateLeave", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regs", "dateLeave", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
