using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;

namespace OnixProject.Domain.Searches
{
    public class UserSearch : IQuerySort 
    {
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Name { get; set; }
        public string Sort { get; set; }

        [QueryOperator(Max = 100)]
        public int? Limit { get; set; } = 10;

        public int? Offset { get; set; } = 0;

        public int? Page { get; set; } = 0;
    }
}