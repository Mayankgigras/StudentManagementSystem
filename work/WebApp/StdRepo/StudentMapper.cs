using AutoMapper;
using DAL.Models;

namespace WebApp.StdRepo
{
    public class StudentMapper:Profile
    {
        public StudentMapper() 
        {
            CreateMap<Student, Models.Student>();
            CreateMap<Marks, Models.Marks>();
            CreateMap<Models.Student, Student>();
        }
       
    }
}
