using ebsiC.Assets.Classes;
using System.ComponentModel;

public class DashboardCardModel : ObservableObject
{
    private string _color;
    private string _title;
    private string _value;
    private string _icon;

    public string Color
    {
        get => _color;
        set
        {
            _color = value;
            OnPropertyChanged(nameof(Color));
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public string Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged(nameof(Value));
        }
    }

    public string Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            OnPropertyChanged(nameof(Icon));
        }
    }

    public DashboardCardModel(string color, string title, string value, string icon)
    {
        _color = color;
        _title = title;
        _value = value;
        _icon = icon;
    }
}
