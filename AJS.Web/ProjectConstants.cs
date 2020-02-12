﻿using System;
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

        #region AdminData
        public const string AdminConfigSection = "AdminData";      // Config Section Name at User Secrets
        public const string AdminEmailKey = "AdminEmail";          //  Admin Email at AdminData Section
        public const string AdminPasswordKey = "AdminPassword";    //  Admin Password at AdminPassword Section
        public const string AdminNameKey = "AdminName";            //  Admin Email at AdminName Section
        public const string AdminRoleName = "Administrator";       // Admin Role Name
        #endregion AdminData
    }
}
