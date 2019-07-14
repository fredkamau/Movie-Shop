namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4849236b-64ac-4197-9e97-588ad43684b9', N'admin@bookrental.com', 0, N'ANrpcmfqQ/rF0/4XQmQV++c/jWw7PzevkqX1Wy91oFkgY8ShXvi1WPjFtiw/48QI8Q==', N'8266c2e5-2460-4e7e-9ac1-852c16c88e3c', NULL, 0, 0, NULL, 1, 0, N'admin@bookrental.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d50f4ab-8728-4e03-9d97-fae61db554ea', N'bookstoremanager@bookrental.com', 0, N'ALjsIR32+ZkX+VPWRc1D/55nqOwUwhND9QyB6aHBE3oTLC5fPGzgEZXvI74EOGmFmQ==', N'2bffe375-893f-4888-8f15-0c40cc6ebbd9', NULL, 0, 0, NULL, 1, 0, N'bookstoremanager@bookrental.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd179620d-c8ab-42f6-91d3-1e4109fa72eb', N'CanManageBooks')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d50f4ab-8728-4e03-9d97-fae61db554ea', N'd179620d-c8ab-42f6-91d3-1e4109fa72eb')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
