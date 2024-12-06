﻿namespace lms.Domain;

public class ClassModel
{
    public required string Name { get; set; }
    public List<CourseModel> Courses { get; set; } = [];
    public List<StudentModel> Students { get; set; } = [];
}
