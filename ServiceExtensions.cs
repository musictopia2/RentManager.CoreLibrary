namespace RentManager.CoreLibrary;
public static class ServiceExtensions
{
    public static IServiceCollection RegisterRentViewModels(this IServiceCollection services)
    {
        services.AddTransient<IViewLeaseViewModel, ViewLeaseViewModel>();
        services.AddTransient<IEnterLeaseViewModel, EnterLeaseViewModel>();
        return services;
    }
}