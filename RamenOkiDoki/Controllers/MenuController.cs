﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data.Models;
using Data.ViewModels;

using Microsoft.AspNetCore.Mvc;

using RamenOkiDoki.Services;

namespace RamenOkiDoki.Controllers
{
    public class MenuController : Microsoft.AspNetCore.Mvc.Controller
    {
        private MenuEndpointService _menuEndpointService { get; set; }

        public MenuController(MenuEndpointService menuEndpointService)
        {
            _menuEndpointService = menuEndpointService;
        }

        public IActionResult Index()
        {
            return View();
        }
        private async Task<FoodItemsViewModel> MakeMenu()
        {
            Globals.FullFoodMenuList = await _menuEndpointService.GetFoodItemsFromCloud();

            FoodItemsViewModel foodItemsViewModel = new FoodItemsViewModel();

            if (Globals.FullFoodMenuList != null)
            {
                foodItemsViewModel.FullFoodMenuList = Globals.FullFoodMenuList;
            }


            return foodItemsViewModel;
        }

        #region =  Dine In Menu

        [Route("menu")]
        public async Task<IActionResult> DineInMenu()
        {
            var foodItemsViewModel = await MakeMenu();

            return View(foodItemsViewModel);
        }



        #endregion

        #region = Take Out Menu

        [Route("take-out")]
        public async Task<IActionResult> TakeOutMenu(string categoryString)
        {
            var foodItemsViewModel = await MakeMenu();

            if (Globals.FullFoodMenuList != null)
            {
                foodItemsViewModel.FoodCategories = new List<string>();

                foreach (var foodCategory in Globals.FullFoodMenuList)
                {
                    if (foodCategory != null && foodCategory.Category != null && foodCategory.FoodItems != null)
                    {
                        foodItemsViewModel.FoodCategories.Add(foodCategory.Category.ToString());
                    }
                }

                foodItemsViewModel.FoodCategories.Distinct().ToString();


                if (string.IsNullOrWhiteSpace(categoryString))
                {
                    if (foodItemsViewModel.FoodCategories.Count > 0)
                    {
                           categoryString = foodItemsViewModel.FoodCategories[0];
                    }
                 
                    if (Globals.CurrentCategory != null)
                    {
                        foreach (var category in foodItemsViewModel.FoodCategories)
                        {
                            if (category == Globals.CurrentCategory)
                            {
                                categoryString = category;
                            }
                        }
                    }
                }

                foodItemsViewModel.FoodItems = new List<FoodMenu.FoodItem>();

                foreach (var categoryItem in Globals.FullFoodMenuList)
                {
                    if (categoryItem.Category == (categoryString))
                    {
                        if (categoryItem.FoodItems != null)
                        {
                            foodItemsViewModel.FoodItems = categoryItem.FoodItems;
                        }

                    }
                }
            }

            return View(foodItemsViewModel);
        }

        #endregion
    }
}
