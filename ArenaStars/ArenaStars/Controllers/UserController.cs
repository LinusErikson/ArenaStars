﻿using ArenaStars.Models;
using ArenaStars.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace ArenaStars.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public ActionResult Register(string username, string email, string password, string password2)
        {
            Regex.Replace(username, @"\s+", "");  //Removes all white spaces.
            List<string> ErrorMsgList = checkRegisterInputFaults(username, email, password, password2);

            if (ErrorMsgList.Count == 0)
            {
                using (ArenaStarsContext context = new ArenaStarsContext())
                {
                    User newUser = new User()
                    {
                        Username = username,
                        Password = password,
                        Email = email,
                        SignUpDate = DateTime.Now,
                        IsAdmin = false,
                        IsTerminated = false,
                        LastLoggedIn = DateTime.Now,
                        ProfilePic = "~ProfilePicture_Default.jpg",
                        BackgroundPic = "ProfileBackground_Default.jpg",
                        Rank = Models.User.RankEnum.Unranked
                    };


                    Session["isLoggedIn"] = true;
                    Session["username"] = username;

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
            }


            return Json(new { errorList = ErrorMsgList }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            List<string> ErrorMsgList = checkLoginInputFaults(username, password);

            if (ErrorMsgList.Count == 0)
            {
                Session["isLoggedIn"] = true;
                //Session["username"] = "";  //Gör tilldelningen i CheckLoginInputFaults, var tyvärr tvungen att göra det ifall username ska vara "statiskt"

            }

            return Json(new { errorList = ErrorMsgList }, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Logout()
        {
            Session["isLoggedIn"] = false;
            Session["username"] = "";
            Session["isAdmin"] = false;

            return RedirectToAction("/Index", "Home");
        }

        public new ActionResult Profile(string username)
        {
            User user = new Models.User();

            int gamesCount = 0;
            string lastFiveGamesScore = "";
            int placeInCountry = 0;
            int placeInWorld = 0;
            double winPercentage = 0;

            using (ArenaStarsContext context = new ArenaStarsContext())
            {
                var findUser = from u in context.Users
                               where username.ToLower() == u.Username.ToLower()
                               select u;

                if (findUser.Count() == 0)
                {
                    context.Dispose();
                    return RedirectToAction("/UserNotFound", "User");
                }

                user = findUser.FirstOrDefault();

                gamesCount = user.Games.Count;
                List<Game> lastFiveGames = user.Games.Take(5).ToList();

                foreach (Game game in lastFiveGames)
                {
                    if (game.Winner.Username == user.Username)
                        lastFiveGamesScore += "W";
                    else
                        lastFiveGamesScore += "L";
                }

                while (lastFiveGamesScore.Length < 5)
                {
                    lastFiveGamesScore += "-";
                }

                List<string> getAllUsersCountry = (from u in context.Users
                                  where u.Country == user.Country
                                  select u.Username).ToList();

                var getAllUsersWorld = from u in context.Users
                                       select u.Username;

                for (int i = 0; i < getAllUsersCountry.Count(); i++)
                {
                    if (getAllUsersCountry.ElementAt(i) == user.Username)
                    {
                        placeInCountry = i + 1;
                        break;
                    }
                }

                int f = 0;
                foreach (string u in getAllUsersWorld)
                {
                    if (u == user.Username)
                    {
                        placeInWorld = f + 1;
                        break;
                    }
                    f++;
                }

                double tempWins = 0.0;
                foreach (Game game in user.Games)
                {
                    if (game.Winner.Username == user.Username)
                        tempWins++;
                }

                winPercentage = (tempWins / user.Games.Count) * 100;

            }
			
            ViewBag.ProfileSelected = "activeNav";
            ViewBag.ProfileNavSelected = "activeNav";

            // TODO: Ge placeInCountry & placeInWorld riktiga värden.

            ViewUser viewUser = new ViewUser()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                SteamId = user.SteamId,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Country = user.Country,
                SignUpDate = user.SignUpDate,
                LastLoggedIn = user.LastLoggedIn,
                IsAdmin = user.IsAdmin,
                Rank = user.Rank,
                Level = user.Level,
                Elo = user.Elo,
                IsTerminated = user.IsTerminated,
                BanReason = user.BanReason,
                BanDuration = user.BanDuration,
                ProfilePic = user.ProfilePic,
                BackgroundPic = user.BackgroundPic,
                
                GamesCount = gamesCount,
                LastFiveGamesScore = lastFiveGamesScore,
                placeInCountry = placeInCountry,
                placeInWorld = placeInWorld,
                winPercentage = winPercentage
            };

            return View(viewUser);
        }

        public ActionResult UserNotFound()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetTournaments(int shown, string username)
        {
            List<object> tournaments = new List<object>();
            int numberToDisplay = 5; //Maybe(probably) make it parameter

            using (ArenaStarsContext context = new ArenaStarsContext())
            {
                var findUser = from u in context.Users
                               where username.ToLower() == u.Username.ToLower()
                               select u;

                User user = findUser.FirstOrDefault();
                int i = 0;
                foreach (var tournament in user.Tournaments)
                {
                    if (i >= shown)
                    {
                        if (i < shown + numberToDisplay)
                        {
                            var newTournament = new
                            {
                                CheckInDate = tournament.CheckInDate.ToString(),
                                CreatedDate = tournament.CreatedDate.ToString(),
                                StartDate = tournament.StartDate.ToString(),
                                HasEnded = tournament.HasEnded,
                                Id = tournament.Id,
                                IsLive = tournament.IsLive,
                                MaxRank = tournament.MaxRank.ToString(),
                                MinRank = tournament.MinRank.ToString(),
                                Name = tournament.Name,
                                PlayerLimit = tournament.PlayerLimit,
                                TrophyPic = tournament.TrophyPic,
                                Type = tournament.Type.ToString(),
                                ParticipantsCount = tournament.Participants.Count
                            };
                            tournaments.Add(newTournament);
                        }
                        else { break; }
                    }
                    else { break; }
                    i++;
                }

            }

            return Json(new { tournamentList = tournaments }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult GetGames(int shown, string username)
        {
            List<object> games = new List<object>();
            int numberToDisplay = 10; //Maybe(probably) make it parameter

            using (ArenaStarsContext context = new ArenaStarsContext())
            {
                var findUser = from u in context.Users
                               where username.ToLower() == u.Username.ToLower()
                               select u;

                User user = findUser.FirstOrDefault();
                int i = 0;
                foreach (Game game in user.Games)
                {
                    if (i >= shown)
                    {
                        if (i < shown + numberToDisplay)
                        {
                            var newGame = new
                            {
                                Id = game.Id,
                                Map = game.Map,
                                ParticipantOne = game.Participants.FirstOrDefault().Username,
                                ParticipantTwo = game.Participants.LastOrDefault().Username,
                                Type = game.Type.ToString(),
                                Winner = game.Winner.Username,
                                PlayedDate = game.PlayedDate.ToString(),
                                Kills = game.GameStats.FirstOrDefault().Kills,
                                Deaths = game.GameStats.FirstOrDefault().Deaths
                            };
                            games.Add(newGame);
                        }
                        else { break; }
                    }
                    else { break; }
                    i++;
                }

            }

            return Json(new { gameList = games }, JsonRequestBehavior.DenyGet);
        }

        private List<string> checkRegisterInputFaults(string username, string email, string password, string password2)
        {
            List<string> errorMsgList = new List<string>();

            //Checks empty or whitespace
            if (string.IsNullOrWhiteSpace(username))
            {
                errorMsgList.Add("Username cannot be empty!");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                errorMsgList.Add("E-mail cannot be empty!");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMsgList.Add("Password cannot be empty!");
            }

            //Checks lengths
            if (username.Length < 3 || username.Length > 30)
            {
                errorMsgList.Add("Username must be between 3 and 30 characters.");
            }
            if (username.Length < 6 || username.Length > 30)
            {
                errorMsgList.Add("Password must be between 6 and 30 characters.");
            }

            //Checks if passwords match
            if (password2 != password)
            {
                errorMsgList.Add("Given passwords do not match!");
            }

            //Regex check
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9A-Za-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-\w]*[0-9A-Za-z]*\.)+[A-Za-z0-9][\-a-z0-9]{0,22}[A-Za-z0-9]))$";
            if (!Regex.IsMatch(email, pattern))
            {
                errorMsgList.Add("Given email address is not valid!");
            }


            using (ArenaStarsContext context = new ArenaStarsContext())
            {
                var checkUserExists = from u in context.Users
                                      where username.ToLower() == u.Username.ToLower()
                                      select u;

                var checkEmailExists = from u in context.Users
                                       where email.ToLower() == u.Email.ToLower()
                                       select u;

                //Checks if user with same username exists
                if (checkUserExists.Count() > 0)
                {
                    errorMsgList.Add("Given username is taken!");
                }

                //Checks if user with same email exists
                if (checkEmailExists.Count() > 0)
                {
                    errorMsgList.Add("Given email is taken!");
                }
            }

            return errorMsgList;
        }

        private List<string> checkLoginInputFaults(string username, string password)
        {
            List<string> errorMsgList = new List<string>();

            //Kollar ifall det finns en användare med angivna username och password.
            //Uppdatera last logged in date.

            //Checks if inputs are empty, null or whitespace
            if (string.IsNullOrWhiteSpace(username))
            {
                errorMsgList.Add("Username field is empty!");
            }
            //Checks if password is empty, null or whitespace
            if (string.IsNullOrWhiteSpace(password))
            {
                errorMsgList.Add("Password field is empty!");
            }

            if (errorMsgList.Count == 0)
            {
                using (ArenaStarsContext context = new ArenaStarsContext())
                {
                    var findUser = from u in context.Users
                                   where username.ToLower() == u.Username.ToLower() && password == u.Password
                                   select u;

                    if (findUser.Count() == 0)
                    {
                        errorMsgList.Add("There is no user with given username and password combination");
                    }
                    else
                    {
                        User u = findUser.FirstOrDefault();
                        u.LastLoggedIn = DateTime.Now;
                        Session["username"] = u.Username;
                        Session["isAdmin"] = u.IsAdmin;
                        Session["profilePictureUrl"] = u.ProfilePic;
                    }
                }
            }


            return errorMsgList;
        }
    }
}