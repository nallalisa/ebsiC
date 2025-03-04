using ebsiC.Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
