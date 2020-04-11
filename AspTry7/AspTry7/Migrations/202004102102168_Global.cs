namespace AspTry7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Global : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regs", "WageRate", c => c.Int(nullable: false));
            AddColumn("dbo.Regs", "Status", c => c.String());
            AddColumn("dbo.Regs", "MonthOfSalary", c => c.String());
            AddColumn("dbo.Regs", "YearOfSalary", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regs", "YearOfSalary");
            DropColumn("dbo.Regs", "MonthOfSalary");
            DropColumn("dbo.Regs", "Status");
            DropColumn("dbo.Regs", "WageRate");
        }
    }
}
