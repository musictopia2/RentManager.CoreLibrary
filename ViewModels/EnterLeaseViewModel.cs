namespace RentManager.CoreLibrary.ViewModels;
public class EnterLeaseViewModel(ILeaseStorage storage,
    ILeaseTermProvider leaseTermProvider,
    IToast toast
    ) : IEnterLeaseViewModel
{

    private bool _hasFirst;
    public int RentAmount { get; set; }
    public bool Visible { get; private set; } = true;
    public bool IsFirstLease => _hasFirst;
    public DateOnly FirstStartDate { get; set; }
    public DateOnly? GetNewStartDate { get; private set; }
    public bool CanStart { get; private set; }
    public int LeaseTerm { get; set; }
    public BasicList<int> AvailableLeaseTerms { get; private set; } = [];
    public async Task InitAsync()
    {
        _hasFirst = await storage.IsFirstLeaseAsync();
        if (_hasFirst == false)
        {
            LeaseModel current = await storage.GetNewestLeaseAsync();
            GetNewStartDate = current.EndDate.AddDays(1);
        }
        AvailableLeaseTerms = await leaseTermProvider.GetAvailableLeaseTermsAsync();
        if (AvailableLeaseTerms.Count == 0)
        {
            throw new CustomBasicException("Must have at least one lease term");
        }
        CanStart = true;
        if (AvailableLeaseTerms.Count == 1)
        {
            LeaseTerm = AvailableLeaseTerms.First(); // Auto-select if there's only one
        }
    }
    public async Task ProcessAsync()
    {
        if (LeaseTerm == 0)
        {
            return; //can't process anymore.
        }
        if (RentAmount <= 0)
        {
            toast.ShowUserErrorToast("You must enter a rent amount");
            return;
        }
        DateOnly startDate;
        if (_hasFirst == true)
        {
            if (FirstStartDate == default)
            {
                toast.ShowUserErrorToast("You must enter a start date since its the first lease ever entered");
                return;
            }
            startDate = FirstStartDate;
        }
        else
        {
            startDate = GetNewStartDate!.Value;
        }
        DateOnly endDate = startDate.AddMonths(LeaseTerm);
        endDate = endDate.AddDays(-1); //forgot this part.
        LeaseModel newLease = new()
        {
            StartDate = startDate,
            EndDate = endDate,
            RentAmount = RentAmount
        };
        Visible = false;
        LeaseTerm = 0;
        await storage.SaveNewLeaseAsync(newLease);
    }
    public async Task SelectLeaseTermAsync(int term)
    {
        LeaseTerm = term;
        // After selecting the term, trigger the process
        await ProcessAsync();
    }
}