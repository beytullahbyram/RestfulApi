using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
	public class PostManager : IPostService
	{
		//bağımlılığı azaltmak için depencdt injection yapıldı
		private readonly IGenericRepository<Posts> _postsRepository;
		public PostManager(IGenericRepository<Posts> postsRepository)
		{
			_postsRepository= postsRepository;
		}
		public Posts Create(Posts posts)
		{
			Posts findposts= _postsRepository.GetById(posts.Id);
			if (findposts != null)
				return null;

			return _postsRepository.Add(posts);
		}



		public Posts GetIdPost(int id)
		{

			Posts findposts=_postsRepository.GetById(id);
			if(findposts != null)
				return findposts;
			else
				return null;
		}


		public List<Posts> GetAll()
		{
			return _postsRepository.GetAll();
		}
		public Posts Delete(int id)
		{
			Posts findposts=_postsRepository.GetById(id);
			var result=_postsRepository.Delete(findposts);
			return result;
		}

		public Posts Update(int id, Posts post)
		{
			return _postsRepository.UpdateById(post,id);
		}
	}
}
