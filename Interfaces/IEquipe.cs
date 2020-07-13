using System.Collections.Generic;
using EPlayers.Models;

namespace EPlayers.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();
         void Update(Equipe e);
         void Delete(int IdEquipe);
    }
}