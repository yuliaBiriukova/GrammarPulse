﻿namespace GrammarPulse.BLL.Entities;

public class Topic
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public int LevelId { get; set; }

    public Level Level { get; set; }

    public ICollection<VersionEntity> Versions { get; set; }

    public ICollection<Excercise> Excercises { get; set; }
}