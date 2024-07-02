using Bulky.DataAccess;
using Bulky.models;
using Bulky.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;

namespace Bulk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatogoriesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public CatogoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork?)unitOfWork;
        }
        public IActionResult Index()
        {
            List<Catogiries> objCatogories = _unitOfWork.CatogoryRepository.GetAll().ToList();
            return View(objCatogories);
        }
        //create
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Catogiries obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CatogoryRepository.Add(obj);
                _unitOfWork.save();
                TempData["success"] = "Catogories created successfully";
                return RedirectToAction("index");
            }
            return View(obj);


        }
        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Catogiries? categoryFromDb = _unitOfWork.CatogoryRepository.Get(u => u.id == id);
            //Catogiries? categoryFromDb=_catogoryRepo.Get(u=>u.Id==id)
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Catogiries obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CatogoryRepository.update(obj);
                _unitOfWork.save();
                TempData["success"] = "Catogories edited successfully";
                return RedirectToAction("index");
            }
            return View();
        }

        //delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0 || !id)
            {
                return NotFound();
            }


            Catogiries? categoryFromDb = _unitOfWork.CatogoryRepository.Get(u => u.id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Catogiries? obj = _unitOfWork.CatogoryRepository.Get(u => u.id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CatogoryRepository.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "Catogories Deletedsu ccessfully";
            return RedirectToAction("index");

        }

    }
}
