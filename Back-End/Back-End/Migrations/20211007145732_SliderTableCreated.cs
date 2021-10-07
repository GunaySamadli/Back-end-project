using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End.Migrations
{
    public partial class SliderTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(maxLength: 50, nullable: true),
                    IconTitle = table.Column<string>(maxLength: 25, nullable: true),
                    Title1 = table.Column<string>(maxLength: 50, nullable: false),
                    Title2 = table.Column<string>(maxLength: 50, nullable: true),
                    Subtitle = table.Column<string>(maxLength: 100, nullable: true),
                    Image = table.Column<string>(maxLength: 100, nullable: true),
                    RedirectUrlText = table.Column<string>(maxLength: 50, nullable: true),
                    RedirectUrl = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
