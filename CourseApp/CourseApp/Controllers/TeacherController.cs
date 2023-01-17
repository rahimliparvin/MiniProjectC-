using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CourseApp.Controllers
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;
        public TeacherController()
        {
            _teacherService = new TeacherService();
        }
        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher name");
        TeacherName: string teacherName = Console.ReadLine();

            var name = teacherName.Trim();
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$")) 
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct name");
                goto TeacherName;
            };

        
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher surname");
        TeacherSurname: string teacherSurname = Console.ReadLine();

            var surname = teacherSurname.Trim();
            if (!Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct surname");
                goto TeacherSurname;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher address");
            TeacherAddress: string teacherAddress = Console.ReadLine();
            var address = teacherAddress.Trim();
            if(address == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("Address cannot be empty! Please add address");
                goto TeacherAddress;
            }
          
      
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher age");
            Age: string teacherAgeStr = Console.ReadLine();
            int teacherAge;

            bool  isCorrectTeacherAge = int.TryParse(teacherAgeStr, out teacherAge);
            if (isCorrectTeacherAge && teacherAge >= 18 && teacherAge < 66)
            {
                try
                {
                    Teacher teacher = new Teacher()
                    {
                        Name = name,
                        Surname = surname,
                        Age = teacherAge,
                        Address = address
                    };
                    var response = _teacherService.Create(teacher);
                    ConsoleColor.Green.WriteConsole($"Id:{response.Id} Name:{response.Name} " +
                        $"Surname:{response.Surname} Age:{response.Age} Address:{response.Address}");
                }

                catch (Exception ex)
                {
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add teacher name again");
                    goto TeacherName;
                }
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format age. Age limit [min 18 ,max 65] ");
                goto Age;
            }

        }
        public void GetAll()
        {
            var result = _teacherService.GetAll();

            if (result.Count == 0)
            {
                ConsoleColor.DarkRed.WriteConsole("Data not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id:{item.Id} Name:{item.Name} " +
                      $"Surname:{item.Surname} Age:{item.Age} Address:{item.Address}");
                }
               
            }
        }
        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id for delete:");
            TeacherId: string teacherId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(teacherId, out id);

            if (isCorrectId)
                try
                {
                    _teacherService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully delete");
                }
                catch (Exception ex)
                {
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add teacher id again");
                    goto TeacherId;
                }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
                goto TeacherId;
            }
        }
        public void Search()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
            Searchtext: string searchText = Console.ReadLine();
            var text = searchText.Trim();

            if (!Regex.IsMatch(text, "^[A-Za-z ]+$") || text == string.Empty)
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format search text");
                goto Searchtext;
            }  

            try
            {
                var response = _teacherService.Search(searchText);

                foreach (var item in response)
                {
                   ConsoleColor.Green.WriteConsole($"Id:{item.Id} Name:{item.Name} " +
                      $"Surname:{item.Surname} Age:{item.Age} Address:{item.Address}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add different search text");
                goto Searchtext;
            }
           
        }
        public void GetByTeacherId()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add Id");
            Id: string idStr = Console.ReadLine();
           
            int id;
            
            bool isCorrectId = int.TryParse(idStr, out id);
            if (isCorrectId)
            {
                try
                {
                    var respons = _teacherService.GetByTeacherId(id);
                    ConsoleColor.Green.WriteConsole($"Id:{respons.Id} Name:{respons.Name} " +
                          $"Surname:{respons.Surname} Age:{respons.Age} Address:{respons.Address}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again id");
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
                goto Id;
            }

        }
        public void Update()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
            Id:  string teacherIdStr = Console.ReadLine();

            int teacherId;
            bool isCorrectTeacherId = int.TryParse(teacherIdStr, out teacherId);
          
            if (isCorrectTeacherId && teacherId >= 1)
            {
                var result = _teacherService.Update(teacherId);
                if (result != null)
                {
                    try
                    {
                        result.Id = teacherId;
                        teacherId = result.Id;
                        result.Id = teacherId;
                    }
                    catch (Exception ex)
                    {
                        ConsoleColor.DarkRed.WriteConsole(ex.Message + "/" + "Please add again id");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleColor.DarkRed.WriteConsole("Data not found");
                    ConsoleColor.DarkRed.WriteConsole("Please add different id");
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format id");
                goto Id;
            }
                
            var result1 = _teacherService.Update(teacherId);

            ConsoleColor.DarkCyan.WriteConsole("Please add new teacher name");
            TeacherNewName: string teacherNewName = Console.ReadLine();

            var teacherName = teacherNewName.Trim();
            if (teacherName != string.Empty)
            {
                if (!Regex.IsMatch(teacherName, "^[a-zA-Z]+$"))
                {
                    ConsoleColor.DarkRed.WriteConsole("Please add correct format name");
                    goto TeacherNewName;
                }
                else
                {
                    result1.Name = teacherName;
                    teacherName = result1.Name;
                    result1.Name = teacherName;
                }

            }
            else
            {
                teacherNewName = result1.Name;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add new teacher surname");
            TeacherNewSurname: string teacherNewSurname = Console.ReadLine();

            var teacherSurname = teacherNewSurname.Trim();
            if (teacherSurname != string.Empty)
            {
                if (!Regex.IsMatch(teacherSurname, "^[a-zA-Z]+$"))
                {
                    ConsoleColor.DarkRed.WriteConsole("Please add correct format surname");
                    goto TeacherNewSurname;
                }
                else
                {
                    result1.Surname = teacherSurname;
                    teacherSurname = result1.Surname;
                    result1.Surname = teacherSurname;

                }

            }
            else
            {
                teacherNewSurname = result1.Surname;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add new teacher address");
            TeacherNewAddress: string teacherNewAddress = Console.ReadLine();
            var teacherAddress = teacherNewAddress;

            if (teacherAddress != string.Empty)
            {
                    result1.Address = teacherAddress;
                    teacherAddress = result1.Address;
                    result1.Address = teacherAddress;
            }
            else
            {
                teacherNewAddress = result1.Address;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add new teacher age");
            TeacherNewAge: string teacherNewAgeStr= Console.ReadLine();

            var name3 = teacherNewAgeStr;
            int teacherNewAge;
            bool isCorrectTeacherNewAge = int.TryParse(teacherNewAgeStr, out teacherNewAge);

            if (isCorrectTeacherNewAge && teacherNewAge >= 18 && teacherNewAge < 66)
            {
                    result1.Age = teacherNewAge;
                    teacherNewAge = result1.Age;
                    result1.Age = teacherNewAge;
            }
            else
            {
                if (!Regex.IsMatch(name3, "[^\\s]+(\\s.*)?$"))
                {
                    
                    teacherNewAge = result1.Age;
                }
                else
                {
                    ConsoleColor.DarkRed.WriteConsole("Please add correct format age. Age limit [min 18, max 65]");
                    goto TeacherNewAge;
                }
            }

            Teacher teacher = new Teacher()
            {
                Id = teacherId,
                Name = teacherNewName,
                Surname = teacherNewSurname,
                Address = teacherNewAddress,
                Age = teacherNewAge
            };
            ConsoleColor.Green.WriteConsole($"Id:{teacher.Id} Name:{teacher.Name} " +
                $"Surname:{teacher.Surname} Age:{teacher.Age} Address:{teacher.Address}");
            ConsoleColor.DarkGreen.WriteConsole("You have successfully updated");
        }
    }
}
