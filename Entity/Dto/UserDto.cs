using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserDto
    {
        public int Id;
        public string UserName { get; set; }
        public string passsword { get; set; }
        public int PersonId { get; set; }
        public bool state { get; set; }
    }
}
