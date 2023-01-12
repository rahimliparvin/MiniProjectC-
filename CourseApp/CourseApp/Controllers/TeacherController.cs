using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

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

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher surname");
            string teacherSurname = Console.ReadLine();

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher address");
            string teacherAddress = Console.ReadLine();

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
                    ConsoleColor.DarkRed.WriteConsole(ex.Message);
                    goto TeacherName;
                }
            }
            else
            {
                ConsoleColor.DarkRed.WriteConsole("Please add correct format age");
                goto Age;
            }

        }
    }
}
