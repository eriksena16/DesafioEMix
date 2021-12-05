using ConsultaCEP.Models;
using ConsultaCEP.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultaCEP.Repositories.Service
{
    public class CepRepository : ICepRepository
    {
        protected readonly DbSet<CEP> DbSet;
        protected readonly DbContext Db;
        public CepRepository(DbContext context)
        {
            Db = context;
            DbSet = context.Set<CEP>();
        }

        public async Task AdicionarCep(CEP cep)
        {
            if(!await Exists(cep.cep))
            {
                DbSet.Add(cep);
                await SaveChanges();
            }
                
        }

        public async Task<List<CEP>> ListarCeps()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public Task<bool> Exists(string cep)
        {
            var teste = DbSet.AnyAsync(c => c.cep.Equals(cep));

            return teste;
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
