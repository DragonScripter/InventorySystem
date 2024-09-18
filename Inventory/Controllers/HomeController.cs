using DAL;
using DAL.Respository.Implementation;
using DAL.Respository.Interface;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository? _repository;
        private readonly IPurchaseOrder? _purchaseOrderRepository;
        private readonly IPurchaseOrderDetailRepository? _podRepository;
        private readonly ISaleRepository? _saleRepository;
        private readonly ISupplierRepository? _supplierRepository;


        public HomeController(ILogger<HomeController> logger, IProductRepository repository, IPurchaseOrder POrepository,
            IPurchaseOrderDetailRepository PODrepository, ISaleRepository Srepository,
            ISupplierRepository SPrepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _purchaseOrderRepository = POrepository ?? throw new ArgumentNullException(nameof(POrepository));
            _podRepository = PODrepository ?? throw new ArgumentNullException(nameof(PODrepository));

            _saleRepository = Srepository ?? throw new ArgumentNullException(nameof(Srepository));

            _supplierRepository = SPrepository ?? throw new ArgumentNullException(nameof(SPrepository));
        }

        //pages
        public async Task<IActionResult> Product()
        {
            var products = await _repository.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> PurchaseOrder()
        {
            var purchaseOrders = await _purchaseOrderRepository.GetAllPurchaseOrder();
            return View(purchaseOrders);
        }



        public async Task<IActionResult> PurchaseOrderDetail()
        {
            var pod= await _podRepository.GetAllPOD();
            return View(pod);
        }

        public async Task<IActionResult> Sale()
        {
            var sales = await _saleRepository.GetAllSales();
            return View(sales);
        }

        public async Task<IActionResult> Suppliers()
        {
            var suppliers = await _supplierRepository.GetAllSuppliers();
            return View(suppliers);
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAllProducts() ?? new List<Product>();
            if (products == null)
            {
                products = new List<Product>();
            }

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                
                _repository.AddProduct(model);
                return RedirectToAction("Product");
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _repository.DeleteProduct(id);

            return RedirectToAction("Product");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //methods

        public async Task<IActionResult> Details(int id)
        {
            var Products = await _repository.GetProductById(id);
            if (Products == null)
            {
                return NotFound();
            }
            return View(Products);
        }


        private async Task<bool> ProductExists(int id)
        {
            return await _repository.GetProductById(id) != null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("ProductID, Name, SKU, Price")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Main()
        {
            var products = await _repository.GetAllProducts();
            var purchaseOrder = await _purchaseOrderRepository.GetAllPurchaseOrder();
            var pod = await _podRepository.GetAllPOD();
            var sale = await _saleRepository.GetAllSales();
            var supplier = await _supplierRepository.GetAllSuppliers();

            var viewModel = new MainViewModel
            {
                Products = products,
                PurchaseOrders = purchaseOrder,
                PurchaseOrderDetails = pod,
                Sales = sale,
                Suppliers = supplier
            };

            return View(viewModel);
        }
    }
}
