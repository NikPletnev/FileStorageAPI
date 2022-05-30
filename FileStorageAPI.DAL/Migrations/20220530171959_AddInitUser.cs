using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileStorageAPI.DAL.Migrations
{
    public partial class AddInitUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsDeleted", "Name", "Password" },
                values: new object[] { 1, false, "Test", "1000:R/4LvuC7c2NZWrLyYB8dMb/zLcbmIOR+:tyM5iL0S1QoFEX+KcG52rq+PESs=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
