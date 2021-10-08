using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End.Migrations
{
    public partial class SettingTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(maxLength: 100, nullable: false),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 20, nullable: false),
                    FooterAddress = table.Column<string>(maxLength: 250, nullable: false),
                    HeaderAddress = table.Column<string>(maxLength: 250, nullable: false),
                    FacebookUrl = table.Column<string>(maxLength: 50, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 50, nullable: true),
                    SkypeUrl = table.Column<string>(maxLength: 50, nullable: true),
                    DribbbleUrl = table.Column<string>(maxLength: 50, nullable: true),
                    LinkedinUrl = table.Column<string>(maxLength: 50, nullable: true),
                    YoutubeUrl = table.Column<string>(maxLength: 50, nullable: true),
                    HeaderEmail = table.Column<string>(maxLength: 100, nullable: true),
                    ContactEmail = table.Column<string>(maxLength: 100, nullable: true),
                    AboutTitle = table.Column<string>(maxLength: 150, nullable: false),
                    AboutSubtitle = table.Column<string>(maxLength: 150, nullable: false),
                    AboutDesc = table.Column<string>(maxLength: 150, nullable: true),
                    AboutVideo = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
