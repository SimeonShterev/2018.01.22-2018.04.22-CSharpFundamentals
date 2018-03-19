using Forum.App.UserInterface.ViewModel;
using Forum.Data;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    public static class PostService
    {
		internal static Category GetCategory(int categoryId)
		{
			ForumData forumData = new ForumData();
			Category category = forumData.Categories.Find(c => c.Id == categoryId);
			return category;
		}

		internal static IList<ReplyViewModel> GetPostReplies(int postId)
		{
			ForumData forumData = new ForumData();
			Post post = forumData.Posts.Find(p => p.Id == postId);
			IList<ReplyViewModel> replies = new List<ReplyViewModel>();
			foreach (var replyId in post.ReplyIds)//							possible Exception
			{
				var reply = forumData.Replies.Find(r => r.Id == replyId);
				replies.Add(new ReplyViewModel(reply));
			}
			return replies;
		}

		internal static string[] GetCategoryNames()
		{
			throw new NotImplementedException();
		}

		public static IEnumerable<Post> GetPostsByCategory(int CategoryId)
		{
			ForumData forumData = new ForumData();

			var postIds = forumData.Categories.First(c => c.Id == CategoryId).PostIds;

			IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

			return posts;
		}
	}
}
