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
                Console.WriteLine("Update");
                break;
            case 3:
                Console.WriteLine("Delete");
                break;
            case 4:
                Console.WriteLine("Delete");
                break;
            case 5:
                teacherController.GetAll();
                break;
            case 6:
                Console.WriteLine("Delete");
                break;
            case 7:
                Console.WriteLine("Delete");
                break;
            case 8:
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
    ConsoleColor.Blue.WriteConsole("Teacher options : 1-Create teacher , 2-Update teacher , 3-Delete teacher , " +
        "4-Get teacher by id , 5-Get all teachers , 6-Search method for teacher name and surname ," +
        " 7- Create group , 8- Update group , 9-Get group by id , 10-Delete group , 11-Get groups by capacity , " +
        "12- Get groups by teacherId , 13- Get all groups by teacherName , 14- Search method  for group by name ," +
        " 15- Get all groups count");
}