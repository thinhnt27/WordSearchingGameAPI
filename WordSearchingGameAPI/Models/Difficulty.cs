﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WordSearchingGameAPI.Models;

public partial class Difficulty
{
    public int DifficultyId { get; set; }

    public string DifficultyLevel { get; set; }

    public virtual ICollection<Level> Levels { get; set; } = new List<Level>();

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}