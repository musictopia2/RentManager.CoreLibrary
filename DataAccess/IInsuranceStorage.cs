namespace RentManager.CoreLibrary.DataAccess;
public interface IInsuranceStorage
{
    //there may be no insurance at all.  not everybody even requires insurance.
    Task<InsuranceModel?> GetCurrentInsuranceAsync(DateOnly currentDate);
    Task SaveNewInsuranceAsync(InsuranceModel insurance);
}