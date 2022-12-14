namespace Taksi
{
    public partial class Client
    {
        public string FullName
        {
            get => $"{Surname} {Name[0]}. {Patronymic[0]}.";
        }
    }
}
