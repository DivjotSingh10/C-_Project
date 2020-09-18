using System;
using System.Collections.Generic;
using System.Linq;

/* This is Final Take Home Project for .NET technologies using C#.
 * Author: Divjot S. Chawla
 * Date: 8 August, 2020
 * Version: 4.10
 * Description: This application will use SchoolDB and perform various CRUD operations. It will make use of WCF services as well 
 * to implemenet the average of grades and many more.
 */
namespace DivjotChawla_FinalProject
{
    class Program
    {

        /*
         * This is implementation of WCF in our project.Eventhough grades are not a part of database.We will ask for user input for three subjects,
         * in this case are Maths, Physics, Chemistry.Then it will calculate the average and total marks scored by the student.
         */
        private static void Calculations()
        {
            ServiceReference1.Service1Client servic = new ServiceReference1.Service1Client();
            Console.WriteLine("Enter grades achieved in Mathematics: "); // asking for user input for marks of maths
            double gradeMaths = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter grades achieved in Physicse: ");
            double gradePhysics = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter grades achieved in Chemistry: ");
            double gradeChemistry = double.Parse(Console.ReadLine());

            double[] gradeData = { gradeMaths, gradePhysics, gradeChemistry };

            Console.WriteLine("Total Marks in Maths, Chemistry and Physics = " + servic.TotalGrades(gradeData));
            Console.WriteLine("Average marks scored  = " + Math.Round(servic.AverageGrades(gradeData), 2));
            servic.Close();
        }

        /* This is the main menu, it will be the first menu to interact with user.
        * It will ask for a user input to perform certain tasks. This is the parent menu. LEVEL 1
        */
        static void Main(string[] args)
        {
            int userInput;
            bool process = true;
            while (process)
            {
                Console.WriteLine(" \n=============== WELCOME TO FINAL ASSIGNMENT- MENU =======================");
                Console.WriteLine("=========================================================================");
                Console.WriteLine("1- CRUD Operation on Teacher");
                Console.WriteLine("2- CRUD Operation on Course");
                Console.WriteLine("3- CRUD Operation on Student");
                Console.WriteLine("4- Calculate Total Grade and Average Grade of Student ");
                Console.WriteLine("5- To Exit the application \n");
                Console.Write(" Enter Your Selection: ");

                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        CrudOnTeachers();
                        break;
                    case 2:
                        CrudOnCourses();
                        break;
                    case 3:
                        CrudOnStudents();
                        break;
                    case 4:
                        Calculations();
                        break;
                    case 5:
                        Console.WriteLine(" Do you  want to exit the menu?");
                        Console.WriteLine(" Enter 1 to EXIT, any other number to continue in menu \n");
                        Console.Write(" Enter Your Selection: ");
                        userInput = int.Parse(Console.ReadLine());
                        if (userInput == 1)
                        {
                            process = false;
                            Console.WriteLine("Thank you for visiting the program.");
                        }
                        break;
                    default:
                        Console.WriteLine(" Invalid Choice. Try Again ");
                        break;
                }
                }
            }

        

        /* This will further showcase the menu if user selects the CRUD operations on Teachers.
         * Will further have 8 sub-options for user to choose from. LEVEL2
         */

        static void CrudOnTeachers()
            {
                int userInput;
                bool process = true;
                while (process)
                {
                    Console.WriteLine("\n=====================TEACHER OPTIONS===============");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("1- Add New Teacher ");  // CRUD operations of insert, update, read and delete on teachers table
                    Console.WriteLine("2- Update Teacher");
                    Console.WriteLine("3- View Teacher");
                    Console.WriteLine("4- Delete Teacher");
                    Console.WriteLine("5- Search Teacher ( name) ");
                    Console.WriteLine("6- View Teacher Details (A-Z)"); // asecnding order for teacher 
                    Console.WriteLine("7- View Teacher Details (Z-A)");  // descending order for teacher 
                    Console.WriteLine("8- Go back to main menu \n");
                    Console.Write(" Enter Your Selection : ");
                    userInput = int.Parse(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            InsertTeacher();
                            break;
                        case 2:
                            UpdateTeacher();
                            break;
                        case 3:
                            ReadTeacher();
                            break;
                        case 4:
                            DeleteTeacher();
                            break;
                        case 5:
                            SearchTeachersByName();
                            break;
                        case 6:
                            SortTeacherByAscending();
                            break;
                        case 7:
                            SortTeacherByDescending();
                            break;
                        case 8:
                            process = false;
                            Console.WriteLine(" Thank you for entering the teacher menu");
                            break;
                        default:
                            Console.WriteLine(" Invalid Choice Try Again ");
                            break;
                    }
                }
            }

        /* This will further showcase the menu if user selects the CRUD operations on Courses.
        * Will further have 5 sub-options for user to choose from. LEVEL2
        */

        static void CrudOnCourses()
            {
                int userInput;
                bool process = true;
                while (process)
                {
                    Console.WriteLine("\n====================COURSES OPTIONS================");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("1- Add New Course ");  // only CRUD operations
                    Console.WriteLine("2- Update Course Details ");
                    Console.WriteLine("3- View Course Details ");
                    Console.WriteLine("4- Delete Course Details ");
                    Console.WriteLine("5- Exit From Course Operation Menu \n");
                    Console.Write(" Enter Your Selection : ");
                    userInput = int.Parse(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            InsertCourse();
                            break;
                        case 2:
                            UpdateCourse();
                            break;
                        case 3:
                            ReadCourse();
                            break;
                        case 4:
                            DeleteCourse();
                            break;
                        case 5:
                            process = false;
                            Console.WriteLine("Thank you for entering the course menu");
                            break;
                        default:
                            Console.WriteLine(" Invalid Choice. Try Again ");
                            break;
                    }
                }
            }

        /* This will further showcase the menu if user selects the CRUD operations on students.
        * Will further have 5 sub-options for user to choose from. LEVEL2
        */
        static void CrudOnStudents()
            {
                int userInput;
                bool process = true;
                while (process)
                {
                    Console.WriteLine("\n=====================STUDENT OPTIONS===============");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("1- Add New Student ");
                    Console.WriteLine("2- Update Student Details ");
                    Console.WriteLine("3- View Student Details ");
                    Console.WriteLine("4- Delete Student Details ");
                    Console.WriteLine("5- Search Student By Name ");
                    Console.WriteLine("6- View Student Details Sort By Name Ascending ");
                    Console.WriteLine("7- View Student Details Sort By Name Descending ");
                    Console.WriteLine("8- Exit From Student Operation Menu ");
                    Console.Write(" Enter Your Choice : ");
                    userInput = int.Parse(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            UpdateStudent();
                            break;
                        case 3:
                            ReadStudent();
                            break;
                        case 4:
                            DeleteStudent();
                            break;
                        case 5:
                            SearchStudentsByName();
                            break;
                        case 6:
                            SortAllStudentByAscending();
                            break;
                        case 7:
                            SortAllStudentByDescending();
                            break;
                        case 8:
                            process = false;
                            Console.WriteLine("Thank you for entering the student menu");
                            break;
                        default:
                            Console.WriteLine(" Invalid Choice Try Again ");
                            break;
                    }
                }
            }

/* The below are the course operations which will help user in the course menu. the four methods defined below are performing CRUD opertaions for 
 * course table. This is LEVEL 3.
 */
            static void InsertCourse()
            {
                try
                {
                    Console.Write("\n Enter Course Name To Be Added: ");
                    string courseName = Console.ReadLine();
                    Console.Write(" Enter Teacher ID: ");
                    int teacherID = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var teacher = (from s in context.Teachers
                                       where s.TeacherId == teacherID
                                       select s).FirstOrDefault();
                        if (teacher != null)
                        {
                            var course = new Course()
                            {
                                CourseName = courseName,
                                Teacher = teacher
                            };

                            context.Courses.Add(course);   // adding the course if it doesnt exist
                            context.SaveChanges();     // saving the changes made above 
                            Console.WriteLine("\n New Course is Added");    // displaying the message that the execution was successful
                        }
                        else
                        {
                            Console.WriteLine("No Teacher with this Teacher ID. Hence course can't be added.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem occured while adding the course due to: " + ex.Message);
                }

            }

            static void ReadCourse()
            {
                string c1 = "Course ID";
                string c2 = "Course Name";
                string c3 = "Teacher ID";
                Console.WriteLine($" \n {c1,-10} {c2,-30} {c3,-20}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var courses = from s in context.Courses select s;
                        if (courses.Count() == 0)
                        {
                            Console.WriteLine(" No Course to be displayed. ");
                        }
                        else
                        {
                            foreach (var course in courses)
                            {
                                int courseID = course.CourseId;
                                string courseName = course.CourseName;
                                int teacherID = (int)course.TeacherId;
                                Console.WriteLine($" {courseID,-10} {courseName,-30} {teacherID,-20}");
                            }
                        }

                    }
                }


            catch (Exception)


            {
                    Console.WriteLine("NO RECORDS FOUND ");
                }
            }

            static void DeleteCourse()
            {
                try
                {
                    Console.Write(" Enter Course ID to be Deleted: ");
                    int courseID = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var course = (from s in context.Courses
                                      where s.CourseId == courseID
                                      select s).FirstOrDefault();
                        if (course != null)
                        {
                            Console.WriteLine(" \n Course to be deleted have the following Details: ");
                            Console.WriteLine(" Course Name is: " + course.CourseName);
                            Console.WriteLine(" Teacher ID is: " + course.TeacherId);
                            Console.WriteLine(" Are You Sure to delete this course? ");
                            Console.WriteLine(" Press 1 to delete, any other key to go back to Course menu. ");
                            Console.Write(" Enter Your Choice: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                context.Courses.Remove(course); // if the user selects 1, then it will deleye the course and display a success message
                                context.SaveChanges();
                                Console.WriteLine(" Given Course Details are DELETED");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Course Details Found that relate to this Course ID");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem occured while deleting the course due to: " + ex.Message);
                }
            }

            static void UpdateCourse()
            {
                try
                {
                    Console.Write(" Enter Course ID to be Updated : ");
                    int courseID = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var course = (from s in context.Courses
                                      where s.CourseId == courseID
                                      select s).FirstOrDefault();
                        if (course != null)
                        {
                            Console.WriteLine("\n-+-+-+-+-+-Older Course Details are-+-+-+-+-+-");
                            Console.WriteLine(" Course Name: " + course.CourseName);
                            Console.WriteLine(" Teacher ID: " + course.TeacherId);
                            Console.WriteLine(" Are You Sure to Update this course ");
                            Console.WriteLine(" Press 1 to delete, any other key to go back to Course menu. \n ");
                            Console.Write(" Enter Your Choice: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.Write(" Enter New Course Name: ");
                                course.CourseName = Console.ReadLine();
                                Console.Write(" Enter New Teacher ID: ");
                                int teacher_id = int.Parse(Console.ReadLine());
                                var teacher = (from s in context.Teachers
                                               where s.TeacherId == teacher_id
                                               select s).FirstOrDefault();
                                if (teacher != null)
                                {
                                    course.Teacher = teacher;
                                    context.SaveChanges();
                                    Console.WriteLine(" Course Details of Given Course ID are updated");
                                }
                                else
                                {
                                    Console.WriteLine("No Teacher with Given Teacher ID. Hence, no update took place.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Course Details are present  which matches the course ID, Please check.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem occured while deleting the course due to: " + ex.Message);
                }
            }


/*
 * The follwoing methods are for the sub-menu of teachers. Insert, Create, Update and delete. It also has Search teachers by  name, and Ascending and descending methods.
 * Further explanation is provided as inline comments before the function starts.
 */

        // This will isnert Teachers by taking the value teacher name, teacher ID and teacher type.
            static void InsertTeacher()
            {
                try
                {
                    Console.Write(" Enter New Teacher Name: ");
                    string teacher_name = Console.ReadLine();
                    Console.Write(" Enter Standard ID: ");
                    int standard_id = int.Parse(Console.ReadLine());
                    Console.Write(" Enter Teacher Type: ");
                    int teacher_type = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var standard = (from s in context.Standards
                                        where s.StandardId == standard_id
                                        select s).FirstOrDefault();
                        if (standard != null)
                        {
                            var teacher = new Teacher()
                            {
                                TeacherName = teacher_name,
                                Standard = standard,
                                TeacherType = teacher_type
                            };

                            context.Teachers.Add(teacher);
                            context.SaveChanges();
                            Console.WriteLine(" SUCCESS. New Teacher is Added. ");
                        }
                        else
                        {
                            Console.WriteLine("No Standard has the given standard ID, so no information is stored.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem occured while deleting the course due to: " + ex.Message);
                }

            }

        // This will view all the teachers stored, in a tabular manner 
            static void ReadTeacher()
            {
                string c1 = "Teacher ID";
                string c2 = "Teacher Name";
                string c3 = "Teacher Type";
                Console.WriteLine($" \n {c1,-20} {c2,-30} {c3,-20}");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var teachers = from s in context.Teachers select s;
                        if (teachers.Count() == 0)
                        {
                            Console.WriteLine("There are no records for Teacher to show.");
                        }
                        else
                        {
                            foreach (var teacher in teachers)
                            {
                                int teacherID = teacher.TeacherId;
                                string teacherName = teacher.TeacherName;
                                int teacherType = (int)teacher.TeacherType;
                                Console.WriteLine($" {teacherID,-20} {teacherName,-30} {teacherType,-20}");
                            }
                        }

                    }
                }

            catch (Exception)

            {
                    Console.WriteLine(" There is No Record Found ");
                }
            }

        // This method will delete the teacher by taking in user input for the teacher ID, then will display  the inofmation to verify that the information is 
        // correct and final  input as to delete or not. 
            static void DeleteTeacher()
            {
                try
                {
                    Console.Write(" Enter Teacher ID to be Deleted : ");
                    int teacherid = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var teacher = (from s in context.Teachers
                                       where s.TeacherId == teacherid
                                       select s).FirstOrDefault();
                        if (teacher != null)
                        {
                            Console.WriteLine("\n The current details of teacher details are ");
                            Console.WriteLine(" Teacher Name: " + teacher.TeacherName);
                            Console.WriteLine(" Standard ID: " + teacher.StandardId);
                            Console.WriteLine(" Teacher Type: " + teacher.TeacherType);
                            Console.WriteLine(" If you are sure to delete this teacher than ");
                            Console.WriteLine(" Press 1 to delete, any other key to go back to Course menu.");
                            Console.Write(" Enter Your Selection: ");
                            int userInput = int.Parse(Console.ReadLine());
                            if (userInput == 1)
                            {
                                context.Teachers.Remove(teacher); // teeacher will be removed
                                context.SaveChanges();
                                Console.WriteLine(" The teacher you selected is deleted.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" There is no teacher ID that matches your input.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A problem occured while deleting the course due to: " + ex.Message);
                }
            }

        // This method will perform the update operation on teacher, It will first ask for user input to get the teacherID to be updated.
        // It will also display  the current informaation for a better user experience, helping user to make appropiate changes.
            static void UpdateTeacher()
            {
                try
                {
                    Console.Write(" Enter Teacher ID that you want updated : ");
                    int teacherid = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var techer = (from s in context.Teachers
                                       where s.TeacherId == teacherid
                                       select s).FirstOrDefault();
                        if (techer != null)
                        {
                            Console.WriteLine("\n=-=-=-=-=-=-=-= Current Teacher details are:=-=-=-=-=-=-=-=-");
                            Console.WriteLine(" Teacher name is : " + techer.TeacherName);
                            Console.WriteLine(" Standard id is : " + techer.StandardId);
                            Console.WriteLine(" Teacher Type is : " + techer.TeacherType);
                            Console.WriteLine(" Are You Sure to Update This Teacher Details? ");
                            Console.WriteLine(" Press 1 For Yes and other Number For No ");
                            Console.Write(" Enter Your Choice: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {

                                Console.Write(" Enter New Teacher Name: ");
                                techer.TeacherName = Console.ReadLine();
                                Console.Write(" Enter New Standard: ");
                                int standard_id = int.Parse(Console.ReadLine());
                                Console.Write(" Enter New Teacher Type: ");
                                techer.TeacherType = int.Parse(Console.ReadLine());
                                var standard = (from s in context.Standards
                                                where s.StandardId == standard_id
                                                select s).FirstOrDefault();
                                if (standard != null)
                                {
                                    techer.Standard = standard;
                                    context.SaveChanges();
                                    Console.WriteLine(" The teacher that you  entered is updated");
                                }
                                else
                                {
                                    Console.WriteLine(" There is No Standard with Given Standard ID. So, No Teacher Details will be updated.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(" There is No Teacher Details Corresonding to This Course ID");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" There is Failure in Deleting Teacher Details due to: " + ex.Message);
                }
            }

        // This is the special feature required for the exam. It will search teacher by name. 
            static void SearchTeachersByName()
            {
                string c1 = "Teacher ID";
                string c2 = "Teacher Name";
                string c3 = "Teacher Type";

                try
                {
                    Console.Write(" Enter Teacher Name: ");
                    string name = Console.ReadLine();
                    using (var context = new SchoolDBEntities())
                    {
                        var teachers = from s in context.Teachers
                                       where s.TeacherName == name
                                       select s;
                        Console.WriteLine($" {c1,-15} {c2,-30} {c3,-20}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                        if (teachers.Count() == 0)
                        {
                            Console.WriteLine(" No Records Were Found.  ");
                        }
                        else
                        {
                            foreach (var teacher in teachers)
                            {
                                int teacherID = teacher.TeacherId;
                                string teacherName = teacher.TeacherName;
                                int teacherType = (int)teacher.TeacherType;
                                Console.WriteLine($" {teacherID,-15} {teacherName,-30} {teacherType,-20}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("NO RECORD FOUND.");
                }
            }

        // This was a special feature of our project, sort teachher by  ascending order, i.e, A TO Z.
            static void SortTeacherByAscending()
            {
                string c1 = "Teacher ID";
                string c2 = "Teacher Name";
                string c3 = "Teacher Type";

                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var teachers = from s in context.Teachers
                                       orderby s.TeacherName ascending
                                       select s;
                        Console.WriteLine($" {c1,-15} {c2,-30} {c3,-20}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=");
                    if (teachers.Count() == 0)
                        {
                            Console.WriteLine("No teachers record found");
                        }
                        else
                        {
                            foreach (var teacher in teachers)
                            {
                                int teacherID = teacher.TeacherId;
                                string teacherName = teacher.TeacherName;
                                int? teacherType = teacher.TeacherType;
                                Console.WriteLine($" {teacherID,-15} {teacherName,-30} {teacherType,-20}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("NO RECORD FOUND");
                }
            }

        // This was a special feature of our project, sort teachher by  descending order, i.e, Z TO A.
        static void SortTeacherByDescending()
            {
                string c1 = "Teacher ID";
                string c2 = "Teacher Name";
                string c3 = "Teacher Type";

                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var techers = from s in context.Teachers
                                       orderby s.TeacherName descending
                                       select s;
                        Console.WriteLine($" {c1,-15} {c2,-30} {c3,-20}");
                        if (techers.Count() == 0)
                        {
                            Console.WriteLine(" No teachers record found");
                        }
                        else
                        {
                            foreach (var teacher in techers)
                            {
                                int teacherID = teacher.TeacherId;
                                string teacherName = teacher.TeacherName;
                                int teacherType = (int)teacher.TeacherType;
                                Console.WriteLine($" {teacherID,-15} {teacherName,-30} {teacherType,-20}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("NO RECORD FOUND");
                }
            }

/* The upcoming methods are used for CRUD oprtaions on Student. There are also some special features like Search by name, Asecnding and 
 * Descending order.
 */

        // This is to add a new student, by taking in the appropiate fields.
            static void AddStudent()
            {
                try
                {
                // taking input here
                    Console.Write(" Enter New Student Name: ");
                    string studName = Console.ReadLine();
                    Console.Write(" Enter Standard ID: ");
                    int standardID = int.Parse(Console.ReadLine());
                    Console.Write(" Enter Course ID: ");
                    int courseID = int.Parse(Console.ReadLine());
                    Console.Write(" Enter Address 1: ");
                    string add1 = Console.ReadLine();
                    Console.Write(" Enter Address 2: ");
                    string add2 = Console.ReadLine();
                    Console.Write(" Enter City: ");
                    string city = Console.ReadLine();
                    Console.Write(" Enter State: ");
                    string state = Console.ReadLine();

                    using (var context = new SchoolDBEntities())
                    {
                        var course = (from s in context.Courses     // fetching the course name based on input of courseID
                                      where s.CourseId == courseID
                                      select s).FirstOrDefault();

                        var standard = (from s in context.Standards    // fetching standard based on StandardID
                                        where s.StandardId == standardID
                                        select s).FirstOrDefault();

                        if (course != null && standard != null)
                        {
                            var student_address = new StudentAddress()
                            {
                                Address1 = add1,
                                Address2 = add2,
                                City = city,
                                State = state
                            };

                            var student = new Student()
                            {
                                StudentName = studName,
                                Standard = standard,
                                StudentAddress = student_address
                            };

                            context.Students.Add(student);
                            student.Courses.Add(course);

                            context.SaveChanges();
                            Console.WriteLine(" Student Is Added.");
                        }
                        else
                        {
                            if (course == null)
                            {
                                Console.WriteLine(" Student information is not saved as there is no course connected with the given courseID.");
                            }
                            if (standard == null)
                            {
                                Console.WriteLine(" Student information is not saved as there is no standard linked with the given standardID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" An error occured while adding student, i.e, : " + ex.Message);
                }

            }

        // This method will read all the records of student and display it in a tabular form. 
            static void ReadStudent()
            {
                string col1 = "Student ID";
                string col2 = "Student Name";
                string col3 = "Course ID";
                Console.WriteLine($" {col1,-20} {col2,-30} {col3,-30}");
                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var stduents = from s in context.Students select s;
                        if (stduents.Count() == 0)
                        {
                            Console.WriteLine(" No student details to display");
                        }
                        else
                        {
                            foreach (var student in stduents)
                            {
                                int studentID = student.StudentID;
                                string studentName = student.StudentName;
                                string courseID = "";
                                foreach (var course in student.Courses)
                                {
                                    courseID += " [ " + course.CourseId + " ]";
                                }
                                if (courseID.Length == 0)
                                {
                                    courseID = "No Record Of Enrollment ";
                                }
                                Console.WriteLine($" {studentID,-20} {studentName,-30} {courseID,-30}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("NO RECORDs FOUND ");
                }
            }

        // This method will perform the Delete Operation on the student table. 
            static void DeleteStudent()
            {
                try
                {
                    Console.Write(" Enter Student ID that you want to delete: ");
                    int studntID = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var student = (from s in context.Students
                                       where s.StudentID == studntID
                                       select s).FirstOrDefault();
                        if (student != null)
                        {
                            Console.WriteLine("\n The student details are as follows:");
                            Console.WriteLine(" Student Name: " + student.StudentName);
                            Console.WriteLine(" Standard ID: " + student.StandardId);
                            if (student.StudentAddress != null)
                            {
                                Console.WriteLine(" Address 1: " + student.StudentAddress.Address1);
                                Console.WriteLine(" Address 2: " + student.StudentAddress.Address2);
                                Console.WriteLine(" City: " + student.StudentAddress.City);
                                Console.WriteLine(" State: " + student.StudentAddress.State);
                            }
                            else
                            {
                                Console.WriteLine(" Invalid student address. ");
                            }
                            if (student.Courses.Count == 0)
                            {
                                Console.WriteLine(" Course Not Found. ");
                            }
                            else
                            {
                                string courseid = "Courses student enrolled in: ";
                                foreach (var course in student.Courses)
                                {
                                    courseid += " [ " + course.CourseId + " ]";
                                }
                                Console.WriteLine(courseid);
                            }
                            Console.WriteLine(" Are You Sure to delete this student ");
                            Console.WriteLine(" Press 1 For 'YES' and other Number For 'NO' ");
                            Console.Write(" Enter Your Selection: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                context.Students.Remove(student);
                                context.SaveChanges();
                                Console.WriteLine(" The provided student details are deleted.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" No student was found with the provided course ID");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("A error occured while performing the operation, i.e, : " + ex.Message);
                }
            }

        // This method will perform the update operation on student table. 
            static void UpdateStudent()
            {
                try
                {
                    Console.Write(" Enter Student ID that has to be deleted: ");
                    int studentid = int.Parse(Console.ReadLine());
                    using (var context = new SchoolDBEntities())
                    {
                        var studnt = (from s in context.Students
                                       where s.StudentID == studentid
                                       select s).FirstOrDefault();
                        if (studnt != null)
                        {// after user enters the student ID, we will show the current information that is stored related to that studentID
                            Console.WriteLine(" \n The current details of student are: ");
                            Console.WriteLine("-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                            Console.WriteLine(" Student Name: " + studnt.StudentName);
                            Console.WriteLine(" Standard ID: " + studnt.StandardId);
                            if (studnt.StudentAddress != null)
                            {
                                Console.WriteLine(" Address 1: " + studnt.StudentAddress.Address1);
                                Console.WriteLine(" Address 2: " + studnt.StudentAddress.Address2);
                                Console.WriteLine(" City: " + studnt.StudentAddress.City);
                                Console.WriteLine(" State: " + studnt.StudentAddress.State);
                            }
                            else
                            {
                                Console.WriteLine(" Student Address is not available. ");
                            }
                            if (studnt.Courses.Count == 0)
                            {
                                Console.WriteLine("Course is not available. ");
                            }
                            else
                            {
                                string courseid = "Courses that student is enrolled in: ";
                                foreach (var course in studnt.Courses)
                                {
                                    courseid += " [ " + course.CourseId + " ]";
                                }
                                Console.WriteLine(courseid);
                            }
                            Console.WriteLine(" Do you want  to update the information: ");
                            Console.WriteLine(" Press 1 to 'YES' or any other digit key for 'No'");
                            Console.Write(" Enter Your Selection: ");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.Write("\n Enter Student Name here: ");
                                studnt.StudentName = Console.ReadLine();
                                Console.Write(" Enter Standard ID here: ");
                                int standard_id = int.Parse(Console.ReadLine());
                                var standard = (from s in context.Standards
                                                where s.StandardId == standard_id
                                                select s).FirstOrDefault();
                                if (standard != null)
                                {
                                    context.SaveChanges();
                                    Console.WriteLine(" The student you choose is updated.");
                                }
                                else
                                {
                                    Console.WriteLine(" The StudentID you entered is not linked to any standard. So no records were updated.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No course was linked to the course id you entered. ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured while porcessing your request for deleteing student, i.e, : " + ex.Message);
                }
            }

        // This is a special feature that will search student by name. 
            static void SearchStudentsByName()
            {
                try
                {
                    string c1 = "Student ID";
                    string c2 = "Student Name";
                    string c3 = "Address";
                    string c4 = "City";
                    string c5 = "Province";

                    Console.Write(" Enter Student Name: "); // asking for name input to search 
                    string studentNames = Console.ReadLine();

                    Console.WriteLine($" {c1,-20} {c2,-30} {c3,-30} {c4,-15} {c5,-15}");
                    using (var context = new SchoolDBEntities())
                    {
                        var students = from s in context.Students     // searching the student by the input name
                                       where s.StudentName == studentNames
                                       select s;
                        if (students.Count() == 0)
                        {
                            Console.WriteLine("No details of student were found. ");
                        }
                        else
                        {
                            foreach (var student in students)
                            {
                                int studentID = student.StudentID;
                                string StudentName = student.StudentName;
                                string address = "Can't be found/ Not saved";
                                string city = "Can't be found/ Not saved";
                                string state = "Can't be found/ Not saved";
                                if (student.StudentAddress != null)
                                {
                                    address = student.StudentAddress.Address1 + " " + student.StudentAddress.Address2;
                                    city = student.StudentAddress.City;
                                    state = student.StudentAddress.State;
                                }
                                Console.WriteLine($" {studentID,-20} {StudentName,-30} {address,-30} {city,-15} {state,-15}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(" There is No Record Found ");
                }
            }

        // This will sort students in ascending order based on user input. A-Z
            static void SortAllStudentByAscending()
            {
                string col1 = "Student ID";
                string col2 = "Student Name";
                string col3 = "Course ID";
                Console.WriteLine($" {col1,-20} {col2,-30} {col3,-30}");
                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var students = from s in context.Students
                                       orderby s.StudentName ascending
                                       select s;
                        if (students.Count() == 0)
                        {
                            Console.WriteLine(" There is No Student Details ");
                        }
                        else
                        {
                            foreach (var student in students)
                            {
                                int sid = student.StudentID;
                                string sname = student.StudentName;
                                string courseid = "";
                                foreach (var course in student.Courses)
                                {
                                    courseid += " [ " + course.CourseId + " ]";
                                }
                                if (courseid.Length == 0)
                                {
                                    courseid = "No Enrollment";
                                }
                                Console.WriteLine($" {sid,-20} {sname,-30} {courseid,-30}");
                            }
                        }

                    }
                }

            catch (Exception)
            {
                    Console.WriteLine("NO RECORDs FOUND");
                }
            }
        // This will sort students based on input from user but in descending order. This is special feature of the project.
            static void SortAllStudentByDescending()
            {
                string col1 = "Student ID";
                string col2 = "Student Name";
                string col3 = "Course ID";
                Console.WriteLine($" {col1,-20} {col2,-30} {col3,-30}");
                try
                {
                    using (var context = new SchoolDBEntities())
                    {
                        var students = from s in context.Students
                                       orderby s.StudentName descending
                                       select s;
                        if (students.Count() == 0)
                        {
                            Console.WriteLine(" There is No Student Details ");
                        }
                        else
                        {
                            foreach (var student in students)
                            {
                                int sid = student.StudentID;
                                string sname = student.StudentName;
                                string courseid = "";
                                foreach (var course in student.Courses)
                                {
                                    courseid += " [ " + course.CourseId + " ]";
                                }
                                if (courseid.Length == 0)
                                {
                                    courseid = "No Enrollment";
                                }
                                Console.WriteLine($" {sid,-20} {sname,-30} {courseid,-30}");
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(" There is No Record Found ");
                }
            }

        

   
       
    }
    }
