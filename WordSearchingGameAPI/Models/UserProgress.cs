﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WordSearchingGameAPI.Models;

public partial class UserProgress
{
    public int ProgressId { get; set; }

    public int? UserId { get; set; }

    public int? LevelId { get; set; }

    public bool? Completed { get; set; }

    public DateTime? CompletionTime { get; set; }

    public virtual Level Level { get; set; }

    public virtual User User { get; set; }
}