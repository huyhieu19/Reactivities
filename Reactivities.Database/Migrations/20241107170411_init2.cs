using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reactivities.Database.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("3d2ef631-317a-4a71-acec-82201625377f"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("4fc269f5-ff5c-476e-9963-b5316a021fcd"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("5aca97fb-fdf1-41b8-9670-7057a2cbea96"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("6259798f-918a-47b6-8212-2bdda16f914d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("802eaba1-7620-4aea-b0c6-331391ec7c91"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("893bb5db-3858-4650-9130-748d0369158d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a733997e-7553-4689-8181-de9deb4542c6"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c77427c1-646e-4044-980d-bd1bdd3ac8a3"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("f3e3f976-290b-4834-af00-4593bbc0721d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("fe183625-140f-479c-8e6d-443751880de6"));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "DateTime", "Description", "IsCancelled", "IsDeleted", "TimeDeleted", "Title", "Venue" },
                values: new object[,]
                {
                    { new Guid("14c65f35-217c-4448-a3cb-0d448afbcad4"), "travel", "Berlin", new DateTimeOffset(new DateTime(2025, 6, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(905), new TimeSpan(0, 0, 0, 0, 0)), "Activity 7 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 7", "All" },
                    { new Guid("456525fa-33bd-47ec-9486-6e3d1cd8ce9a"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 4, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(901), new TimeSpan(0, 0, 0, 0, 0)), "Activity 5 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 5", "Punch and Judy" },
                    { new Guid("7276816c-76bd-4703-9eb3-f4e3afe1af2e"), "music", "London", new DateTimeOffset(new DateTime(2025, 5, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(903), new TimeSpan(0, 0, 0, 0, 0)), "Activity 6 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 6", "O2 Arena" },
                    { new Guid("76a0c6c8-f94e-4a1b-90a5-7aeec2966f2e"), "food", "London", new DateTimeOffset(new DateTime(2025, 1, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(887), new TimeSpan(0, 0, 0, 0, 0)), "Activity 2 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 2", "Jamies Italian" },
                    { new Guid("7d2e42f8-3cf9-4940-becc-8cdf2d427c1d"), "culture", "London", new DateTimeOffset(new DateTime(2025, 3, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(899), new TimeSpan(0, 0, 0, 0, 0)), "Activity 4 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 4", "British Museum" },
                    { new Guid("89b00774-872f-4a7a-ac97-d06a363c24c2"), "music", "London", new DateTimeOffset(new DateTime(2024, 12, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(885), new TimeSpan(0, 0, 0, 0, 0)), "Activity 1 month in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 1", "Wembly Stadium" },
                    { new Guid("a0bb729e-88d5-4c89-92c0-294316163958"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 7, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(908), new TimeSpan(0, 0, 0, 0, 0)), "Activity 8 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 8", "Pub" },
                    { new Guid("b5b1e6fa-89b0-4485-a858-9c1bc49a7ce0"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 2, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 0, 0, 0, 0)), "Activity 3 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 3", "Pub" },
                    { new Guid("e184d569-2dac-4fc7-97a6-e7db28c575d6"), "culture", "Paris", new DateTimeOffset(new DateTime(2024, 10, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(882), new TimeSpan(0, 0, 0, 0, 0)), "Activity 1 month ago", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Past Activity 2", "The Louvre" },
                    { new Guid("fbf49c4f-741c-40ac-8837-651dd6c2ac32"), "drinks", "London", new DateTimeOffset(new DateTime(2024, 9, 7, 17, 4, 10, 977, DateTimeKind.Unspecified).AddTicks(863), new TimeSpan(0, 0, 0, 0, 0)), "Activity 2 months ago", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Past Activity 1", "Pub" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "RoleType" },
                values: new object[,]
                {
                    { new Guid("17ce571c-33df-49dd-ba34-a5d140d03fc4"), null, "Owner", "OWNER", 8 },
                    { new Guid("4685ebff-ad96-425c-81d1-6205760b84f6"), null, "Admin", "ADMIN", 4 },
                    { new Guid("aedd8ce6-a7a5-4b1f-a227-d81a80279c5f"), null, "Guest", "GUEST", 1 },
                    { new Guid("b9313020-bdb4-445a-bd58-52033c19dc7d"), null, "User", "USER", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleType",
                table: "Roles",
                column: "RoleType",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleType",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("14c65f35-217c-4448-a3cb-0d448afbcad4"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("456525fa-33bd-47ec-9486-6e3d1cd8ce9a"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7276816c-76bd-4703-9eb3-f4e3afe1af2e"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("76a0c6c8-f94e-4a1b-90a5-7aeec2966f2e"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7d2e42f8-3cf9-4940-becc-8cdf2d427c1d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("89b00774-872f-4a7a-ac97-d06a363c24c2"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("a0bb729e-88d5-4c89-92c0-294316163958"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("b5b1e6fa-89b0-4485-a858-9c1bc49a7ce0"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("e184d569-2dac-4fc7-97a6-e7db28c575d6"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("fbf49c4f-741c-40ac-8837-651dd6c2ac32"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("17ce571c-33df-49dd-ba34-a5d140d03fc4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4685ebff-ad96-425c-81d1-6205760b84f6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aedd8ce6-a7a5-4b1f-a227-d81a80279c5f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b9313020-bdb4-445a-bd58-52033c19dc7d"));

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "DateTime", "Description", "IsCancelled", "IsDeleted", "TimeDeleted", "Title", "Venue" },
                values: new object[,]
                {
                    { new Guid("3d2ef631-317a-4a71-acec-82201625377f"), "culture", "Paris", new DateTimeOffset(new DateTime(2024, 10, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2938), new TimeSpan(0, 0, 0, 0, 0)), "Activity 1 month ago", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Past Activity 2", "The Louvre" },
                    { new Guid("4fc269f5-ff5c-476e-9963-b5316a021fcd"), "culture", "London", new DateTimeOffset(new DateTime(2025, 3, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2960), new TimeSpan(0, 0, 0, 0, 0)), "Activity 4 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 4", "British Museum" },
                    { new Guid("5aca97fb-fdf1-41b8-9670-7057a2cbea96"), "music", "London", new DateTimeOffset(new DateTime(2025, 5, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2964), new TimeSpan(0, 0, 0, 0, 0)), "Activity 6 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 6", "O2 Arena" },
                    { new Guid("6259798f-918a-47b6-8212-2bdda16f914d"), "music", "London", new DateTimeOffset(new DateTime(2024, 12, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2950), new TimeSpan(0, 0, 0, 0, 0)), "Activity 1 month in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 1", "Wembly Stadium" },
                    { new Guid("802eaba1-7620-4aea-b0c6-331391ec7c91"), "travel", "Berlin", new DateTimeOffset(new DateTime(2025, 6, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2966), new TimeSpan(0, 0, 0, 0, 0)), "Activity 7 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 7", "All" },
                    { new Guid("893bb5db-3858-4650-9130-748d0369158d"), "food", "London", new DateTimeOffset(new DateTime(2025, 1, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2953), new TimeSpan(0, 0, 0, 0, 0)), "Activity 2 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 2", "Jamies Italian" },
                    { new Guid("a733997e-7553-4689-8181-de9deb4542c6"), "drinks", "London", new DateTimeOffset(new DateTime(2024, 9, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2919), new TimeSpan(0, 0, 0, 0, 0)), "Activity 2 months ago", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Past Activity 1", "Pub" },
                    { new Guid("c77427c1-646e-4044-980d-bd1bdd3ac8a3"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 2, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2956), new TimeSpan(0, 0, 0, 0, 0)), "Activity 3 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 3", "Pub" },
                    { new Guid("f3e3f976-290b-4834-af00-4593bbc0721d"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 7, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2969), new TimeSpan(0, 0, 0, 0, 0)), "Activity 8 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 8", "Pub" },
                    { new Guid("fe183625-140f-479c-8e6d-443751880de6"), "drinks", "London", new DateTimeOffset(new DateTime(2025, 4, 7, 16, 58, 29, 467, DateTimeKind.Unspecified).AddTicks(2962), new TimeSpan(0, 0, 0, 0, 0)), "Activity 5 months in future", false, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Future Activity 5", "Punch and Judy" }
                });
        }
    }
}
