using System.Collections.Generic;
using EPlayers.Models;

namespace EPlayers.Interfaces
{
    public interface INoticias 
    {
        void Create(Noticias n);
         List<Noticias> ReadAll();
         void Update(Noticias n);
         void Delete(int IdNoticias);
    }
}