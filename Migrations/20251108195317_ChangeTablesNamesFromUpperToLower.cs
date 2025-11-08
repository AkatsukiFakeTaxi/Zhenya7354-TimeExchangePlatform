using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeExchangePlatform.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablesNamesFromUpperToLower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Offers_OfferId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Users_ProviderId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Users_ReceiverId",
                table: "Exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_ReviewedUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_ReviewerUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exchanges",
                table: "Exchanges");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "skills");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "reviews");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "requests");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "offers");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Exchanges",
                newName: "exchanges");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_UserId",
                table: "skills",
                newName: "IX_skills_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerUserId",
                table: "reviews",
                newName: "IX_reviews_ReviewerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewedUserId",
                table: "reviews",
                newName: "IX_reviews_ReviewedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_UserId",
                table: "requests",
                newName: "IX_requests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "offers",
                newName: "IX_offers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Exchanges_ReceiverId",
                table: "exchanges",
                newName: "IX_exchanges_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Exchanges_ProviderId",
                table: "exchanges",
                newName: "IX_exchanges_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_Exchanges_OfferId",
                table: "exchanges",
                newName: "IX_exchanges_OfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skills",
                table: "skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviews",
                table: "reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requests",
                table: "requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_offers",
                table: "offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_exchanges_offers_OfferId",
                table: "exchanges",
                column: "OfferId",
                principalTable: "offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exchanges_users_ProviderId",
                table: "exchanges",
                column: "ProviderId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_exchanges_users_ReceiverId",
                table: "exchanges",
                column: "ReceiverId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_offers_users_UserId",
                table: "offers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_ReviewedUserId",
                table: "reviews",
                column: "ReviewedUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_ReviewerUserId",
                table: "reviews",
                column: "ReviewerUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_skills_users_UserId",
                table: "skills",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exchanges_offers_OfferId",
                table: "exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_exchanges_users_ProviderId",
                table: "exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_exchanges_users_ReceiverId",
                table: "exchanges");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_offers_users_UserId",
                table: "offers");

            migrationBuilder.DropForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_ReviewedUserId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_ReviewerUserId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_skills_users_UserId",
                table: "skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skills",
                table: "skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requests",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_offers",
                table: "offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exchanges",
                table: "exchanges");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "skills",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "reviews",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "requests",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "offers",
                newName: "Offers");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "exchanges",
                newName: "Exchanges");

            migrationBuilder.RenameIndex(
                name: "IX_skills_UserId",
                table: "Skills",
                newName: "IX_Skills_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_ReviewerUserId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_ReviewedUserId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_requests_UserId",
                table: "Requests",
                newName: "IX_Requests_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_offers_UserId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_exchanges_ReceiverId",
                table: "Exchanges",
                newName: "IX_Exchanges_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_exchanges_ProviderId",
                table: "Exchanges",
                newName: "IX_Exchanges_ProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_exchanges_OfferId",
                table: "Exchanges",
                newName: "IX_Exchanges_OfferId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exchanges",
                table: "Exchanges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Offers_OfferId",
                table: "Exchanges",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Users_ProviderId",
                table: "Exchanges",
                column: "ProviderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Users_ReceiverId",
                table: "Exchanges",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserId",
                table: "Requests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_ReviewedUserId",
                table: "Reviews",
                column: "ReviewedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_ReviewerUserId",
                table: "Reviews",
                column: "ReviewerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Users_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
