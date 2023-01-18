using System.Collections.Generic;

namespace WebApplication1.Repository
{
	//bu interface new ile oluşturulabilir ve class olacak şeklinde kısıtlamaları verdik
	public interface IGenericRepository<T> where T : class , new()
	{
		//CRUD işlemlerimizi burada gerçekleştireceğiz her bir işlem için class oluşturmak yerine T tipinde generic bir class oluşturduk
		T Add (T model);
		T Delete (T model);
		T GetById(int id);
		List<T> GetAll();
		T UpdateById(T model,int id);
	}

}
