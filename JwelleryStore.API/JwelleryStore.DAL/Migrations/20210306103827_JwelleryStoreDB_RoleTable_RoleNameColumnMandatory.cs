using Microsoft.EntityFrameworkCore.Migrations;

namespace JwelleryStore.DAL.Migrations
{
    public partial class JwelleryStoreDB_RoleTable_RoleNameColumnMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoleName",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "DiscountPrice", "RoleName" },
                values: new object[] { 1, null, "Normal" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "DiscountPrice", "RoleName" },
                values: new object[] { 2, 2.0, "Privileged" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserDetailId", "FirstName", "LastName", "Password", "RoleId", "UserName" },
                values: new object[] { 1, "Normal", "User", "nu", 1, "normalUser" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "UserDetailId", "FirstName", "LastName", "Password", "RoleId", "UserName" },
                values: new object[] { 2, "Privileged", "User", "pu", 2, "privilegedUser" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoleName",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "UserDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserDetails",
                keyColumn: "UserDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_RoleName",
                table: "Roles",
                column: "RoleName",
                unique: true,
                filter: "[RoleName] IS NOT NULL");
        }
    }
}
