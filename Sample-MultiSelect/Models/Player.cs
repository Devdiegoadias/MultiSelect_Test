using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample_MultiSelect.Models
{
    public class Player
    {
        public Player()
        {
            this.Teams = new List<Team>();
        }

        [Key]
        public Guid PlayerId { get; set; }

        [Required]
        [Display(Name = "Player Name")]
        [StringLength(128, ErrorMessage = "Player's name can only be 128 characters in length.")]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}