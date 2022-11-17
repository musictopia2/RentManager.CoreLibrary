namespace RentManager.CoreLibrary.ViewModels;
public class EnterLeaseViewModel : IEnterLeaseViewModel
{
    public EnterLeaseViewModel(ILeaseStorage storage,
        ILeaseLength length,
        IToast toast
        )
    {
        _storage = storage;
        _length = length;
        _toast = toast;
    }
    private bool _hasFirst;
    private readonly ILeaseStorage _storage;
    private readonly ILeaseLength _length;
    private readonly IToast _toast;
    public int RentAmount { get; set; }
    public bool Visible { get; private set; } = true;
    public bool IsFirstLease => _hasFirst;
    public DateOnly FirstStartDate { get; set; }
    public DateOnly? GetNewStartDate { get; private set; }
    public bool CanStart { get; private set; }
    public async Task InitAsync()
    {
        _hasFirst = await _storage.IsFirstLeaseAsync();
        if (_hasFirst == false)
        {
            LeaseModel current = await _storage.GetNewestLeaseAsync();
            GetNewStartDate = current.EndDate.AddDays(1);
        }
        CanStart = true;
    }
    public async Task ProcessAsync()
    {
        if (RentAmount <= 0)
        {
            _toast.ShowUserErrorToast("You must enter a rent amount");
            return;
        }
        DateOnly startDate;
        if (_hasFirst == true)
        {
            if (FirstStartDate == default)
            {
                _toast.ShowUserErrorToast("You must enter a start date since its the first lease ever entered");
                return;
            }
            startDate = FirstStartDate;
        }
        else
        {
            startDate = GetNewStartDate!.Value;
        }
        DateOnly endDate = startDate.AddMonths(_length.Months);
        endDate = endDate.AddDays(-1);
        LeaseModel newLease = new();
        newLease.StartDate = startDate;
        newLease.EndDate = endDate;
        newLease.RentAmount = RentAmount;
        Visible = false;
        await _storage.SaveNewLeaseAsync(newLease);
    }
}