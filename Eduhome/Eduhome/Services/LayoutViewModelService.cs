using Eduhome.Data;
using Eduhome.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutViewModelService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public Setting GetSiteSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public Subscribe Subscribe { get; set; }
      
    }
}
