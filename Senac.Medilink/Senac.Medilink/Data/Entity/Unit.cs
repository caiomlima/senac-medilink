﻿using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity;

public class Unit : BaseEntity
{
    public Unit() { }

    public Unit(
        string name,
        string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        Active = true;
        Schedules = new List<Schedule>();
        WorkSchedules = new List<ProfessionalWorkSchedules>();
        ProfessionalSpecialties = new List<ProfessionalSpecialty>();
        ExamSpecialties = new List<ExamSpecialty>();
    }

    public string Name { get; private set; }
    public string Description { get; private set; } // opcional
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool Active { get; private set; }

    public virtual ICollection<Schedule> Schedules { get; private set; }
    public virtual ICollection<ProfessionalWorkSchedules> WorkSchedules { get; private set; }
    public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; private set; }
    public virtual ICollection<ExamSpecialty> ExamSpecialties { get; private set; }

    internal void Inactivate()
    {
        Active = false;
        UpdatedAt = DateTime.Now;
    }
}
