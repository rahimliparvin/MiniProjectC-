using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(int id ,Group group);
        void Delete(int? id);
        Group GetGroupById(int id);    
        List<Group> Search(string searchText);
        Group Update(int id,Group group);
        List<Group> GetGroupsByCapacity(int capacity);
        List<Group> GetGroupsByTeacherId(int id);
        List<Group> GetAllGroupsByTeacherName(string text);
        List<Group> GetAllGroupsCount();


    }
}
