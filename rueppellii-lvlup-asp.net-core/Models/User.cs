﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rueppellii_lvlup_asp.net_core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string GivenName { get; set; }
        [MaxLength(25)]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public string Pic { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Pitch> Pitches { get; set; }
        public List<UserLevel> UserLevels { get; set; }
    }
}
