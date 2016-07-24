using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.Mappers
{
    public partial class MapperHelper
    {
        private static readonly object syncLock = new object();

        private static IMapper _mapper;

        private static MapperConfiguration MapperConfiguration { get; set; }

        public static IMapper Mapper
        {
            get
            {
                if (null == _mapper)
                {
                    lock (syncLock)
                    {
                        if (null == _mapper)
                        {
                            InitMapper();
                        }
                    }
                }
                return _mapper;
            }
        }

        private static void InitMapper()
        {
            MapperConfiguration = new MapperConfiguration(ConfigMapper);
            _mapper = MapperConfiguration.CreateMapper();
        }

        private static void ConfigMapper(IMapperConfigurationExpression obj)
        {
            throw new NotImplementedException();
        }
    }
}