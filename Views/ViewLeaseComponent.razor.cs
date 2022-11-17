namespace RentManager.CoreLibrary.Views;
public partial class ViewLeaseComponent
{
    [Inject]
    [AllowNull]
    public IViewLeaseViewModel DataContext { get; set; }
    LeaseModel? _lease;
    private bool _processing = true;
    protected override async Task OnInitializedAsync()
    {
        _lease = await DataContext.GetCurrentLeaseAsync();
        _processing = false;
    }
    private string Dollars => _lease!.RentAmount.ConvertToIntegerWords();
}