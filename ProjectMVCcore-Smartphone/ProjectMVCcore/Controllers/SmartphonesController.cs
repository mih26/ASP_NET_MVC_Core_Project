using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMVCcore.Models;
using ProjectMVCcore.ViewModels;

namespace ProjectMVCcore.Controllers
{ 
        public class SmartphonesController : Controller
{
    
        private readonly SmartphoneDbContext db;
        private readonly IWebHostEnvironment env;
        public SmartphonesController (SmartphoneDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public async Task<IActionResult> All()
        {
            var data = await db.Configurations.ToListAsync();
            return Json(data);
        }
        public IActionResult Index()
        {
            return View(db.Smartphones.Include(d => d.Configurations).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SmartphoneInputModel model)
        {
            if (ModelState.IsValid)
            {
                var Smartphone = new Smartphone
                {
                    SmartphoneModel = model.SmartphoneModel,
                    ManufactureDate = model.ManufactureDate,
                    Price = model.Price,
                    Instock = model.Instock,
                    Picture = model.Picture

                };
               foreach(var s in model.configurations)
                {
                    Smartphone.Configurations.Add(new Configuration { ConfigurationDetails = s.ConfigurationDetails, BrandValue = s.BrandValue });
                }
                await db.Smartphones.AddAsync(Smartphone);
                await db.SaveChangesAsync();
                return Json(new { id = Smartphone.SmartphoneId });
            }
            return View(null);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await db.Smartphones.Include(x => x.Configurations).FirstOrDefaultAsync(x => x.SmartphoneId == id);
            if (data == null) return NotFound();
            var viewData = new SmartphoneEditModel
            {
                SmartphoneId = data.SmartphoneId,
                SmartphoneModel = data.SmartphoneModel,
                ManufactureDate = data.ManufactureDate,
                Price = data.Price,
                Instock = data.Instock,
                Picture = data.Picture
            };
            viewData.Configurations = data.Configurations.Select(x => new ConfigurationInputModel { ConfigurationDetails = x.ConfigurationDetails, BrandValue = x.BrandValue, ConfigurationId = x.ConfigurationId }).ToList();
            return View(viewData);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(SmartphoneEditModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await db.Smartphones.Include(x => x.Configurations).FirstOrDefaultAsync(x => x.SmartphoneId == model.SmartphoneId);
                if (data == null) return NotFound();
                db.Configurations.RemoveRange(data.Configurations);
                data.SmartphoneModel = model.SmartphoneModel;
                data.ManufactureDate = model.ManufactureDate;
                data.Price = model.Price;
                data.Instock = model.Instock;
                data.Picture = model.Picture;
                foreach (var s in model.Configurations)
                {
                    data.Configurations.Add(new Configuration { ConfigurationDetails = s.ConfigurationDetails, BrandValue = s.BrandValue });
                }
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Smartphone d = new Smartphone { SmartphoneId = id };
            db.Entry(d).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Json(new { id = id });
        }
        public IActionResult GetConfigurations(int id)
        {
            var data = db.Configurations.Where(x => x.SmartphoneId == id).ToList();
            return Json(data);
        }
        public async Task<IActionResult> Upload(ImageUpload data)
        {
            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(data.Picture.FileName).ToLower();
                string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                FileStream fs = new FileStream(Path.Combine(env.WebRootPath, "Pictures", f), FileMode.Create);
                await data.Picture.CopyToAsync(fs);
                fs.Close();
                return Json(new { Saved = f });
            }
            return Json(null);
        }
    }
}
