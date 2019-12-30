using LocaAi.Domain.Entities;
using LocaAi.Infra.Data.Context;
using LocaAi.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LocaAi.Test.Infra.UnityTests
{
    [Collection("Database Collection")]
    public class ProdutoRepositoryUnitTest
    {
        private readonly LocaAiContext _context;
        private readonly ProdutoRepository _repository; 

        public ProdutoRepositoryUnitTest(DataDBInitialilizer dbInitializer)
        {
            _context = dbInitializer.context;
            _repository = new ProdutoRepository(_context);
        }

        [Fact]
        public async Task TesteCarregarTodos()
        {
            IList<Produto> produtos = await _repository.CarregarTodos();            
            Assert.Equal(3, produtos.Count);
        }
    }
}
