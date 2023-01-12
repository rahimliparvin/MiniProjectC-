using DomainLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
 
    public class TeacherService : ITeacherService
    {
        private readonly TeacherRepository _repo;

        private int _count  = 1;
        public TeacherService()
        {
            _repo= new TeacherRepository();
        }
        public Teacher Create(Teacher teacher)
        {
            teacher.Id = _count;
            _repo.Create(teacher);
            _count++;
            return teacher;
        }

        public Teacher Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> Search(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
