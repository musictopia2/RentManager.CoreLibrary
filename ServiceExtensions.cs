namespace RentManager.CoreLibrary;
public static class ServiceExtensions
{
    extension (IServiceCollection services)
    {
        public IServiceCollection RegisterRentViewModels()
        {
            services.AddTransient<IViewLeaseViewModel, ViewLeaseViewModel>();
            services.AddTransient<IEnterLeaseViewModel, EnterLeaseViewModel>();
            return services;
        }
    }
}