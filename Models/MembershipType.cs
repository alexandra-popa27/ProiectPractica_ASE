using System;
using System.ComponentModel.DataAnnotations;
namespace ProiectPractica_ASE.Models
{
    public class MembershipType
    {
        [Key]
        public Guid IdMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLenghtMonths { get; set; }
        public string Text { get; set; }
    }
}
