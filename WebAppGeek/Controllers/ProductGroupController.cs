using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Abstraction;
using WebAppGeek.Data;
using WebAppGeek.Dto;
using WebAppGeek.Models;
using WebAppGeek.Repository;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupController(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }
        [HttpPost]
        public ActionResult<int> AddProductGroup(ProductGroupDto productGroupDto)
        {
            try
            {
                var id = _productGroupRepository.AddProductGroup(productGroupDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductGroup>> GetAllProductGroups()
        {
            return Ok(_productGroupRepository.GetAllProductGroups());
        }
        [HttpDelete]
        public ActionResult DeleteProductGroup(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var productGroup = storageContext.ProductGroups.FirstOrDefault(p => p.Id == id);
                if (productGroup != null)
                {
                    storageContext.ProductGroups.Remove(productGroup);
                    storageContext.SaveChanges();
                    return Ok();
                }
                return StatusCode(404, "Нет группы с таким ID");
            }
        }
    }
}