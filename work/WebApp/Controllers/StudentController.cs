using DAL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using WebApp.StdRepo;
using System;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataContext _context;
        Repository repo;
        private readonly IMapper _mapper;
        public StudentController(StudentDataContext context, IMapper mapper)
        {
            _context = context;
            repo = new Repository(_context);
            _mapper = mapper;
        }
        #region for view of AddStudent
        public IActionResult AddStudent()
        {
            return View();
        }
        #endregion

        #region View students data who have scored more than 90% for past two years
        public IActionResult ViewStudent()
        {
            List<Models.Student> lstModelStd = new List<Models.Student>();
            var listStudents = repo.GetStudents();
            foreach (var std in listStudents)
            {
                lstModelStd.Add(_mapper.Map<Models.Student>(std));
            }
            return View(lstModelStd);
        }
        #endregion

        #region saving students data in student table
        [HttpPost]
        public IActionResult SaveAddStudents(Models.Student student)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = repo.AddStudent(_mapper.Map<Student>(student));
                    if (status)
                        return RedirectToAction("AddStudent", student);
                    else
                        return View("Error");
                }
            }
            catch (System.Exception)
            {

                return View("Error");
            }
            return View("AddStudent", student);
        }
        #endregion

        #region update student
        public IActionResult UpdateStudent(Models.Student std)
        {
            return View(std);
        }
        #endregion

        #region update student post method
        [HttpPost]
        public IActionResult SaveUpdateStudents(Models.Student student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = repo.UpdateStudent(_mapper.Map<Student>(student));
                    if (status)
                        return RedirectToAction("ViewStudent");
                    else
                        return View("Error");
                }
                catch (System.Exception)
                {
                    return View("Error");
                }
            }
            return View("UpdateStudent", student);
        }
        #endregion

        #region delete student
        public IActionResult DeleteStudent(Models.Student student)
        {
            return View(student);
        }
        #endregion
        
        #region delete student method
        [HttpPost]
        public IActionResult SaveDelete(int RollNo)
        {
            bool status = false;
            try
            {
                status = repo.DeleteStd(RollNo);
                if (status)
                {
                    return RedirectToAction("ViewStudent");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
         
        }
        #endregion
    }
}
