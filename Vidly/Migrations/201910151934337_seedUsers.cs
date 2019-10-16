namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd23317b3-ac5d-426b-bd18-61710ffb5908', N'admin@vidly.com', 0, N'AFuoW0WvgpxQOy0zhs74M+K2yK2wLQKDR/TSipLfos643gJ0PWM6odd5keEJMMyCOA==', N'73573fc8-68e0-4ab0-bc50-201d778b14e7', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e0421bc6-7d33-4a05-8059-1f0be693b0b9', N'guest@vidly.com', 0, N'APtBH1ibIRLWgf0d7xiXhswvPU6+l24eilOowgZ3WNPihiRMmwf7B3m3hdSU635PKg==', N'93794ee3-4130-43dc-adb4-03cf0c8430c3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e451b58-1448-4774-89ea-4baceaf9ca84', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd23317b3-ac5d-426b-bd18-61710ffb5908', N'1e451b58-1448-4774-89ea-4baceaf9ca84')

");
        }
        public override void Down()
        {
        }
    }
}
