using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJS.Web
{
    public static class ProjectConstants
    {
        #region ApplicationConstants

        public const string LanguageResourcesPath = "Resources";
        public const string ErrorLogTitle = "Internal server error: ";
        public const string NLogConfigFileDirectory = "/nlog.config";
        public const string DefaultConnection = "DefaultConnection";
        public const string SendGridConfigSection = "SendGrid";
        public const string ErrorControllerPath = "/Home/Error";
        public const string FacebookAppId = "FacebookAutentication:FacebookAppId";
        public const string FacebookAppSecret = "FacebookAutentication:FacebookAppSecret";

        #endregion ApplicationConstants

        #region CategoryNavigationMenuPartialViewModel

        public const string CategoryNavigationMenuPartialViewModelAreaNameRequiredErrorMessage = "Area Name is Required";
        public const string CategoryNavigationMenuPartialViewModelControllerNameRequiredErrorMessage = "Controller Name is Required";
        public const string CategoryNavigationMenuPartialViewModelActionNameRequiredErrorMessage = "Action Name is Required";
        public const string CategoryNavigationMenuPartialViewModelCategoryNameRequiredErrorMessage = "Category Name is Required";
        public const string CategoryNavigationMenuPartialViewModelCategoryIdRequiredErrorMessage = "Category Id is Required";

        #endregion CategoryNavigationMenuPartialViewModel

        #region ElementGridPartialViewModel

        public const int ElementGridPartialViewModelPictureByteArrayMaximumLength = 10 * 124 * 1024;

        public const string ElementGridPartialViewModelPublicationDateTimeRequiredErrorMessage = "Publication date for ad in 'AdsGridPartialViewModel' is required.";

        public const string ElementGridPartialViewModelTitleRequiredErrorMessage = "'Ad name' for ad in 'AdsGridPartialViewModel' required.";

        public const string ElementGridPartialViewModelIdRequiredErrorMessage = "'Ad id' for ad in 'AdsGridPartialView' is required.";

        public const string ElementGridPartialViewUnitRouteModelActionNameRequiredErrorMassage = "Action name in 'ElementGridPartialView' is Required";

        public const string ElementGridPartialViewUnitRouteModelControllerNameRequiredErrorMassage = "Controller name in 'ElementGridPartialView' is Required";

        public const string ElementGridPartialViewUnitRouteModelAreaNameRequiredErrorMassage = "Area name in 'ElementGridPartialView' is Required";

        public const string ElementGridPartialViewUnitRouteModelRequiredErrorMassage = "Element Route Model in 'ElementGridPartialView' is Required";

        #endregion ElementGridPartialViewModel
    }
}
