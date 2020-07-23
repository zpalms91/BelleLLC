using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BelleEssense.DATA
{
    #region Users
    [MetadataType(typeof(UserMetadata))]
    public partial class User { }

    public class UserMetadata
    {
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "First Name must be 30 characters or less")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Last Name must be 30 characters or less")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid Email")]
        [StringLength(50, ErrorMessage = "Email must be 50 characters or less")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Address must be 50 characters or less")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City must be 30 characters or less")]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be a two-letter abbreviation")]
        public string State { get; set; }

        [DataType(DataType.PostalCode, ErrorMessage = "Please enter a valid ZIP Code")]
        public string ZIP { get; set; }

        [StringLength(30, ErrorMessage = "Country must be 30 characters or less")]
        public string Country { get; set; }
    }
    #endregion

    #region Products
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }    

    public class ProductMetadata
    {
        [StringLength(30, ErrorMessage = "Product Name must be less than 30 characters")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public string Name { get; set; }

        [Required(ErrorMessage = "***REQUIRED***")]
        [UIHint("MultilineText")]
        public string Description { get; set; }
    }
    #endregion

    #region Lotions
    [MetadataType(typeof(LotionMetadata))]
    public partial class Lotion { }

    public class LotionMetadata
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", NullDisplayText = "[--N/A--]")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid Price")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "Enter a value between 1 and 100")]
        public float Discount { get; set; }

        [Display(Name = "Add CBD?")]
        public bool CBD { get; set; }

        [Display(Name = "Add Magnesium Oil?")]
        public bool MagOil { get; set; }

        [Display(Name = "Featured Item?")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo1 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo2 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo3 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo4 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo5 { get; set; }

        [UIHint("MultilineText")]
        [StringLength(100, ErrorMessage = "Notes must be less than 100 characters")]
        public string Notes { get; set; }
    }
    #endregion

    #region Candles
    [MetadataType(typeof(CandleMetadata))]
    public partial class Candle { }

    public class CandleMetadata
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}", NullDisplayText = "[--N/A--]")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid Price")]
        [Required(ErrorMessage = "***REQUIRED***")]
        public decimal Price { get; set; }

        [Range(1, 100, ErrorMessage = "Enter a value between 1 and 100")]
        public float Discount { get; set; }

        [Display(Name = "Featured Item?")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo1 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo2 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo3 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo4 { get; set; }

        [Display(Name = "Photo URL")]
        [StringLength(100, ErrorMessage = "Photo URL must be less than 100 characters")]
        public string Photo5 { get; set; }

        [UIHint("MultilineText")]
        [StringLength(100, ErrorMessage = "Notes must be less than 100 characters")]
        public string Notes { get; set; }
    }
    #endregion

    #region Scents
    [MetadataType(typeof(ScentMetadata))]
    public partial class Scent { }

    public class ScentMetadata
    {
        [Display(Name = "Scent Name")]
        [StringLength(25, ErrorMessage = "Scent Name must be 25 characters or less")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
    #endregion

    #region Labels
    [MetadataType(typeof(LabelMetadata))]
    public partial class Label { }

    public class LabelMetadata
    {

        public string Description { get; set; }
    }
    #endregion

    #region Sizes
    [MetadataType(typeof(SizeMetadata))]
    public partial class Size { }

    public class SizeMetadata
    {

        public string Description { get; set; }
    }    
    #endregion
}
