using FirstGameStore.Api.Dtos;

namespace FirstGameStore.Api.Data;

public static class GameData
{
    public static readonly IReadOnlyList<GamesDto> Games =
    [
        new GamesDto(1,  "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99m, new DateOnly(2017, 3,  3)),
        new GamesDto(2,  "Red Dead Redemption 2",                   "Action-Adventure", 59.99m, new DateOnly(2018, 10, 26)),
        new GamesDto(3,  "The Witcher 3: Wild Hunt",                "RPG",              39.99m, new DateOnly(2015, 5,  19)),
        new GamesDto(4,  "Cyberpunk 2077",                          "RPG",              59.99m, new DateOnly(2020, 12, 10)),
        new GamesDto(5,  "Minecraft",                               "Sandbox",          26.95m, new DateOnly(2011, 11, 18)),
        new GamesDto(6,  "Fortnite",                                "Battle Royale",     0.00m, new DateOnly(2017, 7,  21)),
        new GamesDto(7,  "Among Us",                                "Party",             4.99m, new DateOnly(2018, 6,  15)),
        new GamesDto(8,  "Elden Ring",                              "Action-RPG",       59.99m, new DateOnly(2022, 2,  25)),
        new GamesDto(9,  "Hogwarts Legacy",                         "Action-Adventure", 59.99m, new DateOnly(2023, 2,  10)),
        new GamesDto(10, "Starfield",                               "Action-RPG",       69.99m, new DateOnly(2023, 9,  6)),
        new GamesDto(11, "Baldur's Gate 3",                         "RPG",              59.99m, new DateOnly(2023, 8,  3)),
        new GamesDto(12, "Palworld",                                "Action-Adventure", 29.99m, new DateOnly(2024, 1,  19)),
        new GamesDto(13, "Dragon Age: Inquisition",                 "RPG",              39.99m, new DateOnly(2014, 11, 18)),
        new GamesDto(14, "Mass Effect Legendary Edition",           "Action-RPG",       59.99m, new DateOnly(2021, 5,  14)),
        new GamesDto(15, "Fallout 4",                               "Action-RPG",       39.99m, new DateOnly(2015, 11, 10)),
        new GamesDto(16, "Skyrim",                                  "Action-RPG",       39.99m, new DateOnly(2011, 11, 11)),
        new GamesDto(17, "GTA V",                                   "Action-Adventure", 49.99m, new DateOnly(2013, 9,  17)),
        new GamesDto(18, "Halo Infinite",                           "FPS",              59.99m, new DateOnly(2021, 12, 8)),
        new GamesDto(19, "Call of Duty: Modern Warfare III",        "FPS",              69.99m, new DateOnly(2023, 11, 10)),
        new GamesDto(20, "Destiny 2",                               "FPS",               0.00m, new DateOnly(2017, 9,  6)),
        new GamesDto(21, "Overwatch 2",                             "FPS",               0.00m, new DateOnly(2022, 10, 4)),
        new GamesDto(22, "League of Legends",                       "MOBA",              0.00m, new DateOnly(2009, 10, 27)),
        new GamesDto(23, "Dota 2",                                  "MOBA",              0.00m, new DateOnly(2013, 7,  9)),
        new GamesDto(24, "Counter-Strike 2",                        "FPS",               0.00m, new DateOnly(2023, 9,  1)),
        new GamesDto(25, "Valorant",                                "FPS",               0.00m, new DateOnly(2020, 6,  2)),
        new GamesDto(26, "Stardew Valley",                          "Simulation",       14.99m, new DateOnly(2016, 2,  28)),
        new GamesDto(27, "The Sims 4",                              "Simulation",       39.99m, new DateOnly(2014, 9,  2)),
        new GamesDto(28, "Persona 5 Royal",                         "JRPG",             59.99m, new DateOnly(2019, 10, 31)),
        new GamesDto(29, "Final Fantasy VII Remake",                "JRPG",             59.99m, new DateOnly(2020, 4,  10)),
        new GamesDto(30, "Monster Hunter: World",                   "Action-RPG",       39.99m, new DateOnly(2018, 1,  26)),
        new GamesDto(31, "Hollow Knight",                           "Metroidvania",     14.99m, new DateOnly(2017, 2,  24)),
        new GamesDto(32, "Celeste",                                 "Platformer",        19.99m, new DateOnly(2018, 1,  25)),
        new GamesDto(33, "Dark Souls III",                          "Action-RPG",       39.99m, new DateOnly(2016, 3,  24)),
        new GamesDto(34, "Bloodborne",                              "Action-RPG",       39.99m, new DateOnly(2015, 3,  24)),
        new GamesDto(35, "Sekiro: Shadows Die Twice",               "Action-Adventure", 59.99m, new DateOnly(2019, 3,  22)),
        new GamesDto(36, "Hades",                                   "Roguelike",        24.99m, new DateOnly(2020, 9,  17)),
        new GamesDto(37, "Portal 2",                                "Puzzle",           19.99m, new DateOnly(2011, 4,  19)),
        new GamesDto(38, "Half-Life: Alyx",                         "FPS",              59.99m, new DateOnly(2020, 3,  23)),
        new GamesDto(39, "Bioshock Infinite",                       "FPS",              39.99m, new DateOnly(2013, 3,  26)),
        new GamesDto(40, "The Last of Us Part I",                   "Action-Adventure", 69.99m, new DateOnly(2022, 9,  2)),
        new GamesDto(41, "God of War Ragnarök",                     "Action-Adventure", 69.99m, new DateOnly(2022, 11, 9)),
        new GamesDto(42, "Uncharted 4: A Thief's End",              "Action-Adventure", 39.99m, new DateOnly(2016, 5,  10)),
        new GamesDto(43, "Astro's Playroom",                        "Platformer",       29.99m, new DateOnly(2020, 11, 12)),
        new GamesDto(44, "Ratchet & Clank: Rift Apart",             "Action-Adventure", 69.99m, new DateOnly(2021, 6,  11)),
        new GamesDto(45, "Spider-Man: Miles Morales",               "Action-Adventure", 49.99m, new DateOnly(2020, 11, 12)),
        new GamesDto(46, "Splatoon 3",                              "Shooter",          59.99m, new DateOnly(2022, 9,  9)),
        new GamesDto(47, "Mario Kart 8 Deluxe",                     "Racing",           59.99m, new DateOnly(2017, 4,  28)),
        new GamesDto(48, "The Legend of Zelda: Tears of the Kingdom", "Action-Adventure", 69.99m, new DateOnly(2023, 5, 12)),


    ];
}
