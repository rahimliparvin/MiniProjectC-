using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Text.RegularExpressions;
using Group = DomainLayer.Entities.Group;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constans;
using System.Numerics;

namespace CourseApp.Controllers
{

    public class GroupController
    {
        private readonly IGroupService _groupService;

        public GroupController()
        {
            _groupService = new GroupService();
        }


        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id:");
            TeacherId: string groupTeacherIdStr = Console.ReadLine();

            int groupTeacherId;
            bool isCorrectGroupTeacherId = int.TryParse(groupTeacherIdStr, out groupTeacherId);
            if (!isCorrectGroupTeacherId || groupTeacherId < 1)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct  format id");
                goto TeacherId;
            }
           
            ConsoleColor.DarkCyan.WriteConsole("Please add group name:");
            GroupName: string groupName = Console.ReadLine();

            var name4 = groupName;
            if(!Regex.IsMatch(name4 , @"^[a-zA-Z0-9]+$") || groupName == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format name");
                 goto GroupName;
            }
        
            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity:");
            GroupCapacity: string groupCapacityStr = Console.ReadLine();

            int groupCapacity;

            bool isCorrectGroupCapacity = int.TryParse(groupCapacityStr, out groupCapacity);
            if (!isCorrectGroupCapacity)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format group capacity:");
                goto GroupCapacity;
            }
            else
            {
                if(groupCapacity > 40 || groupCapacity < 1)
                {
                    ConsoleColor.DarkRed.WriteConsole("The capacity of the group is [min 1,max 40]." +
                  " Please enter the appropriate capacity for the group capacity:");
                    goto GroupCapacity;

                }
            }

            Group group = new Group()
            {

                Name = groupName,
                Capacity = groupCapacity,
                CreateDate = DateTime.Now,

            };
            try
            {
                var res = _groupService.Create(groupTeacherId, group);

                ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
                $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} " +
                $"TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
                $"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} " +
                $"TeacherAddress {res.Teacher.Address}");

            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again TeacherId");
                goto TeacherId;
            }
        }
        public void GetGroupById()
        {
            
            ConsoleColor.DarkCyan.WriteConsole("Please add Id");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectId =  int.TryParse(idStr, out id);
            if (isCorrectId && id >= 1)
            {
                try
                {
                    var result = _groupService.GetGroupById(id);

                    ConsoleColor.Green.WriteConsole($"Id:{result.Id} Name:{result.Name} " +
                    $"Capacity:{result.Capacity} CreateDate:{result.CreateDate} " +
                    $"TeacherId {result.Teacher.Id} TeacherName {result.Teacher.Name} " +
                    $"TeacherSurname {result.Teacher.Surname} TeacherAge {result.Teacher.Age} " +
                    $"TeacherAddress {result.Teacher.Address}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.DarkRed.WriteConsole(ex.Message);
                   
                }
               
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id.id min = 1");
                goto Id;
            }
         

        }
        public void SearchMethodForGroupByName()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
        Searchtext: string searchText = Console.ReadLine();
           var name5 = searchText;

            if (!Regex.IsMatch(name5, @"^[a-zA-Z0-9]+$") || searchText == string.Empty )
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format search text");
                goto Searchtext;
            }

            try
            {
                var response = _groupService.Search(searchText);

                foreach (var item in response)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id} Name:{item.Name} " +
                $"Capacity:{item.Capacity} CreateDate:{item.CreateDate} " +
                $"TeacherId {item.Teacher.Id} TeacherName {item.Teacher.Name} " +
                $"TeacherSurname {item.Teacher.Surname} TeacherAge {item.Teacher.Age} " +
                $"TeacherAddress {item.Teacher.Address}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.WriteConsole(ex.Message);
            }

        }
       

        }
}            