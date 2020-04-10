using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRank.Libs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private const string TableName = "MovieRank";
        private readonly IAmazonDynamoDB _dynamoDbClient;

        public MovieRankRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        public async Task<ScanResponse> GetAllItems()
        {
            var scanRequest = new ScanRequest(TableName);
            return await _dynamoDbClient.ScanAsync(scanRequest);
        }

       public async Task<GetItemResponse> GetMovie(int userId, string movieName)
       {
           var itemRequest = new GetItemRequest{
               TableName = TableName,
               Key = new Dictionary<string, AttributeValue>{
                   {"UserId", new AttributeValue {N = userId.ToString()}},
                   {"MovieName", new AttributeValue {S=movieName}}
               }
           };
            return await _dynamoDbClient.GetItemAsync(itemRequest);
       }
    }
}
