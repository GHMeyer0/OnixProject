using AutoMapper;
using OnixProject.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace OnixProject.Application.Converters
{
    public class PagedListTypeConverter : ITypeConverter<IPagedList<T>, PagedViewModel<T>>
    {

        public PagedViewModel<T> Convert(IPagedList<T> source, PagedViewModel<T> destination, ResolutionContext context)
        {
            var source = (IPagedList<T>)context.SourceValue;
            return new PagedViewModel<T>()
            {
                FirstItemOnPage = source.FirstItemOnPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                IsFirstPage = source.IsFirstPage,
                IsLastPage = source.IsLastPage,
                LastItemOnPage = source.LastItemOnPage,
                PageCount = source.PageCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalItemCount = source.TotalItemCount,
                rows = source
            };
        }
    }
}
