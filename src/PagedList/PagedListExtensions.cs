using System.Linq;

namespace DemoApi.PagedList {
    public static class PagedListExtensions
    {
        public static PagedList.PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNum, int pageSize) where T : class
        {
            return new PagedList.PagedList<T>(source, pageNum, pageSize);
        }
    }
}