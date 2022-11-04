using AutoMapper;
using RedTechnologies.App.Command;
using RedTechnologies.App.ViewModel;
using RedTechnologies.Repository.Models;

namespace RedTechnologies.App.Mapper
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderCommand, Order>();
            CreateMap<UserCommand, User>();

        }
    }
}
