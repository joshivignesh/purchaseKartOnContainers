using CatalogAPI.Models;
using CatalogAPI.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CatalogController : ControllerBase
    {
        private IRepository<Product> repository;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration configuration;

        private static CloudStorageAccount storageAccount;


        public CatalogController(IRepository<Product> repo, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.repository = repo;
            _hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }

        //GET /api/images
        [HttpGet("", Name = "ListProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return this.repository.GetAll();
        }


        [HttpGet("{id:int}", Name = "GetBlog")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var item = await this.repository.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            else
                return item;
        }

        [HttpPost("", Name = "AddProduct")]
        public async Task<ActionResult<Product>> AddProduct()
        {
            //ConnectionString = configuration.GetValue<string>("StorageConnectionString");
            Product product = new Product();
            var file = Request.Form.Files[0];
            product.Name = Request.Form["productName"].ToString();
            product.Cost = Convert.ToInt32(Request.Form["Price"]);
            string filePath = $@"{Path.Combine(_hostingEnvironment.WebRootPath, "images")}\{Path.GetFileName(file.FileName)}";

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                product.ImageUrl = await UploadImage(filePath, "myfiles");
            }
            var result = await this.repository.AddAsync(product);
            return result;
        }

        public static async Task<string> UploadImage(string imagePath, string containerName)
        {
            var fileName = Path.GetFileName(imagePath);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(fileName);
            await blob.UploadFromFileAsync(imagePath);
            return blob.Uri.AbsoluteUri;

        }




    }
}