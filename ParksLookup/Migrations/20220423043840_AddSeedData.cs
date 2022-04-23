using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksLookup.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Activities", "Name", "ParkSystem", "State" },
                values: new object[,]
                {
                    { 1, "hiking, horseback riding, snowshoeing", "Yellowstone", "National", "Wyoming" },
                    { 2, "hiking, camping, astronomy", "Black Canyon of the Gunnison", "National", "Colorado" },
                    { 3, "hiking, sight-seeing, living history", "Staunton State Park", "State", "Colorado" },
                    { 4, "fishing, swimming, kayaking", "Huntsville State Park", "State", "Texas" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);
        }
    }
}
