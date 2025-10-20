using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quiz.BLL.Service.Product;
using Quiz.DAL.Models.Products;
namespace Quiz_PL.Controllers.Products;

public class ProductController : Controller
{
    private readonly IProductService service;
    private readonly ILogger<ProductController> logger;
    private readonly IWebHostEnvironment webHost;

    public ProductController(IProductService service, ILogger<ProductController> logger, IWebHostEnvironment webHost)
    {
        this.service = service;
        this.logger = logger;
        this.webHost = webHost;
        //deptService = DeptService;
    }




    public IActionResult Index()
    {

        var Products = service.GetAllProducts();
        return View(Products);

    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Quiz.DAL.Models.Products.Product product)
    {
        if (ModelState.IsValid)
        {
            service.AddProduct(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = service.GetPRoductById(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        service.UpdateProduct(product);
        TempData["Success"] = "Product updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var product = service.GetPRoductById(id);
        if (product == null)
            return NotFound();

        return View(product);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        service.DeleteProduct(id);
        TempData["Success"] = "Product deleted successfully!";
        return RedirectToAction(nameof(Index));
    }

}
