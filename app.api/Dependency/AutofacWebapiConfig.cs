using app.service.Services.StudentService;
using app.service.Services.UserService;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace app.api.Dependency
{
    public class AutofacWebapiConfig
    {

        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterType<DBCustomerEntities>()
            //       .As<DbContext>()
            //       .InstancePerRequest();

            //builder.RegisterType<DbFactory>()
            //       .As<IDbFactory>()
            //       .InstancePerRequest();

            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //       .As(typeof(IGenericRepository<>))
            //       .InstancePerRequest();

            builder.RegisterType(typeof(UserService))
                   .As(typeof(IUserService))
                   .InstancePerRequest();

            builder.RegisterType(typeof(StudentService))
                   .As(typeof(IStudentService))
                   .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}