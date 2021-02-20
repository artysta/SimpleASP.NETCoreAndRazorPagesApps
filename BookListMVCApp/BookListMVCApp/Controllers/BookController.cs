﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookListMVCApp.Data;
using BookListMVCApp.Models;

namespace BookListMVCApp.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext _db;

		public BookController(ApplicationDbContext db)
		{
			_db = db;
		}
		
		public IActionResult Index()
		{
			IEnumerable<Book> objList = _db.Book;
			return View(objList);
		}

		// GET for Create
		public IActionResult Create()
		{	
			return View();
		}

		// Post for Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db.Book.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		// GET for Edit
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		// POST for Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db.Book.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		// POST for Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Book.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			_db.Book.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}