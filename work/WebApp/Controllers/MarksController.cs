using AutoMapper;
using DAL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata.Ecma335;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApp.Controllers
{
    public class MarksController : Controller
    {
        private readonly StudentDataContext _context;
        Repository repo;
        private readonly IMapper _mapper;
        public MarksController(StudentDataContext context, IMapper mapper)
        {
            _context = context;
            repo = new Repository(_context);
            _mapper = mapper;
        }
        #region view all student data
        public IActionResult ViewStudent()
        {
            List<Models.Marks> lstModelStd = new List<Models.Marks>();
          //List<Models.Marks> lstModelStd1 = new List<Models.Marks>();
            var listStudents = repo.GetList();
            foreach (var mark in listStudents.Item1)
            {
                lstModelStd.Add(_mapper.Map<Models.Marks>(mark));
            }
            foreach (var marks in listStudents.Item2)
            {
                lstModelStd.Add(_mapper.Map<Models.Marks>(marks));
            }
            return View(lstModelStd);
        }
        #endregion
        
        #region View all Marks table data
        public IActionResult ViewMarks()
        {List<Models.Marks> lstModelMarks = new List<Models.Marks>();
            var listMarks=repo.GetMarks();
            foreach (var mark in listMarks) 
            {
                lstModelMarks.Add(_mapper.Map<Models.Marks>(mark));    
            }
            return View(lstModelMarks);
        }
        #endregion
        
        #region update marks
        public IActionResult UpdateMarks(Models.Marks mks)
        {
            return View(mks);
        }
        #endregion
        
        #region update marks post method
        [HttpPost]
        public IActionResult SaveUpdateMarks(Models.Marks marks)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = repo.UpdateMarks(_mapper.Map<Marks>(marks));
                    if (status)
                        return RedirectToAction("ViewMarks");
                    else
                        return View("UpdateMarks");
                }
                catch (System.Exception)
                {
                    return View("UpdateMarks");
                }
            }
            return View("UpdateStudent", marks);
        }
        #endregion
        
        #region delete marks
      
        public IActionResult DeleteMarks(Models.Marks marks)
        {
            return View(marks);
        }
        #endregion
        
        #region delete student method
        [HttpPost]
        public IActionResult SaveDelete(int RollNo,int year)
        {
            bool status = false;
            try
            {
                status = repo.DeleteMarks(RollNo,year);
                if (status)
                {
                    return RedirectToAction("ViewMarks");
                }
                else
                {
                    return View("DeleteMarks");
                }
            }
            catch (Exception)
            {

                return View("DeleteMarks");
            }

        }
        #endregion
        
        #region view all student data
        public IActionResult ViewHighest()
        {
       //List<Models.Marks> lstModelStd1 = new List<Models.Marks>();
            ViewBag.One = repo.Mathsmax();
            ViewBag.Sci = repo.ScienceMax();    
            ViewBag.Three = repo.AvgMax();
            ViewBag.Four = repo.EngMax();
            return View();
        }
        #endregion

        #region add marks
        public IActionResult AddMarks()
        {
            string marksId = repo.GetNextId();
            ViewBag.NextId = marksId;
            return View();
        }
        #endregion

        #region save added students 
        [HttpPost]
        public IActionResult SaveAddMark(Marks marks) 
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                { if (marks.Science == 0 && marks.Maths == 0)
                    {
                        marks.SmAverage = 0;
                    }
                    else { marks.SmAverage = (marks.Science + marks.Maths) / 2; }
                    if (marks.Science == 0 && marks.Maths == 0 && marks.History == 0 && marks.English == 0 && marks.Geography == 0)
                    {
                        marks.MarksAverage = 0;
                    }
                    else
                    {

                        marks.MarksAverage = (marks.Science + marks.Geography + marks.Maths + marks.History + marks.English) / 5;
                    }
                    status = repo.AddMarks(_mapper.Map<Marks>(marks));
                    if (status)
                        return RedirectToAction("ViewMarks");
                    else
                        return View("AddMarks");
                }
                catch (Exception)
                {
                    return View("AddMarks");
                }
            }
            return View("ViewMarks", marks);
        }
        #endregion
    }
}
