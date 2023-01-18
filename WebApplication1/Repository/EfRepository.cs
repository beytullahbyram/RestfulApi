using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.DataAccessLayer;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
	public class EfRepository<T> : IGenericRepository<T> where T : class, new()
	{
		private readonly DataBaseContext _context;
		private readonly DbSet<T> _dbSet;
		public EfRepository(DataBaseContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>(); //_Contex.set<T> işlemini her satırda yeniden yapmak yerine burada tek seferde oluşturmuş olduk
		}
		public T Add(T model)
		{
			var result = new T();	
			_dbSet.Add(model);
			int sonuc=_context.SaveChanges();
			result=model;
			return result;
		}

		public T Delete(T model)
		{
			var result= new	T();
			_dbSet.Remove(model);
			_context.SaveChanges();
			result=model;
			return result;


		}

		public List<T> GetAll()
		{
			var result = new List<T>();
			var list = _dbSet.ToList();
			if(list != null)
				result=list;
			else
				result = null;
			return result;
		}

		public T GetById(int id)
		{
			var result=new T();
			result=_dbSet.Find(id);
			if(result != null)
				return result;
			return null;
		}

		public T UpdateById(T model, int id)
		{
			var result=new T();
			var foundModel =_dbSet.Find(id);

			if(foundModel != null)
			{
				//güncelleme işlemi burada yapılır, yeni değerleri set et
				_context.Entry(foundModel).CurrentValues.SetValues(model);
				_context.SaveChanges();
				result=foundModel;
				return result;
			}
			else
				return null;
		}
	}
}
