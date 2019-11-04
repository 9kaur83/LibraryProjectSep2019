using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryProjectSep2019.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    IsbnNumber = table.Column<string>(nullable: false),
                    BookName = table.Column<string>(nullable: false),
                    IssuedUserID = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    BooksCategory = table.Column<int>(nullable: false),
                    ReplacementPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsbnNumber", x => x.IsbnNumber);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserIDOfCustomer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.UserIDOfCustomer);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TransactionType = table.Column<int>(nullable: false),
                    IsbnNumber = table.Column<string>(nullable: false),
                    UserIDOfCustomer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_Books_IsbnNumber",
                        column: x => x.IsbnNumber,
                        principalTable: "Books",
                        principalColumn: "IsbnNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_Customers_UserIDOfCustomer",
                        column: x => x.UserIDOfCustomer,
                        principalTable: "Customers",
                        principalColumn: "UserIDOfCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_IsbnNumber",
                table: "transactions",
                column: "IsbnNumber");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_UserIDOfCustomer",
                table: "transactions",
                column: "UserIDOfCustomer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
