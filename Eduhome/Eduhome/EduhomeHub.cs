using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome
{
    public class EduhomeHub:Hub
    {
        private readonly UserManager<AppUser> _userManager;

        public EduhomeHub(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
    }
}
