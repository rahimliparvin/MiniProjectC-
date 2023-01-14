using CourseApp.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Enums;

TeacherController teacherController = new();
GroupController  groupController  = new();


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
            case (int)Options.CreateTeacher:
                teacherController.Create();
                break;
            case (int)Options.UpdateTeacher:
                teacherController.Update();
                break;
            case (int)Options.DeleteTeacher:
                teacherController.Delete();
                break;
            case (int)Options.GetTeacherById:
                teacherController.GetByTeacherId();
                break;
            case (int)Options.GetAllTeachers:
                teacherController.GetAll();
                break;
            case (int)Options.SearchMethodTeacherNameAndSurname:
                teacherController.Search();
                break;
            case (int)Options.CreateGroup:
                groupController.Create();
                break;
            case (int)Options.UpdateGroup:
                Console.WriteLine("Delete");
                break;
            case (int)Options.GetGroupById:
                groupController.GetById();
                break;
            case (int)Options.DeleteGroup:
                Console.WriteLine("Delete");
                break;
            case (int)Options.GetGroupsByCapacity:
                Console.WriteLine("Delete");
                break;
            case (int)Options.GetGroupsByTeacherId:
                Console.WriteLine("Delete");
                break;
            case (int)Options.GetAllGroupsByTeacherName:
                Console.WriteLine("Delete");
                break;
            case (int)Options.SearchMethodForGroupByName:
                groupController.Search();
                break;
            case (int)Options.GetAllGroupsCount:
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