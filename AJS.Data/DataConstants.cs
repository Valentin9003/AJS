namespace AJS.Data
{
    public static class DataConstants
    {
        #region String Length Data Annotation Constants

        public const int DescriptionTextMnimumLength = 10;

        public const int DescriptionTextMaximumLength = 700;

        public const int AdTitleMinimumLength = 2;

        public const int AdTitleMaximumLength = 22;

        public const int AdLocationCountryMnimumLength = 3;

        public const int AdLocationCountryMaximumLength = 15;

        public const int AdLocationCityMnimumLength = 3;

        public const int AdLocationCityMaximumLength = 15;

        public const int AdLocationStreetMaximumLength = 15;

        public const int AdLocationAddressMaximumLength = 15;

        public const int AdLocationPostCodeMaximumLength = 10;

        public const int PictureByteArrayMaximumLength = 10 * 1024 * 1024;   // Max size for Picture is 10MB

        #endregion String Length Data Annotation Constants
    }
}
