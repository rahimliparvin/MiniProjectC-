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
            ConsoleColor.DarkCyan.WriteConsole("Please add group name:");
            string groupName = Console.ReadLine();

            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity:");
        GroupCapacity: string groupCapacityStr = Console.ReadLine();

            int groupCapacity;

            bool isCorrectGroupCapacity = int.TryParse(groupCapacityStr, out groupCapacity);
            if (!isCorrectGroupCapacity)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format group capacity");
                goto GroupCapacity;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id:");
        TeacherId: string groupTeacherIdStr = Console.ReadLine();

            int groupTeacherId;
            bool isCorrectGroupTeacherId = int.TryParse(groupTeacherIdStr, out groupTeacherId);

            if (isCorrectGroupTeacherId)
            {
              
                Group group = new Group()
                {
                    
                    Name = groupName,
                    Capacity = groupCapacity,
                    CreateDate= DateTime.Now,
                
                };
                var  res =  _groupService.Create(groupTeacherId , group);
                ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
                        $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} Teacher:{res.Teacher.Name}");
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format teacher id");
                goto TeacherId;
            };
        }
        //public void GetById()
        //{
        //    ConsoleColor.DarkCyan.WriteConsole("Please add Id");
        //Id: string idStr = Console.ReadLine();

        //    int id;

        //    bool isCorrectId = int.TryParse(idStr, out id);
        //    if (isCorrectId)
        //    {
        //        try
        //        {
        //       //     var respons = _groupService.GetById(id);
        //            ConsoleColor.Green.WriteConsole($"Id:{respons.Id} Name:{respons.Name}" +
        //                $" Capacity:{respons.Capacity} Teacher{respons.Teacher} ");
        //        }
        //        catch (Exception ex)
        //        {
        //            ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again id");
        //            goto Id;
        //        }
        //    }
        //    else
        //    {
        //        ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
        //        goto Id;
        //    }
            
        //}
        public void Search()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
            Searchtext: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("Please  dont empty search text");
                goto Searchtext;
            }

            try
            {
                var response = _groupService.Search(searchText);

                foreach (var item in response)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id} Name:{item.Name} " +
                       $"Capacity:{item.Capacity} Create:{item.CreateDate} Teacher:{item.Teacher}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add search text again");
                goto Searchtext;
            }

        }


    }
}