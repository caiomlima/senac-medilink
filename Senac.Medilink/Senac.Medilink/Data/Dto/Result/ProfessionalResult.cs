using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Dto.Result
{
    public class ProfessionalResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; } // hmmm

        public static explicit operator ProfessionalResult(Professional entity)
        {
            if (entity == null)
                return null;

            return new ProfessionalResult
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
