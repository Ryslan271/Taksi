using System.Windows;

namespace Taksi
{
    public partial class Employee
    {
        public string FullName
        {
            get => $"{Surname} {Name[0]}. {Patronymic[0]}.";
        }

        public Visibility AdministratorVisibility
        {
            get
            {
                if (RoleID == 0)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public string InProcessing
        {
            get
            {
                if (this.RoleID == 0)
                    return "Администратор";
                else if (this.RoleID == 1)
                    return "Водитель";

                return "Поддержка";
            }
        }
    }
}
