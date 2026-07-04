namespace TaxIntake.Model
{
    public class IntakeForm
    {

        public string? Primary_Last_Name { get; set; }
        public string? Primary_First_Name { get; set; }
        public string? Primary_Title { get; set; }
        public MaritalStatus? Primary_Marital_Status { get; set; }
        public string? Primary_SIN { get; set; }
        public string? Primary_DOB { get; set; }
        public string? Primary_Street_Address { get; set; }
        public string? Primary_PO_Box { get; set; }
        public string? Primary_RR { get; set; }
        public string? Primary_City { get; set; }
        public Province? Primary_Province { get; set; }
        public string? Primary_Postal_Code { get; set; }
        public string? Primary_Phone_Number { get; set; }
        public string? Primary_Email { get; set; }

        public bool? Primary_Is_Citizen { get; set; }
        public bool? Primary_Is_To_Reveal_Citizen { get; set; }

        public bool? Primary_Is_To_Sell_Principal_Residence { get; set; }
        public bool? Primary_Is_To_Sell_Other_Real_Estate { get; set; }
        public bool? Primary_Is_To_Have_Foreign_Investments { get; set; }
        public bool? Primary_Is_To_Own_Foreign_Business { get; set; }

    }
}
