using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public interface IPostService
	{
		Posts Create(Posts posts);

		Posts GetIdPost(int id);
		List<Posts> GetAll();

		Posts Delete(int id);
		Posts Update(int id, Posts post);	
	}
}
