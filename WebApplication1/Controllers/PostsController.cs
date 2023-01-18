using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	[Route("api/posts")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly IPostService _PostService;
		public PostsController(IPostService PostManager)
		{
			_PostService= PostManager;
		}


		[HttpPost]
		public IActionResult Create(Posts model) 
		{ 
			var result=_PostService.Create(model);
			return Ok(result);	
		}

		[HttpGet("{id}")]
		public IActionResult GetIdPost(int id)
		{
			var result=_PostService.GetIdPost(id);
			return Ok(result);	
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result=_PostService.GetAll();
			return Ok(result);
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result= _PostService.Delete(id);
			return Ok(result);	
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id,Posts model)
		{
			var result= _PostService.Update(id,model);
			return Ok(result);	
		}

	}
}
