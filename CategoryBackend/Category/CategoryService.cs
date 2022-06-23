using AutoMapper;
using CategoryBackend.Category;
using CategoryBackend.Helpers;
using CategoryBackend.MyContext.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.Services
{
    public class CategoryService
    {
        private readonly IRepository<CategoryModel> _context;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<CategoryModel> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return _context.Find(x => x.isActive == 1);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _context.GetById(id);

            if (category == null)
            {
                return new CategoryDTO();
            }
            //var data = TipoUsuarioDTO.DeModeloADTO(tipoUsuario);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public async Task<Response> PostCategory(CategoryModel category)
        {

            var SavedCategory = await _context.GetById(category.id);
            if (SavedCategory != null)
            {
                return new Response
                {
                    Status = "Failed",
                    Message = "This category already exists!"
                };
            }
            //var tipoUsuario = TipoUsuarioDTO.DeDTOAModelo(tipoUsuarioDTO);
            _context.Add(category);
            _context.SaveChanges();
            return new Response
            {
                Status = "Sucess",
                Message = "Category Added sucefully"
            };
        }

        public async Task<Response> PutCategory(CategoryDTO categoryDTO)
        {

            var currentCategoryDTO = await GetById(categoryDTO.id);
            if (currentCategoryDTO != null)
            {
                var currentCategory = _mapper.Map<CategoryModel>(categoryDTO);
                _context.Update(currentCategory);
                _context.SaveChanges();
                return new Response
                {
                    Status = "Sucess",
                    Message = $"Category {categoryDTO.name} modified correctly!"
                };
            }
            return new Response
            {
                Status = "Failed",
                Message = $"Category {categoryDTO.name} does not exist!"
            };
        }

        public async Task<Response> DeleteCategory(CategoryDTO categoryDTO)
        {
            var currentCategoryDTO = await GetById(categoryDTO.id);
            if (currentCategoryDTO != null)
            {
                var currentCategory = _mapper.Map<CategoryModel>(categoryDTO);

                currentCategory.isActive = 0;
                _context.Update(currentCategory);
                _context.SaveChanges();
                return new Response
                {
                    Status = "Sucess",
                    Message = $"Category {categoryDTO.name} deleted correctly!"
                };
            }
            return new Response
            {
                Status = "Failed",
                Message = $"Category {categoryDTO.name} does not exist!"
            };
        }
    }
}
