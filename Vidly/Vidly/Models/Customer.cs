using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //Navigation Property
        public MembershipType MembershipType { get; set; }
        //we dont need the entire membershiptype but the id as the FK
        public int MembershipTypeId { get; set; }

    }
}