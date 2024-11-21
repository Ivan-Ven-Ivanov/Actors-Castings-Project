using System.ComponentModel.DataAnnotations;

namespace ActorsCastings.Data.Models
{
    public class ActorProfile
    {
        public ActorProfile()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
