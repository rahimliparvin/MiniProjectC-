using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Constans;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GroupService : IGroupService
    {
        private readonly TeacherRepository _teacher;
        private readonly GroupRepository _repo;
        public GroupService()
        {
            _teacher = new TeacherRepository();
            _repo = new GroupRepository();
        }


        private int _count = 1;
        public Group Create(int teacherId, Group group)
        {
            group.Id = _count;
            Group existGroup = _repo.Get(m => m.Name.ToLower() == group.Name.ToLower());
            if (existGroup != null) throw new InvalidGroupException(ResponseMessages.ArgumentNull +
              ". Please use a different group name next time");

            Teacher existTeacher = _teacher.Get(m => m.Id == teacherId);
            if (existTeacher != null)
            {
                group.Teacher = existTeacher;
            }
            else
            {
                throw new NotFoundException(ResponseMessages.NotFound + 
                ". Please add different TeacherId  next time ");
            }
            _repo.Create(teacherId, group);
            _count++;
            return group;

        }
           
        //public Group GetById(int id)
        //{
        //    Group group = _repo.Get(m => m.Id == id);
        //    if (group == null) throw new NotFoundException(ResponseMessages.NotFound);
        //    return group;
        //}

        public List<Group> Search(string searchText)
        {
            List<Group> groups = _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));
            if (groups.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);
            return groups;
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }

        public Group GetGroupById(int id)
        {
            Group group = _repo.Get(m => m.Id == id);
            if (group == null) throw new NotFoundException(ResponseMessages.NotFound);
            return group;
        }

        public Group GetGroupsByCapacity(int capacity)
        {
            Group group = _repo.Get(m => m.Capacity == capacity);
            if (group == null) throw new NotFoundException(ResponseMessages.NotFound);
            return group;
            //Group result = _repo.Get(m => m.Capacity == capacity);
            //if (result == null) throw new NotFoundException(ResponseMessages.NotFound);
            // return result;
        }

        public List<Group> GetGroupsByTeacherId()
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroupsByTeacherName()
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroupsCount()
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

               Group dbGroup = _repo.Get(m => m.Id == id);

               if (dbGroup == null) ConsoleColor.DarkRed.WriteConsole(ResponseMessages.NotFound);

                _repo.Delete(dbGroup);
        }

        //public void Delete(int?id group)
        //{

        //    if (id is null) throw new ArgumentNullException();

        //    Group dbGroup = _repo.Get(m => m.Id == id);

        //    if (dbGroup == null) ConsoleColor.DarkRed.WriteConsole(ResponseMessages.NotFound);

        //    _repo.Delete(dbGroup);
        //}


    }
}


