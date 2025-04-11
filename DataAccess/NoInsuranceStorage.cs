namespace RentManager.CoreLibrary.DataAccess;
public class NoInsuranceStorage : IInsuranceStorage
{
    Task<InsuranceModel?> IInsuranceStorage.GetCurrentInsuranceAsync(DateOnly currentDate)
    {
        return Task.FromResult<InsuranceModel?>(null);
    }
    Task IInsuranceStorage.SaveNewInsuranceAsync(InsuranceModel insurance)
    {
        throw new CustomBasicException("There is no insurance to save  because you chose no insurance.");
    }
}