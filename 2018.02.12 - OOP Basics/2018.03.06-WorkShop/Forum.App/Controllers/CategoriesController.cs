﻿namespace Forum.App.Services
{
    using System;
	using System.Linq;
	using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;
	using Forum.Data;

	public class CategoriesController : IController, IPaginationController
    {
		public const int PAGE_OFFSET = 10;
		private const int COMMAND_COUNT = PAGE_OFFSET + 3;

		public CategoriesController()
		{
			this.CurrentPage = 0;
			this.LoadCategories();
		}

        public int CurrentPage { get; set; }

		private string[] AllCategoryNames { get; set; }

		private string[] CurrentPageCategories { get; set; }

		private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);

		private bool IsFirstPage => this.CurrentPage == 0;

		private bool IsLastPage => this.CurrentPage == this.LastPage;

		public MenuState ExecuteCommand(int index)
        {
            if(index>1 && index<11)
			{
				index = 1;
			}
			switch((Command)index)
			{
				case Command.Back:
					return MenuState.Back;
				case Command.ViewPost:
					return MenuState.OpenCategory;
				case Command.PreviousPage:
					this.ChangePage(false);
					return MenuState.Rerender;
				case Command.NextPage:
					this.ChangePage();
					return MenuState.Rerender;
			}
			throw new InvalidCommandException();
        }

		public void ChangePage(bool forward = true)
		{
			this.CurrentPage += forward ? 1 : -1;
		}

		internal static string[] GetAllCategoryNames()
		{
			ForumData forumData = new ForumData();

			var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

			return allCategories;
		}

		private void LoadCategories()
		{
			this.AllCategoryNames = PostService.GetCategoryNames();

			this.CurrentPageCategories = this.AllCategoryNames
				.Skip(this.CurrentPage * PAGE_OFFSET)
				.Take(PAGE_OFFSET)
				.ToArray();
		}

		public IView GetView(string userName)
		{
			LoadCategories();
			return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
		}



		private enum Command
		{
			Back = 0,
			ViewPost =1,
			PreviousPage = 11,
			NextPage = 12
		}
    }
}
