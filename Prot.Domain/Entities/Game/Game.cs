using Prot.Domain.Commons;

namespace Prot.Domain.Entities.Game;

public class Game: Auditable
{
    public int Attempts { get; set; }
    public bool Win { get; set; }
    public List<string> Description { get; set; }
}
