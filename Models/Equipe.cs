using System;
using System.Collections.Generic;
using System.IO;
using EPlayers.Interfaces;

namespace EPlayers.Models
{
    public class Equipe : EPlayersbase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public void Create(Equipe e)
        {
            string[] linhas = { PrepararLinha(e)};
            File.AppendAllLines(PATH, linhas);
        }
        private string PrepararLinha(Equipe e)
        {
            return $"{e.IdEquipe}{e.Nome};{e.Imagem}";
        }
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());

            RewriteCSV(PATH, linhas);
        }
        public List<Equipe> ReadAll()
        {
      
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString());

            RewriteCSV(PATH, linhas);
        }

        }

       
    }

