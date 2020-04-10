using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieResponseContract(ScanResponse response)
        {
            return response.Items.Select(ToMovieResponseContract);
        }

        public MovieResponse ToMovieResponseContract(IDictionary<string, AttributeValue> item)
        {
            return new MovieResponse{
                MovieName = item["MovieName"].S,
                Description = item["Description"].S,
                Actors = item["Actors"].SS,
                Ranking =Convert.ToInt32(item["Ranking"].N),
                TimeRanked = item["RankedDateTime"].S
            };
        }

        public MovieResponse ToMovieContract(GetItemResponse response)
        {
              return new MovieResponse{
                MovieName = response.Item["MovieName"].S,
                Description = response.Item["Description"].S,
                Actors = response.Item["Actors"].SS,
                Ranking =Convert.ToInt32(response.Item["Ranking"].N),
                TimeRanked = response.Item["RankedDateTime"].S
            };
        }
    }
}
