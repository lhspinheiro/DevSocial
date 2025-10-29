using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSocial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class loggedUserIdIntoReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddForeignKey(
                name: "FK_Replys_Users_UserId",
                table: "Replys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Replys");
        }
    }
}
