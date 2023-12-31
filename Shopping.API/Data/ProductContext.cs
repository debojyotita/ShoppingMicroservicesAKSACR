using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public  class ProductContext
    {    
        public IMongoDatabase _catalogDB { get; set; }
        private IConfiguration _configuration;
        private bool isFirsttimeInitiated;

        public ProductContext(IConfiguration configuration)
        {
            _configuration=configuration;
            MongoClient client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            _catalogDB = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            isFirsttimeInitiated = true;
        } 
        
        public async Task<IMongoCollection<Product>>  GetProducts()
        {
            if (_catalogDB != null)
            {
                if (isFirsttimeInitiated)
                {
                    await _catalogDB.GetCollection<Product>(_configuration["DatabaseSettings:CollectionName"]).InsertManyAsync(ProductItems.Products);
                    isFirsttimeInitiated=false;
                }                             
                return _catalogDB.GetCollection<Product>(_configuration["DatabaseSettings:CollectionName"]);
            }
            else
            {
                return null;
            }
            
        }
    }
}
