namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) values (1, 'PayAsYouGo', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes(Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) values (2, 'Monthly', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes(Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) values (3, 'Quarterly', 90, 4, 15)");
            Sql("INSERT INTO MembershipTypes(Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) values (4, 'Annually', 120, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
