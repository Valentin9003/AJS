using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Web.Models
{
    public class ElementGridPartialViewModel
    {
        public string Category { get; set; }

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewModelIdRequiredErrorMessage)]
        public string ElementId { get; set; }

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewModelTitleRequiredErrorMessage)]
        public string ElementTitle { get; set; } 

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewModelPublicationDateTimeRequiredErrorMessage)]
        public DateTime PublicationDate { get; set; }

        [MaxLength(ProjectConstants.ElementGridPartialViewModelPictureByteArrayMaximumLength)]
        public byte[] Picture { get; set; } = new byte[ProjectConstants.ElementGridPartialViewModelPictureByteArrayMaximumLength];

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewUnitRouteModelRequiredErrorMassage)]
        public ElementGridPartialViewUnitRouteModel ElementRoute = new ElementGridPartialViewUnitRouteModel();
    }
}
