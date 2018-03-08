namespace Forum.App.Services
{
	using Forum.App;
	using Forum.App.Services.Contracts;
	using Forum.App.UserInterface;
	using Forum.App.UserInterface.Contracts;
	using Forum.App.UserInterface.Views;

	public class SignUpController : IController, IReadUserInfoController
	{
		private const string DetailsError = "Invalid Username or Password!";
		private const string UsernameTakenError = "Username already in use!";

		public string Username { get; private set; }

		private string Password { get; set; }

		private string ErrorMessage { get; set; }

		private enum Command
		{
			ReadUsername,
			ReadPassword,
			SignUp,
			Back
		}

		public enum SignUpStatus
		{
			Success,
			DetailsError,
			UsernameTakenError
		}

		private void ResetSignUp()
		{
			this.ErrorMessage = string.Empty;
			this.Username = string.Empty;
			this.Password = string.Empty;
		}

		public MenuState ExecuteCommand(int index)
		{
			switch ((Command)index)
			{
				case Command.ReadUsername:
					this.ReadUsername();
					return MenuState.Signup;
				case Command.ReadPassword:
					this.ReadPassword();
					return MenuState.Signup;
				case Command.SignUp:
					SignUpStatus signUp = UserService.TrySignUpUser(this.Username, this.Password);
					switch (signUp)
					{
						case SignUpStatus.Success:
							return MenuState.SuccessfulLogIn;
						case SignUpStatus.DetailsError:
							this.ErrorMessage = DetailsError;
							return MenuState.Error;
						case SignUpStatus.UsernameTakenError:
							this.ErrorMessage = UsernameTakenError;
							return MenuState.Error;
					}
					break;
				case Command.Back:
					this.ResetSignUp();
					return MenuState.Back;
			}
			throw new System.InvalidOperationException();
		}

		public IView GetView(string userName)
		{
			return new SignUpView(this.ErrorMessage);
		}

		public void ReadPassword()
		{
			this.Password = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}

		public void ReadUsername()
		{
			this.Username = ForumViewEngine.ReadRow();
			ForumViewEngine.HideCursor();
		}
	}
}
