using System.Collections.Generic;
using System.Windows;

namespace Taksi.Pages
{
    public partial class ListClientPage
    {
        public IEnumerable<Client> Clients
        {
            get { return (IEnumerable<Client>)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(IEnumerable<Client>), typeof(ListClientPage));
    }
}
