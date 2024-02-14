using Bulky.DataAccess;
using Bulky.models;
using Bulky.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork?)unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objCatogories = _unitOfWork.ProductRepository.GetAll().ToList();
            IEnumerable<SelectListItem>CatogoryList = _unitOfWork.CatogoryRepository.GetAll().Select(u=>new SelectListItem
            {
                Text = u.Name,
                Value=u.id.ToString(),
            } );
            return View(objCatogories);
        }
        //create
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Add(obj);
                _unitOfWork.save();
                TempData["success"] = "Products created successfully";
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

            Product? productFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            //Product? productFromDb=_catogoryRepo.Get(u=>u.Id==id)
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.update(obj);
                _unitOfWork.save();
                TempData["success"] = "Product edited successfully";
                return RedirectToAction("index");
            }
            return View();
        }

        //delete
        
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Product? productFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "Products Deleted ccessfully";
            return RedirectToAction("index");

        }

    }
}
