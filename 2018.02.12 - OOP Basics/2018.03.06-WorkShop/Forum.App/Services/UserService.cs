﻿using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Forum.App.Services.SignUpController;

namespace Forum.App.Services
{
    public static class UserService
    {
		public static bool TryLogInUser(string username, string password)
		{
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				return false;
			}
			ForumData forumData = new ForumData();
			bool userExists = forumData.Users.Any(u => u.Username == username && u.Password == password);
			return userExists;
		}

		public static SignUpStatus TrySignUpUser(string username, string password)
		{
			bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length > 3;
			bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 3;
			if(!validPassword||!validUsername)
			{
				return SignUpStatus.DetailsError;
			}

			ForumData forumData = new ForumData();
			bool userAlreadyExists = forumData.Users.Any(u => u.Username == username);
			if(!userAlreadyExists)
			{
				int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
				User user = new User(userId, username, password);
				forumData.Users.Add(user);
				forumData.SaveChanges();

				return SignUpStatus.Success;
			}

			return SignUpStatus.UsernameTakenError;
		}
    }
}