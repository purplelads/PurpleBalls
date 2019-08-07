using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleBalls.Data.Models
{
    public class PlayerShirt
    {
        [Key()]
        public int PlayerShirtId { get; set; }
        public string ShirtName {get; set;}
        public int ShirtNumber { get; set; }
        public int ShirtStyle { get; set; }
        public string ShirtPrimary { get; set; }
        public string ShirtSecondary { get; set; }
        public string TextColour { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
