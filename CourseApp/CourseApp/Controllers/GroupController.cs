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
        GroupName: string groupName = Console.ReadLine();

            if (groupName == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format name");
                goto GroupName;
            }


            //ConsoleColor.DarkCyan.WriteConsole("Please add teacher id:");
            //TeacherId: string groupTeacherIdStr = Console.ReadLine();

            //int groupTeacherId;
            //bool isCorrectGroupTeacherId = int.TryParse(groupTeacherIdStr, out groupTeacherId);

            //if (!isCorrectGroupTeacherId)
            //{
            //    ConsoleColor.DarkRed.WriteConsole("Please add correct  format id");
            //    goto TeacherId;
            //}

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
                    CreateDate = DateTime.Now,

                };
                try
                {
                    var res = _groupService.Create(groupTeacherId, group);

                    ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
                            $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
                            $"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} TeacherAddress {res.Teacher.Address}");

                }
                catch (Exception ex)
                {
                    
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again GroupName");
                    goto GroupName;
                    //ConsoleColor.DarkRed.WriteConsole("Please add new group name");
                    //goto GroupName;

                }
            
        
            //Group group = new Group()
            //{

            //    Name = groupName,
            //    Capacity = groupCapacity,
            //    CreateDate = DateTime.Now,

            //};
            //try
            //{
            //    var res = _groupService.Create(groupTeacherId, group);

            //    ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
            //            $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
            //            $"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} TeacherAddress {res.Teacher.Address}");

            //}
            //catch (Exception ex)
            //{

            //    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "This name is used");
            //    ConsoleColor.DarkRed.WriteConsole("Please add new group name");
            //    goto GroupName;


            //if (!isCorrectGroupTeacherId)
            //{
            //    ConsoleColor.DarkRed.WriteConsole("Please add correct  format id");
            //}

            //    if (isCorrectGroupTeacherId)
            //    {
            //        try
            //        {
            //            Group group = new Group()
            //            {

            //                Name = groupName,
            //                Capacity = groupCapacity,
            //                CreateDate = DateTime.Now,

            //            };
            //            var res = _groupService.Create(groupTeacherId, group);

            //        }
            //        catch (Exception ex)
            //        {
            //            ConsoleColor.DarkRed.WriteConsole(ex.Message);
            //        }

            //    }
            //    else
            //    {
            //        ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
            //    }
            //    var res = _groupService.Create(groupTeacherId, group);
            //ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
            //$"Capacity:{res.Capacity} CreateDate:{res.CreateDate} TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
            //$"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} TeacherAddress {res.Teacher.Address}");


            //catch (Exception ex)
            //{

            //    ConsoleColor.DarkRed.WriteConsole(ex.Message);
            //  //  ConsoleColor.DarkRed.WriteConsole("Please add new group name");




            //if (groupName == null)
            //{
            //    ConsoleColor.DarkRed.WriteConsole("Please add correct format name:");
            //    goto GroupName;
            //}

            //if (groupName == string.Empty)
            //{
            //    ConsoleColor.DarkRed.WriteConsole("Please add correct format name:");
            //    goto GroupName;
            //}
            //else
            //{
            //    Group group = new Group()
            //    {

            //        Name = groupName,
            //        Capacity = groupCapacity,
            //        CreateDate = DateTime.Now,

            //    };
            //    try
            //    {
            //        var res = _groupService.Create(groupTeacherId, group);

            //        ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
            //                $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
            //                $"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} TeacherAddress {res.Teacher.Address}");

            //    }
            //    catch (Exception ex)
            //    {

            //        ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "This name is used");
            //        ConsoleColor.DarkRed.WriteConsole("Please add new group name");
            //        goto GroupName;
            //    }
            //}

            //ConsoleColor.DarkCyan.WriteConsole("Please add teacher id:");
            //TeacherId: string groupTeacherIdStr = Console.ReadLine();

            //int groupTeacherId;
            //bool isCorrectGroupTeacherId = int.TryParse(groupTeacherIdStr, out groupTeacherId);

            //if (!isCorrectGroupTeacherId)
            //{
            //    ConsoleColor.DarkRed.WriteConsole("Please add correct  format id");
            //}



            //Group group = new Group()
            //{

            //    Name = groupName,
            //    Capacity = groupCapacity,
            //    CreateDate = DateTime.Now,

            //};
            //try
            //{
            //    var res = _groupService.Create(groupTeacherId, group);

            //    ConsoleColor.Green.WriteConsole($"Id:{res.Id} Name:{res.Name} " +
            //            $"Capacity:{res.Capacity} CreateDate:{res.CreateDate} TeacherId {res.Teacher.Id} TeacherName {res.Teacher.Name} " +
            //            $"TeacherSurname {res.Teacher.Surname} TeacherAge {res.Teacher.Age} TeacherAddress {res.Teacher.Address}");

            //}
            //catch (Exception ex)
            //{

            //    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "This name is used");
            //    ConsoleColor.DarkRed.WriteConsole("Please add new group name");
            //    goto GroupName;

            //}
        }
    }    
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
        public void GetAll()
        {
            var result = _groupService.GetAll();
            if (result.Count == 0)
            {
                ConsoleColor.DarkRed.WriteConsole("Data  not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id} Name:{item.Name} " +
                            $"Capacity:{item.Capacity} CreateDate:{item.CreateDate} TeacherId {item.Teacher.Id} TeacherName {item.Teacher.Name} " +
                            $"TeacherSurname {item.Teacher.Surname} TeacherAge {item.Teacher.Age} TeacherAddress {item.Teacher.Address}");
                }
            }
        }
    }
}            