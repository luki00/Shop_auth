﻿using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_auth.Repos
{
    public interface IRolesRepo
    {
        RolesViewModel GetRolesListViewModel();

        bool SetRoleViewModel(RolesViewModel role);
    }
}