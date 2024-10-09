using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiKiemTra03_03.Data;  // Đường dẫn tới lớp ApplicationDbContext
using BaiKiemTra03_03.Models;  // Đường dẫn tới lớp Contract, Customer
using System.Threading.Tasks;

namespace BaiKiemTra03_03.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contract/Index
        public async Task<IActionResult> Index()
        {
            // Include Customer để hiển thị thông tin khách hàng trong danh sách hợp đồng
            var contracts = await _context.Contracts.Include(c => c.Customer).ToListAsync();
            return View(contracts);
        }

        // GET: Contract/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.ContractId == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contract/Create
        public IActionResult Create()
        {
            // Hiển thị danh sách khách hàng trong dropdown
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Contract/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,ContractName,SigningDate,CustomerId,ContractValue")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName", contract.CustomerId);
            return View(contract);
        }

        // GET: Contract/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            // Hiển thị dropdown để chọn khách hàng
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName", contract.CustomerId);
            return View(contract);
        }

        // POST: Contract/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,ContractName,SigningDate,CustomerId,ContractValue")] Contract contract)
        {
            if (id != contract.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.ContractId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Hiển thị lại danh sách khách hàng trong dropdown nếu có lỗi
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName", contract.CustomerId);
            return View(contract);
        }

        // GET: Contract/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(m => m.ContractId == id);

            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.ContractId == id);
        }
    }
}

