#nullable disable

using ElectricGamesApi.Logic.Models;
using ElectricGamesApi.Logic.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace ElectricGamesApi.Logic.Contexts;

public class ElectricGamesContext : DbContext
    {
        public ElectricGamesContext(DbContextOptions<ElectricGamesContext> options) : base(options){}
        public DbSet<Game> Game { get; set; }
        //public DbSet<CharacterGame> CharacterGame { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Location> Location { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Server=(localdb)\mssqllocaldb;Database=ElectricGamesApi;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Location>().ToTable("Location"); //, tablebuilder => tablebuilder.Property(p => p.GameId).HasColumnName("GameId")

            modelBuilder.Entity<Game>().HasKey(g => g.Id);
            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Location>().HasKey(l => l.Id);*/

            modelBuilder.Entity<Game>().Property(g => g.Platform).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

            modelBuilder.Entity<Game>().Property(g => g.Genre).HasConversion(
                v => v.ToString(),
                v => (GenreEnum)Enum.Parse(typeof(GenreEnum), v)
            );

            //modelBuilder.Entity<CharacterGame>().HasKey(cg => new { cg.CharacterId, cg.GameId });
            //modelBuilder.Entity<CharacterGame>().HasOne(cg => cg.Character).WithMany(c => c.Games).HasForeignKey(cg => cg.CharacterId);

            /*modelBuilder.Entity<Character>().Property(c => c.GameId).HasConversion(
                v => string.Join(',', v),
                v => (ICollection<int>)v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );*/

            //modelBuilder.Entity<Location>().Property<int?>("GameId");

            //modelBuilder.Entity<Location>().Property(l => l.GameId).HasColumnName("GameId");

            /*modelBuilder.Entity<Game>(
                g => { g
                    .HasMany(g => g.Characters)
                    .WithMany(c => c.Games).UsingEntity(e => e.ToTable("GameCharacter"));
                    //.HasForeignKey(c => c.GameId);
                }
            );*/

            /*modelBuilder.Entity<Game>(
                g => { g
                    .HasMany(g => g.Locations)
                    .WithOne(l => l.Game)
                    .HasForeignKey(l => l.GameId).HasPrincipalKey(g => g.Id);
                }
            );*/

            /*modelBuilder.Entity<Location>()
                .Navigation(l => l.Game)
                .UsePropertyAccessMode(PropertyAccessMode.Property);*/
            
            /*modelBuilder.Entity<Location>(
                l => { l
                    .HasOne(l => l.Game)
                    .WithMany(g => g.Locations)
                    //.IsRequired() - redudant
                    .HasForeignKey(l => l.GameId).HasPrincipalKey(g => g.Id);
                }
            );*/
            
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1001,
                    Title = "Batman: Arkham City",
                    Genre = GenreEnum.ActionAdventure,
                    Platform = new List<string>{"PlayStation 3", "Xbox 360", "Microsoft Windows"},
                    Developer = "Rocksteady Studios",
                    Publisher = "Warner Bros. Interactive Entertainment",
                    ReleaseDate = new DateOnly(2011, 10, 18),
                    Price = 19.99,
                    Rating = 9.0,
                    Description = "Batman: Arkham City is a 2011 action-adventure video game developed by Rocksteady Studios and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the sequel to the 2009 video game Batman: Arkham Asylum and the second game in the Batman: Arkham series. The game was released for the PlayStation 3 and Xbox 360 in October 2011, and for Microsoft Windows in November 2011. A remastered version of the game, subtitled Armored Edition, was released for PlayStation 4 and Xbox One in October 2016, and for Nintendo Switch in November 2017. The game is set two years after the events of Batman: Arkham Asylum, and follows Batman as he attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Batman through the game's three-dimensional environments, using his gadgets and fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.",
                    Image = "batman-arkham-city.jpeg"
                },
                new Game
                {
                    Id = 1002,
                    Title = "Bayonetta 2",
                    Genre = GenreEnum.ActionAdventure,
                    Platform = new List<string>{"Nintendo Switch"},
                    Developer = "PlatinumGames",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateOnly(2014, 10, 24),
                    Price = 19.99,
                    Rating = 8.5,
                    Description = "Bayonetta 2 is a 2014 action-adventure hack and slash video game developed by PlatinumGames and published by Nintendo for the Wii U. It is the sequel to the 2010 video game Bayonetta, and the second game in the Bayonetta series. The game was released in Japan on October 24, 2014, in North America on October 24, 2014, and in Europe on October 24, 2014. The game is set two years after the events of the first game, and follows the titular character Bayonetta as she attempts to stop the re-emergence of the criminal organization known as the Black Mask. The game features an open world environment and incorporates stealth elements. Players control Bayonetta through the game's three-dimensional environments, using her fighting abilities to defeat enemies. The game's story is told through cutscenes and voice-overs, and is based on the Batman: Arkham Asylum comic book series.",
                    Image = "bayonetta-2.webp"
                },
                new Game
                {
                    Id = 1003,
                    Title = "BioShock Infinite",
                    Genre = GenreEnum.Shooter,
                    Platform = new List<string>{"PlayStation 3", "Xbox 360", "Microsoft Windows"},
                    Developer = "Irrational Games",
                    Publisher = "2K Games",
                    ReleaseDate = new DateOnly(2013, 3, 26),
                    Price = 19.99,
                    Rating = 9.0,
                    Description = "BioShock Infinite is a 2013 first-person shooter video game developed by Irrational Games and published by 2K Games. It was released worldwide for the Microsoft Windows, PlayStation 3, and Xbox 360 platforms on March 26, 2013; an OS X port by Aspyr was later released on August 29, 2013 and a Linux port was released on March 17, 2014. BioShock Infinite is the third installment in the BioShock series, and was built using a modified version of the Unreal Engine 3. The game is set in 1912 in the fictional city of Columbia, and follows the story of former Pinkerton agent Booker DeWitt, who has been sent to the city...",
                    Image = "bioshock-infinite.jpeg"
                },
                new Game
                {
                    Id = 1004,
                    Title = "Celeste",
                    Genre = GenreEnum.Platformer,
                    Platform = new List<string>{"Nintendo Switch", "PlayStation 4", "Xbox One", "Microsoft Windows"},
                    Developer = "Matt Makes Games",
                    Publisher = "Matt Makes Games",
                    ReleaseDate = new DateOnly(2018, 1, 25),
                    Price = 19.99,
                    Rating = 9.0,
                    Description = "Celeste is a 2018 platform video game developed and published by Matt Makes Games. The game was released for Microsoft Windows, macOS, PlayStation 4, Xbox One, and Nintendo Switch on January 25, 2018. The game follows...",
                    Image = "celeste.png"
                },
                new Game
                {
                    Id = 1005,
                    Title = "Dark Souls",
                    Genre = GenreEnum.RolePlaying,
                    Platform = new List<string>{"PlayStation 3", "Xbox 360", "Microsoft Windows"},
                    Developer = "FromSoftware",
                    Publisher = "Namco Bandai Games",
                    ReleaseDate = new DateOnly(2011, 9, 22),
                    Price = 19.99,
                    Rating = 9.0,
                    Description = "Dark Souls is an action role-playing video game developed by FromSoftware and published by Namco Bandai Games. The game is the spiritual successor to FromSoftware's Demon's Souls, released in 2009. Dark Souls takes place in the fictional kingdom of Lordran, where players assume the role of a cursed undead character who begins a pilgrimage to discover the fate of their kind. The game is noted for its steep learning curve, nonlinear gameplay, and emphasis on player preparation and exploration. Dark Souls was released for Microsoft Windows, PlayStation 3, and Xbox 360 in 2011, and has since been ported to Linux, PlayStation 4, Xbox One, and Nintendo Switch. A remastered version of the game, titled Dark Souls: Remastered, was released for PlayStation 4, Xbox One, and Microsoft Windows in May 2018. A spiritual successor, titled Sekiro: Shadows Die Twice, was released in March 2019.",
                    Image = "dark-souls.jpeg"
                },
                new Game
                {
                    Id = 1006,
                    Title = "Death Stranding",
                    Genre = GenreEnum.Action,
                    Platform = new List<string>{"PlayStation 4"},
                    Developer = "Kojima Productions",
                    Publisher = "Sony Interactive Entertainment",
                    ReleaseDate = new DateOnly(2019, 11, 8),
                    Price = 19.99,
                    Rating = 9.0,
                    Description = "Death Stranding is an action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. The game was released worldwide on November 8, 2019. The game follows Sam Bridges, a delivery...",
                    Image = "death-stranding.jpeg"
                }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                    {
                        Id = 3001,
                        Name = "Batman",
                        Description = "Batman is a fictional superhero appearing in American comic books published by DC Comics. The character was created by artist Bob Kane and writer Bill Finger, and first appeared in Detective Comics #27 in 1939. Originally named the \"Bat-Man\", the character is also referred to by such epithets as the Caped Crusader, the Dark Knight, and the World's Greatest Detective. Batman's secret identity is Bruce Wayne, a wealthy American playboy, philanthropist, and owner of Wayne Enterprises. Batman resides in Gotham City, with assistance from various supporting characters, including his butler Alfred, police commissioner Jim Gordon, and vigilante allies such as Robin. Unlike most superheroes, Batman does not possess any superpowers; rather, he relies on his genius intellect, physical prowess, martial arts abilities, detective skills, science and technology, vast wealth, intimidation, and indomitable will. A large assortment of villains make up Batman's rogues gallery, including his archenemy, the Joker.",
                        Image = "batman.webp"
                    },
                new Character
                    {
                        Id = 3002,
                        Name = "Harley Quinn",
                        Description = "Harley Quinn is a fictional character appearing in American comic books published by DC Comics, commonly in association with the superhero Batman. The character was created by Paul Dini and Bruce Timm, and first appeared in Batman: The Animated Series. Harley Quinn is a psychiatrist at Arkham Asylum who falls in love with the Joker and becomes his partner in crime. She is known for her unpredictable nature and her ability to use weapons and explosives. She is also known for her signature red and black harlequin outfit, which she wears in the comics and in the...",
                        Image = "harley-quinn.webp"                       
                    },
                new Character
                    {
                        Id = 3003,
                        Name = "The Joker",
                        Description = "The Joker is a fictional supervillain created by Bill Finger, Bob Kane, and Jerry Robinson who first appeared in the debut issue of the comic book Batman (April 25, 1940) published by DC Comics. Originally named the \"Red Hood\", the character is also referred to by such epithets as the Crown Prince of Crime, the Clown Prince of Crime, the Dark Knight's Nemesis, and the Harlequin of Hate. He is considered one of the most infamous and dangerous criminals within Gotham City, and Batman's archenemy. The Joker is a master criminal with a clown-like appearance, and is considered one of the most infamous criminals within Gotham City. He has caused the death of several prominent Gotham City residents, including the Waynes, and has been responsible for the deaths of several prominent superheroes, including Green Arrow, Jason Todd, and Barbara Gordon. He is also responsible for the deaths of several prominent Gotham City police officers, including Harvey Bullock, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths of several prominent Gotham City gangsters, including Sal Maroni, and has been responsible for the deaths of several prominent Gotham City mobsters, including Carmine Falcone. He is also responsible for the deaths of several prominent Gotham City politicians, including Mayor Hamilton Hill, and has been responsible for the deaths of several prominent Gotham City businessmen, including Rupert Thorne. He is also responsible for the deaths...",
                        Image = "joker.webp"
                    },
                new Character
                    {
                        Id = 3004,
                        Name = "Bayonetta",
                        Description = "Description not available",
                        Image = "bayonetta.jpeg"
                    },
                new Character
                    {
                        Id = 3005,
                        Name = "Jeanne",
                        Description = "Description not available",
                        Image = "jeanne.jpeg"  
                    },
                new Character
                    {
                        Id = 3006,
                        Name = "Booker DeWitt",
                        Description = "Booker DeWitt is a fictional character and the protagonist of the 2013 first-person shooter video game BioShock Infinite. He is voiced by Troy Baker. Booker DeWitt is a former Pinkerton agent who is sent to the floating city of Columbia to rescue Elizabeth...",
                        Image = "booker-dewitt.webp"
                    },
                new Character
                    {
                        Id = 3007,
                        Name = "Elizabeth",
                        Description = "Elizabeth is a fictional character and the deuteragonist of the 2013 first-person shooter video game BioShock Infinite. She is voiced by Courtnee Draper. Elizabeth is a...",
                        Image = "elizabeth.webp"
                    },
                new Character
                    {
                        Id = 3008,
                        Name = "Madeline",
                        Description = "Madeline is the main protagonist of Celeste. She is a young...",
                        Image = "madeline.png"
                    },
                new Character
                    {
                        Id = 3009,
                        Name = "Gwyn, Lord of Cinder",
                        Description = "Gwyn, Lord of Cinder, is a character in the Dark Souls series. He is the final boss of Dark Souls and the first boss of Dark Souls III. He is the last of the Lords of Cinder, and the last of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.",
                        Image = "gwyn.webp"
                    },
                new Character
                    {
                        Id = 3010,
                        Name = "Solaire of Astora",
                        Description = "Solaire of Astora is a character in the Dark Souls series. He is a warrior of Astora who is known for his cheerful demeanor and his love of the sun. He is the first boss of Dark Souls and the first boss of Dark Souls III. He is the first of the Lords of Cinder, and the first of the ancient dragons. He is the father of Gwynevere, the brother of Gwyndolin, and the grandfather of Gwynevere's children, including Gwynevere's son, the player character of Dark Souls. He is also the father of the player character of Dark Souls.",
                        Image = "solaire.avif"
                    },
                new Character
                    {
                        Id = 3011,
                        Name = "Sam Bridges",
                        Description = "Sam Bridges is the main protagonist of Death Stranding.",
                        Image = "sam-bridges.webp"
                    }
            );

            /*modelBuilder.Entity<CharacterGame>().HasData(
                new CharacterGame
                    {
                        CharacterId = 3001,
                        GameId = 1001
                    },
                new CharacterGame
                    {
                        CharacterId = 3002,
                        GameId = 1001
                    },
                new CharacterGame
                    {
                        CharacterId = 3003,
                        GameId = 1001
                    },
                new CharacterGame
                    {
                        CharacterId = 3004,
                        GameId = 1002
                    },
                new CharacterGame
                    {
                        CharacterId = 3005,
                        GameId = 1002
                    },
                new CharacterGame
                    {
                        CharacterId = 3006,
                        GameId = 1003
                    },
                new CharacterGame
                    {
                        CharacterId = 3007,
                        GameId = 1003
                    },
                new CharacterGame
                    {
                        CharacterId = 3008,
                        GameId = 1004
                    },
                new CharacterGame
                    {
                        CharacterId = 3009,
                        GameId = 1005
                    },
                new CharacterGame
                    {
                        CharacterId = 3010,
                        GameId = 1005
                    },
                new CharacterGame
                    {
                        CharacterId = 3011,
                        GameId = 1006
                    }
            );*/

            modelBuilder.Entity<Location>().HasData(
                new Location
                    {
                        Id = 5001,
                        Name = "Arkham City",
                        Image = "arkham-city.avif",
                        GameId = 1001
                    },
                new Location
                    {
                        Id = 5002,
                        Name = "Gotham City",
                        Image = "gotham-city.jpeg",
                        GameId = 1001
                    },
                new Location
                    {
                        Id = 5003,
                        Name = "Heaven",
                        Image = "heaven.jpeg",
                        GameId = 1002
                    },
                new Location
                    {
                        Id = 5004,
                        Name = "Hell",
                        Image = "hell.webp",
                        GameId = 1002
                    },
                new Location
                    {
                        Id = 5005,
                        Name = "Columbia",
                        Image = "columbia.webp",
                        GameId = 1003
                    },
                new Location
                    {
                        Id = 5006,
                        Name = "Rapture",
                        Image = "rapture.jpeg",
                        GameId = 1003
                    },
                new Location
                    {
                        Id = 5007,
                        Name = "Celeste Mountain",
                        Image = "celeste-mountain.png",
                        GameId = 1004
                    },
                new Location
                    {
                        Id = 5008,
                        Name = "Lordran",
                        Image = "lordran.webp",
                        GameId = 1005
                    },
                new Location
                    {
                        Id = 5009,
                        Name = "Anor Londo",
                        Image = "anor-londo.webp",
                        GameId = 1005
                    },
                new Location
                    {
                        Id = 5010,
                        Name = "Bridges' Base",
                        Image = "bridges.jpeg",
                        GameId = 1006
                    }
            );

        }


    }