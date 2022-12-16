using System.ComponentModel;
using System.Windows;

namespace Taksi.Pages
{
    public partial class ListClientPage
    {
        public ICollectionView Clients
        {
            get { return (ICollectionView)GetValue(ClientsProperty); }
            set { SetValue(ClientsProperty, value); }
        }

        public static readonly DependencyProperty ClientsProperty =
            DependencyProperty.Register("Clients", typeof(ICollectionView), typeof(ListClientPage));
    }
}
