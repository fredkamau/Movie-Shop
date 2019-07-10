namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdateAddedToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birtdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birtdate");
        }
    }
}
