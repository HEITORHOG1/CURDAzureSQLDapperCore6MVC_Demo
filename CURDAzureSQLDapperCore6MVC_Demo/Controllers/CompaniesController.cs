using CURDAzureSQLDapperCore6MVC_Demo.Models;
using CURDAzureSQLDapperCore6MVC_Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CURDWithDapperCore6MVC_Demo.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository repository;

        public CompaniesController(ICompanyRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetCompanies());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await repository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateCompany(company);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CompaniesController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await repository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await repository.UpdateCompany(id, company);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await repository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await repository.DeleteCompany(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
