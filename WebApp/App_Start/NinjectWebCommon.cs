[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace WebApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BL.Services.PersonService;
    using Interfaces;
    using DAL.Repositories;
    using DAL;
    using DAL.Helpers;
    using BL.Services.NoticeService;
    using BL.Services.ApartmentService;
    using BL.Services.VotingService;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Meie elame oma elu siin.
            kernel.Bind<ICooperationContext>().To<CooperationContext>().InRequestScope();
            kernel.Bind<IRepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>().InRequestScope();
            kernel.Bind<IUow>().To<Uow>().InRequestScope();
            kernel.Bind<IPersonService>().To<PersonService>().InThreadScope();
            kernel.Bind<IPersonRepository>().To<PersonRepository>().InRequestScope();
            kernel.Bind<INoticeService>().To<NoticeService>().InThreadScope();
            kernel.Bind<INoticeRepository>().To<NoticeRepository>().InRequestScope();
            kernel.Bind<IApartmentService>().To<ApartmentService>().InThreadScope();
            kernel.Bind<IApartmentRepository>().To<ApartmentRepository>().InRequestScope();
            kernel.Bind<IOwnershipRepository>().To<OwnershipRepository>().InRequestScope();
            kernel.Bind<IHouseRepository>().To<HouseRepository>().InRequestScope();
            kernel.Bind<IVotingRepository>().To<VotingRepository>().InRequestScope();            //Skoobid tegelevad objetkide elutsüklitega:
            kernel.Bind<IVoteRepository>().To<VoteRepository>().InRequestScope();
            kernel.Bind<IPossibleVoteRepository>().To<PossibleVoteRepository>().InRequestScope();
            kernel.Bind<IApartmentOwnersVoteRepository>().To<ApartmentOwnersVoteRepository>().InRequestScope();
            kernel.Bind<IVotingService>().To<VotingService>().InThreadScope();
            //Singleton: Objekt luuakse üks kord, kui teda küsitakse ja enam ära ei kustutata, kuni rakendus töötab.
            //InRequest: Spetsiaalselt veebiserveri jaoks loodud, püsib elus, kuni töötab see veebipäring.
        }
    }
}
