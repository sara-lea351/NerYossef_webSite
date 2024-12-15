namespace NerYossefWebsite.DTO_s
{
    public class personDTO
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? NumberId { get; set; }

        public string? PassportNumber { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PersonType { get; set; } = null!;
    }
}
