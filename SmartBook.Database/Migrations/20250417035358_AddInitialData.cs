using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBook.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Resources",
                            columns: new[] { "Id", "Name", "Description", "Type", "IsActive" },
                            values: new object[,]
                            {
                    { 1, "Meeting Room A", "Small meeting room for up to 4 people", "Room", true },
                    { 2, "Projector 1", "Standard HD projector", "Equipment", true },
                    { 3, "Conference Hall", "Large hall for events", "Room", true }
                                // Add more resource data here
                            });

            // Add more InsertData calls for other tables like Bookings and Users
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
