using AutoMapper;
using EndPointParametersTask.Models;
using EndPointParametersTask.Models.DTOs;
using EndPointParametersTask.Repositories;

namespace EndPointParametersTask.Services
{
    //Service layer for managing product-related business logic.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OutputProductDTO>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            var products = await _repository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<OutputProductDTO>>(products);
        }

        public async Task<OutputProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<OutputProductDTO>(product);
        }

        public async Task<OutputProductDTO> AddProductAsync(InputProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.AddAsync(product);
            return _mapper.Map<OutputProductDTO>(product);
        }

        public async Task<OutputProductDTO?> UpdateProductAsync(int id, InputProductDTO productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return null;

            // Update product properties using AutoMapper
            _mapper.Map(productDto, product);
            await _repository.UpdateAsync(product);

            return _mapper.Map<OutputProductDTO>(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
