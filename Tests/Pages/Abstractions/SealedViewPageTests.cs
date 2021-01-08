using Data.Abstractions;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions;

namespace Tests.Pages.Abstractions {


    [TestClass]
    public abstract class SealedViewPageTests<TClass, TRepository, TObj, TView, TData>
        : SealedPageTests<TClass, ViewPage<TRepository, TObj, TView, TData>, TRepository, TObj, TView, TData>
        where TClass : ViewPage<TRepository, TObj, TView, TData>
        where TRepository : class, ICrudMethods<TObj>, ISorting, IFiltering, IPaging
        where TObj : UniqueEntity<TData>
        where TData : UniqueEntityData, new()
        where TView : UniqueEntityView {
    }

}
