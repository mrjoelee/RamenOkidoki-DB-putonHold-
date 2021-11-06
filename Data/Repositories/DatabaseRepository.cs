﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models.DashboardData;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data.Repositories
{
    public class DatabaseRepository
    {
        private RestaurantDbContext _context;
        public DatabaseRepository()
        {
            _context = new RestaurantDbContext();
        }

        public BusinessLocation GetBusinessLocation()
        {
            BusinessLocation businessLocation = _context.BusinessLocations.First() as BusinessLocation;
                
                

            return businessLocation;
        }

        public HoursOfOperation GetHoursOfOperation()
        {
            HoursOfOperation hoursOfOperation = _context.BusinessHours.FirstOrDefault();

            return hoursOfOperation;
        }

        public AddOnCharges GetAddOnCharges()
        {
            AddOnCharges addOnCharges = _context.AddOns.FirstOrDefault();

            return addOnCharges;
        }

        public void SaveRestaurantData<T>(T data)
        {
            _context.Update(data);

            _context.SaveChanges();
        }
       public void AddRestaurantData<T>(T data)
        {
            _context.Add(data);

            _context.SaveChanges();
        }    

        //public void AddRestaurantDataList <T> (List<T> dataList)
        //{
        //    _context.Add(dataList);

        //    _context.SaveChanges();
        //}
    }
}