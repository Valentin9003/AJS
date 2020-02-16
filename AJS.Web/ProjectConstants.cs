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

        public const string DeniedActionName = "Denied";

        public const string HomeControllerName = "Home";

        public const string SeedDatabaseNullAdminDataErrorMessage = "Admin data not found in 'User Secrets'";

        #endregion ApplicationConstants

        #region CategoryNavigationMenuPartialViewModel

        public const string CategoryNavigationMenuPartialViewModelAreaNameRequiredErrorMessage = "Area Name is Required";
        
        public const string CategoryNavigationMenuPartialViewModelControllerNameRequiredErrorMessage = "Controller Name is Required";
        
        public const string CategoryNavigationMenuPartialViewModelActionNameRequiredErrorMessage = "Action Name is Required";
        
        public const string CategoryNavigationMenuPartialViewModelCategoryNameRequiredErrorMessage = "Category Name is Required";

        public const string CategoryNavigationMenuPartialViewModelCategoryIdRequiredErrorMessage = "Category ID is Required";
      
        public const string ChildCategoryNavigationMenuPartialViewModelAreaNameRequiredErrorMessage = "Child Area Name is Required";
      
        public const string ChildCategoryNavigationMenuPartialViewModelControllerNameRequiredErrorMessage = "Child Controller Name is Required";
      
        public const string ChildCategoryNavigationMenuPartialViewModelActionNameRequiredErrorMessage = "Child Action Name is Required";
      
        public const string ChildCategoryNavigationMenuPartialViewModelCategoryNameRequiredErrorMessage = "Child Category Name is Required";
      
        public const string ChildCategoryNavigationMenuPartialViewModelCategoryIdRequiredErrorMessage = "Child Category Id is Required";

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

        #region AdminData

        public const string AdminConfigSection = "AdminData";      // Config Section Name at User Secrets

        public const string AdminEmailKey = "AdminEmail";          //  Admin Email at AdminData Section

        public const string AdminPasswordKey = "AdminPassword";    //  Admin Password at AdminPassword Section

        public const string AdminNameKey = "AdminName";            //  Admin Email at AdminName Section

        public const string AdminRoleName = "Administrator";       // Admin Role Name

        #endregion AdminData
    }
}
