﻿using DomainLayer.Entities;
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

            var nameGroup = groupName.Trim();
            if ( nameGroup == string.Empty)
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
                if (groupCapacity > 40 || groupCapacity < 1)
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
            bool isCorrectId = int.TryParse(idStr, out id);
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
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different id");
                    goto Id;

                }

            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id.id min = 1");
                goto Id;
            }


        }
        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group id for delete:");
        GroupId: string groupId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(groupId, out id);

            if (isCorrectId && id >= 1)
                try
                {
                    _groupService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully delete group");
                }
                catch (Exception ex)
                {
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add group id again");
                    goto GroupId;
                }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id.Id limit [min 1] ");
                goto GroupId;
            }
        }
        public void GetGroupsByCapacity()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group  capacity");
        Capacity: string groupCapacityStr = Console.ReadLine();

            int groupCapacity;
            bool isCorrectGroupCapacity = int.TryParse(groupCapacityStr, out groupCapacity);
            if (isCorrectGroupCapacity && groupCapacity > 0 && groupCapacity < 40)
            {
                try
                {
                    var groupsCapacity = _groupService.GetGroupsByCapacity(groupCapacity);

                    foreach (var item in groupsCapacity)
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

                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different capacity");
                    goto Capacity;

                }

            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Pease add correct format capacity. Capacity limit[min 1,max 40]");
                goto Capacity;
            }
        }
        public void GetGroupsByTeacherId()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add id");
        TeacherId: string teacherIdStr = Console.ReadLine();

            int teacherId;
            bool isCorrectId = int.TryParse(teacherIdStr, out teacherId);
            if (isCorrectId && teacherId > 0)
            {
                try
                {
                    var groupsTeacherId = _groupService.GetGroupsByTeacherId(teacherId);

                    foreach (var item in groupsTeacherId)
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
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different teacher id");
                    goto TeacherId;
                }
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
                goto TeacherId;
            }
        }
        public void GetAllGroupsByTeacherName()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher name");
            TeacherName: string teacherName = Console.ReadLine();
            var nameTeacher = teacherName.Trim();
            if (!Regex.IsMatch(nameTeacher, "^[a-zA-Z]+$") || nameTeacher == string.Empty)
            { 
               ConsoleColor.DarkRed.WriteConsole("Please add correct format teacher name");
                goto TeacherName;

            }
            else
            {
                try
                {
                    var groupsByTeacherName = _groupService.GetAllGroupsByTeacherName(teacherName);
                    foreach (var item in groupsByTeacherName)
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

                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different teacher name");
                    goto TeacherName;
                }
            }
        }
        public void SearchMethodForGroupByName()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group name :");
            Searchtext: string searchText = Console.ReadLine();
            var nameSearch = searchText.Trim();

            if (  nameSearch == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("It cannot be empty group name");
                goto Searchtext;
            }

            try
            {
                var response = _groupService.Search(searchText.Trim());

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
                ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different name");
                goto Searchtext;
            }

        }
        public void GetAllGroupsCount()
        {

           


            var groups = _groupService.GetAllGroupsCount();

            if (groups.Count >= 1 )
            {
                ConsoleColor.Green.WriteConsole("Groups count: " + groups.Count.ToString());
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Data not found");
            }
        }
    }
}
