using Microsoft.AspNetCore.Mvc;
using S_ITPE006LA___Activity_5.Models;
using S_ITPE006LA___Activity_5.UnitOfWork;
using System.Threading.Tasks;

namespace S_ITPE006LA___Activity_5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _uow.Products.GetAllAsync(p => p.Category!, p => p.Supplier!);
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _uow.Products.GetByIdAsync(id.Value, p => p.Category!, p => p.Supplier!);
            if (product == null) return NotFound();

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _uow.Categories.GetAllAsync();
            ViewBag.Suppliers = await _uow.Suppliers.GetAllAsync();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _uow.Categories.GetAllAsync();
                ViewBag.Suppliers = await _uow.Suppliers.GetAllAsync();
                return View(product);
            }

            await _uow.Products.AddAsync(product);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _uow.Products.GetByIdAsync(id.Value);
            if (product == null) return NotFound();

            ViewBag.Categories = await _uow.Categories.GetAllAsync();
            ViewBag.Suppliers = await _uow.Suppliers.GetAllAsync();
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _uow.Categories.GetAllAsync();
                ViewBag.Suppliers = await _uow.Suppliers.GetAllAsync();
                return View(product);
            }

            _uow.Products.Update(product);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _uow.Products.GetByIdAsync(id.Value, p => p.Category!, p => p.Supplier!);
            if (product == null) return NotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            _uow.Products.Delete(product);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}