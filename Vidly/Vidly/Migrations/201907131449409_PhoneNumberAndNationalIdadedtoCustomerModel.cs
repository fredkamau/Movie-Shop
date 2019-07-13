namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumberAndNationalIdadedtoCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "NationalId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NationalId");
            DropColumn("dbo.Customers", "PhoneNumber");
        }
    }
}
