using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {

        static void Main(string[] args)
        {
            BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
            bool run = true;

            while (run)
            {
                Console.WriteLine("");
                Console.WriteLine("----- Respository Program -----");
                Console.WriteLine("[          Teacher           ]");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher"); 
                Console.WriteLine("3. Remove Teacher");
                Console.WriteLine("4. Display all courses associated with a Teacher ID");
                Console.WriteLine("5. Display all teachers");
                Console.WriteLine("");
                Console.WriteLine("[          Course           ]");
                Console.WriteLine("6. Add Course");
                Console.WriteLine("7. Update Course");  
                Console.WriteLine("8. Remove Course");
                Console.WriteLine("9. Display all courses");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select an option: ");
                Console.WriteLine("");

                int optionInt = Convert.ToInt32(Console.ReadLine());

                if (optionInt == 1)
                {
                    Console.WriteLine("Teacher Name ?");
                    string name = Console.ReadLine();

                    Teacher temp = new Teacher
                    {
                        TeacherName = name
                    };

                    bl.AddTeacher(temp);
                }
                else if (optionInt == 2)
                {
                    Console.WriteLine("1. Update Teacher by teacher id");
                    Console.WriteLine("2. Update Teacher by teacher name");
                    Console.WriteLine("Select an option: ");
                    int subOption = Convert.ToInt32(Console.ReadLine());
                    if (subOption == 1)
                    {
                        Console.WriteLine("Teacher ID ?");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Teacher teacher = bl.GetTeacherByID(id);
                        if (teacher == null)
                        {
                            Console.WriteLine("Teacher not found!");
                        }
                        else
                        {
                            Console.WriteLine("Enter new teacher name: ");
                            teacher.TeacherName = Console.ReadLine();
                            bl.UpdateTeacher(teacher);
                        }
                    }
                    else if (subOption == 2)
                    {
                        Console.WriteLine("Teacher Name ?");
                        string name = Console.ReadLine();
                        Teacher temp = bl.GetTeacherByName(name);
                        if (temp == null)
                        {
                            Console.WriteLine("Teacher not found!");
                        }
                        else
                        {
                            int id = temp.TeacherId;
                            Teacher teacher = bl.GetTeacherByID(id);
                            if (teacher == null)
                            {
                                Console.WriteLine("Teacher not found!");
                            }
                            else
                            {
                                Console.WriteLine("Enter new teacher name: ");
                                teacher.TeacherName = Console.ReadLine();
                                bl.UpdateTeacher(teacher);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is invalid");
                    }
                }
                else if (optionInt == 3)
                {
                    Console.WriteLine("Teacher ID to be deleted?");
                    int id = Convert.ToInt16(Console.ReadLine());
                    Teacher teacher = bl.GetTeacherByID(id);
                    if (teacher == null)
                    {
                        Console.WriteLine("Teacher not found !");
                    }
                    else
                    {
                        bl.RemoveTeacher(teacher);
                    }      
                }
                else if (optionInt == 4)
                {
                    Console.WriteLine("Teacher ID ?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Teacher teacher = bl.GetCoursesByTeacherID(id);
                    if (teacher == null || teacher.Courses.Count == 0)
                    {
                        Console.WriteLine("No courses associated with this Teacher ID");
                    }
                    else
                    {
                        foreach (Course c in teacher.Courses)
                            Console.WriteLine("- " + c.CourseName);
                    }
                }
                else if (optionInt == 5)
                {
                    IEnumerable<Teacher> allTeachers = bl.GetAllTeachers();
                    Console.WriteLine();
                    Console.WriteLine("ID Teacher Name");
                    foreach (Teacher temp in allTeachers)
                    {
                        Console.WriteLine(temp.TeacherId + "  " + temp.TeacherName);
                    }
                    Console.WriteLine();
                }
                else if (optionInt == 6)
                {
                    Console.WriteLine("Teacher ID ?");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Teacher teacher = bl.GetTeacherByID(id);
                    if (teacher == null)
                    {
                        Console.WriteLine("Teacher not found!");
                    }
                    else
                    {
                        Console.WriteLine("Course Name? ");
                        string cName = Console.ReadLine();
                        //Console.WriteLine("Course Location? ");
                        //string cLocation = Console.ReadLine();
                        Course temp = new Course()
                        {
                            CourseName = cName,
                            TeacherId = id
                        };
                        bl.AddCourse(temp);
                    }

                }
                else if (optionInt == 7)
                {
                    Console.WriteLine("1. Update Course by Course id");
                    Console.WriteLine("2. Update Course by Course name");
                    Console.WriteLine("Select an option: ");
                    int subOption = Convert.ToInt32(Console.ReadLine());
                    if (subOption == 1)
                    {
                        Console.WriteLine("Course ID ?");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Course course = bl.GetCourseByID(id);
                        if (course == null)
                        {
                            Console.WriteLine("Course not found");
                        }
                        else
                        {
                            Console.WriteLine("Enter new course name: ");
                            course.CourseName = Console.ReadLine();

                            IEnumerable<Teacher> allTeachers = bl.GetAllTeachers();
                            Console.WriteLine("");
                            Console.WriteLine("Current available Teachers");
                            foreach (Teacher temp in allTeachers)
                            {
                                Console.WriteLine(temp.TeacherId + "  " + temp.TeacherName);
                            }

                            Console.WriteLine("Current teacher id is " +course.TeacherId +" . Please enter new teacher id: ");
                            int idTemp = Convert.ToInt32(Console.ReadLine());
                            bool flag = false;
                            foreach (Teacher temp in allTeachers)
                            {
                                if(idTemp == temp.TeacherId)
                                {
                                    flag = true;
                                }
                            }
                            if (flag == true)
                            {
                                course.TeacherId = idTemp;
                                bl.UpdateCourse(course);
                            }
                            else
                            {
                                Console.WriteLine("Teacher ID is invalid");
                            }

                        }

                    }
                    else if (subOption == 2)
                    {
                        Console.WriteLine("Course Name ?");
                        string name = Console.ReadLine();
                        Course tempCourse = bl.GetCourseByName(name);
                        if (tempCourse == null)
                        {
                            Console.WriteLine("Course not found!");
                        }
                        else
                        {
                            int id = tempCourse.CourseId;
                            Course course = bl.GetCourseByID(id);
                            if (course == null)
                            {
                                Console.WriteLine("Course not found!");
                            }
                            else
                            {
                                Console.WriteLine("Enter new course name: ");
                                course.CourseName = Console.ReadLine();
                                IEnumerable<Teacher> allTeachers = bl.GetAllTeachers();
                                Console.WriteLine("");
                                Console.WriteLine("Current available Teachers");
                                foreach (Teacher temp in allTeachers)
                                {
                                    Console.WriteLine(temp.TeacherId + "  " + temp.TeacherName);
                                }

                                Console.WriteLine("Current teacher id is " + course.TeacherId + " . Please enter new teacher id: ");
                                int idTemp = Convert.ToInt32(Console.ReadLine());
                                bool flag = false;
                                foreach (Teacher temp in allTeachers)
                                {
                                    if (idTemp == temp.TeacherId)
                                    {
                                        flag = true;
                                    }
                                }
                                if (flag == true)
                                {
                                    course.TeacherId = idTemp;
                                    bl.UpdateCourse(course);
                                }
                                else
                                {
                                    Console.WriteLine("Teacher ID is invalid");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is invalid");
                    }
                }
                else if (optionInt == 8)
                {
                    Console.WriteLine("Course ID to be deleted?");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Course course = bl.GetCourseByID(id);
                    if (course == null)
                    {
                        Console.WriteLine("Course not found!");
                    }
                    else
                    {
                        bl.RemoveCourse(course);
                    }
                }
                else if (optionInt == 9)
                {
                    IEnumerable<Course> allCourses = bl.GetAllCourses();
                    Console.WriteLine();
                    Console.WriteLine("ID Course Name");
                    foreach (Course temp in allCourses)
                    {
                        Console.WriteLine(temp.CourseId + "  " + temp.CourseName);
                    }
                    Console.WriteLine();
                }
                else if (optionInt == 0)
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("Input is invalid, please re-enter the option from 0-9");
                }
            } //end while

        }

    }

}
