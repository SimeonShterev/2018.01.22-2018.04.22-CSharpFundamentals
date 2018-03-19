namespace Forum.App.Services
{
    using System;
	using System.Linq;
	using Forum.App.Services.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class CategoryController : IController, IPaginationController
    {
		public const int PAGE_OFFSET = 10;
		private const int COMMAND_COUNT = PAGE_OFFSET + 3;

		public CategoriesController()
		{
			this.CurrentPage = 0;
			this.SetCategory(0);
		}

        public int CurrentPage { get; set; }

		private string[] PostTitles { get; set; }

		private int LastPAge => this.PostTitles.Length / 11;

		public int CategoryId { get; private set; }

		public void SetCategory(int CategoryId)
		{
			this.CategoryId = CategoryId;
		}

		private void ChangePage(bool forward = true)
		{
			this.CurrentPage += forward ? 1 : -1;
			GetPosts();
		}

		public MenuState ExecuteCommand(int index)
        {
            switch((Command)index)
			{
				case Command.Back:
					return MenuState.Back;
				case Command.ViewPost:
					return MenuState.ViewPost;
				case Command.PreviousPage:
					return MenuState.OpenCategory;
				case Command.NextPage:
					return MenuState.OpenCategory;
			}

			throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
			GetPosts();
			string categoryName = PostService.GetCategory(this.CategoryId).Name;
			return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

		private void GetPosts()
		{
			var allCategoryPosts = PostService.GetPostsByCategory(this.CategoryId);

			this.PostTitles = allCategoryPosts
				.Skip(this.CurrentPage * PAGE_OFFSET)
				.Take(PAGE_OFFSET)
				.Select(p => p.Title)
				.ToArray();
		}

		private enum Command
		{
			Back = 0,
			ViewPost = 1,
			PreviousPage = 11,
			NextPage = 12
		}
	}
}
