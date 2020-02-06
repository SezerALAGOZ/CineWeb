namespace CineWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43b9bf6a-3245-4441-a203-3a7007371e89', N'sezeralagoz@outlook.com', 0, N'AK85dQO5FsstH0bbnj4XRlC5GjkiWN4mwH2kwyJx8Qfz35AExEOomZnt9QkTvQGTZg==', N'802975a5-77e0-473a-9ba3-42308ffd6ca3', NULL, 0, 0, NULL, 1, 0, N'sezeralagoz@outlook.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9b73441-7bde-4fed-a417-e2937bda0f21', N'sezeralagoz8@gmail.com', 0, N'AEf9rkckKvkBtKtgMivwEBY/SqXlvPGKseC89jE/9l3ih2oU27Y4QX6eFsthaq/j/Q==', N'bad649a9-fcf4-4bd0-9337-ed5d5b9d3c30', NULL, 0, 0, NULL, 1, 0, N'sezeralagoz8@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5a890f4f-b928-4707-aead-165b493d32ca', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43b9bf6a-3245-4441-a203-3a7007371e89', N'5a890f4f-b928-4707-aead-165b493d32ca')


");
        }

        public override void Down()
        {
        }
    }
}
