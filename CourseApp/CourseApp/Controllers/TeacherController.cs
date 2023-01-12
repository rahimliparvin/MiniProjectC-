using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
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

            string teacherNameStr;
            if (string.IsNullOrEmpty(teacherName))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add teacher name");
                goto TeacherName;
            }

            var name = teacherName.Trim();
            if (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct name");
                goto TeacherName;
            }
           

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher surname");
            TeacherSurname: string teacherSurname = Console.ReadLine();

            string teacherSurnameStr;
            if (string.IsNullOrEmpty(teacherSurname))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add teacher surname");
                goto TeacherSurname;
            }

            var surname = teacherSurname.Trim();
            if (!Regex.IsMatch(surname, "^[a-zA-Z]+$"))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct surname");
                goto TeacherSurname;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher address");
            TeacherAddress: string teacherAddress = Console.ReadLine();
            string teacherAddressStr;
            if (string.IsNullOrEmpty(teacherAddress))
            {
                ConsoleColor.DarkRed.WriteConsole("Please add teacher address");
                goto TeacherAddress;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher age");
            Age: string teacherAgeStr = Console.ReadLine();
            int teacherAge;

            bool  isCorrectTeacherAge = int.TryParse(teacherAgeStr, out teacherAge);
            if (isCorrectTeacherAge)
            {
                try
                {
                    Teacher teacher = new Teacher()
                    {
                        Name = teacherName,
                        Surname = teacherSurname,
                        Age = teacherAge,
                        Address = teacherAddress
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
                ConsoleColor.DarkRed.WriteConsole("Please add correct format age");
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

	}
}
