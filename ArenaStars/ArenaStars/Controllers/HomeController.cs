﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArenaStars.Models;

namespace ArenaStars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArenaStarsContext context = new ArenaStarsContext();

            context.Database.Initialize(true);

            var rankedGames = from g in context.Games
                              where g.Type == Game.GameTypeEnum.Ranked
                              select g;

            var tournamentGames = from t in context.Games
                                  where t.Type == Game.GameTypeEnum.Tournament
                                  select t;

            var tournamentWinners = from t in context.Tournaments
                                    where t.Winner != null
                                    select t.Winner;

            var reports = from r in context.Reports
                          select r;

            var userlist = from u in context.Users
                           select u;

            ViewBag.TWinners = tournamentWinners;
            ViewBag.Users = userlist;
            ViewBag.Reports = reports;
            ViewBag.TGames = tournamentGames;
            ViewBag.RGames = rankedGames;

            //Active state css ViewBag
            ViewBag.HomeSelected = "activeNav";

            return View();
        }

        public ActionResult DummyData()
        {
            using (ArenaStarsContext context = new ArenaStarsContext())
            {
                List<User> Tournament1UserList = new List<User>(); //Userlist for tournament 1
                List<Game> Tournament1GameList = new List<Game>(); //Gamelist for tournament 1

                /***************USER***************/

                #region Users

                User u1 = new User()
                {
                    #region info

                    Username = "MuppetNicke",
                    Firstname = "Niclas",
                    Lastname = "Pettersson",
                    Country = "Sweden",
                    Email = "Nicke.Pettersson@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-20),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 1953,
                    Rank = Models.User.RankEnum.Master,
                    Level = 9,
                    IsTerminated = false,
                    SteamId = "1",
                    ProfilePic = "/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u2 = new User()
                {
                    #region info

                    Username = "AlleBalle",
                    Firstname = "Alexander",
                    Lastname = "Andersson",
                    Country = "Sweden",
                    Email = "Alexander.Andersson@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-10),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = true,
                    Elo = 900,
                    Rank = Models.User.RankEnum.Legend,
                    Level = 9,
                    IsTerminated = false,
                    SteamId = "2",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u3 = new User()
                {
                    #region info

                    Username = "linustechtips",
                    Firstname = "Linus",
                    Lastname = "Eriksson",
                    Country = "Sweden",
                    Email = "linus.eriksson@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-10),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 500,
                    Rank = Models.User.RankEnum.Gold,
                    Level = 5,
                    IsTerminated = false,
                    SteamId = "3",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u4 = new User()
                {
                    #region info

                    Username = "Steffe",
                    Firstname = "Stefan",
                    Lastname = "Larsson",
                    Country = "Sweden",
                    Email = "stefan.larsson@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-10),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 400,
                    Rank = Models.User.RankEnum.Silver,
                    Level = 4,
                    IsTerminated = false,
                    SteamId = "4",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u5 = new User()
                {
                    #region info

                    Username = "Olofmeister",
                    Firstname = "Olof",
                    Lastname = "Meister",
                    Country = "Sweden",
                    Email = "Olof.Meister@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-20),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 700,
                    Rank = Models.User.RankEnum.Master,
                    Level = 7,
                    IsTerminated = false,
                    SteamId = "5",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u6 = new User()
                {
                    #region info

                    Username = "AW",
                    Firstname = "Arne",
                    Lastname = "Weise",
                    Country = "Sweden",
                    Email = "Arne.Weise@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-30),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 200,
                    Rank = Models.User.RankEnum.Challanger,
                    Level = 2,
                    IsTerminated = false,
                    SteamId = "6",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u7 = new User()
                {
                    #region info

                    Username = "KennyS",
                    Firstname = "Kenny",
                    Lastname = "Schrub",
                    Country = "Sweden",
                    Email = "Kenny.Schrub@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-15),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 500,
                    Rank = Models.User.RankEnum.Grandmaster,
                    Level = 5,
                    IsTerminated = false,
                    SteamId = "7",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u8 = new User()
                {
                    #region info

                    Username = "Khem",
                    Firstname = "Erik",
                    Lastname = "Westman",
                    Country = "Sweden",
                    Email = "Erik.Westman@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-50),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 100,
                    Rank = Models.User.RankEnum.Bronze,
                    Level = 1,
                    IsTerminated = false,
                    SteamId = "8",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u9 = new User()
                {
                    #region info

                    Username = "Get_Right",
                    Firstname = "Christopher",
                    Lastname = "Alesund",
                    Country = "Sweden",
                    Email = "Christopher.Alesund@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-50),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 900,
                    Rank = Models.User.RankEnum.Legend,
                    Level = 9,
                    IsTerminated = false,
                    SteamId = "9",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User u10 = new User()
                {
                    #region info

                    Username = "PashaBiceps",
                    Firstname = "Jarosław",
                    Lastname = "Jarząbkowski",
                    Country = "Poland",
                    Email = "Jarosław.Jarząbkowski@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-60),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = false,
                    Elo = 900,
                    Rank = Models.User.RankEnum.Legend,
                    Level = 9,
                    IsTerminated = false,
                    SteamId = "10",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                User admin = new User()
                {
                    #region info

                    Username = "Admin",
                    Firstname = "Admin",
                    Lastname = "Admin",
                    Country = "Sweden",
                    Email = "Admin.Admin@gmail.com",
                    Password = "hejsan",
                    SignUpDate = DateTime.Now.AddDays(-100),
                    LastLoggedIn = DateTime.Now,
                    IsAdmin = true,
                    Elo = 0,
                    Rank = Models.User.RankEnum.Unranked,
                    Level = 0,
                    IsTerminated = false,
                    SteamId = "Admin",
                    ProfilePic = "~/Images/Profile/ProfilePicture_Default.png",
                    BackgroundPic = "~/Images/Profile/ProfileBackground_Default.jpg"

                    #endregion
                };

                #endregion

                //Adding Users to database
                context.Users.Add(u1);
                context.Users.Add(u2);
                context.Users.Add(u3);
                context.Users.Add(u4);
                context.Users.Add(u5);
                context.Users.Add(u6);
                context.Users.Add(u7);
                context.Users.Add(u8);
                context.Users.Add(u9);
                context.Users.Add(u10);
                context.Users.Add(admin);

                //Adding Users in Userlist for tournament 1
                Tournament1UserList.Add(u1);
                Tournament1UserList.Add(u2);
                Tournament1UserList.Add(u3);
                Tournament1UserList.Add(u4);
                Tournament1UserList.Add(u5);
                Tournament1UserList.Add(u6);
                Tournament1UserList.Add(u7);
                Tournament1UserList.Add(u8);

                /****************GAMES*****************/

                #region Games

                Game RankedGame1 = new Game()
                {
                    Participants = new List<User>() { u1, u2 },
                    Winner = u1,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                    PlayedDate = DateTime.Now.AddHours(-5)
                };

                Game RankedGame2 = new Game()
                {
                    Participants = new List<User>() { u2, u3 },
                    Winner = u2,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame3 = new Game()
                {
                    Participants = new List<User>() { u3, u4 },
                    Winner = u4,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame4 = new Game()
                {
                    Participants = new List<User>() { u4, u5 },
                    Winner = u4,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame5 = new Game()
                {
                    Participants = new List<User>() { u5, u6 },
                    Winner = u6,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame6 = new Game()
                {
                    Participants = new List<User>() { u6, u7 },
                    Winner = u6,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame7 = new Game()
                {
                    Participants = new List<User>() { u7, u8 },
                    Winner = u7,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame8 = new Game()
                {
                    Participants = new List<User>() { u8, u9 },
                    Winner = u9,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game RankedGame9 = new Game()
                {
                    Participants = new List<User>() { u9, u10 },
                    Winner = u10,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Ranked,
                };

                Game Tournament1Game1 = new Game()
                {
                    Participants = new List<User>() { u1, u2 },
                    Winner = u1,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game2 = new Game()
                {
                    Participants = new List<User>() { u3, u4 },
                    Winner = u3,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game3 = new Game()
                {
                    Participants = new List<User>() { u5, u6 },
                    Winner = u6,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game4 = new Game()
                {
                    Participants = new List<User>() { u7, u8 },
                    Winner = u7,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                    PlayedDate = DateTime.Now
                };

                Game Tournament1Game5 = new Game()
                {
                    Participants = new List<User>() { u9, u10 },
                    Winner = u10,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game6 = new Game()
                {
                    Participants = new List<User>() { u1, u3 },
                    Winner = u1,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game7 = new Game()
                {
                    Participants = new List<User>() { u6, u7 },
                    Winner = u6,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                Game Tournament1Game8 = new Game()
                {
                    Participants = new List<User>() { u1, u6 },
                    Winner = u1,
                    Map = "aim_map",
                    Type = Game.GameTypeEnum.Tournament,
                };

                #endregion

                //Adding Ranked Games to database
                context.Games.Add(RankedGame1);
                context.Games.Add(RankedGame2);
                context.Games.Add(RankedGame3);
                context.Games.Add(RankedGame4);
                context.Games.Add(RankedGame5);
                context.Games.Add(RankedGame6);
                context.Games.Add(RankedGame7);
                context.Games.Add(RankedGame8);
                context.Games.Add(RankedGame9);

                //Adding Tournament 1 Games to database
                context.Games.Add(Tournament1Game1);
                context.Games.Add(Tournament1Game2);
                context.Games.Add(Tournament1Game3);
                context.Games.Add(Tournament1Game4);
                context.Games.Add(Tournament1Game5);
                context.Games.Add(Tournament1Game6);
                context.Games.Add(Tournament1Game7);
                context.Games.Add(Tournament1Game8);

                //Adding Tournament 1 Games to list
                Tournament1GameList.Add(Tournament1Game1);
                Tournament1GameList.Add(Tournament1Game2);
                Tournament1GameList.Add(Tournament1Game3);
                Tournament1GameList.Add(Tournament1Game4);
                Tournament1GameList.Add(Tournament1Game5);
                Tournament1GameList.Add(Tournament1Game6);
                Tournament1GameList.Add(Tournament1Game7);
                Tournament1GameList.Add(Tournament1Game8);

                /*************GAME STATS***************/

                #region GameStats

                GameStats GameStatsRanked1Player1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0.75,
                    SteamId = "1",
                    Game = RankedGame1

                    #endregion
                };

                GameStats GameStatsRanked1Player2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.45,
                    SteamId = "2",
                    Game = RankedGame1

                    #endregion
                };

                GameStats GameStatsRanked2Player1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0.5,
                    SteamId = "2",
                    Game = RankedGame2

                    #endregion
                };

                GameStats GameStatsRanked2Player2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.45,
                    SteamId = "3",
                    Game = RankedGame2

                    #endregion
                };

                GameStats GameStatsRanked3Player1 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.50,
                    SteamId = "3",
                    Game = RankedGame3

                    #endregion
                };

                GameStats GameStatsRanked3Player2 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 1.00,
                    SteamId = "4",
                    Game = RankedGame3

                    #endregion
                };

                GameStats GameStatsRanked4Player1 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.45,
                    SteamId = "4",
                    Game = RankedGame4

                    #endregion
                };

                GameStats GameStatsRanked4Player2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.45,
                    SteamId = "5",
                    Game = RankedGame4

                    #endregion
                };

                GameStats GameStatsRanked5Player1 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0.00,
                    SteamId = "5",
                    Game = RankedGame5

                    #endregion
                };

                GameStats GameStatsRanked5Player2 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 1.00,
                    SteamId = "6",
                    Game = RankedGame5

                    #endregion
                };

                GameStats GameStatsRanked6Player1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0.50,
                    SteamId = "6",
                    Game = RankedGame6

                    #endregion
                };

                GameStats GameStatsRanked6Player2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.00,
                    SteamId = "7",
                    Game = RankedGame6

                    #endregion
                };

                GameStats GameStatsRanked7Player1 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 0.33,
                    SteamId = "7",
                    Game = RankedGame7

                    #endregion
                };

                GameStats GameStatsRanked7Player2 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0.00,
                    SteamId = "8",
                    Game = RankedGame7

                    #endregion
                };

                GameStats GameStatsRanked8Player1 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 1.00,
                    SteamId = "8",
                    Game = RankedGame8

                    #endregion
                };

                GameStats GameStatsRanked8Player2 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0.50,
                    SteamId = "9",
                    Game = RankedGame8

                    #endregion
                };

                GameStats GameStatsRanked9Player1 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 0.00,
                    SteamId = "9",
                    Game = RankedGame9

                    #endregion
                };

                GameStats GameStatsRanked9Player2 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0.50,
                    SteamId = "10",
                    Game = RankedGame9

                    #endregion
                };

                GameStats GS_T1_G1_P1 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 1,
                    SteamId = "1",
                    Game = Tournament1Game1

                    #endregion
                };

                GameStats GS_T1_G1_P2 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0,
                    SteamId = "2",
                    Game = Tournament1Game1

                    #endregion
                };

                GameStats GS_T1_G2_P1 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 1,
                    SteamId = "3",
                    Game = Tournament1Game2

                    #endregion
                };

                GameStats GS_T1_G2_P2 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0,
                    SteamId = "4",
                    Game = Tournament1Game2

                    #endregion
                };

                GameStats GS_T1_G3_P1 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 1,
                    SteamId = "5",
                    Game = Tournament1Game3

                    #endregion
                };

                GameStats GS_T1_G3_P2 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 0,
                    SteamId = "6",
                    Game = Tournament1Game3

                    #endregion
                };

                GameStats GS_T1_G4_P1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 1,
                    SteamId = "7",
                    Game = Tournament1Game4

                    #endregion
                };

                GameStats GS_T1_G4_P2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 1,
                    SteamId = "8",
                    Game = Tournament1Game4

                    #endregion
                };

                GameStats GS_T1_G5_P1 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0.00,
                    SteamId = "9",
                    Game = Tournament1Game5

                    #endregion
                };

                GameStats GS_T1_G5_P2 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 0.50,
                    SteamId = "10",
                    Game = Tournament1Game5

                    #endregion
                };

                GameStats GS_T1_G6_P1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 1.00,
                    SteamId = "1",
                    Game = Tournament1Game6

                    #endregion
                };

                GameStats GS_T1_G6_P2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 1.00,
                    SteamId = "3",
                    Game = Tournament1Game6

                    #endregion
                };

                GameStats GS_T1_G7_P1 = new GameStats()
                {
                    #region Info

                    Kills = 2,
                    Deaths = 1,
                    HsRatio = 1.00,
                    SteamId = "6",
                    Game = Tournament1Game7

                    #endregion
                };

                GameStats GS_T1_G7_P2 = new GameStats()
                {
                    #region Info

                    Kills = 1,
                    Deaths = 2,
                    HsRatio = 1.00,
                    SteamId = "7",
                    Game = Tournament1Game7

                    #endregion
                };

                GameStats GS_T1_G8_P1 = new GameStats()
                {
                    #region Info

                    Kills = 0,
                    Deaths = 3,
                    HsRatio = 0.00,
                    SteamId = "6",
                    Game = Tournament1Game8

                    #endregion
                };

                GameStats GS_T1_G8_P2 = new GameStats()
                {
                    #region Info

                    Kills = 3,
                    Deaths = 0,
                    HsRatio = 1.00,
                    SteamId = "1",
                    Game = Tournament1Game8

                    #endregion
                };

                #endregion

                //Adding Ranked GameStats to database
                context.GameStats.Add(GameStatsRanked1Player1);
                context.GameStats.Add(GameStatsRanked1Player2);
                context.GameStats.Add(GameStatsRanked2Player1);
                context.GameStats.Add(GameStatsRanked2Player2);
                context.GameStats.Add(GameStatsRanked3Player1);
                context.GameStats.Add(GameStatsRanked3Player2);
                context.GameStats.Add(GameStatsRanked4Player1);
                context.GameStats.Add(GameStatsRanked4Player2);
                context.GameStats.Add(GameStatsRanked5Player1);
                context.GameStats.Add(GameStatsRanked5Player2);
                context.GameStats.Add(GameStatsRanked6Player1);
                context.GameStats.Add(GameStatsRanked6Player2);
                context.GameStats.Add(GameStatsRanked7Player1);
                context.GameStats.Add(GameStatsRanked7Player2);
                context.GameStats.Add(GameStatsRanked8Player1);
                context.GameStats.Add(GameStatsRanked8Player2);
                context.GameStats.Add(GameStatsRanked9Player1);
                context.GameStats.Add(GameStatsRanked9Player2);

                //Adding Tournament 1 GameStats to database
                context.GameStats.Add(GS_T1_G1_P1);
                context.GameStats.Add(GS_T1_G1_P2);
                context.GameStats.Add(GS_T1_G2_P1);
                context.GameStats.Add(GS_T1_G2_P2);
                context.GameStats.Add(GS_T1_G3_P1);
                context.GameStats.Add(GS_T1_G3_P2);
                context.GameStats.Add(GS_T1_G4_P1);
                context.GameStats.Add(GS_T1_G4_P2);
                context.GameStats.Add(GS_T1_G5_P1);
                context.GameStats.Add(GS_T1_G5_P2);
                context.GameStats.Add(GS_T1_G6_P1);
                context.GameStats.Add(GS_T1_G6_P2);
                context.GameStats.Add(GS_T1_G7_P1);
                context.GameStats.Add(GS_T1_G7_P2);
                context.GameStats.Add(GS_T1_G8_P1);
                context.GameStats.Add(GS_T1_G8_P2);

                /***************TOURNAMENTS*****************/


                Tournament Tournament1 = new Tournament()
                {
                    Name = "AllStars Only",
                    Participants = Tournament1UserList,
                    Type = Tournament.TournamentTypeEnum.AllStars,
                    CreatedDate = DateTime.Today.AddDays(9).Add(new TimeSpan(17, 00, 00)),
                    StartDate = DateTime.Today.AddDays(10).Add(new TimeSpan(15, 00, 00)),
                    CheckInDate = DateTime.Today.AddDays(10).Add(new TimeSpan(14, 30, 00)),
                    HasEnded = false,
                    IsLive = false,
                    MinRank = Models.User.RankEnum.Bronze,
                    MaxRank = Models.User.RankEnum.Legend,
                    PlayerLimit = 8,
                    Winner = Tournament1GameList.LastOrDefault().Winner,
                    TrophyPic = "~/Images/Trophy/Trophy1",
                    Games = Tournament1GameList
                };

                //Adding tournaments to database
                context.Tournaments.Add(Tournament1);

                /********************REPORTS*********************/

                #region Reports

                Report report1 = new Report()
                {
                    ReportedUser = u1,
                    Reportee = u2,
                    Reason = Report.ReasonEnum.Cheating,
                    Message = "This guy is cheatng for sure",
                    SubmittedDate = DateTime.Now
                };

                Report report2 = new Report()
                {
                    ReportedUser = u2,
                    Reportee = u1,
                    Reason = Report.ReasonEnum.Other,
                    Message = "This guy reported me for nothing",
                    SubmittedDate = DateTime.Now
                };

                Report report3 = new Report()
                {
                    ReportedUser = u3,
                    Reportee = u1,
                    Reason = Report.ReasonEnum.Toxic,
                    Message = "To much tech tips",
                    SubmittedDate = DateTime.Now
                };

                #endregion

                //Adding reports to database
                context.Reports.Add(report1);
                context.Reports.Add(report2);
                context.Reports.Add(report3);

                //Saving changes to database
                context.SaveChanges();
            }
            return RedirectToAction("/Index", "Home");
        }
    }
}