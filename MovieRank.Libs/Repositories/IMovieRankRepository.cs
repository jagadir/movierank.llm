using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<ScanResponse> GetAllItems();
        Task<GetItemResponse> GetMovie(int userId, string movieName);
    }
}