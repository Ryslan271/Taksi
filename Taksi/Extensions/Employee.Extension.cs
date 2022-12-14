namespace Taksi
{
    public partial class Employee
    {
        public string FullName
        {
            get => $"{Surname} {Name[0]}. {Patronymic[0]}.";
        }
    }
}
