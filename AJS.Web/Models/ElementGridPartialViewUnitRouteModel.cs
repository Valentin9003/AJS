using System.ComponentModel.DataAnnotations;

namespace AJS.Web.Models
{
    public class ElementGridPartialViewUnitRouteModel
    {
        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewUnitRouteModelActionNameRequiredErrorMassage)]
        public string Action { get; set; }

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewUnitRouteModelControllerNameRequiredErrorMassage)]
        public string Controller { get; set; }

        [Required(ErrorMessage = ProjectConstants.ElementGridPartialViewUnitRouteModelAreaNameRequiredErrorMassage)]
        public string Area { get; set; }
    }
}
