using System.Windows;

namespace Taksi.Windows
{
    public partial class MakeClientWindow
    {
        public Client NewClient
        {
            get { return (Client)GetValue(NewClientProperty); }
            set { SetValue(NewClientProperty, value); }
        }

        public static readonly DependencyProperty NewClientProperty =
            DependencyProperty.Register("NewClient", typeof(Client), typeof(MakeClientWindow));
    }
}
