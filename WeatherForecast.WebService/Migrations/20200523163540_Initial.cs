using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forecasts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: true),
                    StartForecast = table.Column<string>(nullable: true),
                    EndForecast = table.Column<string>(nullable: true),
                    TypeForecast = table.Column<string>(nullable: true),
                    MinTemperature = table.Column<int>(nullable: false),
                    MaxTemperature = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forecasts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "EndForecast", "MaxTemperature", "MinTemperature", "StartForecast", "TypeForecast" },
                values: new object[] { 1L, "10.02.2017 17:59:00", "11.02.2017 09:00:00 ", -2, -4, "10.02.2017 21:00:00", "двенадцатичасовой прогноз" });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "EndForecast", "MaxTemperature", "MinTemperature", "StartForecast", "TypeForecast" },
                values: new object[] { 2L, "29.06.2018 06:02:00", "29.06.2018 12:00:00", 29, 27, "29.06.2018 09:00:00", "трехчасовой прогноз" });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "EndForecast", "MaxTemperature", "MinTemperature", "StartForecast", "TypeForecast" },
                values: new object[] { 3L, "26.06.2018 05:54:00", "26.06.2018 12:00:00", 26, 24, "26.06.2018 09:00:00", "трехчасовой прогноз" });

            migrationBuilder.InsertData(
                table: "Forecasts",
                columns: new[] { "Id", "Date", "EndForecast", "MaxTemperature", "MinTemperature", "StartForecast", "TypeForecast" },
                values: new object[] { 4L, "28.06.2018 05:35:00", "28.06.2018 12:00:00", 29, 27, "28.06.2018 09:00:00", "трехчасовой прогноз" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forecasts");
        }
    }
}
