using Senac.Medilink.Common;
using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity.User
{
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
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
        }

        // TODO Adicionar um user role ??? acho que type já deve fazer isso
        public string Email { get; private set; }
        public string Password { get; private set; }
        //public string Avatar { get; set; } // TODO MANO, nem considera isso, puta trampo ....
        public UserType UserType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual Professional Professional { get; private set; }
        public virtual Patient Patient { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }

        internal void UpdateEmail(string email) 
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        internal void UpdatePassword(string password)
        {
            Password = password;
            UpdatedAt = DateTime.UtcNow;
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
}
