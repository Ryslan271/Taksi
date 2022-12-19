using System.Windows;

namespace Taksi.Windows
{
    public partial class MainWindow
    {
        public Visibility FlagClickTab
        {
            get { return (Visibility)GetValue(FlagClickTabProperty); }
            set { SetValue(FlagClickTabProperty, value); }
        }

        public static readonly DependencyProperty FlagClickTabProperty =
            DependencyProperty.Register("FlagClickTab", typeof(Visibility), typeof(MainWindow));

        public Visibility VisibilityRadioButtonAdminSupport
        {
            get { return (Visibility)GetValue(VisibilityRadioButtonAdminSupportProperty); }
            set { SetValue(VisibilityRadioButtonAdminSupportProperty, value); }
        }

        public static readonly DependencyProperty VisibilityRadioButtonAdminSupportProperty =
            DependencyProperty.Register("VisibilityRadioButtonAdminSupport", typeof(Visibility), typeof(MainWindow));
    }
}
