using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.gRPC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateandSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 0m, "No discount on latest Pro model", "techphone 15 pro" },
                    { 2, 50m, "Standard model discount", "techphone 15" },
                    { 3, 0m, "No discount on premium flagship", "galaxy s24 ultra max" },
                    { 4, 75m, "Spring sale offer", "galaxy s24 standard" },
                    { 5, 100m, "AI camera special", "pixel pro 8" },
                    { 6, 80m, "Clearance discount", "pixel 8" },
                    { 7, 60m, "Flagship killer deal", "oneplus 12" },
                    { 8, 40m, "Mid-range special", "oneplus 12r" },
                    { 9, 90m, "Global release promo", "xiaomi 14 pro" },
                    { 10, 45m, "Edge series discount", "moto edge 50" },
                    { 11, 150m, "Creator bundle discount", "sony xperia 1 v" },
                    { 12, 120m, "Gamer mobile special", "asus rog phone 8" },
                    { 13, 0m, "No discount on limited edition", "nothing phone (2)" },
                    { 14, 20m, "Budget king offer", "poco x6 pro" },
                    { 15, 30m, "Speedster discount", "realme gt 5" },
                    { 16, 0m, "No discount on premium Mac", "macbook pro 16" },
                    { 17, 100m, "Student back-to-school discount", "macbook air 15" },
                    { 18, 150m, "Creator laptop sale", "dell xps 15" },
                    { 19, 200m, "Business fleet promo", "thinkpad x1 carbon" },
                    { 20, 80m, "Ultrabook deal", "asus zenbook 14" },
                    { 21, 120m, "Convertible laptop offer", "hp spectre x360" },
                    { 22, 0m, "No discount on premium gaming", "razer blade 16" },
                    { 23, 50m, "Holiday special discount", "acer swift go 14" },
                    { 24, 180m, "Esports gaming discount", "lenovo legion pro 7" },
                    { 25, 0m, "No discount on new release", "alienware m16 r2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
