﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models;
using Data.Models.DashboardData;
using Data.Models.FoodMenus;
using Data.Repositories;
using Data.ViewModels;

using DataServices.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace RamenOkiDoki.Controllers
{
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuEndpointService _menuEndpointService;
        private DatabaseRepository _databaseRepository;

        private RestaurantDbContext _context;

        //  public List<FoodItem> FoodItemsList;

        public AdminController(ILogger<HomeController> logger, MenuEndpointService menuEndpointService, DatabaseRepository databaseRepository)
        {
            _logger = logger;
            _menuEndpointService = menuEndpointService;
            _databaseRepository = databaseRepository;
        }


        //returns the users to the index(home of the index view page)
        public IActionResult Index()
        {
           DashboardViewModel dashboardViewModel = new DashboardViewModel();
           
            return View(dashboardViewModel);

        }




        //Gets the menu from cloud via SQL DB - and returns the view as Food Items which is created in FoodItemsviewModel
        public async Task<IActionResult> FoodMenuEdit()
        {
            Globals.FoodCategoriesList = _databaseRepository.GetFoodCategories();
            
            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

            if (Globals.FoodCategoriesList != null)
            {
                foodItemsViewModel.FoodCategoriesList = Globals.FoodCategoriesList;   
            
            }

            if (Globals.FoodCategoriesList != null && Globals.FoodCategoriesList.Count > 0)
            {

                foreach (var category in Globals.FoodCategoriesList)
                {

                    if (category != null)// && category.FoodItems.Count > 0)
                    {

                        foreach (var fooditem in category.FoodItems)
                        {
                            
                            if (fooditem != null)
                            {
                                foodItemsViewModel.FoodItems.Add(fooditem);

                            }
                        }
                    }
                }

            }

            if (foodItemsViewModel != null)
            {
                return View(foodItemsViewModel);
            }


            return View();
        }


        //Creates new item and returns to the menu.
        public IActionResult FoodMenuAddEdit(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                if (Globals.FoodCategoriesList == null || Globals.FoodCategoriesList.Count < 1)
                {
                  //  Globals.FoodCategoriesList = await _menuEndpointService.GetFoodItemsFromCloud();

                  Globals.FoodCategoriesList = _databaseRepository.GetFoodCategories();
                }

                foreach (var category in Globals.FoodCategoriesList)
                {
              

                    if (category.FoodItems != null && category.FoodItems.Count > 0)
                    {
                        foreach (var item in category.FoodItems)
                        {
                            if (item != null)
                            {
                                //   int.TryParse(item.id, out itemId);

                                if (item.Id == index)
                                {
                                  
                                    item.foodCategory = category.Category;
                                    item.foodCategoryId = category.Id;
     
                                    return View(item);
                                }
                            }

                        }
                    }
                }
            }


            return View();
        }
        #region saving new item

        [HttpPost]
        public async Task<IActionResult> PutMenuItem(FoodMenu.FoodItem item)
        {
            foreach (var category in Globals.FoodCategoriesList)
            {
                if (category.Category == item.foodCategory)
                {
                    item.foodCategoryId = category.Id;
                }
            }

         //   await _menuEndpointService.AddMenuItemToCloud(item);

            return Redirect("FoodMenuEdit");
        }
        #endregion

        #region deleting  item
        public async Task<IActionResult> DeleteMenuItem(int? id)
        {
            if (id != null)
            {
                int index = (int)id;
                int itemId;

                foreach (var item in Globals.FoodItemsList)
                {
                    //  int.TryParse(item.Id, out itemId);

                    if (item.Id == index)
                    {
                        await _menuEndpointService.DeleteMenuItemFromCloud(index);
                    }
                }
            }

            return RedirectToAction("FoodMenuEdit");
        }
        #endregion


        public IActionResult AdminSignin()
        {
            Globals.UserSignedIn = true;

            Globals.UserRole = Globals.UserRoles.Admin;

            return Redirect("Index");
        }

        
        public IActionResult AdminSignOut()
        {
            Globals.UserSignedIn = false;

            Globals.UserRole = Globals.UserRoles.Patron;//Globals.UserRoles.Admin;

            return Redirect("Index");

        }

        public IActionResult DashBoard()
        {
            return View("Index");
        }

        public IActionResult OpenAddressForm()
        {
            Globals.DisplayAddressForm = true;

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult SaveBusinessLocation(DashboardViewModel dvm)
        {
            Globals.DisplayAddressForm = false;
            
            var location = dvm.MyBusinessLocation;

            if (location != null)
            {
                _databaseRepository.SaveRestaurantData<BusinessLocation>(location);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult OpenHourOfOperationForm()
        {
            Globals.DisplayHoursForm = true;
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        [HttpPost]
        public IActionResult SaveHoursOfOperation(DashboardViewModel dvm)
        {
            Globals.DisplayHoursForm = false;

            var hours = dvm.MyHoursOfOperation;

            if (hours != null)
            {
                _databaseRepository.SaveRestaurantData<HoursOfOperation>(hours);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }

        public IActionResult OpenAddOnsForm()
        {
            Globals.DisplayAddOnsForm = true;

            return Redirect("Index");
        }

        public IActionResult SaveAddOnsForm(DashboardViewModel dvm)
        {
            Globals.DisplayAddOnsForm = false;

            AddOnCharges addOnCharges = dvm.AddOns;

            if (addOnCharges != null)
            {
                _databaseRepository.SaveRestaurantData<AddOnCharges>(addOnCharges);
            }

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            return RedirectToAction("Index", dashboardViewModel);
        }
    }
}

