using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.whitelabel.data.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrders_Pizzas_PizzaId",
                table: "ItemOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemOrders_PizzaId",
                table: "ItemOrders");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "ItemOrders");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemOrderId",
                table: "Pizzas",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ItemOrderId",
                table: "Pizzas",
                column: "ItemOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_ItemOrders_ItemOrderId",
                table: "Pizzas",
                column: "ItemOrderId",
                principalTable: "ItemOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_ItemOrders_ItemOrderId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_ItemOrderId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ItemOrderId",
                table: "Pizzas");

            migrationBuilder.AddColumn<Guid>(
                name: "PizzaId",
                table: "ItemOrders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrders_PizzaId",
                table: "ItemOrders",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrders_Pizzas_PizzaId",
                table: "ItemOrders",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
