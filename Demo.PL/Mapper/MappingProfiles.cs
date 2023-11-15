using AutoMapper;
using Demo.DAL.Enitities;
using Demo.PL.Models;

namespace Demo.PL.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
           
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }

    }
}
