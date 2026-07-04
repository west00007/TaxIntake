using System.ComponentModel.DataAnnotations;

namespace TaxIntake.Model
{
    public enum MaritalStatus
    {
        [Display(Name = "Married")]
        Married = 2,

        [Display(Name = "Living Common-law")]
        LivingCommonlaw = 3,

        [Display(Name = "Widowed")]
        Widowed = 4,

        [Display(Name = "Divorced")]
        Divorced = 5,

        [Display(Name = "Separated")]
        Separated = 6,

        [Display(Name = "Single")]
        Single = 1,
    }

    public enum Province
    {
        [Display(Name = "Nova Scotia")]
        Nova_Scotia,

        [Display(Name = "Alberta")]
        Alberta,

        [Display(Name = "British Columbia")]
        British_Columbia,

        [Display(Name = "Manitoba")]
        Manitoba,

        [Display(Name = "New Brunswick")]
        New_Brunswick,

        [Display(Name = "Newfoundland and Labrador")]
        Newfoundland_and_Labrador,

        [Display(Name = "Northwest Territories")]
        Northwest_Territories,

        [Display(Name = "Nunavut")]
        Nunavut,

        [Display(Name = "Ontario")]
        Ontario,

        [Display(Name = "Prince Edward Island")]
        Prince_Edward_Island,

        [Display(Name = "Saskatchewan")]
        Saskatchewan,

        [Display(Name = "Yukon")]
        Yukon,

        [Display(Name = "others")]
        others,
    }
}
