using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RecipeManager>().As<IRecipeService>().SingleInstance();
            builder.RegisterType<EfRecipeDal>().As<IRecipeDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<DirectionManager>().As<IDirectionService>().SingleInstance();
            builder.RegisterType<EfDirectionDal>().As<IDirectionDal>().SingleInstance();

            builder.RegisterType<InfoManager>().As<IInfoService>().SingleInstance();
            builder.RegisterType<EfInfoDal>().As<IInfoDal>();

            builder.RegisterType<IngredientManager>().As<IIngredientService>().SingleInstance();
            builder.RegisterType<EfIngredientDal>().As<IIngredientDal>().SingleInstance();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();





            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
