using ebsiC.Assets.Classes;

namespace ebsiC.Assets.MVVM.ViewModel
{
    public class DashboardCardVM : ObservableObject
    {
        private DashboardCardModel _card;

        public string Color => _card.Color;
        public string Title => _card.Title;
        public string Value => _card.Value;
        public string Icon => _card.Icon;

        public DashboardCardVM(DashboardCardModel model)
        {
            _card = model;
        }

    }
}
