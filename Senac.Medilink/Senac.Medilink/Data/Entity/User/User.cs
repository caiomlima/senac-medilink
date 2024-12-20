﻿using Senac.Medilink.Common;
using Senac.Medilink.Data.Dto.Request.Login;
using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity.User;

public class User : BaseEntity
{
    public User() { }

    public User(
        string email,
        string password,
        UserType userType)
    {
        Email = email;
        Password = password;
        UserType = userType;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        Active = true;
    }
        
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserType UserType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool Active { get; private set; }

    public virtual Professional Professional { get; private set; }
    public virtual Patient Patient { get; private set; }

    internal void AddProfessional(string name, string document)
    {
        Professional = new Professional(name, document);
    }

    internal void AddPatient(string name, string document)
    {
        Patient = new Patient(name, document);
    }

    internal void Inactivate()
    {
        Active = false;
        UpdatedAt = DateTime.Now;
    }

    internal void UpdateEmail(string email) 
    {
        Email = email;
        UpdatedAt = DateTime.Now;
    }

    internal void UpdatePassword(string password)
    {
        Password = password;
        UpdatedAt = DateTime.Now;
    }

    // usar isso pra pegar a role pelo type
    //internal UserRole GetRole()
    //{
    //    UserType switch
    //    {
    //        case UserType.Admin => UserRole.Admin,
    //    };
    //}
}
