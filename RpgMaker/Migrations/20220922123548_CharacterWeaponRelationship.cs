using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgMaker.Migrations
{
    public partial class CharacterWeaponRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Equipment_EquipmentId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapons_WeaponId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CharacterId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Character_EquipmentId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_WeaponId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Character");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CharacterId",
                table: "Inventory",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Character_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Character_CharacterId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CharacterId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Character",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CharacterId",
                table: "Inventory",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_EquipmentId",
                table: "Character",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_WeaponId",
                table: "Character",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Equipment_EquipmentId",
                table: "Character",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapons_WeaponId",
                table: "Character",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }
    }
}
