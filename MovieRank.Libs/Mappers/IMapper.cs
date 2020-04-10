using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieResponse> ToMovieResponseContract(ScanResponse response);
        MovieResponse ToMovieResponseContract(IDictionary<string, AttributeValue> item);
        MovieResponse ToMovieContract(GetItemResponse item);

    }
}
