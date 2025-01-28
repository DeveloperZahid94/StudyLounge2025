namespace StudyLounge25.DomainModels
{
    public class StudentModal
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool? IsDisabled { get; set; }

        public virtual ICollection<CabinAssignmentModal> CabinAssignments { get; set; }
        public virtual ICollection<FeeModal> Fees { get; set; }
    }
}
