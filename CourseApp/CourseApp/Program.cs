using CourseApp.Controllers;
using ServiceLayer.Helpers;

TeacherController teacherController = new();


while (true)
{
    GetOptions();

    Option: string option = Console.ReadLine();

    int selectedOption;

    bool isCorrectOption = int.TryParse(option, out selectedOption);

    if (isCorrectOption)
    {
        switch (selectedOption)
        {
            case 1:
                teacherController.Create();
                break;
            case 2:
                Console.WriteLine("GetAll");
                break;
            case 3:
                Console.WriteLine("Delete");
                break;
            default:
                ConsoleColor.DarkRed.WriteConsole("Please add correct option");
                goto Option;
               
        }
    }
    else
    {
        ConsoleColor.DarkRed.WriteConsole("Please add correct format option");
       goto Option;
    }
}

static  void GetOptions()
{
    ConsoleColor.DarkYellow.WriteConsole("Please select one option");
    ConsoleColor.Blue.WriteConsole("Teacher options : 1-Create , 2-GetAll , 3-Delete");
}