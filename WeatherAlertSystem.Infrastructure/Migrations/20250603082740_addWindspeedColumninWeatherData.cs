using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAlertSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addWindspeedColumninWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WindSpeed",
                table: "WeatherDatas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "WeatherDatas");
        }
    }
}
