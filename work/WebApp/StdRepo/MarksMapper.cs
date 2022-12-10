
using AutoMapper;
using DAL.Models;

namespace WebApp.StdRepo
{
    public class MarksMapper:Profile
    {
       public MarksMapper() 
        {
            CreateMap<Marks, Models.Marks>();
            CreateMap<Models.Marks, Marks>();
        }
    }
}
