using System.Windows;

namespace Taksi.Pages
{
    public partial class PersonalClientPage
    {
        public Client ClientPersonal
        {
            get { return (Client)GetValue(ClientPersonalProperty); }
            set { SetValue(ClientPersonalProperty, value); }
        }

        public static readonly DependencyProperty ClientPersonalProperty =
            DependencyProperty.Register("ClientPersonal", typeof(Client), typeof(PersonalClientPage));
    }
}
