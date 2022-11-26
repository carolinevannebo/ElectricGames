﻿// <auto-generated />
using System;
using ElectricGamesApi.Logic.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectricGamesApi.Migrations
{
    [DbContext(typeof(ElectricGamesContext))]
    partial class ElectricGamesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CharacterGame");
                });

            modelBuilder.Entity("ElectricGamesApi.Logic.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 3001,
                            Description = "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger, and first appeared in Detective Comics #27 in 1939. Originally named the \"Bat-Man\", the character is also referred to by such epithets as the Caped Crusader, the Dark Knight, and the World's Greatest Detective. Batman's secret identity is Bruce Wayne, a wealthy American playboy, philanthropist, and owner of Wayne Enterprises. Batman resides in Gotham City, with assistance from various supporting characters, including his butler Alfred, police commissioner Jim Gordon, and vigilante allies such as Robin. Unlike most superheroes, Batman does not possess any superpowers; rather, he relies on his genius intellect, physical prowess, martial arts abilities, detective skills, science and technology, vast wealth, intimidation, and indomitable will. A large assortment of villains make up Batman's rogues gallery, including his archenemy, the Joker.",
                            Image = "batman.webp",
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 3002,
                            Description = "Harley Quinn is a fictional character appearing in American comic books published by DC Comics, commonly in association with the superhero Batman. The character was created by Paul Dini and Bruce Timm, and first appeared in Batman: The Animated Series. Harley Quinn is a psychiatrist at Arkham Asylum who falls in love with the Joker and becomes his partner in crime. She is known for her unpredictable nature and her ability to use weapons and explosives. She is also known for her signature red and black harlequin outfit, which she wears in the comics and in the...",
                            Image = "harley-quinn.webp",
                            Name = "Harley Quinn"
                        },
                        new
                        {
                            Id = 3003,
                            Description = "The Joker is a fictional supervillain created by Bill Finger, Bob Kane, and Jerry Robinson who first appeared in the debut issue of the comic book Batman (April 25, 1940) published by DC Comics. Originally named the \"Red Hood\", the character is also referred to by such epithets as the Crown Prince of Crime, the Clown Prince of Crime, the Dark Knight's Nemesis, and the Harlequin of Hate. He is considered one of the most infamous and dangerous criminals within Gotham City, and Batman's archenemy. The Joker is a master criminal with a clown-like appearance, and is considered one of the most infamous criminals within Gotham City. He has caused the death of several prominent Gotham City residents, including the Waynes, and has been responsible for the deaths of several prominent superheroes, including Green Arrow, Jason Todd, and Barbara Gordon. He is also responsible for the deaths of several prominent Gotham City police officers, including Harvey Bullock, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths...",
                            Image = "joker.webp",
                            Name = "The Joker"
                        },
                        new
                        {
                            Id = 3004,
                            Description = "Description not available",
                            Image = "bayonetta.jpeg",
                            Name = "Bayonetta"
                        },
                        new
                        {
                            Id = 3005,
                            Description = "Description not available",
                            Image = "jeanne.jpeg",
                            Name = "Jeanne"
                        },
                        new
                        {
                            Id = 3006,
                            Description = "Booker DeWitt is a fictional character and the protagonist of the 2013 first-person shooter video game BioShock Infinite. He is voiced by Troy Baker. Booker DeWitt is a former Pinkerton agent who is sent to the floating city of Columbia to rescue Elizabeth...",
                            Image = "booker-dewitt.webp",
                            Name = "Booker DeWitt"
                        },
                        new
                        {
                            Id = 3007,
                            Description = "Elizabeth is a fictional character and the deuteragonist of the 2013 first-person shooter video game BioShock Infinite. She is voiced by Courtnee Draper. Elizabeth is a...",
                            Image = "elizabeth.webp",
                            Name = "Elizabeth"
                        },
                        new
                        {
                            Id = 3008,
                            Description = "Madeline is the main protagonist of Celeste. She is a young...",
                            Image = "madeline.png",
                            Name = "Madeline"
                        },
                        new
                        {
                            Id = 3009,
                            Description = "Gwyn, Lord of Cinder, is a character in the Dark Souls series. He is the final boss of Dark Souls and the first boss of Dark Souls III. He is the last of the Lords of Cinder, and the last of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.",
                            Image = "gwyn.webp",
                            Name = "Gwyn, Lord of Cinder"
                        },
                        new
                        {
                            Id = 3010,
                            Description = "Solaire of Astora is a character in the Dark Souls series. He is a warrior of Astora who is known for his cheerful demeanor and his love of the sun. He is the first boss of Dark Souls and the first boss of Dark Souls III. He is the first of the Lords of Cinder, and the first of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.",
                            Image = "solaire.avif",
                            Name = "Solaire of Astora"
                        },
                        new
                        {
                            Id = 3011,
                            Description = "Sam Bridges is the main protagonist of Death Stranding.",
                            Image = "sam-bridges.webp",
                            Name = "Sam Bridges"
                        });
                });

            modelBuilder.Entity("ElectricGamesApi.Logic.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Platform")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Description = "Batman: Arkham City is a 2011 action-adventure video game developed by Rocksteady Studios and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the sequel to the 2009 video game Batman: Arkham Asylum and the second game in the Batman: Arkham series. The game was released for the PlayStation 3 and Xbox 360 in October 2011, and for Microsoft Windows in November 2011. A remastered version of the game, subtitled Armored Edition, was released for PlayStation 4 and Xbox One in October 2016, and for Nintendo Switch in November 2017. The game is set two years after the events of Batman: Arkham Asylum, and follows Batman as he attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Batman through the game's three-dimensional environments, using his gadgets and fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.",
                            Developer = "Rocksteady Studios",
                            Genre = "ActionAdventure",
                            Image = "batman-arkham-city.jpeg",
                            Platform = "PlayStation 3,Xbox 360,Microsoft Windows",
                            Price = 19.989999999999998,
                            Publisher = "Warner Bros. Interactive Entertainment",
                            Rating = 9.0,
                            ReleaseDate = new DateOnly(2011, 10, 18),
                            Title = "Batman: Arkham City"
                        },
                        new
                        {
                            Id = 1002,
                            Description = "Bayonetta 2 is a 2014 action-adventure hack and slash video game developed by PlatinumGames and published by Nintendo for the Wii U. It is the sequel to the 2010 video game Bayonetta, and the second game in the Bayonetta series. The game was released in Japan on October 24, 2014, in North America on October 24, 2014, and in Europe on October 24, 2014. The game is set two years after the events of the first game, and follows the titular character Bayonetta as she attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Bayonetta through the game's three-dimensional environments, using her fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.",
                            Developer = "PlatinumGames",
                            Genre = "ActionAdventure",
                            Image = "bayonetta-2.webp",
                            Platform = "Nintendo Switch",
                            Price = 19.989999999999998,
                            Publisher = "Nintendo",
                            Rating = 8.5,
                            ReleaseDate = new DateOnly(2014, 10, 24),
                            Title = "Bayonetta 2"
                        },
                        new
                        {
                            Id = 1003,
                            Description = "BioShock Infinite is a 2013 first-person shooter video game developed by Irrational Games and published by 2K Games. It was released worldwide for the Microsoft Windows, PlayStation 3, and Xbox 360 platforms on March 26, 2013; an OS X port by Aspyr was later released on August 29, 2013 and a Linux port was released on March 17, 2014. BioShock Infinite is the third installment in the BioShock series, and was built using a modified version of the Unreal Engine 3. The game is set in 1912 in the fictional city of Columbia, and follows the story of former Pinkerton agent Booker DeWitt, who has been sent to the city...",
                            Developer = "Irrational Games",
                            Genre = "Shooter",
                            Image = "bioshock-infinite.jpeg",
                            Platform = "PlayStation 3,Xbox 360,Microsoft Windows",
                            Price = 19.989999999999998,
                            Publisher = "2K Games",
                            Rating = 9.0,
                            ReleaseDate = new DateOnly(2013, 3, 26),
                            Title = "BioShock Infinite"
                        },
                        new
                        {
                            Id = 1004,
                            Description = "Celeste is a 2018 platform video game developed and published by Matt Makes Games. The game was released for Microsoft Windows, macOS, PlayStation 4, Xbox One, and Nintendo Switch on January 25, 2018. The game follows...",
                            Developer = "Matt Makes Games",
                            Genre = "Platformer",
                            Image = "celeste.png",
                            Platform = "Nintendo Switch,PlayStation 4,Xbox One,Microsoft Windows",
                            Price = 19.989999999999998,
                            Publisher = "Matt Makes Games",
                            Rating = 9.0,
                            ReleaseDate = new DateOnly(2018, 1, 25),
                            Title = "Celeste"
                        },
                        new
                        {
                            Id = 1005,
                            Description = "Dark Souls is an action role-playing video game developed by FromSoftware and published by Namco Bandai Games. The game is the spiritual successor to FromSoftware's Demon's Souls, released in 2009. Dark Souls takes place in the fictional kingdom of Lordran, where players assume the role of a cursed undead character who begins a pilgrimage to discover the fate of their kind. The game is noted for its steep learning curve, nonlinear gameplay, and emphasis on player preparation and exploration. Dark Souls was released for Microsoft Windows, PlayStation 3, and Xbox 360 in 2011, and has since been ported to Linux, PlayStation 4, Xbox One, and Nintendo Switch. A remastered version of the game, titled Dark Souls: Remastered, was released for PlayStation 4, Xbox One, and Microsoft Windows in May 2018. A spiritual successor, titled Sekiro: Shadows Die Twice, was released in March 2019.",
                            Developer = "FromSoftware",
                            Genre = "RolePlaying",
                            Image = "dark-souls.jpeg",
                            Platform = "PlayStation 3,Xbox 360,Microsoft Windows",
                            Price = 19.989999999999998,
                            Publisher = "Namco Bandai Games",
                            Rating = 9.0,
                            ReleaseDate = new DateOnly(2011, 9, 22),
                            Title = "Dark Souls"
                        },
                        new
                        {
                            Id = 1006,
                            Description = "Death Stranding is an action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. The game was released worldwide on November 8, 2019. The game follows Sam Bridges, a delivery...",
                            Developer = "Kojima Productions",
                            Genre = "Action",
                            Image = "death-stranding.jpeg",
                            Platform = "PlayStation 4",
                            Price = 19.989999999999998,
                            Publisher = "Sony Interactive Entertainment",
                            Rating = 9.0,
                            ReleaseDate = new DateOnly(2019, 11, 8),
                            Title = "Death Stranding"
                        });
                });

            modelBuilder.Entity("ElectricGamesApi.Logic.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 5001,
                            GameId = 1001,
                            Image = "arkham-city.avif",
                            Name = "Arkham City"
                        },
                        new
                        {
                            Id = 5002,
                            GameId = 1001,
                            Image = "gotham-city.jpeg",
                            Name = "Gotham City"
                        },
                        new
                        {
                            Id = 5003,
                            GameId = 1002,
                            Image = "heaven.jpeg",
                            Name = "Heaven"
                        },
                        new
                        {
                            Id = 5004,
                            GameId = 1002,
                            Image = "hell.webp",
                            Name = "Hell"
                        },
                        new
                        {
                            Id = 5005,
                            GameId = 1003,
                            Image = "columbia.webp",
                            Name = "Columbia"
                        },
                        new
                        {
                            Id = 5006,
                            GameId = 1003,
                            Image = "rapture.jpeg",
                            Name = "Rapture"
                        },
                        new
                        {
                            Id = 5007,
                            GameId = 1004,
                            Image = "celeste-mountain.png",
                            Name = "Celeste Mountain"
                        },
                        new
                        {
                            Id = 5008,
                            GameId = 1005,
                            Image = "lordran.webp",
                            Name = "Lordran"
                        },
                        new
                        {
                            Id = 5009,
                            GameId = 1005,
                            Image = "anor-londo.webp",
                            Name = "Anor Londo"
                        },
                        new
                        {
                            Id = 5010,
                            GameId = 1006,
                            Image = "bridges.jpeg",
                            Name = "Bridges' Base"
                        });
                });

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.HasOne("ElectricGamesApi.Logic.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectricGamesApi.Logic.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElectricGamesApi.Logic.Models.Location", b =>
                {
                    b.HasOne("ElectricGamesApi.Logic.Models.Game", "Game")
                        .WithMany("Locations")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("ElectricGamesApi.Logic.Models.Game", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
