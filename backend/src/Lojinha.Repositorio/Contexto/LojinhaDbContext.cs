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

            mb.Entity<Venda>()
                .Property(nameof(Venda.Data))
                .HasComputedColumnSql("getdate()");


            // POPULAR DB INICIAL
            mb.Entity<Funcionario>().HasData(
                    new Funcionario
                    {
                        Matricula = 1,
                        Nome = "Funcionario 1",
                        Endereco = "Endereco funcionario 1",
                        Telefone = "Telefone funcionario 1",
                        Cpf = "123456789-88",
                        SalarioBase = 1200
                    },
                    new Funcionario
                    {
                        Matricula = 2,
                        Nome = "Funcionario 2",
                        Endereco = "Endereco funcionario 2",
                        Telefone = "Telefone funcionario 2",
                        Cpf = "123456789-00",
                        SalarioBase = 980
                    }
                );

            mb.Entity<Produto>().HasData(
                    new Produto
                    {
                        Codigo = 1,
                        Nome = "Produto 1",
                        Descricao = "Descricao produto 1",
                        Valor = 75.89,
                        QtdEstoque = 20,
                        EstoqueMinimo = 10,
                        Validade = DateTime.Now.AddMonths(6)
                    },
                    new Produto
                    {
                        Codigo = 2,
                        Nome = "Produto 2",
                        Descricao = "Descricao produto 2",
                        Valor = 52.00,
                        QtdEstoque = 8,
                        EstoqueMinimo = 10,
                        Validade = DateTime.Now.AddMonths(4)
                    },
                    new Produto
                    {
                        Codigo = 3,
                        Nome = "Produto 3",
                        Descricao = "Descricao produto 3",
                        Valor = 39.99,
                        QtdEstoque = 20,
                        EstoqueMinimo = 30,
                        Validade = DateTime.Now.AddDays(-5)
                    }
                );

        }


    }
}
