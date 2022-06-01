using Microsoft.EntityFrameworkCore.Migrations;

namespace dblibrary.Migrations
{
    public partial class webshopapi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    currencyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.currencyid);
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    deliveryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.deliveryid);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    paymentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    method = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.paymentid);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.productid);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "seller",
                columns: table => new
                {
                    sellerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seller", x => x.sellerid);
                    table.ForeignKey(
                        name: "FK_seller_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.userid);
                    table.ForeignKey(
                        name: "FK_address_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "currencyuser",
                columns: table => new
                {
                    currencyuserid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencyuser", x => x.currencyuserid);
                    table.ForeignKey(
                        name: "FK_currencyuser_currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "currency",
                        principalColumn: "currencyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_currencyuser_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    deliveryid = table.Column<int>(type: "int", nullable: false),
                    paymentid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderid);
                    table.ForeignKey(
                        name: "FK_orders_delivery_deliveryid",
                        column: x => x.deliveryid,
                        principalTable: "delivery",
                        principalColumn: "deliveryid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_payment_paymentid",
                        column: x => x.paymentid,
                        principalTable: "payment",
                        principalColumn: "paymentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_currencyuser_currencyid",
                table: "currencyuser",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_currencyuser_userid",
                table: "currencyuser",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_deliveryid",
                table: "orders",
                column: "deliveryid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_paymentid",
                table: "orders",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_productid",
                table: "orders",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userid",
                table: "orders",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_seller_productid",
                table: "seller",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "currencyuser");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "seller");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
