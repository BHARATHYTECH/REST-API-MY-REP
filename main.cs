namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Azure",Designation="UI Developer",Address="cuddalore" },
        new Product { Id = 2, Name = "AWS",Designation="software Developer",Address="cuddalore" },
        new Product { Id = 3, Name = "GCP",Designation="Developer",Address="cuddalore" }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.Find(x => x.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
     [HttpGet("{Designation}")]
     public IActionResult GetByDesignation(String Designation)
    {
        var product = _products.Find(x => x.Designation == Designation);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}
