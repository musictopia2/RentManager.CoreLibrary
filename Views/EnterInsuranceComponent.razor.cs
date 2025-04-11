namespace RentManager.CoreLibrary.Views;
public partial class EnterInsuranceComponent
{
    [Inject]
    [AllowNull]
    public IEnterInsuranceViewModel DataContext { get; set; }
    [Inject]
    public IToast? Toast { get; set; }
    private async Task ProcessAsync()
    {
        if (DataContext.InsuranceAmount <= 0)
        {
            Toast!.ShowUserErrorToast("Insurance amount must be greater than 0");
            return;
        }
        await DataContext!.ProcessAsync();
    }
}