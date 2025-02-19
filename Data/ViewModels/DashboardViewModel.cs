﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DbContext;
using Data.Models;
using Data.Models.DashboardData;
using Data.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Data.ViewModels
{
    public class DashboardViewModel
    {
 private DatabaseRepository databaseRepository { get; set; }
        public BusinessLocation MyBusinessLocation { get; set; }
        public HoursOfOperation MyHoursOfOperation { get; set; }

        public List<CustomerReview> Reviews { get; set; }

        public int NewRating { get; set; }

        public DashboardViewModel()
        {
            databaseRepository = new DatabaseRepository();

            MyBusinessLocation = databaseRepository.GetBusinessLocation();

            MyHoursOfOperation = databaseRepository.GetHoursOfOperation();


        }
    }

}
