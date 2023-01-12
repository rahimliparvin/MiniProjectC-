using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher Create(Teacher teacher);
        Teacher Delete(int Id);
        Teacher GetById(int Id);
        List<Teacher> Search(string searchText);
        List<Teacher> GetAll();
    }
}
