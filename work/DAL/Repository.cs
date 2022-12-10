using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Xml.XPath;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Xml.Linq;
using System.Data.SqlTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAL
{
   public class Repository
    {
        StudentDataContext _context;
        public Repository(StudentDataContext context)
        {
            _context = context;
        }

        #region Function for Login using Database Function

        public bool LoginUser(string email, string password)
        {

            bool result = false;
            try
            {
                result = (from u in _context.Alogin select StudentDataContext.ufn_ValidateUserCredentials(email, password)).FirstOrDefault();
                    return result;
            }
            catch (Exception)
            { 
                return result;
            }
        }
        #endregion

        #region Add Student Data 
        public bool AddStudent(Student student)
        {
            int result = 0;
            bool status = false;
            try
            {
               
                 SqlParameter Rollno = new SqlParameter("@sRollNo", student.RollNo);
                  SqlParameter Firstname = new SqlParameter("@sFirstName", student.StudentFname);
                  SqlParameter Lastname = new SqlParameter("@sLastName", student.StudentFname);
                  SqlParameter Contact = new SqlParameter("@sContact", student.Contact );
                  SqlParameter Fname = new SqlParameter("@sFatherName", student.FatherName);
                  SqlParameter Division = new SqlParameter("@sClass", student.Class);
                  SqlParameter Year = new SqlParameter("@sJYear", student.JoiningYear);
                  SqlParameter Result = new SqlParameter("@result", System.Data.SqlDbType.Int);
                  Result.Direction = System.Data.ParameterDirection.Output;
                  result = _context.Database.ExecuteSqlRaw("EXEC @result=AddStudent @sRollNo,@sContact,@sFirstName,@sLastName,@sJYear,@sFatherName,@sClass", new[]
                  { Result, Rollno,Contact, Firstname, Lastname, Year,Fname, Division });
                if (result == 1)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
                status = false;
            }
            return status;
        }
        #endregion
      
        #region update details of student
        public bool UpdateStudent(Student student)
        {
            bool status = false;
            try
            {
                var students = (from Student in _context.Student
                               where Student.RollNo == student.RollNo select Student).FirstOrDefault<Student>();
                if (students != null)
                {
                    if (students.StudentFname != null)
                    {
                        students.StudentFname = student.StudentFname;
                    }

                    if (students.StudentLname != null)
                    {
                        students.StudentLname = student.StudentLname;
                    }
                    if (students.Contact != 0)
                    {
                        students.Contact = student.Contact;
                    }
                    if (students.Class != null)
                    {
                        students.Class = student.Class;
                    }
                    if (students.JoiningYear != 0)
                    {
                        students.JoiningYear = student.JoiningYear;
                    }
                    if (students.FatherName != null)
                    {
                        students.FatherName = students.FatherName;
                    }
                    _context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }
        #endregion

        #region update student marks.
        public bool UpdateMarks(Marks mark)
        {
            bool status = false;
            try
            {
                var marks = (from Marks in _context.Marks
                                where Marks.RollNo == mark.RollNo && Marks.Yr == mark.Yr
                                select Marks).FirstOrDefault<Marks>();
                if ( marks != null)
                {
                    if (marks.Maths >=0 )
                    {
                        marks.Maths = mark.Maths;
                    }

                    if (marks.Science >= 0)
                    {
                        marks.Science = mark.Science;
                    }
                    if (marks.History >= 0)
                    {
                        marks.History = mark.History;
                    }
                    if (marks.Geography >= 0)
                    {
                        marks.Geography = mark.Geography;
                    }
                    if (marks.English >= 0)
                    {
                        marks.English = mark.English;
                    }
                    if (marks.MarksAverage >=0)
                    {
                        marks.MarksAverage = mark.MarksAverage;
                    }
                    if (marks.SmAverage >= 0)
                    {
                        marks.SmAverage = mark.SmAverage;
                    }
                    _context.SaveChanges();
                    status = true;
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }

        #endregion

        #region delete student details from student table.
        public bool DeleteStd(int rollno)
        {
            bool status = false;
            try
            {
                if (rollno >= 0)
                {
                    var det = (from Student in _context.Student
                               where Student.RollNo == rollno
                               select Student).FirstOrDefault();
                    if (det != null)
                    {

                        var entry = (from Marks in _context.Marks
                                     where Marks.RollNo == (from Student in _context.Student
                                                            where Student.RollNo == rollno
                                                            select Student.RollNo).FirstOrDefault()
                                     select Marks).FirstOrDefault<Marks>();
                        if (entry != null)
                        {
                            _context.Marks.Remove(entry);
                            _context.SaveChanges();
                        }
                        var del = (from Student in _context.Student
                                   where Student.RollNo == rollno
                                   select Student).FirstOrDefault<Student>();

                        _context.Student.Remove(del);
                        _context.SaveChanges();
                        status = true;
                    }

                }
            }
            catch (Exception ex)
            {
                status = false;
                Console.WriteLine(ex);
            }
            return status;
        }
    
        #endregion

        #region delete marks details from student table.
            public bool DeleteMarks(int Rno,int yr)
            {
                int result = 0;
                bool status = false;
                try
                {
                    if (Rno >= 0)
                    {
                        SqlParameter RollNo = new SqlParameter("@RollNo", Rno);
                        SqlParameter Year = new SqlParameter("@Yr", yr);
                        SqlParameter Result = new SqlParameter("@result", System.Data.SqlDbType.Int);
                        Result.Direction = System.Data.ParameterDirection.Output;
                        result =  _context.Database.ExecuteSqlRaw("EXEC @result=del @RollNo,@Yr" ,new[] { Result, RollNo,Year });
                        status = true;
                    }

                }
                catch (Exception ex)
                {
                    status = false;
                    Console.WriteLine(ex);
                }
                return status;
            }
            #endregion

        #region finding total number of student having highest marks in maths
        public string Mathsmax()
        {
            var year = DateTime.Today.Year;  /*for getting present year*/
            long result = 0;
            try
            {
                result = (from a in _context.Marks select StudentDataContext.ufn_maxmaths()).FirstOrDefault();
                return result.ToString();
            }
            catch (Exception)
            {
                return result.ToString();
            }
        }

        #endregion

        #region finding total number of student having highest marks in science
        public string ScienceMax()
      {     var year = DateTime.Today.Year;  /*for getting present year*/
            long result = 0;
            try
            {
                result = (from a in _context.Marks select StudentDataContext.ufn_maxsci()).FirstOrDefault();
                return result.ToString();
            }
            catch (Exception)
            {
                return result.ToString();
            }
        }
        #endregion

        #region finding total number of student having highest marks in english
        public string EngMax()
        {
            var year = DateTime.Today.Year;  /*for getting present year*/
            long result = 0;
            try
            {
                result = (from a in _context.Marks select StudentDataContext.ufn_maxeng()).FirstOrDefault();
                return result.ToString();
            }
            catch (Exception)
            {
                return result.ToString();
            }
           
        }
        #endregion

        #region finding total number of students having avg > 90
        public int AvgMax()
        {
            var year = DateTime.Today.Year  ;/*for getting present year*/

            var max = (from Marks in _context.Marks
                       where Marks.Yr == year && Marks.MarksAverage >= 90
                       select Marks.RollNo).Count();

            return max;
        }
        #endregion

        #region finding the students who have more than 90% from last two years
        public (List<Marks> , List<Marks>) GetList()
        {
            var year = DateTime.Today.Year - 1; /*for getting previous year*/
            var year1 = DateTime.Today.Year -2; /*for getting previous year*/

            var listyearone = (from Marks in _context.Marks
                                  where Marks.SmAverage >=90 && Marks.Yr == year
                                  select Marks).ToList();

            var listyeartwo = (from Marks in  _context.Marks
                               where Marks.SmAverage >= 90 && Marks.Yr == year1
                               select Marks).ToList();

            var result = listyearone.Where(listyearone => listyeartwo.Any(Marks => Marks.RollNo == Marks.RollNo)).ToList();
            var res = listyeartwo.Where(listyeartwo => listyearone.Any(Marks => Marks.RollNo == Marks.RollNo)).ToList();
            return (res , result);
            
        }
        #endregion

        #region To get all Student Data
        public List<Models.Student> GetStudents()
        {
            try
            {
                return _context.Student.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region To get all Student Data
        public List<Models.Marks> GetMarks()
        {
            try
            {
                return _context.Marks.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region get next id
        public string GetNextId()
        {   int id = 101;
            try
            {

          
            string Id = _context.Marks.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault().ToString();
            if (Id != null)
            {
                 id = Convert.ToInt32(Id.Substring(1, Id.Length - 1)) + 1;
            }
            else if(Id == null){
                id = 101;
            }
            }
            catch (Exception)
            {

                throw;
            }
            return "M" + id.ToString();
        }
        #endregion

        #region add student marks
        public bool AddMarks(Models.Marks mark) 
        {
            try
            {
                _context.Marks.AddRange(mark);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            /*  bool status = false; 
              int result = 0;
              long Avg = (mark.English + mark.Science + mark.Maths + mark.History + mark.Geography) / 5;
              long SAvg = (mark.Science + mark.Maths) / 2;
              try
              {
              SqlParameter pId = new SqlParameter("@Id",mark.Id);
              SqlParameter pRollNo = new SqlParameter("@RollNo",mark.RollNo);
              SqlParameter pYear = new SqlParameter("@Yr", mark.Yr);
              SqlParameter pMaths = new SqlParameter("@Maths",mark.Maths);
              SqlParameter pGeography = new SqlParameter("@Geo", mark.Geography);
              SqlParameter pScience = new SqlParameter("@Science", mark.Science);
              SqlParameter pHistory = new SqlParameter("@History",mark.History);
              SqlParameter pEnglish = new SqlParameter("@Eng",mark.English);
              SqlParameter pAvg = new SqlParameter("@Avg", Avg);
              SqlParameter pSAvg = new SqlParameter("@SAvg", SAvg);          
              result = _context.Database.ExecuteSqlRaw("EXEC MarksAdd @Id,@RollNo,@Yr,@Maths,@Geo,@Science,@History,@Eng,@Avg,@SAvg", new[]
              {pId,pRollNo,pYear,pMaths,pGeography,pScience,pHistory,pEnglish,pAvg,pSAvg });
              if (result == 1)
              {
                  status = true;
              }
              }
              catch (Exception )
              {
                  status = false;
                  throw;
              }
              return status;*/
        }

        #endregion
    }
}
