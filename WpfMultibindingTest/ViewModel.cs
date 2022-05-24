using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfMultibindingTest;

public class ViewModel : INotifyPropertyChanged
{
    private double? _value;

    public ViewModel()
    {
        Value = 4;
    }

    public double? Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    #region INotifyPropertyChanged implementation

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}