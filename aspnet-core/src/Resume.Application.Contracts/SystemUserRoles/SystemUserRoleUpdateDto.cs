using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemUserRoles
{
    public class SystemUserRoleUpdateDto
    {
        [Required]
        [StringLength(SystemUserRoleConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public int Keys { get; set; }
        [StringLength(SystemUserRoleConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemUserRoleConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemUserRoleConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}