using Lojinha.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Repositorio.Contexto
{
    public class LojinhaDbContext : DbContext 
    {
        public LojinhaDbContext(DbContextOptions<LojinhaDbContext> options) 
            : base (options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Venda>()
                .HasOne(x => x.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Cliente>()
                .HasIndex(c => c.Cpf)
                .IsUnique();

            mb.Entity<ItemVenda>()
                .HasOne(i => i.Produto)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            //mb.Entity<ItemVenda>()
            //    .Property(nameof(ItemVenda.ValorTotal))
            //    .HasComputedColumnSql("getutcdate()");


            //mb.HasDbFunction(typeof(LojinhaDbContext).GetMethod(nameof(CalculaValorTotal)))
            //            .HasName("CalculaTotal");
        }

        //public double CalculaValorTotal() => throw new NotSupportedException();

    }
}
