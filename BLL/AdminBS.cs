﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBs
    {
        public CategoryBs categoryBs { get; set; }
        public UrlBs urlBs { get; set; }
        public UserBs userBs { get; set; }
        public AdminBs()
        {
            categoryBs = new CategoryBs();
            userBs = new UserBs();
            urlBs = new UrlBs();
        }

    }
}
