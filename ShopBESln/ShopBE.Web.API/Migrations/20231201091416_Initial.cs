using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopBE.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATNAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CATID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MAKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HOTEN = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    DCHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SODT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGSINH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGDK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOANHSO = table.Column<decimal>(type: "decimal(8,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MAKH);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MANV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HOTEN = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    SODT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGVL = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VITRI = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MANV);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(8,3)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    SOHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NGHD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MAKH = table.Column<int>(type: "int", nullable: false),
                    MANV = table.Column<int>(type: "int", nullable: false),
                    TRIGIA = table.Column<decimal>(type: "decimal(8,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.SOHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MAKH",
                        column: x => x.MAKH,
                        principalTable: "KhachHang",
                        principalColumn: "MAKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_MANV",
                        column: x => x.MANV,
                        principalTable: "NhanVien",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategorySanPham",
                columns: table => new
                {
                    CategoryCATID = table.Column<int>(type: "int", nullable: false),
                    SanPhamMaSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySanPham", x => new { x.CategoryCATID, x.SanPhamMaSP });
                    table.ForeignKey(
                        name: "FK_CategorySanPham_Category_CategoryCATID",
                        column: x => x.CategoryCATID,
                        principalTable: "Category",
                        principalColumn: "CATID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySanPham_SanPham_SanPhamMaSP",
                        column: x => x.SanPhamMaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTHD",
                columns: table => new
                {
                    SOHD = table.Column<int>(type: "int", nullable: false),
                    MASP = table.Column<int>(type: "int", nullable: false),
                    SL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHD", x => x.SOHD);
                    table.ForeignKey(
                        name: "FK_CTHD_HoaDon_SOHD",
                        column: x => x.SOHD,
                        principalTable: "HoaDon",
                        principalColumn: "SOHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CTHD_SanPham_MASP",
                        column: x => x.MASP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySanPham_SanPhamMaSP",
                table: "CategorySanPham",
                column: "SanPhamMaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTHD_MASP",
                table: "CTHD",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MAKH",
                table: "HoaDon",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MANV",
                table: "HoaDon",
                column: "MANV");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySanPham");

            migrationBuilder.DropTable(
                name: "CTHD");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");
        }
    }
}
