namespace StudyLounge25.DTO
{
    public class FetchFeeDetailDto
    {
       public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalFee { get; set; }
        public decimal FeePaid { get; set; }
        public string CabinName { get; set; }

    }
}
