using AutoMapper;
using WebAppGeek.Abstraction;
using WebAppGeek.Data;
using WebAppGeek.Dto;
using WebAppGeek.Models;

namespace WebAppGeek.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;
        public ProductGroupRepository(StorageContext storageContext, IMapper mapper)
        {
            this.storageContext = storageContext;
            this._mapper = mapper;
        }
        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (storageContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
                throw new Exception("Уже есть группа с таким именем");

            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            storageContext.ProductGroups.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;
        }

        public void DeleteProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroupDto> GetAllProductGroups()
        {
            var listDto = storageContext.ProductGroups.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
        }
    }
}