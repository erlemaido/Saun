using System;
using System.Collections.Generic;
using System.Linq;
using Data.Shop.Brands;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Data.Shop.DeliveryTypes;
using Data.Shop.PaymentTypes;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.ProductTypes;
using Data.Shop.Roles;
using Data.Shop.Statuses;
using Data.Shop.Stocks;
using Data.Shop.Units;
using Data.Shop.UserRoles;
using Data.Shop.Users;
using Domain.Shop.PaymentTypes;

namespace Infra
{
    public static class SaunaDbInitializer
    {
        internal static BrandData rento = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Rento",
            Description = ""
        };

        internal static BrandData sauflex = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauflex",
            Description = ""
        };
        
        internal static BrandData cariitti = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Cariitti",
            Description = ""
        };

        internal static BrandData harvia = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Harvia",
            Description = "Harvia Plc. on Soome keriste, sauna, spaa ja saunade siseruumide tootja. Ettevõtte " +
                          "tootepakkumine hõlmab kõiki kolme saunatüüpi: traditsiooniline saun, aurusaun ja " +
                          "infrapunasaun. Ettevõtte peakontor asub Muurame'is, Kesk-Soomes. Harvia tooteid " +
                          "levitatakse ülemaailmselt edasimüüjate võrgustiku kaudu."
        };

        internal static BrandData saunia = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Saunia",
            Description = "ll the SAUNIA sauna products are designed for the every day use not forgotting the " +
                          "home interior.Using well choosen design and quality materials they are made to last. " +
                          "SAUNIA collection includes products for everyone. Stylish thermometers and combinations, " +
                          "modern as well traditional bowls and ladles, beuatiful textiles and sauna aromas - " +
                          "just to mentione a few products."
        };

        internal static BrandData tylöhelo = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tylöhelo",
            Description = "We are Tylö, the world’s leading sauna and steam manufacturer. What we do and the " +
                          "wellness experiences we create set us apart. The built in sense of pride and genuine " +
                          "feel that signifies our sauna and steam products can’t be replicated. It is the people " +
                          "behind the scenes that institute it. The innovators, the visionaries, the entrepreneurs. " +
                          "Hard work and commitment to our clients’ needs and an inherent drive to continuously " +
                          "do better and promote health and fitness."
        };

        internal static BrandData sawo = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sawo",
            Description = "Sawo,Inc. on suurem ja tuntum saunatoodete valmistaja euroopas,kes investeeris esimesena " +
                          "saunatehnoloogiad Aasiasse,ning avas esimesena oma tehased seal.Teda järgides on seda " +
                          "teinud ka teised suurimad saunatarvikute tootjad. Firma soome-saksa päritoluga juhtkond " +
                          "ja noortest ning kõrgestimotiveeritud töölistest komplekteeritud meeskond tagab " +
                          "kõrgekavliteedilise toodangu kogu Sawo tootevalikule. Üle 300 töötaja, ja nende arv " +
                          "kasvab pidevalt,tagab selle,et saame pidevalt suurendada nii tootevalikuid ,kui ka " +
                          "toodete mahtu. Hetkel on Sawo maailmas kolmandal kohal elektrikeriste tootmises. " +
                          "Tootmisvõimsust jätkub hetkel juba üle 150 000 kerise aastatoodanguks. Lisaks veel " +
                          "ülejäänud saunatarvikute tootmine. Praktiliselt iga kuu ilmub tootevalikusse uusi " +
                          "tooteid,et täita ka kõige nõudlikumate saunasõprade soove. Sawo on võtnud endale " +
                          "eesmärgiks toota tippklassi saunatooteid ka nõudlikematele saunasõpradele,samas " +
                          "kättesaadava hinnaga."
        };

        internal static BrandData tammer = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tammer",
            Description = ""
        };
        
        internal static BrandData kerkes = new BrandData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kerkes",
            Description = "Kerkes – The Philosopher’s Stone for the Sauna Stove. 70% of the spas and public " +
                          "swimming pools in Finland and 50% in Germany use Kerkes Sauna Stones."
        };

        internal static ProductTypeData kerisekivid = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kerisekivid"
        };

        internal static ProductTypeData kibud = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauna kibud"
        };

        internal static ProductTypeData kulbid = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauna kulbid"
        };

        internal static ProductTypeData termoJaHügroMeetrid = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Termo- ja hügromeetrid"
        };

        internal static ProductTypeData kellad = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kellad"
        };

        internal static ProductTypeData istumisalused = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauna istumisalused"
        };
        
        internal static ProductTypeData porandarestid = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauna põrandarestid"
        };

        internal static ProductTypeData vihad = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Saunavihad"
        };
        
        internal static ProductTypeData tekstiil = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Sauna tekstiil"
        };

        internal static ProductTypeData saunatarvikud = new ProductTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Muud saunatarvikud"
        };
        
        internal static DeliveryTypeData ups = new DeliveryTypeData()
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

        internal static ProductData tylöheloAlumiiniumiÄmber = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = tylöhelo.Id,
            Name = "TYLÖHELO ÄMBER «BRILLIANT» 5L HÕBEHALL",
            Price = 68.26,
            Description = "Tylöhelo alumiiniumi ämber. Ämbri maht: 5l",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kibud.Id
        };

        internal static ProductData sauflexSaunaKibu = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "SAUFLEX 4,0 L SAUNAKIBU, PÕLETATUD HAAB",
            Price = 19.94,
            Description = "Puust saunakibu. " +
                          "Materjal: Põletatud haab" +
                          "Maht: 4l" +
                          "Plastikust siseosa tagab tootele pika eluea ja muudab ka puhastamise kergemaks.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kibud.Id
        };

        internal static ProductData rentoKibu = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = rento.Id,
            Name = "RENTO KIBU, SININE, 5,0L",
            Price = 50.40,
            Description = "230 × 230 mm",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kibud.Id
        };
        
        internal static ProductData sawoKibu = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sawo.Id,
            Name = "SAWO SAUNAKIBU, 18L",
            Price = 85.06,
            Description = "Puust saunakibu kaanega." +
                          "Materjal: Seeder" +
                          "Maht: 18l" +
                          "Kõrgus - 300 mm" +
                          "⌀ 425 mm" +
                          "SAWO 381-D + 381-D-COV",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kibud.Id
        };
        
        internal static ProductData tylöheloHygromeeter = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = tylöhelo.Id,
            Name = "TYLÖHELO HÜGROMEETER PREMIUM DARK",
            Price = 58.80,
            Description = "TMaterjal: Haab" +
                          "Pikkus: 230 mm" +
                          "Laius: 100 mm" +
                          "Sügavus: 20 mm",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = termoJaHügroMeetrid.Id
        };

        internal static ProductData cariittiHygromeeter = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = cariitti.Id,
            Name = "CARIITTI HÜGROMEETER SQ, ROOSTEVABA TERAS",
            Price = 87.89,
            Description = "Sauna hügromeeter SQ on valmistatud satiini klaasist ja roostevabast terasest. " +
                          "Seda seadet saab valgustada ühe 2-4 mm kiududega, mis ei kuu komplektile. Valgustusena vaab " +
                          "valida mis tahes Cariitti komplekti, näiteks tootekoodiga 1371. Seinale paigaldatav. " +
                          "Mõõdud on 120 x 120 mm ja süvend 40 mm. Seinapinnast on kõrgus 20 mm. Hügromeeter " +
                          "paigaldatakse seinale, 3. roostevabast terasest kruviga.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = termoJaHügroMeetrid.Id
        };

        internal static ProductData tylöheloTermomeeter = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = rento.Id,
            Name = "TYLÖHELO TERMOMEETER «BRILLIANT» MUST",
            Price = 63,
            Description = "",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = termoJaHügroMeetrid.Id
        };
        
        internal static ProductData harviaLiivakell = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = harvia.Id,
            Name = "HARVIA LIIVAKELL, SAC19900, LEPP",
            Price = 15.74,
            Description = "Liivakell Lux on ilus dekoratsioon teie sauna jaoks ning seda saab kasutada sobiva " +
                          "saunaskäigu aja näitamiseks või lihtsalt meeldetuletusena, et aeg liigub. Liiv " +
                          "voolab 15 minutit. Materjal: Lepp Kõrgus: 305 mm Laius: 70 mm SKU: SAC19900",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kellad.Id
        };
        
                internal static ProductData tammeviht = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "TAMMEVIHT",
            Price = 3.78,
            Description = "",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = vihad.Id
        };

        internal static ProductData kaseviht = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "KASEVIHT",
            Price = 3.14,
            Description = "Oma kättesaadavuse tõttu on kaseviht vihtade seas üks populaarsemaid. Samuti on see on " +
                          "kasulike ainete allikaks. Kaselehed sisaldavad eeterlikke õlisid, C-vitamiini ja " +
                          "A-provitamiini, vaik- ja parkaineid, mis avaldavad nahale soodsat mõju, pehmendavad " +
                          "seda ja teevad selle siidjaks. Kaseviha eriliseks väärtuseks on võime väikeseid bronhe " +
                          "tugevalt laiendada, soodustades sellega limaeritust ja parandades kopsude ventilatsiooni. " +
                          "Vaat seetõttu on pärast kasevihaga vihtlemist nii kerge hingata. Kaseviht on eriti kasulik " +
                          "suitsetajatele. On tehtud kindlaks, et kasesalu õhk on sama puhas kui operatsioonisaali " +
                          "õhk. Juuste tugevdamise ja kõõma ravimise eesmärgil pestakse pead kaseviha tõmmisega. " +
                          "Kaseviht võtab pärast füüsilisi koormusi valu lihastest ja liigestest. Värske ja " +
                          "meeldivalt lõhnav viht annab võimsa energialaengu ning hea tuju paljudeks päevadeks.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = vihad.Id
        };
        
        internal static ProductData eukalüptiviht = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "EUKALÜPTIVIHT",
            Price = 3.78,
            Description = "Eukalüpti raviomadused on ammu ja laialdaselt teada. Selle lehed on bakteritsiidse ja " +
                          "põletikuvastase toimega hinnalise eeterliku õli allikaks, samuti sisaldavad need õhku " +
                          "puhastavaid ja tervendavaid fütontsiide. Eukalüpt- see on suurepärane looduslik inhalaator. " +
                          "Eukalüptiviha aroom on respiratoorsete ja külmetushaiguste korral asendamatuks ravi- ja " +
                          "profülaktikavahendiks. Saunaskäigu ajal soovitatakse suruda eukalüptiviht vastu nägu ja " +
                          "selle aroomi 3-5 minuti jooksul sisse hingata. Teravalehise eukalüpti kombineerimine " +
                          "hõbelehise eukalüptiga annab vihale lisaks raviomadustele ka erilise vastupidavuse ja " +
                          "painduvuse. Samuti saab seda vihta soovi korral kase- või tammelehtedega kombineerida. " +
                          "Sellised vihad aitavad reumatismi, lihase- ja liigesevalude korral. Seepärast on soovitav " +
                          "kasutada sellist vihta ennekõike massaa˛ivahendina, mis aitab reumatismi, lihase- ja " +
                          "liigesevalude korral. Eukalüpti jahutav, kirbe aroom mobiliseerib närvisüsteemi, aitab " +
                          "taastuda pärast stressi ja haigust. Suurendab pikaealisuseks vajalikku energiat.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = vihad.Id
        };
        
        internal static ProductData sauflexSaunamyts = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "SAUFLEX SAUNAMÜTS",
            Price = 5.26,
            Description = "Saunamüts kaitseb juukseid ja peanahka sauna kuumuse eest. Talvel hoiab saunamüts pea soojas kümblustünnis ka.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = tekstiil.Id
        };

        internal static ProductData rentoSaunaMyts = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = rento.Id,
            Name = "RENTO SAUNAMÜTS",
            Price = 18.90,
            Description = "The linen terry sauna hat protects the hair and scalp from the heat of the sauna. " +
                          "In winter, the sauna hat also keeps your head warm in the hot tub.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = tekstiil.Id
        };
        
        internal static ProductData harviaSaunaRatik = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = harvia.Id,
            Name = "HARVIA SAUNARÄTIK BY LUHTA 80х160cm",
            Price = 31.50,
            Description = "Harvia, Luhta on valmistatud kvaliteetsest puuvillasest vahvlilinadest, mis nahale " +
                          "mõnusalt tekitab hea tunde ja annab moodsa loomuliku ilme. Tekstiilid on suurepärase " +
                          "imendumisvõimega ja kuivavad pärast kasutamist kiiresti. Lihtsalt stiilne ja ajatu " +
                          "kujundus täiendab teie saunamõnusid ning pärast lõõgastavat saunasessiooni on mõnus " +
                          "enda ümber suur rätik mähkida. 75% puuvill, 25% linane, peske temperatuuril 60 ° C",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = tekstiil.Id
        };
        
        internal static ProductData saunakividSauflex20Kg = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "SAUNAKIVID SAUFLEX 5-9cm, 20kg",
            Price = 21.00,
            Description = "Pinnale asetatakse ligikaudu 1/3 ümarast oliviini diabeedist ja alt kantakse tavalised " +
                          "traditsioonilised kivid. Vesi imeb sujuvalt sileda kivide vahel, mis asetsevad pinnal ja " +
                          "voolavad allpool asetsevatele kividele, moodustades õrna auru. Kõik kivikaed peavad olema " +
                          "täidetud ümmarguste kividega. Samal ajal tulevad igast kivist aur, mis muutub valguse õrna " +
                          "auruga pilveks. Kokku on vaja vähemalt 20 kg kive nii, et vesi ei liiguks nende vahel " +
                          "liiga palju. Ainult elektrikerisele. Soovitatav on kõik kivid pesta, et eemaldada " +
                          "plekid või tolm, mis võivad põhjustada ebameeldivat lõhna, kerise esmakordsel kasutamisel.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kerisekivid.Id
        };
        
        internal static ProductData kerkesMixKerisekivid = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = kerkes.Id,
            Name = "KERISEKIVID KERAAMILISED, KERKES MIX, 20KG",
            Price = 103.94,
            Description = "Tavalised kerisekivid sisaldavad rohkelt lisandeid, mis satuvad kivide kuumutamise " +
                          "tagajärjel õhku. Tänu sellele muutub kivi kergemaks ja muutub tasapisi põrandale " +
                          "pudenevaks liivaks. Sauna kuumakskütmiseks kulub rohkem aega. Sellisel juhul tuleb " +
                          "kivid välja vahetada. Just sellel põhjusel on muutunud populaarseks kasutada " +
                          "kommertslikel eesmärkidel Kerkes keraamilisi kivisid. Just need kivid tagavad " +
                          "saunapuhkuse unikaalsuse. Need kivid on kasutamiseks täiesti puhtad, sest ei eralda " +
                          "kuumutamisel õhku mingeid gaase ning hakkavad põlema alles temperatuuri juures, mis " +
                          "ületab 1300 ºC. Te võite nautida puhast ja lõõgastavat sauna. Ning kodustes tingimustes " +
                          "võivad need kerisekivid kesta igavesti. Need tuleb ahjus üks kord korralikult paika panna " +
                          "ning rohkem ei ole vaja nende pärast muretseda. 20 kg, Ainult elektrikerisele. Soovitatav " +
                          "on kõik kivid pesta, et eemaldada plekid või tolm, mis võivad põhjustada ebameeldivat " +
                          "lõhna, kerise esmakordsel kasutamisel.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kerisekivid.Id
        };

        internal static ProductData kerkesTetra = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = kerkes.Id,
            Name = "KERISEKIVID KERAAMILISED, KERKES TETRA, 10KG",
            Price = 59.86,
            Description = "TMeie tetrakujulisi kive on kahes suuruses - suured ja väikesed. Neid kasutatakse kõigi " +
                          "saunaahjude pealmiseks kihiks. Tulekahju või õhuvoolu ahjus reguleerib pinna kivikihi " +
                          "paksus. Tetrakujulise kivi pinnakonstruktsioon tagab intensiivse kuumuse.",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = tekstiil.Id
        };
        
        internal static ProductData saunakividSauflex = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sauflex.Id,
            Name = "SAUNAKIVID SAUFLEX ÜMARDATUD 5-9cm, 20kg",
            Price = 10.50,
            Description = "Gabbro-diabetaas on üks populaarsemaid kive saunaahjude jaoks. Suhteliselt madala " +
                          "hinnaga on sellel kõik vajalikud omadused - kuumuskindlus, vastupidavus tsükliliste " +
                          "temperatuurimuutustele, akumuleerib soojust kiiresti ja hoiab seda pikka aega. Ainult " +
                          "elektrikerisele",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = tekstiil.Id
        };
        
        internal static ProductData sauniaAroomikauss = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = saunia.Id,
            Name = "SAUNIA AROMIKAUSS",
            Price = 42.00,
            Description = "Soolakivi. Kett: 140cm. Sisaldab ca. 50g Hiimala soola",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = saunatarvikud.Id
        };
        
        internal static ProductData rentoKulp = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = rento.Id,
            Name = "RENTO KULP 50cm",
            Price = 37.80,
            Description = "",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kulbid.Id
        };
        
        internal static ProductData tyloheloKulp = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = tylöhelo.Id,
            Name = "TYLOHELO KULP, PREMIUM DARK",
            Price = 78.74,
            Description = "",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kulbid.Id
        };
        
        internal static ProductData sawoSteamshotKulp = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sawo.Id,
            Name = "SAWO STEAMSHOT KULP, MUST",
            Price = 53.56,
            Description = "",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = kulbid.Id
        };
        
        internal static ProductData harviaIstumisalused = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = harvia.Id,
            Name = "SAUNA ISTUMISALUSED, POLÜETEEN",
            Price = 1.90,
            Description = "Mõõdud: 410x310x3mm",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = istumisalused.Id
        };
        
        internal static ProductData istumisAlused = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sawo.Id,
            Name = "SAUNA ISTUMISALUSED, LEPP",
            Price = 12.60,
            Description = "Sauna istumisalused lepast. Mõõdud: 320 x 400 x 10 mm",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = istumisalused.Id
        };
        
        internal static ProductData porandaRest = new ProductData()
        {
            Id = Guid.NewGuid().ToString(),
            BrandId = sawo.Id,
            Name = "TUGEVDATUD PÕRANDAREST, TERMOHAAB 600 x 1200 mm",
            Price = 48.30,
            Description = "Põranda puitrest saab kasutada kuivades ja mõõdukalt niisketes ruumides, näiteks " +
                          "saunas. Seda ei soovitata kasutada väga niisketes ruumides, kus on pidev veevool, " +
                          "näiteks duširuumis, sest puu paisub kiiresti ja rest muutub kasutamiskõlbmatuks. " +
                          "Pikaajaliseks kasutamiseks on soovitatav pind katta spetsiaalse puidukaitseõliga. Suurus: " +
                          "600 x 1200 x 43 mm Materjal: termotöödeldud haab",
            PictureUrl = "mingi url",
            UnitId = piece.Id,
            ProductTypeId = porandarestid.Id
        };
        

        internal static StockData tylöheloAlumiiniumiÄmberStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 36,
            ProductId = tylöheloAlumiiniumiÄmber.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData sauflexSaunaKibuStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 100,
            ProductId = sauflexSaunaKibu.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData rentoKibuStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 2,
            ProductId = rentoKibu.Id,
            Comment = "Tuleb juurde tellida",
            LastUpdateTime = System.DateTime.Now
        };
        
        
        
        
        internal static StockData sawoKibuStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 101,
            ProductId = sawoKibu.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData tylöheloHygromeeterStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 76,
            ProductId = tylöheloHygromeeter.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData cariittiHygromeeterStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 1,
            ProductId = cariittiHygromeeter.Id,
            Comment = "Tuleb juurde tellida",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData tylöheloTermomeeterStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 80,
            ProductId = tylöheloTermomeeter.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData harviaLiivakellStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 10,
            ProductId = harviaLiivakell.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData tammevihtStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 200,
            ProductId = tammeviht.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData kasevihtStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 360,
            ProductId = kaseviht.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData eukalüptivihtStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 101,
            ProductId = eukalüptiviht.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData sauflexSaunamytsStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 4,
            ProductId = sauflexSaunamyts.Id,
            Comment = "Tuleb juurde tellida",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData rentoSaunaMytsStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 18,
            ProductId = rentoSaunaMyts.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData harviaSaunaRatikStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 76,
            ProductId = harviaSaunaRatik.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData saunakividSauflex20KgStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 0,
            ProductId = saunakividSauflex20Kg.Id,
            Comment = "Otsas",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData kerkesMixKerisekividStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 20,
            ProductId = kerkesMixKerisekivid.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData kerkesTetraStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 450,
            ProductId = kerkesTetra.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData saunakividSauflexStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 11,
            ProductId = saunakividSauflex.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData sauniaAroomikaussStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 7,
            ProductId = sauniaAroomikauss.Id,
            Comment = "Tuleb juurde tellida",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData rentoKulpStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 18,
            ProductId = rentoKulp.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData tyloheloKulpStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 7,
            ProductId = tyloheloKulp.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData sawoSteamshotKulpStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 0,
            ProductId = sawoSteamshotKulp.Id,
            Comment = "Otsas",
            LastUpdateTime = System.DateTime.Now
        };
        
        internal static StockData harviaIstumisalusedStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 36,
            ProductId = harviaIstumisalused.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData istumisAlusedStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 6,
            ProductId = istumisAlused.Id,
            Comment = "",
            LastUpdateTime = System.DateTime.Now
        };

        internal static StockData porandaRestStock = new StockData()
        {
            Id = Guid.NewGuid().ToString(),
            InStock = 0,
            ProductId = porandaRest.Id,
            Comment = "Otsas",
            LastUpdateTime = System.DateTime.Now
        };
        
        
        
        internal static StatusData pooleli = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Pooleli"
        };
        
        internal static StatusData makstud = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Makstud"
        };
        
        internal static StatusData komplekteerimisel = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Komplekteerimisel"
        };
        
        internal static StatusData valmis = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Valmis järeletulekuks"
        };
        
        internal static StatusData saatmisel = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Saatmisel"
        };
        
        internal static StatusData tyhistatud = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tühistatud"
        };
        
        internal static StatusData kohaleToimetatud = new StatusData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kohale toimetatud"
        };
        
        internal static CountryData estonia = new CountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Eesti"

        };
        internal static CountryData russia = new CountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Venemaa"

        };
        internal static CountryData usa = new CountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "USA"

        };
        internal static CountryData latvia = new CountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Läti"

        };
        internal static CountryData china = new CountryData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Hiina",

        };
        internal static CityData tallinn = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tallinn",
            CountryId = estonia.Id
        };
        
        internal static CityData tartu = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Tartu",
            CountryId = estonia.Id
        };
        
        internal static CityData parnu = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Pärnu",
            CountryId = estonia.Id
        };
        
        internal static CityData moscow = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Moskva",
            CountryId = russia.Id

        };
        internal static CityData peking = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Peking",
            CountryId = china.Id

        };
        internal static CityData newyork = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "New York",
            CountryId = usa.Id
        };
        internal static CityData riga = new CityData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Riia",
            CountryId = latvia.Id
        };
        
        internal static RoleData admin = new RoleData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Admin",
            Description = "",
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.MaxValue
        };
        
        internal static RoleData user = new RoleData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "User",
            Description = "Tavakasutaja",
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.MaxValue
        };
        
        internal static RoleData manager = new RoleData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Juhataja",
            Description = "",
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.MaxValue
        };
        
        internal static PaymentTypeData kaart = new PaymentTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Kaart",
        };
        
        internal static PaymentTypeData ylekanne = new PaymentTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ülekanne",
        };
        
        internal static PaymentTypeData jarelmaks = new PaymentTypeData()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Järelmaks",
        };
        
        internal static PersonData mari = new PersonData()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Mari",
            LastName = "Männiste",
            Email = "mari.manniste@gmail.com"
        };
        
        internal static PersonData sergei = new PersonData()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Sergei",
            LastName = "Tamm",
            Email = "s.tmm@eesti.ee"
        };
        
        internal static PersonData kristo = new PersonData()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Kristo",
            LastName = "Kraav",
            Email = "kristokraav@gmail.com"
        };
        
        internal static PersonData adminPerson = new PersonData()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "Admin",
            LastName = "User",
            Email = "admin@saun.ee"
        };
        
        internal static UserData adminUser = new UserData()
        {
            Id = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            PasswordHash = "njndrfkflcwmapodlmka843eu892ujr",
            PersonId = adminPerson.Id,
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.MaxValue,
            Comment = "Kasutaja admin õigusteks"
        };
        
        internal static UserRoleData adminUserRole = new UserRoleData()
        {
            Id = Guid.NewGuid().ToString(),
            RoleId = admin.Id,
            UserId = adminUser.Id,
            ValidFrom = DateTime.Now,
            ValidTo = DateTime.MaxValue,
            Comment = ""
        };
        
        
        internal static List<BrandData> Brands => new List<BrandData>
        {
            sauflex, rento, harvia, saunia, sawo, tammer, tylöhelo, cariitti, kerkes
        };
        
        internal static List<PersonData> People => new List<PersonData>
        {
            mari, sergei, kristo, adminPerson
        };
        
        internal static List<UserData> Users => new List<UserData>
        {
            adminUser
        };
        
        internal static List<PaymentTypeData> PaymentTypes => new List<PaymentTypeData>
        {
            kaart, ylekanne, jarelmaks
        };
        
        internal static List<RoleData> Roles => new List<RoleData>
        {
            admin, user, manager
        };
        
        internal static List<UserRoleData> UserRoles => new List<UserRoleData>
        {
            adminUserRole
        };

        internal static List<ProductTypeData> ProductTypes => new List<ProductTypeData>
        {
            kerisekivid, kibud, kulbid, termoJaHügroMeetrid, kellad, istumisalused, porandarestid, vihad, tekstiil, saunatarvikud
        };
        internal static List<CountryData> Countries => new List<CountryData>
        {
            estonia,usa,latvia,russia,china
        };

        internal static List<CityData> Cities => new List<CityData>
        {
            tallinn, moscow, peking, newyork, riga, tartu, parnu
        };
        internal static List<StatusData> Statuses => new List<StatusData>
        {
            pooleli, makstud, komplekteerimisel, valmis, saatmisel, kohaleToimetatud, tyhistatud
        };
        internal static List<UnitData> Units => new List<UnitData>
        {
            kilogram, gram, liter, piece, meter
        };

        internal static List<ProductData> Products => new List<ProductData>
        {
            tylöheloAlumiiniumiÄmber, sauflexSaunaKibu, rentoKibu, sawoKibu, tylöheloHygromeeter, cariittiHygromeeter,
            tylöheloTermomeeter, harviaLiivakell, tammeviht, kaseviht, eukalüptiviht, sauflexSaunamyts, rentoSaunaMyts, 
            harviaSaunaRatik, saunakividSauflex, kerkesMixKerisekivid, kerkesTetra, saunakividSauflex20Kg, sauniaAroomikauss,
            rentoKulp, tyloheloKulp, sawoSteamshotKulp, harviaIstumisalused, istumisAlused, porandaRest
        };

        internal static List<StockData> Stocks => new List<StockData>
        {
            tylöheloAlumiiniumiÄmberStock, sauflexSaunaKibuStock, rentoKibuStock, sawoKibuStock, tylöheloHygromeeterStock,
            cariittiHygromeeterStock, tylöheloTermomeeterStock, harviaLiivakellStock, tammevihtStock, kasevihtStock, 
            eukalüptivihtStock, sauflexSaunamytsStock, rentoSaunaMytsStock, harviaSaunaRatikStock, saunakividSauflexStock, 
            kerkesMixKerisekividStock, kerkesTetraStock, saunakividSauflex20KgStock, sauniaAroomikaussStock, 
            rentoKulpStock, tyloheloKulpStock, sawoSteamshotKulpStock, harviaIstumisalusedStock, istumisAlusedStock, 
            porandaRestStock
            
        };
        internal static List<DeliveryTypeData> deliveryTypes = new List<DeliveryTypeData>
        {
            ups,standard,parcelMachine,smartpost
        };
        private static void InitializeDeliveryTypes(SaunaDbContext db)
        {
            if (db.DeliveryTypes.Count() != 0) return;
            db.DeliveryTypes.AddRange(deliveryTypes);
            db.SaveChanges();
        }
        private static void InitializePaymentTypes(SaunaDbContext db)
        {
            if (db.PaymentTypes.Count() != 0) return;
            db.PaymentTypes.AddRange(PaymentTypes);
            db.SaveChanges();
        }
        
        private static void InitializePeople(SaunaDbContext db)
        {
            if (db.People.Count() != 0) return;
            db.People.AddRange(People);
            db.SaveChanges();
        }
        private static void InitializeUsers(SaunaDbContext db)
        {
            if (db.Users.Count() != 0) return;
            db.Users.AddRange(Users);
            db.SaveChanges();
        }
        private static void InitializeDeliveryStatus(SaunaDbContext db)
        {
            if (db.Statuses.Count() != 0) return;
            db.Statuses.AddRange(Statuses);
            db.SaveChanges();
        }
        private static void InitializeRoles(SaunaDbContext db)
        {
            if (db.Roles.Count() != 0) return;
            db.Roles.AddRange(Roles);
            db.SaveChanges();
        }
        private static void InitializeUserRoles(SaunaDbContext db)
        {
            if (db.UserRoles.Count() != 0) return;
            db.UserRoles.AddRange(UserRoles);
            db.SaveChanges();
        }
        private static void InitializeBrands(SaunaDbContext db)
        {
            if (db.Brands.Count() != 0) return;
            db.Brands.AddRange(Brands);
            db.SaveChanges();
        }
        private static void InitializeCountries(SaunaDbContext db)
        {
            if (db.Countries.Count() != 0) return;
            db.Countries.AddRange(Countries);
            db.SaveChanges();
        }
        private static void InitializeCities(SaunaDbContext db)
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

        private static void InitializeStock(SaunaDbContext db)
        {
            if (db.Stock.Count() != 0) return;
            db.Stock.AddRange(Stocks);
            db.SaveChanges();
        }

        public static void Initialize(SaunaDbContext db)
        {
            InitializeBrands(db);
            InitializeProductTypes(db);
            InitializeUnits(db);
            InitializeProducts(db);
            InitializeStock(db);
            InitializeCountries(db);
            InitializeDeliveryTypes(db);
            InitializeDeliveryStatus(db);
            InitializeCities(db);
            InitializeRoles(db);
            InitializePaymentTypes(db);
            InitializePeople(db);
            InitializeUsers(db);
            InitializeUserRoles(db);
        }

    }
}