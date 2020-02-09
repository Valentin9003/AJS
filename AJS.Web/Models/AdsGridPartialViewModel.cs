using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Web.Models
{
    public class AdsGridPartialViewModel
    {
        [Required(ErrorMessage = ProjectConstants.AdsGridPartialViewModelAdIdRequiredErrorMessage)]
        public string AdId { get; set; }

        [Required(ErrorMessage = ProjectConstants.AdsGridPartialViewModelAdTitleRequiredErrorMessage)]
        public string AdTitle { get; set; } 

        [Required(ErrorMessage = ProjectConstants.AdsGridPartialViewModelDateTimeRequiredErrorMessage)]
        public DateTime PublicationDate { get; set; }

        [MaxLength(ProjectConstants.AdsGridPartialViewModelPictureByteArrayMaximumLength)]
        public byte[] Picture { get; set; } = new byte[ProjectConstants.AdsGridPartialViewModelPictureByteArrayMaximumLength];
    }
}
