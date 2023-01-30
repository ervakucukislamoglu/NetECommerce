using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetECommerce.DAL.Migrations
{
    public partial class productadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CreatedComputerName", "CreatedDate", "CreatedIpAddress", "Description", "ImagePath", "IsActive", "MasterID", "ProductName", "Status", "UnitPrice", "UnitsInStock", "UpdatedComputerName", "UpdatedDate", "UpdatedIpAddress" },
                values: new object[] { 1, null, new DateTime(2023, 1, 30, 12, 42, 55, 12, DateTimeKind.Local).AddTicks(2679), null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas ornare ex non erat dapibus congue. Curabitur ullamcorper vitae tortor vitae pharetra.", "https://www.slntechnologies.com/wp-content/uploads/2017/08/ef3-placeholder-image.jpg", true, new Guid("00000000-0000-0000-0000-000000000000"), "Chai", 1, 18m, (short)500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
