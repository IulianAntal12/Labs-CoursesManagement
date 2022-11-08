using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsAndCoursesManagement.Models.Models
{
    public abstract class Person
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Surname { get;  protected set; }

        public string Gender { get; protected set; }
    }
}
