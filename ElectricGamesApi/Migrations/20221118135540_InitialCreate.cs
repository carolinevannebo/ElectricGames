using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectricGamesApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Platform = table.Column<string>(type: "TEXT", nullable: true),
                    Developer = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterGame",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterGame", x => new { x.CharactersId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CharacterGame_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterGame_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 3001, "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger, and first appeared in Detective Comics #27 in 1939. Originally named the \"Bat-Man\", the character is also referred to by such epithets as the Caped Crusader, the Dark Knight, and the World's Greatest Detective. Batman's secret identity is Bruce Wayne, a wealthy American playboy, philanthropist, and owner of Wayne Enterprises. Batman resides in Gotham City, with assistance from various supporting characters, including his butler Alfred, police commissioner Jim Gordon, and vigilante allies such as Robin. Unlike most superheroes, Batman does not possess any superpowers; rather, he relies on his genius intellect, physical prowess, martial arts abilities, detective skills, science and technology, vast wealth, intimidation, and indomitable will. A large assortment of villains make up Batman's rogues gallery, including his archenemy, the Joker.", "batman.webp", "Batman" },
                    { 3002, "Harley Quinn is a fictional character appearing in American comic books published by DC Comics, commonly in association with the superhero Batman. The character was created by Paul Dini and Bruce Timm, and first appeared in Batman: The Animated Series. Harley Quinn is a psychiatrist at Arkham Asylum who falls in love with the Joker and becomes his partner in crime. She is known for her unpredictable nature and her ability to use weapons and explosives. She is also known for her signature red and black harlequin outfit, which she wears in the comics and in the...", "harley-quinn.webp", "Harley Quinn" },
                    { 3003, "The Joker is a fictional supervillain created by Bill Finger, Bob Kane, and Jerry Robinson who first appeared in the debut issue of the comic book Batman (April 25, 1940) published by DC Comics. Originally named the \"Red Hood\", the character is also referred to by such epithets as the Crown Prince of Crime, the Clown Prince of Crime, the Dark Knight's Nemesis, and the Harlequin of Hate. He is considered one of the most infamous and dangerous criminals within Gotham City, and Batman's archenemy. The Joker is a master criminal with a clown-like appearance, and is considered one of the most infamous criminals within Gotham City. He has caused the death of several prominent Gotham City residents, including the Waynes, and has been responsible for the deaths of several prominent superheroes, including Green Arrow, Jason Todd, and Barbara Gordon. He is also responsible for the deaths of several prominent Gotham City police officers, including Harvey Bullock, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths...", "joker.webp", "The Joker" },
                    { 3004, "Description not available", "bayonetta.jpeg", "Bayonetta" },
                    { 3005, "Description not available", "jeanne.jpeg", "Jeanne" },
                    { 3006, "Booker DeWitt is a fictional character and the protagonist of the 2013 first-person shooter video game BioShock Infinite. He is voiced by Troy Baker. Booker DeWitt is a former Pinkerton agent who is sent to the floating city of Columbia to rescue Elizabeth...", "booker-dewitt.webp", "Booker DeWitt" },
                    { 3007, "Elizabeth is a fictional character and the deuteragonist of the 2013 first-person shooter video game BioShock Infinite. She is voiced by Courtnee Draper. Elizabeth is a...", "elizabeth.webp", "Elizabeth" },
                    { 3008, "Madeline is the main protagonist of Celeste. She is a young...", "madeline.png", "Madeline" },
                    { 3009, "Gwyn, Lord of Cinder, is a character in the Dark Souls series. He is the final boss of Dark Souls and the first boss of Dark Souls III. He is the last of the Lords of Cinder, and the last of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.", "gwyn.webp", "Gwyn, Lord of Cinder" },
                    { 3010, "Solaire of Astora is a character in the Dark Souls series. He is a warrior of Astora who is known for his cheerful demeanor and his love of the sun. He is the first boss of Dark Souls and the first boss of Dark Souls III. He is the first of the Lords of Cinder, and the first of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.", "solaire.avif", "Solaire of Astora" },
                    { 3011, "Sam Bridges is the main protagonist of Death Stranding.", "sam-bridges.webp", "Sam Bridges" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "Developer", "Genre", "Image", "Platform", "Price", "Publisher", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1001, "Batman: Arkham City is a 2011 action-adventure video game developed by Rocksteady Studios and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the sequel to the 2009 video game Batman: Arkham Asylum and the second game in the Batman: Arkham series. The game was released for the PlayStation 3 and Xbox 360 in October 2011, and for Microsoft Windows in November 2011. A remastered version of the game, subtitled Armored Edition, was released for PlayStation 4 and Xbox One in October 2016, and for Nintendo Switch in November 2017. The game is set two years after the events of Batman: Arkham Asylum, and follows Batman as he attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Batman through the game's three-dimensional environments, using his gadgets and fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.", "Rocksteady Studios", 1, "batman-arkham-city.jpeg", "PlayStation 3,Xbox 360,Microsoft Windows", 19.989999999999998, "Warner Bros. Interactive Entertainment", 9.0, new DateOnly(2011, 10, 18), "Batman: Arkham City" },
                    { 1002, "Bayonetta 2 is a 2014 action-adventure hack and slash video game developed by PlatinumGames and published by Nintendo for the Wii U. It is the sequel to the 2010 video game Bayonetta, and the second game in the Bayonetta series. The game was released in Japan on October 24, 2014, in North America on October 24, 2014, and in Europe on October 24, 2014. The game is set two years after the events of the first game, and follows the titular character Bayonetta as she attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Bayonetta through the game's three-dimensional environments, using her fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.", "PlatinumGames", 1, "bayonetta-2.webp", "Nintendo Switch", 19.989999999999998, "Nintendo", 8.5, new DateOnly(2014, 10, 24), "Bayonetta 2" },
                    { 1003, "BioShock Infinite is a 2013 first-person shooter video game developed by Irrational Games and published by 2K Games. It was released worldwide for the Microsoft Windows, PlayStation 3, and Xbox 360 platforms on March 26, 2013; an OS X port by Aspyr was later released on August 29, 2013 and a Linux port was released on March 17, 2014. BioShock Infinite is the third installment in the BioShock series, and was built using a modified version of the Unreal Engine 3. The game is set in 1912 in the fictional city of Columbia, and follows the story of former Pinkerton agent Booker DeWitt, who has been sent to the city...", "Irrational Games", 11, "bioshock-infinite.jpeg", "PlayStation 3,Xbox 360,Microsoft Windows", 19.989999999999998, "2K Games", 9.0, new DateOnly(2013, 3, 26), "BioShock Infinite" },
                    { 1004, "Celeste is a 2018 platform video game developed and published by Matt Makes Games. The game was released for Microsoft Windows, macOS, PlayStation 4, Xbox One, and Nintendo Switch on January 25, 2018. The game follows...", "Matt Makes Games", 6, "celeste.png", "Nintendo Switch,PlayStation 4,Xbox One,Microsoft Windows", 19.989999999999998, "Matt Makes Games", 9.0, new DateOnly(2018, 1, 25), "Celeste" },
                    { 1005, "Dark Souls is an action role-playing video game developed by FromSoftware and published by Namco Bandai Games. The game is the spiritual successor to FromSoftware's Demon's Souls, released in 2009. Dark Souls takes place in the fictional kingdom of Lordran, where players assume the role of a cursed undead character who begins a pilgrimage to discover the fate of their kind. The game is noted for its steep learning curve, nonlinear gameplay, and emphasis on player preparation and exploration. Dark Souls was released for Microsoft Windows, PlayStation 3, and Xbox 360 in 2011, and has since been ported to Linux, PlayStation 4, Xbox One, and Nintendo Switch. A remastered version of the game, titled Dark Souls: Remastered, was released for PlayStation 4, Xbox One, and Microsoft Windows in May 2018. A spiritual successor, titled Sekiro: Shadows Die Twice, was released in March 2019.", "FromSoftware", 9, "dark-souls.jpeg", "PlayStation 3,Xbox 360,Microsoft Windows", 19.989999999999998, "Namco Bandai Games", 9.0, new DateOnly(2011, 9, 22), "Dark Souls" },
                    { 1006, "Death Stranding is an action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. The game was released worldwide on November 8, 2019. The game follows Sam Bridges, a delivery...", "Kojima Productions", 0, "death-stranding.jpeg", "PlayStation 4", 19.989999999999998, "Sony Interactive Entertainment", 9.0, new DateOnly(2019, 11, 8), "Death Stranding" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "GameId", "Image", "Name" },
                values: new object[,]
                {
                    { 5001, 1001, "arkham-city.avif", "Arkham City" },
                    { 5002, 1001, "gotham-city.jpeg", "Gotham City" },
                    { 5003, 1002, "heaven.jpeg", "Heaven" },
                    { 5004, 1002, "hell.webp", "Hell" },
                    { 5005, 1003, "columbia.webp", "Columbia" },
                    { 5006, 1003, "rapture.jpeg", "Rapture" },
                    { 5007, 1004, "celeste-mountain.png", "Celeste Mountain" },
                    { 5008, 1005, "lordran.webp", "Lordran" },
                    { 5009, 1005, "anor-londo.webp", "Anor Londo" },
                    { 5010, 1006, "bridges.jpeg", "Bridges' Base" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterGame_GamesId",
                table: "CharacterGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_GameId",
                table: "Location",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterGame");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
