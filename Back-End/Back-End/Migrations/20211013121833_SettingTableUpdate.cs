using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End.Migrations
{
    public partial class SettingTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutSubtitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutVideo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DribbbleUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FooterAddress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HeaderAddress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HeaderEmail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SkypeUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "YoutubeUrl",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "HeaderLogo",
                table: "Settings",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FooterLogo",
                table: "Settings",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AboutTitle",
                table: "Settings",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "AboutDesc",
                table: "Settings",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutImage",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutSubDesc",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUrl",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUrlText",
                table: "Settings",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactMail",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CopyRight",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dribble",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DribbleUrl",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fb",
                table: "Settings",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FbUrl",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterDesc",
                table: "Settings",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePageImg",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Insta",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstaUrl",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailIcon",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Settings",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneIcon",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceImage",
                table: "Settings",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportMail",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Settings",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Settings",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutImage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutSubDesc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutUrlText",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ContactMail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CopyRight",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Dribble",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "DribbleUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Fb",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FbUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FooterDesc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HomePageImg",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Insta",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "InstaUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "MailIcon",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "PhoneIcon",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "ServiceImage",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SupportMail",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "HeaderLogo",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FooterLogo",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutTitle",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutDesc",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutSubtitle",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutVideo",
                table: "Settings",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Settings",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DribbbleUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterAddress",
                table: "Settings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderAddress",
                table: "Settings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderEmail",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkypeUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrl",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
