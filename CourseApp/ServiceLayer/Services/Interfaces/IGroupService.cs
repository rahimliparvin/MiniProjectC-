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
        Group Delete(int? group);
        Group GetGroupById(int id);  
        List<Group> GetAll();
        List<Group> Search(string searchText);
        Group Update(int id,Group group);
        List<Group> GetGroupsByCapacity();
        List<Group> GetGroupsByTeacherId();
        List<Group> GetAllGroupsByTeacherName();
        Group SearchMethodForGroupByName();
        List<Group> GetAllGroupsCount();


    }
}
