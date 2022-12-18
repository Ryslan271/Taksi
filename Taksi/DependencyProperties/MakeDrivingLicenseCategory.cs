using System.Collections.ObjectModel;
using System.Windows;

namespace Taksi.Windows
{
    public partial class MakeDrivingLicenseCategory
    {
        public ObservableCollection<DrivingLicenseCategory> DrivingLicenseCategories
        {
            get { return (ObservableCollection<DrivingLicenseCategory>)GetValue(DrivingLicenseCategoriesProperty); }
            set { SetValue(DrivingLicenseCategoriesProperty, value); }
        }

        public static readonly DependencyProperty DrivingLicenseCategoriesProperty =
            DependencyProperty.Register("DrivingLicenseCategories", typeof(ObservableCollection<DrivingLicenseCategory>), typeof(MakeDrivingLicenseCategory));
    }
}
