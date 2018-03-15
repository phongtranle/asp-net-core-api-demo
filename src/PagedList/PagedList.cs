using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoApi.PagedList
{
    public class PagedList<T> where T : class
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
				throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
			if (pageSize < 1)
				throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            this.TotalItems = source != null ? source.Count() : 0;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Items = source
                            .Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize)
                            .ToList();
        }

        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public IList<T> Items { get; }
        public IList<LinkInfo> Links { get; set; }
        public int TotalPages =>
              (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);
        public bool HasPreviousPage => this.PageNumber > 1;
        public bool HasNextPage => this.PageNumber < this.TotalPages;
        public int NextPageNumber =>
               this.HasNextPage ? this.PageNumber + 1 : this.TotalPages;
        public int PreviousPageNumber =>
               this.HasPreviousPage ? this.PageNumber - 1 : 1;
    }
}