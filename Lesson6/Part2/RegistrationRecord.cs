class RegistrationRecord
{
    public string Surname { get; }
    public DateTime RegistrationDate { get; }
    public RegistrationRecord(string surname, DateTime registrationDate)
    {
        Surname = surname;
        RegistrationDate = registrationDate;
    }
}