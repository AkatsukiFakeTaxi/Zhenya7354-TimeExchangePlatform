using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeExchangePlatform.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agreements_AspNetUsers_ProviderId",
                table: "agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_agreements_AspNetUsers_ReceiverId",
                table: "agreements");

            migrationBuilder.DropIndex(
                name: "IX_agreements_ProviderId",
                table: "agreements");

            migrationBuilder.DropIndex(
                name: "IX_agreements_ReceiverId",
                table: "agreements");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "agreements");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "agreements");

            migrationBuilder.CreateIndex(
                name: "IX_agreements_ProviderUserId",
                table: "agreements",
                column: "ProviderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_agreements_ReceiverUserId",
                table: "agreements",
                column: "ReceiverUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_agreements_AspNetUsers_ProviderUserId",
                table: "agreements",
                column: "ProviderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agreements_AspNetUsers_ReceiverUserId",
                table: "agreements",
                column: "ReceiverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agreements_AspNetUsers_ProviderUserId",
                table: "agreements");

            migrationBuilder.DropForeignKey(
                name: "FK_agreements_AspNetUsers_ReceiverUserId",
                table: "agreements");

            migrationBuilder.DropIndex(
                name: "IX_agreements_ProviderUserId",
                table: "agreements");

            migrationBuilder.DropIndex(
                name: "IX_agreements_ReceiverUserId",
                table: "agreements");

            migrationBuilder.AddColumn<string>(
                name: "ProviderId",
                table: "agreements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "agreements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_agreements_ProviderId",
                table: "agreements",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_agreements_ReceiverId",
                table: "agreements",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_agreements_AspNetUsers_ProviderId",
                table: "agreements",
                column: "ProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agreements_AspNetUsers_ReceiverId",
                table: "agreements",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
