using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialTrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "ArrivalTime", "BookingId", "DepartureTime", "FromCityId", "Price", "ToCityId" },
                values: new object[,]
                {
                    { 1, "12:30", null, "07:00", 1, 649m, 2 },
                    { 2, "18:30", null, "13:00", 1, 699m, 2 },
                    { 3, "12:30", null, "07:00", 2, 649m, 1 },
                    { 4, "18:30", null, "13:00", 2, 699m, 1 },
                    { 5, "13:30", null, "07:30", 2, 749m, 3 },
                    { 6, "21:00", null, "15:00", 2, 799m, 3 },
                    { 7, "13:30", null, "07:30", 3, 749m, 2 },
                    { 8, "21:00", null, "15:00", 3, 799m, 2 },
                    { 9, "11:30", null, "08:00", 3, 349m, 4 },
                    { 10, "18:00", null, "14:30", 3, 399m, 4 },
                    { 11, "11:30", null, "08:00", 4, 349m, 3 },
                    { 12, "18:00", null, "14:30", 4, 399m, 3 },
                    { 13, "11:45", null, "08:30", 4, 329m, 5 },
                    { 14, "17:15", null, "14:00", 4, 349m, 5 },
                    { 15, "11:45", null, "08:30", 5, 329m, 4 },
                    { 16, "17:15", null, "14:00", 5, 349m, 4 },
                    { 17, "12:45", null, "07:30", 1, 549m, 6 },
                    { 18, "18:45", null, "13:30", 1, 599m, 6 },
                    { 19, "12:45", null, "07:30", 6, 549m, 1 },
                    { 20, "18:45", null, "13:30", 6, 599m, 1 },
                    { 21, "10:45", null, "08:00", 6, 329m, 7 },
                    { 22, "17:45", null, "15:00", 6, 349m, 7 },
                    { 23, "10:45", null, "08:00", 7, 329m, 6 },
                    { 24, "17:45", null, "15:00", 7, 349m, 6 },
                    { 25, "14:30", null, "08:00", 1, 649m, 7 },
                    { 26, "19:00", null, "12:30", 1, 699m, 7 },
                    { 27, "14:30", null, "08:00", 7, 649m, 1 },
                    { 28, "19:00", null, "12:30", 7, 699m, 1 },
                    { 29, "10:45", null, "07:30", 2, 369m, 8 },
                    { 30, "17:15", null, "14:00", 2, 399m, 8 },
                    { 31, "10:45", null, "07:30", 8, 369m, 2 },
                    { 32, "17:15", null, "14:00", 8, 399m, 2 },
                    { 33, "11:00", null, "07:30", 6, 399m, 8 },
                    { 34, "17:30", null, "14:00", 6, 449m, 8 },
                    { 35, "11:00", null, "07:30", 8, 399m, 6 },
                    { 36, "17:30", null, "14:00", 8, 449m, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
