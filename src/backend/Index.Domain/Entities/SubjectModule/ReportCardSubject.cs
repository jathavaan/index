﻿namespace Index.Domain.Entities.SubjectModule;

public class ReportCardSubject
{
    public string SubjectCode { get; set; } = null!;
    public int ReportCardId { get; set; }
    public int Year { get; set; }
    public Semester Semester { get; set; }
    public Grade Grade { get; set; }

    public virtual Subject Subject { get; set; } = null!;
    public virtual ReportCard ReportCard { get; set; } = null!;
}