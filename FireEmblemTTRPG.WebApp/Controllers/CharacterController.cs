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

            var character = new Character();
            var stat = new Stat();
            var growthRate = new GrowthRate();
            var classes = new Class();
            var weapon = new Weapon();
            List<Class> classnames = PopulateClassNames();
            List<Weapon> weaponnames = PopulateWeaponNames();

            character.Id = vm.CharacterId;    
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
            classes.Id = vm.ClassId;
            weapon.Id = vm.WeaponId;

            classnames.Add(vm.ClassName());

            


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

        private static List<Class> PopulateClassNames()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FEDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<Class> items = new List<Class>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT Name FROM Class";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new Class
                            {
                                Name = sdr["Name"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

        private static List<Weapon> PopulateWeaponNames()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FEDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<Weapon> items = new List<Weapon>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT Name FROM Weapon";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new Weapon
                            {
                                Name = sdr["Name"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
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
