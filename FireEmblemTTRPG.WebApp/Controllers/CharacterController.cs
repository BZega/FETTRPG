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
using System.Data.SqlClient;
using System.Collections.Generic;

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
                .Include(x => x.StatGrowth)
                .Include(x => x.GrowthRate)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.BaseStat)
                .Include(x => x.Classes)
                    .ThenInclude(x => x.MaxStat)
                .Include(x => x.Weapons)
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
            CreateCharacterViewModel model = new CreateCharacterViewModel();
            model.ClassNames = GetClasses().Select<Class, ClassCheckSelect>(x => new ClassCheckSelect() { Name = x.Name, ClassId = x.Id }).ToList();
            model.WeaponNames = GetWeapons().Select<Weapon, WeaponCheckSelect>(x => new WeaponCheckSelect() { Name = x.Name, WeaponId = x.Id }).ToList();
            return View(model);
        }

        // POST: Character/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCharacterViewModel vm)
        {

            var character = new Character();
            var stat = new Stat();
            var growthRate = new GrowthRate();
            List<Class> classnames = GetClasses();
            List<Weapon> weaponnames = GetWeapons();

            //var classes = new List<Class>();
            //var weapons = new List<Weapon>();

            character.Name = vm.Name;
            character.Level = vm.Level;
            character.Experience = vm.Experience;
            stat.HP = vm.StatGrowthHP;
            stat.Str = vm.StatGrowthStr;
            stat.Mag = vm.StatGrowthMag;
            stat.Skl = vm.StatGrowthSkl;
            stat.Spd = vm.StatGrowthSpd;
            stat.Lck = vm.StatGrowthLck;
            stat.Def = vm.StatGrowthDef;
            stat.Res = vm.StatGrowthRes;
            stat.Mov = vm.StatGrowthMov;
            growthRate.HPGrowthRate = vm.GrowthHP;
            growthRate.StrGrowthRate = vm.GrowthStr;
            growthRate.MagGrowthRate = vm.GrowthMag;
            growthRate.SklGrowthRate = vm.GrowthSkl;
            growthRate.SpdGrowthRate = vm.GrowthSpd;
            growthRate.LckGrowthRate = vm.GrowthLck;
            growthRate.DefGrowthRate = vm.GrowthDef;
            growthRate.ResGrowthRate = vm.GrowthRes;

            character.StatGrowth = stat;
            character.GrowthRate = growthRate;

            character.Classes = vm.SelectedClasses.Select<int, Class>(x => classnames.FirstOrDefault(y => y.Id == x)).ToList();
            character.Weapons = vm.SelectedWeapons.Select<int, Weapon>(x => weaponnames.FirstOrDefault(y => y.Id == x)).ToList();



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

        private List<Class> GetClasses()
        {
            return _context.Classes.ToList();
        }

        private List<Weapon> GetWeapons()
        {
            return _context.Weapons.ToList();
        }


        // GET: Character/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                                  .Include(x => x.StatGrowth)
                                  .FirstOrDefaultAsync(x => x.Id == id);

            if (character == null)
            {
                return NotFound();
            }


            var editVM = new EditViewModel
            {
                Id = character.Id,
                Name = character.Name,
                Level = character.Level,
                Experience = character.Experience,
                StatGrowthHP = character.StatGrowth.HP,
                StatGrowthStr = character.StatGrowth.Str,
                StatGrowthMag = character.StatGrowth.Mag,
                StatGrowthSkl = character.StatGrowth.Skl,
                StatGrowthSpd = character.StatGrowth.Spd,
                StatGrowthLck = character.StatGrowth.Lck,
                StatGrowthDef = character.StatGrowth.Def,
                StatGrowthRes = character.StatGrowth.Res,
                StatGrowthMov = character.StatGrowth.Mov
            };
            return View(editVM);
        }

        // POST: Character/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditViewModel editVM)
        {

            if (ModelState.IsValid == false)
            {
                return View(editVM);
            }

            var character = await _context.Characters
                                  .Include(x => x.StatGrowth)
                                  .FirstOrDefaultAsync(x => x.Id == id);
            character.Level = editVM.Level;
            character.Experience = editVM.Experience;
            character.StatGrowth.HP = editVM.StatGrowthHP;
            character.StatGrowth.Str = editVM.StatGrowthStr;
            character.StatGrowth.Mag = editVM.StatGrowthMag;
            character.StatGrowth.Skl = editVM.StatGrowthSkl;
            character.StatGrowth.Spd = editVM.StatGrowthSpd;
            character.StatGrowth.Lck = editVM.StatGrowthLck;
            character.StatGrowth.Def = editVM.StatGrowthDef;
            character.StatGrowth.Res = editVM.StatGrowthRes;
            character.StatGrowth.Mov = editVM.StatGrowthMov;


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
