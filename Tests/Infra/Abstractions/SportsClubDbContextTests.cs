//using System;
//using System.Linq;
//using System.Linq.Expressions;
//using Aids.Reflection;
//using Infra;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Metadata.Conventions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Tests.Infra.Abstractions
//{
//    [TestClass]
//    public class SportsClubDbContextTests : BaseClassTests<SaunaDbContext, DbContext>
//    {

//        private DbContextOptions<SaunaDbContext> options;

//        private class TestClass : SaunaDbContext
//        {
//            public TestClass(DbContextOptions<SaunaDbContext> o) : base(o) { }

//            public ModelBuilder RunOnModelCreating()
//            {
//                var set = new ConventionSet();
//                var mb = new ModelBuilder(set);
//                OnModelCreating(mb);

//                return mb;
//            }
//        }

//        [TestInitialize]
//        public override void TestInitialize()
//        {
//            base.TestInitialize();
//            options = new DbContextOptionsBuilder<SaunaDbContext>().UseInMemoryDatabase("TestDb").Options;
//            obj = new SaunaDbContext(options);
//        }

//        [TestMethod]
//        public void InitializeTablesTest()
//        {
//            static void TestKey<T>(IMutableEntityType entity, params Expression<Func<T, object>>[] values)
//            {
//                var key = entity.FindPrimaryKey();

//                if (values is null) Assert.IsNull(key);
//                else
//                    foreach (var v in values)
//                    {
//                        var name = GetMember.Name(v);
//                        Assert.IsNotNull(key.Properties.FirstOrDefault(x => x.Name == name));
//                    }
//            }

//            static void TestEntity<T>(ModelBuilder b, params Expression<Func<T, object>>[] values)
//            {
//                var name = typeof(T).FullName ?? string.Empty;
//                var entity = b.Model.FindEntityType(name);
//                Assert.IsNotNull(entity, name);
//                TestKey(entity, values);
//            }

//            SaunaDbContext.InitializeTables(null);
//            var o = new TestClass(options);
//            var builder = o.RunOnModelCreating();
//            SaunaDbContext.InitializeTables(builder);
//            TestEntity<ClientData>(builder);
//            TestEntity<CoachData>(builder);
//            TestEntity<LocationData>(builder);
//            TestEntity<ParticipantOfTrainingData>(builder, x=> x.TimetableEntryId, x=> x.ClientId);
//            TestEntity<TimetableEntryData>(builder);
//            TestEntity<TrainingCategoryData>(builder);
//            TestEntity<TrainingTypeData>(builder);
//            TestEntity<TrainingData>(builder);
//        }

//        [TestMethod]
//        public void ClientsTest() => IsNullableProperty(obj, nameof(obj.Clients), typeof(DbSet<ClientData>));

//        [TestMethod]
//        public void CoachesTest() => IsNullableProperty(obj, nameof(obj.Coaches), typeof(DbSet<CoachData>));

//        [TestMethod]
//        public void LocationsTest() => IsNullableProperty(obj, nameof(obj.Locations), typeof(DbSet<LocationData>));

//        [TestMethod]
//        public void ParticipantsOfTrainingTest() => IsNullableProperty(obj, nameof(obj.ParticipantsOfTraining), typeof(DbSet<ParticipantOfTrainingData>));

//        [TestMethod]
//        public void TimetableEntriesTest() => IsNullableProperty(obj, nameof(obj.TimetableEntries), typeof(DbSet<TimetableEntryData>));

//        [TestMethod]
//        public void TrainingCategoriesTest() => IsNullableProperty(obj, nameof(obj.TrainingCategories), typeof(DbSet<TrainingCategoryData>));

//        [TestMethod]
//        public void TrainingTypesTest() => IsNullableProperty(obj, nameof(obj.TrainingTypes), typeof(DbSet<TrainingTypeData>));

//        [TestMethod]
//        public void TrainingsTest() => IsNullableProperty(obj, nameof(obj.Trainings), typeof(DbSet<TrainingData>));
//    }
//}
