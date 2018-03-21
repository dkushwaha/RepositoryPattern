using System;
using System.Collections.Generic;
using Repository.Demo.Entities;
using Repository.Demo.DAL.Entities;

namespace Repository.Demo.DAL
{
	public class EfCustomerRepository : IRepository<Customer>
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Create(Customer entity)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				context.Customers.Add(entity);
				context.SaveChanges();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				var entity = context.Customers.Find(id);
				context.Customers.Remove(entity);
				context.SaveChanges();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>

		public void Delete(Customer entity)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				context.Customers.Remove(entity);
				context.SaveChanges();
			}
		}
		/// <summary>
		/// 
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Customer> GetAll()
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				return context.Customers;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Customer GetById(int id)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				return context.Customers.Find(id);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		public void Update(Customer entity)
		{
			using (ApplicationDbContext context = new ApplicationDbContext())
			{
				context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
