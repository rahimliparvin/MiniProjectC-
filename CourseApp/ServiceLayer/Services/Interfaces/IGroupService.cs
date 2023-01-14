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
        Group Create(Group group);
        Group Delete(int? group);
        Group GetById(int id);  
        List<Group> GetAll();
        List<Group> Search(string searchText);
        Group Update(int id,Group group);

    }
}
