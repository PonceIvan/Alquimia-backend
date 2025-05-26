using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendAlquimia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Intensities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intensities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OlfactoryFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlfactoryFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OlfactoryPyramid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlfactoryPyramid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Option1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyCompatibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Familia1Id = table.Column<int>(type: "int", nullable: false),
                    Familia2Id = table.Column<int>(type: "int", nullable: false),
                    GradoDeCompatibilidad = table.Column<int>(type: "int", nullable: false),
                    FamiliaMenor = table.Column<int>(type: "int", nullable: false, computedColumnSql: "(case when [Familia1Id]<[Familia2Id] then [Familia1Id] else [Familia2Id] end)", stored: true),
                    FamiliaMayor = table.Column<int>(type: "int", nullable: false, computedColumnSql: "(case when [Familia1Id]<[Familia2Id] then [Familia2Id] else [Familia1Id] end)", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompatibilidadesFamilias_FamiliasOlfativas_Familia1Id",
                        column: x => x.Familia1Id,
                        principalTable: "OlfactoryFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompatibilidadesFamilias_FamiliasOlfativas_Familia2Id",
                        column: x => x.Familia2Id,
                        principalTable: "OlfactoryFamilies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FamiliaOlfativaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PiramideOlfativaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notasFamiliaOlfativa",
                        column: x => x.FamiliaOlfativaId,
                        principalTable: "OlfactoryFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notasPiramideOlfativa",
                        column: x => x.PiramideOlfativaId,
                        principalTable: "OlfactoryPyramid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IdOpciones = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsOptions",
                        column: x => x.IdOpciones,
                        principalTable: "Options",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Subscription",
                        column: x => x.IdEstado,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormulaNote",
                columns: table => new
                {
                    FormulaNotaId = table.Column<int>(type: "int", nullable: false),
                    PiramideOlfativaId = table.Column<int>(type: "int", nullable: true),
                    NotaId1 = table.Column<int>(type: "int", nullable: false),
                    NotaId2 = table.Column<int>(type: "int", nullable: true),
                    NotaId3 = table.Column<int>(type: "int", nullable: true),
                    NotaId4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaNote", x => x.FormulaNotaId);
                    table.ForeignKey(
                        name: "FK_nota1",
                        column: x => x.NotaId1,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nota2",
                        column: x => x.NotaId2,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nota3",
                        column: x => x.NotaId3,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_nota4",
                        column: x => x.NotaId4,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_piramideOlfativa",
                        column: x => x.PiramideOlfativaId,
                        principalTable: "OlfactoryPyramid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IncompatibleNotes",
                columns: table => new
                {
                    NotaId = table.Column<int>(type: "int", nullable: false),
                    NotaIncompatibleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Incompat__06842A27C29444C3", x => new { x.NotaId, x.NotaIncompatibleId });
                    table.ForeignKey(
                        name: "FK_NotaIncompatible_nota",
                        column: x => x.NotaId,
                        principalTable: "Notes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotaIncompatible_notaIncompatible",
                        column: x => x.NotaIncompatibleId,
                        principalTable: "Notes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizPreguntas",
                        column: x => x.IdPregunta,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductoId = table.Column<int>(type: "int", nullable: true),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Shape = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LabelColor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Typography = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TextColor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.Id);
                    table.ForeignKey(
                        name: "FK_design_ProductTypes",
                        column: x => x.TipoProductoId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinalEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true),
                    DesignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadFinal_Design",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Formulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormulaCorazon = table.Column<int>(type: "int", nullable: false),
                    FormulaSalida = table.Column<int>(type: "int", nullable: false),
                    FormulaFondo = table.Column<int>(type: "int", nullable: false),
                    IntensidadId = table.Column<int>(type: "int", nullable: false),
                    ConcentracionAlcohol = table.Column<double>(type: "float", nullable: false),
                    ConcentracionAgua = table.Column<double>(type: "float", nullable: false),
                    ConcentracionEsencia = table.Column<double>(type: "float", nullable: false),
                    CreadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulas_corazon",
                        column: x => x.FormulaCorazon,
                        principalTable: "FormulaNote",
                        principalColumn: "FormulaNotaId");
                    table.ForeignKey(
                        name: "FK_Formulas_fondo",
                        column: x => x.FormulaFondo,
                        principalTable: "FormulaNote",
                        principalColumn: "FormulaNotaId");
                    table.ForeignKey(
                        name: "FK_Formulas_intensidad",
                        column: x => x.IntensidadId,
                        principalTable: "Intensities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formulas_salida",
                        column: x => x.FormulaSalida,
                        principalTable: "FormulaNote",
                        principalColumn: "FormulaNotaId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    IdFormulas = table.Column<int>(type: "int", nullable: true),
                    IdQuiz = table.Column<int>(type: "int", nullable: true),
                    IdSuscripcion = table.Column<int>(type: "int", nullable: true),
                    EsProveedor = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estado_Users",
                        column: x => x.IdEstado,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_formulas_Users",
                        column: x => x.IdFormulas,
                        principalTable: "Formulas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_quiz_Users",
                        column: x => x.IdQuiz,
                        principalTable: "Quiz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_suscripcion_Users",
                        column: x => x.IdSuscripcion,
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedidosEstado",
                        column: x => x.EstadoId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_pedido_usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProductoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes",
                        column: x => x.TipoProductoId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productIdProv",
                        column: x => x.IdProveedor,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productIdUser",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProviderReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProviderReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_opinionProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_opinionUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    PedidoProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: true),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.PedidoProductoId);
                    table.ForeignKey(
                        name: "FK_pedidoIdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pedidoProductoId",
                        column: x => x.ProductosId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_opinionUsuario_producto",
                        column: x => x.IdUsuario,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_opinion_ProductoId",
                        column: x => x.IdProducto,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_producto",
                        column: x => x.ProductoId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProducts_usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_IdProducto",
                table: "Design",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Design_TipoProductoId",
                table: "Design",
                column: "TipoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilidadesFamilias_Familia1Id",
                table: "FamilyCompatibilities",
                column: "Familia1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilidadesFamilias_Familia2Id",
                table: "FamilyCompatibilities",
                column: "Familia2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Compatibilities",
                table: "FamilyCompatibilities",
                columns: new[] { "FamiliaMenor", "FamiliaMayor" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinalEntity_DesignId",
                table: "FinalEntity",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalEntity_IdUsuario",
                table: "FinalEntity",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_FinalEntity_ProductosId",
                table: "FinalEntity",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaNote_NotaId1",
                table: "FormulaNote",
                column: "NotaId1");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaNote_NotaId2",
                table: "FormulaNote",
                column: "NotaId2");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaNote_NotaId3",
                table: "FormulaNote",
                column: "NotaId3");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaNote_NotaId4",
                table: "FormulaNote",
                column: "NotaId4");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaNote_PiramideOlfativaId",
                table: "FormulaNote",
                column: "PiramideOlfativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_CreadorId",
                table: "Formulas",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_FormulaCorazon",
                table: "Formulas",
                column: "FormulaCorazon");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_FormulaFondo",
                table: "Formulas",
                column: "FormulaFondo");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_FormulaSalida",
                table: "Formulas",
                column: "FormulaSalida");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_IntensidadId",
                table: "Formulas",
                column: "IntensidadId");

            migrationBuilder.CreateIndex(
                name: "IX_IncompatibleNotes_NotaIncompatibleId",
                table: "IncompatibleNotes",
                column: "NotaIncompatibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_FamiliaOlfativaId",
                table: "Notes",
                column: "FamiliaOlfativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_PiramideOlfativaId",
                table: "Notes",
                column: "PiramideOlfativaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_IdPedido",
                table: "OrderProduct",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProducto_ProductosId",
                table: "OrderProduct",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EstadoId",
                table: "Orders",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsuarioId",
                table: "Orders",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdProveedor",
                table: "Products",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Products",
                column: "TipoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioId",
                table: "Products",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdOpciones",
                table: "Questions",
                column: "IdOpciones");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_IdPregunta",
                table: "Quiz",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_IdEstado",
                table: "Subscription",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductReviews_IdProducto",
                table: "UserProductReviews",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductReviews_IdUsuario",
                table: "UserProductReviews",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductoId",
                table: "UserProducts",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UsuarioId",
                table: "UserProducts",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProviderReviews_IdProveedor",
                table: "UserProviderReviews",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_UserProviderReviews_IdUsuario",
                table: "UserProviderReviews",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdEstado",
                table: "Users",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdFormulas",
                table: "Users",
                column: "IdFormulas");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdQuiz",
                table: "Users",
                column: "IdQuiz");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdSuscripcion",
                table: "Users",
                column: "IdSuscripcion");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Usuarios_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Usuarios_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Usuarios_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Usuarios_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_design_productId",
                table: "Design",
                column: "IdProducto",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadFinal_IdUsuario",
                table: "FinalEntity",
                column: "IdUsuario",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadFinal_ProductoId",
                table: "FinalEntity",
                column: "ProductosId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Usuarios_CreadorId",
                table: "Formulas",
                column: "CreadorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Usuarios_CreadorId",
                table: "Formulas");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FamilyCompatibilities");

            migrationBuilder.DropTable(
                name: "FinalEntity");

            migrationBuilder.DropTable(
                name: "IncompatibleNotes");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "UserProductReviews");

            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "UserProviderReviews");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Formulas");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "FormulaNote");

            migrationBuilder.DropTable(
                name: "Intensities");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "OlfactoryFamilies");

            migrationBuilder.DropTable(
                name: "OlfactoryPyramid");
        }
    }
}
