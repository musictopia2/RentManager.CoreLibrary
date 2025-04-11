namespace RentManager.CoreLibrary.ViewModels;
public class EnterInsuranceViewModel(IInsuranceStorage storage) : IEnterInsuranceViewModel
{
    public bool Visible { get; private set; } = true;
    public decimal InsuranceAmount { get; set; }
    async Task IEnterInsuranceViewModel.ProcessAsync()
    {
        InsuranceModel insurance = new();
        insurance.CurrentInsuranceRate = InsuranceAmount;
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        insurance.StartDate = new DateOnly(today.Year, today.Month, 1);
        Visible = false;
        await storage.SaveNewInsuranceAsync(insurance);
    }
}