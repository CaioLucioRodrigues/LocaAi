using Xunit;

namespace LocaAi.Test.Infra
{
    [CollectionDefinition("Database Collection")]
    public class DataBaseCollection : ICollectionFixture<DataDBInitialilizer>
    {
    }
}
