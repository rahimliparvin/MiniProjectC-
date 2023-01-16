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
                groupController.GetGroupById();
                break;
            case (int)Options.DeleteGroup:
                groupController.Delete();
                break;
            case (int)Options.GetGroupsByCapacity:
                groupController.GetGroupsByCapacity();
                break;
            case (int)Options.GetGroupsByTeacherId:
                groupController.GetGroupsByTeacherId();
                break;
            case (int)Options.GetAllGroupsByTeacherName:
                groupController.GetAllGroupsByTeacherName();
                break;
            case (int)Options.SearchMethodForGroupByName:
                groupController.SearchMethodForGroupByName();
                break;
            case (int)Options.GetAllGroupsCount:
                groupController.GetAllGroupsCount();
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
    ConsoleColor.Blue.WriteConsole("\n Teacher options : \n 1-Create teacher , \n 2-Update teacher , \n 3-Delete teacher , " +
        " \n 4-Get teacher by id , \n 5-Get all teachers , \n 6-Search method for teacher name and surname ,\n Group options :  \n 7-Create group , \n 8-Update group , \n 9-Get group by id , \n 10-Delete group , \n 11-Get groups by capacity , " +
        " \n 12-Get groups by teacherId , \n 13-Get all groups by teacherName , \n 14-Search method  for group by name ," +
        " \n 15-Get all groups count");
}