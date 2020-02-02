namespace AJS.Data
{
    public static class DataConstants
    {
        #region String Length Ad Data Annotation Constants

        public const int AdDescriptionTextMinimumLength = 10;

        public const int AdDescriptionTextMaximumLength = 700;

        public const int AdTitleMinimumLength = 2;

        public const int AdTitleMaximumLength = 22;

        public const int AdLocationCountryMinmumLength = 3;

        public const int AdLocationCountryMaximumLength = 15;

        public const int AdLocationCityMinimumLength = 3;

        public const int AdLocationCityMaximumLength = 15;

        public const int AdLocationStreetMaximumLength = 15;

        public const int AdLocationAddressMaximumLength = 15;

        public const int AdLocationPostCodeMaximumLength = 10;

        public const int AdPictureByteArrayMaximumLength = 10 * 1024 * 1024;   // Max size for Picture is 10MB

        public const string AdPriceCurrencyRegex = "^(BG|EN|USD|EUR|GDP)$";

        #endregion String Length Ad Data Annotation Constants

        #region String Length Service Data Annotation Constants

        public const int ServiceDescriptionTextMinimumLength = 10;

        public const int ServiceDescriptionTextMaximumLength = 700;

        public const int ServiceTitleMinimumLength = 2;

        public const int ServiceTitleMaximumLength = 22;

        public const int ServiceLocationCountryMinimumLength = 3;

        public const int ServiceLocationCountryMaximumLength = 15;

        public const int ServiceLocationCityMinimumLength = 3;

        public const int ServiceLocationCityMaximumLength = 15;

        public const int ServiceLocationStreetMaximumLength = 15;

        public const int ServiceLocationAddressMaximumLength = 15;

        public const int ServiceLocationPostCodeMaximumLength = 10;

        public const int ServicePictureByteArrayMaximumLength = 10 * 1024 * 1024;   // Max size for Picture is 10MB

        public const string ServicePriceCurrencyRegex = "^(BG|EN|USD|EUR|GDP)$";

        #endregion String Length Service Data Annotation Constants

        #region String Length Job Data Annotation Constants

        public const int JobDescriptionTextMinimumLength = 10;

        public const int JobDescriptionTextMaximumLength = 700;
                         
        public const int JobTitleMinimumLength = 2;
                         
        public const int JobTitleMaximumLength = 22;
                         
        public const int JobLocationCountryMinimumLength = 3;
                         
        public const int JobLocationCountryMaximumLength = 15;
                         
        public const int JobLocationCityMinimumLength = 3;
                         
        public const int JobLocationCityMaximumLength = 15;
                         
        public const int JobLocationStreetMaximumLength = 15;
                         
        public const int JobLocationAddressMaximumLength = 15;

        public const int JobLocationPostCodeMaximumLength = 10;
                         
        public const int JobPictureByteArrayMaximumLength = 10 * 1024 * 1024;   // Max size for Picture is 10MB

        public const string JobPriceCurrencyRegex = "^(BG|EN|USD|EUR|GDP)$";

        #endregion String Length Job Data Annotation Constants

        #region String Length Message Data Annotation Constants 

        public const int MessageTextMaximumLength = 700;
        public const int MessageTextMinimumLength = 2;
        public const int MessageTitleMaximumLength = 50;
        public const int MessageTitleMinimumLength = 2;
        public const string MessageTimeSeenDateTimeRegularExpression = @"^((0[1-9])|([1-2][0-9])|(3[0-1]))\.((0[1-9])|(1[0-2]))\.20\d{2}(T|\s)(([0-1][0-9])|(2[0-3])):([0-5][0-9]):([0-5][0-9])";  // DateTime Format: "31.12.2000 23:59:59"

        #endregion String Length Message Data Annotation Constants

        #region String Length News Data Annotation Constants

        public const int NewsTitleMaximumLength = 50;
        public const int NewsTitleMinimumLength = 2;
        public const int NewsDescriptionMaximumLength = 1500;
        public const int NewsDescriptionMinimumLength = 20;

        #endregion String Length News Data Annotation Constants
    }
}
