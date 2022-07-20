using AutoMapper;
using MoviesWatchlist.Domain.Entities;
using MoviesWatchlist.Domain.Models;

namespace MoviesWatchlist.Service.Mapper;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<WatchListItem, MovieItem>();
        CreateMap<MovieItem, WatchListItem>();
    }
}