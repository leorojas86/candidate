using DataProject;
using IRepository;
using Repository;
using StructureMap;
namespace WebApplication {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IContactsRepository>().Use<DatabaseContactsRepository>();
                            //x.For<IContactsRepository>().Use<MockContactsRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}