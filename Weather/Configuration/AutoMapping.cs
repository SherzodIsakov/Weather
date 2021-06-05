using AutoMapper;
using System;
using Weather.Entities.JsonModels;
using Weather.Entities.Models;

namespace Weather.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<WeatherEntity, TemperatureModel>()
                .ForMember(x => x.City, q => { q.MapFrom(w => w.Name); })
                .ForMember(x => x.Temperature, q => { q.MapFrom(w => w.mainTemp.Temp); });

            CreateMap<WeatherEntity, WindModel>()
              .ForMember(x => x.City, q => { q.MapFrom(w => w.Name); })
              .ForMember(x => x.Speed, q => { q.MapFrom(w => w.wind.Speed); })
              .ForMember(x => x.Degree, q => { q.MapFrom(w => w.wind.Deg); })
              .ForMember(x => x.Direction, q => { q.MapFrom(w => w.wind.Deg); });

            CreateMap<Futures, FuturesModel>()
                .ForMember(x => x.City, q => { q.MapFrom(w => w.City.Name); })
                .ForMember(x => x.FutureModel, q => { q.MapFrom(w => w.FutureEntity); });

            CreateMap<FutureEntity, FutureModel>()
              .ForMember(x => x.Date, q => { q.MapFrom(w => w.Date); })
              .ForMember(x => x.Temperature, q => { q.MapFrom(w => w.mainTemp.Temp); });
        }
    }
}
