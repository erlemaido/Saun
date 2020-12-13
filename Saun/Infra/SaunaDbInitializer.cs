using System;
using System.Collections.Generic;
using System.Linq;
using Data.Brands;
using Data.DeliveryCity;
using Data.DeliveryCountry;
using Data.DeliveryStatus;
using Data.DeliveryType;
using Data.Products;
using Data.ProductTypes;
using Data.Stocks;
using Data.Units;

namespace Infra
{
    public static class SaunaDbInitializer
    {
        internal static BrandData nike = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Nike",
            Description = "Nike sai oma praeguse nime aastal 1972, kuid firma loodi juba 1964. " +
                          "Blue Ribbon Sports nime all. Asutajaliikmete Bill Bowerman ja Philip Knighti " +
                          "esimene disain oli Waffle Trainer ja peale seda on välja antud mitmeid ja " +
                          "mitmeid klassikalisi mudeleid. Need mudelid ja Nike kaval sponsoriprogramm ja " +
                          "marketinginipid on teinud neist maailma juhtiva jalatsitootja. Nike Swoosh, mis " +
                          "kaunistab igat jalatsit, on märk kvaliteedist ja ideaalsest disainist. Nike Sportswear " +
                          "keskendub vabaaja mudelitele ja eridisainidele, kuid loomulikult on liinis olemas " +
                          "ka tõelised klassikud nagu Air Max, Air Force, Cortez, Dunk ja paljud teised. " +
                          "Aastal 2001. alustas ka Nike Skateboarding, mida iseloomustab mitmekülgne " +
                          "rulatajatest tiim ning innovaatilisus."
        };
        
        internal static BrandData adidas = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Adidas",
            Description = "Adidas AG on Saksa päritolu rahvusvaheline korporatsioon, mille tegevusalade hulka " +
                          "kuuluvad spordijalatsite, -rõivaste ja -aksessuaaride disain ja tootmine. " +
                          "Korporatsiooni peakontor asub Baieris Herzogenaurachis."
        };
        
        internal static BrandData gucci = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Gucci",
            Description = "Gucci moemaja, ka lihtsalt Gucci, on Itaalia moeajaloo ikoon ja nahktoodete bränd. " +
                          "Sellele pani aluse Guccio Gucci Firenzes 1921. aastal. Guccit peetakse üheks maailma " +
                          "kuulsamaks, prestiižsemaks ja tuntumaks moebrändiks maailmas."
        };
        
        internal static BrandData balenciaga = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Balenciaga",
            Description = "Balenciaga on luksusmoemaja, mille asutas 1917. aastal Hispaania disainer Cristóbal " +
                          "Balenciaga Hispaanias San Sebastianis ja mis praegu asub Pariisis. Balenciagal oli " +
                          "kompromissitute standardite couturieri maine ja Christian Dior nimetas teda meie " +
                          "kõigi peremeheks."
        };
        
        internal static BrandData samsung = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Samsung",
            Description = "Samsung Group on Lõuna-Koreas baseeruv rahvusvaheline korporatsioon, mis tegeleb " +
                          "mitmesuguste kaupade tootmise ja teenuste pakkumisega peamiselt Samsungi kaubamärgi all. " +
                          "Korporatsiooni peakorter asub Soulis Samsung Townis. Samsungi asutas 1938. aastal " +
                          "Lee Byung-chul kaubandusettevõttena."
        };
        
        internal static BrandData evian = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Evian",
            Description = "Évian on mineraalvee kaubamärk, mis pärineb mitmest allikast Évian-les-Bainsi lähedal " +
                          "Genfi järve lõunakaldal. Tänapäeval kuulub Évian Prantsuse hargmaisele korporatsioonile " +
                          "Danone. Lisaks mineraalveele kasutab Danone Group Éviani nime nii orgaaniliste " +
                          "nahahooldustoodete sarja kui ka luksuskuurordi jaoks Prantsusmaal. "
        };
        
        internal static BrandData lenovo = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Lenovo",
            Description = "Lenovo Group Limited on Hiina päritolu rahvusvaheline mikrotehnoloogiafirma, " +
                          "mis töötab välja, toodab ja turustab lauaarvuteid ja sülearvuteid, tööjaamaarvuteid, " +
                          "servereid, kõvakettaid, IT haldustarkvara ning muid selliseid tooteid ja teenuseid. " +
                          "Lenovo hakkas tegutsema praegusel kujul aastal 1988 Hongkongis nime Legend all. "
        };
        
        internal static ProductTypeData mug = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kruus"
        };
        
        internal static ProductTypeData water = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Vesi"
        };
        
        internal static ProductTypeData sweatshirt = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Pusa"
        };
        
        internal static ProductTypeData sneakers = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Vabaajajalanõud"
        };
        
        internal static ProductTypeData laptop = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sülearvuti"
        };
        
        internal static ProductTypeData coat = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Mantel"
        };
        internal static DeliveryTypeData UPS = new DeliveryTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "UPS"
        };
        internal static DeliveryTypeData smartpost = new DeliveryTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "SmartPost"
        };
        internal static DeliveryTypeData standard = new DeliveryTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tulen ise järele"
        };
        internal static DeliveryTypeData parcelMachine = new DeliveryTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Postiautomaat"
        };
        internal static UnitData kilogram = new UnitData()
        {
            Id = Guid.NewGuid().ToString(),
            Code = "kg",
            Name = "Kilogramm"
        };
        
        internal static UnitData liter = new UnitData()
        {
            Id = Guid.NewGuid().ToString(),
            Code = "l",
            Name = "Liiter"
        };
        
        internal static UnitData gram = new UnitData()
        {
            Id = Guid.NewGuid().ToString(),
            Code = "g",
            Name = "Gramm"
        };
        
        internal static UnitData meter = new UnitData()
        {
            Id = Guid.NewGuid().ToString(),
            Code = "m",
            Name = "Meeter"
        };
        
        internal static UnitData piece = new UnitData()
        {
            Id = Guid.NewGuid().ToString(),
            Code = "tk",
            Name = "Tükk"
        };
        
        internal static ProductData adidasOriginalsSneakers = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = adidas.Id,
            Name = "Adidas Originals vabaajajalanõud",
            Price = 120,
            Description = "Maailma parimad tossud",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = sneakers.Id
        };
        
        internal static ProductData thinkpadP51 = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = lenovo.Id,
            Name = "Thinkpad P51 sülearvuti",
            Price = 2549,
            Description = "Lenovo ThinkPad P51 Mobile Workstation 20HH000TUS " +
                          "Intel Quad-Core i7-7700HQ, " +
                          "16GB DDR4 RAM, " +
                          "512GB PCIe NVMe SSD, " +
                          "15.6'' FHD IPS 1920x1080 Display, " +
                          "NVIDIA Quadro M1200 4GB, " +
                          "Windows 10 Pro.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = laptop.Id
        };
        
        internal static ProductData evian500mlWater = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = evian.Id,
            Name = "Vesi Evian 500ml",
            Price = 0.7,
            Description = "Mineraalvesi Evian",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = water.Id
        };
        
        internal static StockData adidasOriginalsSneakersStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 36,
            ProductId = adidasOriginalsSneakers.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData evian500mlWaterStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 100,
            ProductId = evian500mlWater.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData thinkpadP51Stock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 2,
            ProductId = thinkpadP51.Id,
            Comment = "Tuleb juurde tellida",
            LastUpdateTime = System.DateTime.Now
        };
        internal static DeliveryStatusData infoReceived = new DeliveryStatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Info Received"

        };
        internal static DeliveryStatusData inTransit = new DeliveryStatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "In Transit"

        };
        internal static DeliveryStatusData outForDelivery = new DeliveryStatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Out for Delivery"

        };
        internal static DeliveryStatusData pickUp = new DeliveryStatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Available for Pickup"

        };
        internal static DeliveryStatusData delivered = new DeliveryStatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Delivered"

        };
        internal static DeliveryCountryData estonia = new DeliveryCountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Estonia"

        };
        internal static DeliveryCountryData russia = new DeliveryCountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Russia"

        };
        internal static DeliveryCountryData USA = new DeliveryCountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "USA"

        };
        internal static DeliveryCountryData latvia = new DeliveryCountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Latvia"

        };
        internal static DeliveryCountryData china = new DeliveryCountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "China",

        };
        internal static DeliveryCityData tallinn = new DeliveryCityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tallinn",
            DeliveryCountryId = estonia.Id

        };
        internal static DeliveryCityData moscow = new DeliveryCityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Moscow",
            DeliveryCountryId = russia.Id

        };
        internal static DeliveryCityData tokyo = new DeliveryCityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tokyo",
            DeliveryCountryId = china.Id

        };
        internal static DeliveryCityData newyork = new DeliveryCityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "New York",
            DeliveryCountryId = USA.Id


        };
        internal static DeliveryCityData riga = new DeliveryCityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Riga",
            DeliveryCountryId = latvia.Id


        };
        internal static List<BrandData> Brands => new List<BrandData>
        {
            adidas, nike, gucci, balenciaga, evian, lenovo, samsung
        };
        
        internal static List<ProductTypeData> ProductTypes => new List<ProductTypeData>
        {
            mug, coat, laptop, sneakers, sweatshirt, water
        };
        internal static List<DeliveryCountryData> Countries => new List<DeliveryCountryData>
        {
            estonia,USA,latvia,russia,china
        };

        internal static List<DeliveryCityData> Cities => new List<DeliveryCityData>
        {
            tallinn, moscow, tokyo, newyork, riga
        };
        internal static List<DeliveryStatusData> Statuses => new List<DeliveryStatusData>
        {
            infoReceived,inTransit,outForDelivery,pickUp,delivered
        };
        internal static List<UnitData> Units => new List<UnitData>
        {
            kilogram, gram, liter, piece, meter
        };
        
        internal static List<ProductData> Products => new List<ProductData>
        {
            adidasOriginalsSneakers, thinkpadP51, evian500mlWater
        };
        
        internal static List<StockData> Stocks => new List<StockData>
        {
            adidasOriginalsSneakersStock, evian500mlWaterStock, thinkpadP51Stock
        };
        internal static List<DeliveryTypeData> DeliveryTypes = new List<DeliveryTypeData>
        {
            UPS,standard,parcelMachine,smartpost
        };
        private static void InitializeDeliveryTypes(SaunaDbContext db)
        {
            if (db.DeliveryTypes.Count() != 0) return;
            db.DeliveryTypes.AddRange(DeliveryTypes);
            db.SaveChanges();
        }
        private static void InitializeDeliveryStatus(SaunaDbContext db)
        {
            if (db.Statuses.Count() != 0) return;
            db.Statuses.AddRange(Statuses);
            db.SaveChanges();
        }
        private static void InitializeBrands(SaunaDbContext db)
        {
            if (db.Brands.Count() != 0) return;
            db.Brands.AddRange(Brands);
            db.SaveChanges();
        }
        private static void InitializeDeliveryCountries(SaunaDbContext db)
        {
            if (db.Countries.Count() != 0) return;
            db.Countries.AddRange(Countries);
            db.SaveChanges();
        }
        private static void InitializeDeliveryCities(SaunaDbContext db)
        {
            if (db.Cities.Count() != 0) return;
            db.Cities.AddRange(Cities);
            db.SaveChanges();
        }
        private static void InitializeProductTypes(SaunaDbContext db)
        {
            if (db.ProductTypes.Count() != 0) return;
            db.ProductTypes.AddRange(ProductTypes);
            db.SaveChanges();
        }
        
        private static void InitializeUnits(SaunaDbContext db)
        {
            if (db.Units.Count() != 0) return;
            db.Units.AddRange(Units);
            db.SaveChanges();
        }
        
        private static void InitializeProducts(SaunaDbContext db)
        {
            if (db.Products.Count() != 0) return;
            db.Products.AddRange(Products);
            db.SaveChanges();
        }
        
        private static void InitializeStocks(SaunaDbContext db)
        {
            if (db.Stocks.Count() != 0) return;
            db.Stocks.AddRange(Stocks);
            db.SaveChanges();
        }

        public static void Initialize(SaunaDbContext db)
        {
            InitializeBrands(db);
            InitializeProductTypes(db);
            InitializeUnits(db);
            InitializeProducts(db);
            InitializeStocks(db);
            InitializeDeliveryCountries(db);
            InitializeDeliveryTypes(db);
            InitializeDeliveryStatus(db);
            InitializeDeliveryCities(db);
        }
        
    }
}