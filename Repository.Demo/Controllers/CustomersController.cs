using System.Net;
using System.Web.Mvc;
using Repository.Demo.DAL;
using Repository.Demo.Entities;

namespace Repository.Demo.Controllers
{
	public class CustomersController : Controller
	{
		private readonly IRepository<Customer> customerrepo;

		public CustomersController()
		{
			//I am creating an Repository instance manualy,because i am not 
			//using dependency injection in this demo. 
			customerrepo = new EfCustomerRepository();
		}
		// GET: Customers
		public ActionResult Index()
		{
			return View(customerrepo.GetAll());
		}

		// GET: Customers/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = customerrepo.GetById((int)id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// GET: Customers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Customers/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Address")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				customerrepo.Create(customer);
				return RedirectToAction("Index");
			}

			return View(customer);
		}

		// GET: Customers/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = customerrepo.GetById((int)id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: Customers/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Address")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				customerrepo.Update(customer);
				return RedirectToAction("Index");
			}
			return View(customer);
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = customerrepo.GetById((int)id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: Customers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			customerrepo.Delete(id);
			return RedirectToAction("Index");
		}


	}
}
