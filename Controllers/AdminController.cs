﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Zmienianie informacji o książce \"{0}\" zapisane", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View("Edit", new Book());
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid == true)
            {
                repository.SaveBook(book);
                TempData["message"] = "Produkt został zapisany w bazie danych";

                return RedirectToAction("Index");
            }
            return View("Edit", book);
        }
        
        public ActionResult Delete(Book book)
        {
            book = repository.Books.FirstOrDefault(p => p.BookId != 0);
            if (ModelState.IsValid == true)
            {
                repository.Delete(book);
                TempData["message"] = "Produkt został usuwany z bazy danych";

                return RedirectToAction("Index");
            }
            return View("Delete", book);
        }

    }
}