using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloggie.web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addingnormalizeduzername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13da635c-bdd6-47fd-a057-39f18e0c710b",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d225d1ae-ed59-4102-ab45-e28bd880424a", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEKPK14j4kQ4rnRRvKWdAb+bhA+vUGcWmUFiVytVBSNjPZGiVH8j9+tODi6L5HQWuEA==", "17efaa91-67de-4d39-b0e6-074c59c80f67" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13da635c-bdd6-47fd-a057-39f18e0c710b",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a45e69-6ac4-409e-a89c-eaceda855a65", null, null, "AQAAAAIAAYagAAAAEHlWLSBa87PDDdHb2wMC6tHMRYxvS1Bh3YfzF77ZX0Vy/vTPsiEGnJvyRU2mv/CYYQ==", "77758f3d-98b2-4ebd-a2da-be9f5cdd5e41" });
        }
    }
}
