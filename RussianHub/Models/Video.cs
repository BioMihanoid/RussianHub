﻿namespace RussianHub.Models;

public class Video
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List <Genre> Genres { get; set; } = null!; //придумать что-то с бд для этой хуйни
    public int Duration { get; set; }
    public List<Model> Models { get; set; } = null!;
    public int CountViews { get; set; }
    public string DescriptionVideo { get; set; } = null!;
    public Rating Rating { get; set; } = null!;
    public int CountComments { get; set; }
    public List<Comment> Comments { get; set; } = null!;
    public string Quality { get; set; } = null!;
    public string Photo { get; set; } = null!; //что-то придумать с фотографиями
}