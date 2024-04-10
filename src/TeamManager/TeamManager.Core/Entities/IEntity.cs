using System.ComponentModel.DataAnnotations;

namespace TeamManager.Core.Entities
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
