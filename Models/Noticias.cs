using System;
using System.Collections.Generic;
using System.IO;
using EPlayers.Interfaces;

namespace EPlayers.Models
{
    public class Noticias : EPlayersbase , INoticias 
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
 
       private const string PATH = "Database/equipe.csv";
        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Noticias n)
        {
            string[] linhas = { PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Texto}";
        }
         public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());

            RewriteCSV(PATH, linhas);
        }
        public List<Noticias> ReadAll()
        {
      
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias not = new Noticias();
                not.IdNoticia = Int32.Parse(linha[0]);
                not.Titulo = linha[1];
                not.Texto = linha[2];
                not.Imagem = linha[3];

                noticias.Add(not);
            }
            return noticias;
        }

        public void Update(Noticias e)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString());

            RewriteCSV(PATH, linhas);
    }
    
}
}