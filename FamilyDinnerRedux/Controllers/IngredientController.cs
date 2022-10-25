﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyDinnerRedux.Data;
using FamilyDinnerRedux.Models;

namespace FamilyDinnerRedux.Controllers
{
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ingredients.ToListAsync());
        }

        // GET: Ingredient/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredientModel == null)
            {
                return NotFound();
            }

            return View(ingredientModel);
        }

        // GET: Ingredient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,IngredientName")] IngredientModel ingredientModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientModel);
        }

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients.FindAsync(id);
            if (ingredientModel == null)
            {
                return NotFound();
            }
            return View(ingredientModel);
        }

        // POST: Ingredient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,IngredientName")] IngredientModel ingredientModel)
        {
            if (id != ingredientModel.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientModelExists(ingredientModel.IngredientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredientModel);
        }

        // GET: Ingredient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingredients == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredientModel == null)
            {
                return NotFound();
            }

            return View(ingredientModel);
        }

        // POST: Ingredient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingredients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ingredients'  is null.");
            }
            var ingredientModel = await _context.Ingredients.FindAsync(id);
            if (ingredientModel != null)
            {
                _context.Ingredients.Remove(ingredientModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientModelExists(int id)
        {
          return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
