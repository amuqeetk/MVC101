using AutoMapper;
using MVC001.Models;
using MVC001.ViewModels;

namespace MVC001.Mappers
{
    public partial class MapperHelper
    {
        private static void ConfigMapperForAuthor(IMapperConfigurationExpression cfg)
        {
            
        }

        public static AuthorViewModel ToViewModel(this Author author)
        {
            return Mapper.Map<Author, AuthorViewModel>(author);
        }
    }
}