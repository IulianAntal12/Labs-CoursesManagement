using LabsAndCoursesManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsAndCoursesManagement.DataAccess.Database
{
    public class TenantContext : ITenantContext
    {
        private string[] values;
        public TenantContext()
        {
            values = new string[] { "test", "value", "incoming" };
        }

        public string CurrentTenant { get; set; }
    }
}
