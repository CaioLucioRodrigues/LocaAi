using LocaAi.Domain.Entities;
using LocaAi.Infra.Data.Context;
using LocaAi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAi.Test.Infra
{
    public class DataDBInitialilizer : IDisposable
    {
        //TODO colocar em um arquivo de configuração
        private readonly string _connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=LocaAiDbTest;Integrated Security=SSPI;MultipleActiveResultSets=True";
        private readonly DbContextOptions<LocaAiContext> _dbContextOptions;
        public LocaAiContext context { get; set; }

        CategoriaRepository _categoriaRepository;
        UsuarioRepository _usuarioRepository;
        ProdutoRepository _produtoRepository;


        public DataDBInitialilizer()
        {
            _dbContextOptions = new DbContextOptionsBuilder<LocaAiContext>()
                            .UseSqlServer(_connectionString, options => options.MaxBatchSize(10))
                            .Options;

            context = new LocaAiContext(_dbContextOptions);

            _categoriaRepository = new CategoriaRepository(context);
            _usuarioRepository = new UsuarioRepository(context);
            _produtoRepository = new ProdutoRepository(context);

#pragma warning disable CS4014
            Seed();
#pragma warning restore CS4014 
        }

        public void Seed()
        {
            limparBanco();
            persistirUsuarios();
            persistirCategorias();
            persistirProduto();

            context.SaveChanges();
        }

        private void persistirUsuarios()
        {
            context.Usuarios.AddRangeAsync(
                new Usuario() { Nome = "Caio", Ativo = true, DataCadastro = DateTime.Now },
                new Usuario() { Nome = "Cabron", Ativo = true, DataCadastro = DateTime.Now }
            );

            context.SaveChanges();
        }

        private void persistirCategorias()
        {
            context.Categorias.AddRangeAsync(
                new Categoria() { Nome = "Geral", Ativo = true, DataCadastro = DateTime.Now },
                new Categoria() { Nome = "Furadeiras", Ativo = true, DataCadastro = DateTime.Now }
            );

            context.SaveChanges();
        }

        private void persistirProduto()
        {
            Categoria categoriaGeral = _categoriaRepository.Buscar(c => c.Nome == "Geral").Result.FirstOrDefault();
            Categoria categoriaFuradeira = _categoriaRepository.Buscar(c => c.Nome == "Furadeiras").Result.FirstOrDefault();
            Usuario usuarioCaio = _usuarioRepository.BuscarPorNome("Caio").Result.FirstOrDefault();

            context.Produtos.AddRangeAsync(
                new Produto()
                {
                    Nome = "Vap",
                    Descricao = "Jatos de alta pressão",
                    CategoriaId = categoriaGeral.Id,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    UsuarioId = usuarioCaio.Id
                },
                new Produto()
                {
                    Nome = "Caixa de Ferramentas",
                    Descricao = "Caixa completa",
                    CategoriaId = categoriaGeral.Id,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    UsuarioId = usuarioCaio.Id
                },
                new Produto()
                {
                    Nome = "Furadeira",
                    Descricao = "Nova",
                    CategoriaId = categoriaFuradeira.Id,
                    Ativo = false,
                    DataCadastro = DateTime.Now,
                    UsuarioId = usuarioCaio.Id
                }
            );

            context.SaveChanges();
        }

        private void limparBanco()
        {
            context.Database.ExecuteSqlRaw("DELETE FROM PRODUTOS");
            context.Database.ExecuteSqlRaw("DELETE FROM CATEGORIAS");
            context.Database.ExecuteSqlRaw("DELETE FROM USUARIOS");            
        }

        public async void Dispose()
        {
            limparBanco();
            await context.DisposeAsync();
        }
    }
}
