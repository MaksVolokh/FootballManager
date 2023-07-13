using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManagerBLL.Dto.UserDto
{
    public enum PlayerPosition
    {
        [Display(Name = "Striker (ST)")]
        ST,
        [Display(Name = "Centre Forward (CF)")]
        CF,
        [Display(Name = "Second Striker (SS)")]
        SS,
        [Display(Name = "Winger (WG)")]
        WG,
        [Display(Name = "Attacking Midfielder (AM)")]
        AM,
        [Display(Name = "Central Midfielder (CM)")]
        CM,
        [Display(Name = "Defensive Midfielder (DM)")]
        DM,
        [Display(Name = "Box-to-Box Midfielder (BBM)")]
        BBM,
        [Display(Name = "Wide Midfielder (WM)")]
        WM,
        [Display(Name = "Full-back (FB)")]
        FB,
        [Display(Name = "Wing-back (WB)")]
        WB,
        [Display(Name = "Centre-back (CB)")]
        CB,
        [Display(Name = "Sweeper (SW)")]
        SW,
        [Display(Name = "Libero (LB)")]
        LB,
        [Display(Name = "Goalkeeper (GK)")]
        GK
    }
}
