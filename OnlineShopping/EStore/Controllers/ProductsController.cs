using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStore.Models;
using BOL;
using SAL;

namespace EStore.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }
 
    //Action Method
    [HttpGet]
    public IActionResult Index()
    {
        /*  Using Collections Only  */
        // ProuductHubService svc=new ProuductHubService();
        // List<Product> allProducts=svc.GetAllProducts();
        // this.ViewData["products"]=allProducts;
        // return View();


        /*  Using File IO & Collections  */
        ProductHubService svc = new ProductHubService();
        List<Product> allProducts = svc.GetAllProducts();
        Console.WriteLine("Product Count" +allProducts.Count);
        this.ViewBag.catalog=allProducts;
        TempData["dataFromIndex"] = "This is data from Index view of Produts";
        return View();


    }

    //http://localhost:7654/products/details/45
    [HttpGet]
    public IActionResult Details(int id)
    {
        /*  Using Collections Only  */
        // return View();


        /*  Using File IO & Collections  */
        ProductHubService svc = new ProductHubService();
        Product product = svc.GetProductById(id);
        Console.WriteLine(product.Title + " " + product.ProductId);
        
        ViewBag.currentProduct = product;

        return View();
    }

}
