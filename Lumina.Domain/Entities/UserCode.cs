using Lumina.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumina.Domain.Entities;
public class UserCode:Auditable
{
    [ForeignKey(nameof(User))]
    public long UserId { get; set; }
    public User User { get; set; }

    [MaxLength(10)]
    public long Code { get; set; }

    public DateTime ExpireDate { get; set; }
}
