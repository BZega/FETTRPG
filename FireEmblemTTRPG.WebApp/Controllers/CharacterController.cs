#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FireEmblemTTRPG.Data;
using FireEmblemTTRPG.Domain.Entities;
using System.Data;
using FireEmblemTTRPG.WebApp.ViewModels;

namespace FireEmblemTTRPG.WebApp.Controllers
{
    public class CharacterController : Controller
    {
        private readonly FEContext _context;

        public CharacterController(FEContext context)
        {
            _context = context;
        }

        // GET: Character
        public async Task<IActionResult> Index()
        {
    
            return View(await _context.Characters
                .Include(x=>x.StatGrowth)
                .Include(x=>x.GrowthRate)
                .Include(x=>x.Classes)
                    .ThenInclude(x=>x.BaseStat)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.MaxStat)
                .Include(x=>x.Weapons)
                .AsNoTracking()
                .ToListAsync());
        }

        // GET: Character/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(x => x.StatGrowth)
                .Include(x => x.GrowthRate)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.BaseStat)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.MaxStat)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.Characters)
                        .ThenInclude(x => x.StatGrowth)
                .Include(x => x.Weapons)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Character/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCharacterViewModel vm)
        {
            var character = await _context.Characters.
                Include(x => x.StatGrowth).Include(x => x.GrowthRate).
                Include(x => x.Classes).Include(x => x.Weapons).SingleAsync();
            character.Name = vm.Name;
            character.Level = vm.Level;
            character.Experience = vm.Experience;
            character.StatGrowth.HP = vm.StatGrowthHP;
            character.StatGrowth.Str = vm.StatGrowthStr;
            character.StatGrowth.Mag = vm.StatGrowthMag;
            character.StatGrowth.Skl = vm.StatGrowthSkl;
            character.StatGrowth.Spd = vm.StatGrowthSpd;
            character.StatGrowth.Lck = vm.StatGrowthLck;
            character.StatGrowth.Def = vm.StatGrowthDef;
            character.StatGrowth.Res = vm.StatGrowthRes;
            character.StatGrowth.Mov = vm.StatGrowthMov;
            character.GrowthRate.HPGrowthRate = vm.GrowthHP;
            character.GrowthRate.StrGrowthRate = vm.GrowthStr;
            character.GrowthRate.MagGrowthRate = vm.GrowthMag;
            character.GrowthRate.SklGrowthRate = vm.GrowthSkl;
            character.GrowthRate.SpdGrowthRate = vm.GrowthSpd;
            character.GrowthRate.LckGrowthRate = vm.GrowthLck;
            character.GrowthRate.DefGrowthRate = vm.GrowthDef;
            character.GrowthRate.ResGrowthRate = vm.GrowthRes;
            character.Classes = vm.Class;
            character.Weapons = vm.Weapon;


            try
            {
                if (ModelState.IsValid)
                {
                    _context.Characters.Add(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
            
        }

        // GET: Character/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Level,Experience,StatGrowth_HP,StatGrowth_Str,StatGrowth_Mag,StatGrowth_Skl,StatGrowth_Spd,StatGrowth_Lck,StatGrowth_Def,StatGrowth_Res,StatGrowth_Mov,GrowthRate_HPGrowthRate,GrowthRate_StrGrowthRate,GrowthRate_MagGrowthRate,GrowthRate_SklGrowthRate,GrowthRate_SpdGrowthRate,GrowthRate_LckGrowthRate,GrowthRate_DefGrowthRate,GrowthRate_ResGrowthRate,ClassId,WeaponId")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: Character/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
