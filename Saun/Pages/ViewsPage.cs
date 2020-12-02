using System;
using Data.Abstractions;
using Domain.Abstractions;
using Facade.Abstractions;

namespace Sauna.Pages
{
    public abstract class ViewsPage<TRepository, TDomain, TView, TData> :
        ViewPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TDomain : IUniqueEntity<TData>
        where TData : UniqueEntityData, new()
        where TView : UniqueEntityView
    {
        protected ViewsPage(TRepository repository, string title) : base(repository, title)
        {
        }

        protected internal Uri CreateUri(int i)
        {
            var uri = CreationUrl.ToString();
            uri += $"&switchOfCreate={i}";

            return new Uri(uri, UriKind.Relative);
        }
    }
}
