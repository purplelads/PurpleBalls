using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleBalls.Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
