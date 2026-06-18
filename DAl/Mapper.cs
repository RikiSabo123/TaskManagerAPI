using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.models;
namespace DAL
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<UsersDTO, User>();
            CreateMap<User, UsersDTO>();
            CreateMap<CategoriesDTO, Category>();
            CreateMap<Category, CategoriesDTO>();
            CreateMap<TasksDTO, models.Task>();
            CreateMap<models.Task, TasksDTO>();
        }
    }
}
