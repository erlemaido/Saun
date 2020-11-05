using System;
using Data.Abstractions;
using Data.CatalogItemBrands;
using Data.CatalogItemTypes;
using Data.Units;

namespace Data.CatalogItems
{
    public class CatalogItemData : DefinedEntityData
    {
        public Guid CatalogItemBrandId { get; set; }
        public CatalogItemBrandData CatalogItemBrandData { get; set; }

        public Guid CatalogItemTypeId { get; set; }
        public CatalogItemTypeData CatalogItemTypeData { get; set; }

        public Guid UnitId { get; set; }
        public UnitData UnitData { get; set; }

        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}