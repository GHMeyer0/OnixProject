using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Sort;

namespace OnixProject.Domain.Searches
{
    public class UserSearch : IQuerySort
    {
        public string Name { get; set; }
        public string Sort { get; set; }

        [QueryOperator(Max = 100)]
        public int? Limit { get; set; } = 10;

        public int? Offset { get; set; } = 1;
    }
}