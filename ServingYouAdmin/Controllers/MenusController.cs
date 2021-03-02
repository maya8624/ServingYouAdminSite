using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;
using ServingyouAdmin.Classes;

namespace ServingYouAdmin.Controllers
{
    public class MenusController : Controller 
    {
        private readonly IFuncs funcs;
        private readonly IMenuRepository repository;        
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly string imageDirectory = "images";
        private readonly string uploadDirectory = string.Empty;

        public MenusController(
            IFuncs funcs,
            IMenuRepository repository, 
            IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment
        )
        {
            this.funcs = funcs;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;            

            uploadDirectory = Path.Combine(webHostEnvironment.WebRootPath, imageDirectory);
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string currentSortOrder, 
            string sortOrder, 
            string searchString, 
            string category, 
            int? pageNumber
        )
        {
            if (pageNumber == null)
            {
                currentSortOrder = sortOrder;
                sortOrder = string.IsNullOrEmpty(sortOrder) ? "name_desc" : string.Empty;
            }

            var menus = new MenuListViewModel
            {
                Menus = await repository.GetAllMenusAsync(currentSortOrder, searchString, category, pageNumber),
                Category = category,
                SearchString = searchString,
                SortOrder = sortOrder,
                CurrentSortOrder = currentSortOrder,
            };

            return View(menus);
        }

        // GET: Menu/Details/5        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await repository.GetMenuAsync(id.Value);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuCreateViewModel model)
        {
            string fileName = string.Empty;

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        fileName = await funcs.UploadFileAsync(model.ImageFile, uploadDirectory);

                        if (!string.IsNullOrEmpty(fileName))
                        {
                            await funcs.UploadFileToS3Async(uploadDirectory, fileName);
                        }
                    }

                    var menu = new Menu
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Available = model.Available,
                        Category = model.Category,
                        Price = model.Price,                        
                        Special = model.Special,
                        SpecialPrice = model.SpecialPrice,
                        Image = fileName,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    await repository.AddSync(menu);
                    await unitOfWork.CompleteAsync();

                    // Invoke PUT Api function
                    // Update normal price to special price before calling Api cause only price column in DynamoDB
                    if (menu.Special)
                    {
                        menu.Price = menu.SpecialPrice;
                    }

                    await funcs.PostMenuToAWSAsync(menu);
                    
                    return RedirectToAction("details", new { id = menu.Id });
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        // GET: Menus/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await repository.GetMenuAsync(id.Value);

            if (menu == null)
            {
                return NotFound();
            }

            var menuEditViewModel = new MenuEditViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description,
                Category = menu.Category,
                Price = menu.Price,
                Available = menu.Available,
                Special = menu.Special,
                SpecialPrice = menu.SpecialPrice,
                Image = menu.Image
            };
           
            return View(menuEditViewModel);
        }

        // POST: Menus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var menu = await repository.GetMenuAsync(model.Id);

                    menu.Name = model.Name;
                    menu.Description = model.Description;
                    menu.Category = model.Category;
                    menu.Price = model.Price;
                    menu.Available = model.Available;
                    menu.Special = model.Special;
                    menu.SpecialPrice = model.SpecialPrice;
                    menu.DateUpdated = DateTime.Now;

                    if (model.ImageFile != null)
                    {
                        if (model.Image != null)
                        {
                            // delete the file in S3 Bucket
                            await funcs.DeleteObjectInS3Async(model.Image);

                            // delete the file in images folder
                            funcs.DeleteFile(Path.Combine(uploadDirectory, model.Image));
                        }

                        // upload a new image     
                        string fileName = await funcs.UploadFileAsync(model.ImageFile, uploadDirectory);

                        if (!string.IsNullOrEmpty(fileName))
                        {
                            menu.Image = fileName;

                            // upload the new file to S3
                            await funcs.UploadFileToS3Async(uploadDirectory, fileName);
                        }
                    }

                    repository.Update(menu);
                    await unitOfWork.CompleteAsync();
                    
                    // Invoke PUT Api function
                    // Update normal price to special price before calling Api cause only price column in DynamoDB
                    if (menu.Special)
                    {
                        menu.Price = menu.SpecialPrice;
                    }
                        
                    await funcs.PutMenuToAWSAsync(menu);
                    
                    return RedirectToAction(nameof(Details), new { id = menu.Id });
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // need to implement logging 
                throw new Exception(ex.Message);
            }            
        }       
    }
}
