namespace RentManager.CoreLibrary.ViewModels;
public class ViewLeaseViewModel : IViewLeaseViewModel
{
    private readonly ILeaseStorage _storage;
    private readonly IDateOnlyPicker _picker;
    public ViewLeaseViewModel(ILeaseStorage storage,
        IDateOnlyPicker picker
        )
    {
        _storage = storage;
        _picker = picker;
    }
    async Task<LeaseModel?> IViewLeaseViewModel.GetCurrentLeaseAsync()
    {
        bool rets = await _storage.IsFirstLeaseAsync();
        if (rets == true)
        {
            return null;
        }
        DateOnly currentDate = _picker.GetCurrentDate;
        if (currentDate.Day >= 10)
        {
            currentDate = currentDate.AddMonths(1);
            currentDate.AddDays(currentDate.Day * -1);
        }
        return await _storage.GetCurrentLeaseAsync(currentDate);
    }
}