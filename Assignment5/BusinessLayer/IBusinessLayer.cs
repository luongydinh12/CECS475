using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        /* 
        #region Standard
        IEnumerable<Standard> GetAllStandards();

        Standard GetStandardByID(int id);

        Standard GetStandardByName(string name);

        void AddStandard(Standard standard);

        void UpdateStandard(Standard standard);

        void RemoveStandard(Standard standard);
        #endregion
        */

        // *********** ADDED  **************
        #region Teacher
        IEnumerable<Teacher> GetAllTeachers();

        Teacher GetTeacherByID(int id);

        Teacher GetTeacherByName(string name);

        Teacher GetCoursesByTeacherID(int id);

        void AddTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        void RemoveTeacher(Teacher teacher);      
        #endregion
               
        #region Course
        IEnumerable<Course> GetAllCourses();

        Course GetCourseByID(int id);

        Course GetCourseByName(string name);

        void AddCourse(Course course);

        void UpdateCourse(Course course);

        void RemoveCourse(Course course);       
        #endregion
        // *********** ADDED  **************
    }
}