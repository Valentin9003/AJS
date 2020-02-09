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

        #region AdsGridPartialViewModel

        public const int AdsGridPartialViewModelPictureByteArrayMaximumLength = 10 * 124 * 1024;

        public const string AdsGridPartialViewModelDateTimeRequiredErrorMessage = "Publication date for ad in 'AdsGridPartialViewModel' is required.";

        public const string AdsGridPartialViewModelAdTitleRequiredErrorMessage = "'Ad name' for ad in 'AdsGridPartialViewModel' required.";

        public const string AdsGridPartialViewModelAdIdRequiredErrorMessage = "'Ad id' for ad in 'AdsGridPartialView' is required.";

        #endregion AdsGridPartialViewModel
    }
}
