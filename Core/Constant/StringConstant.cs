using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{

    public static class MessageString
    {
        public const string ServerError = "Internal Server Error Please Contact Adminstrator.";
        public const string LoginError = "Invalid Credentials";
        public const string LockError = "User account locked out.";
        public const string InvalidLogin = "Invalid login attempt.";
        public const string NotFound = "Record Not Found";
        public const string CreateError = "Error While Creating Record";
        public const string DeleteError = "Error While Deleting Record";

    }
    public static class CacheSuffix
    {
        public const string LocaleStringResourcesSuffix = "Localized.Property";
        public const string LocalizedPropertiesPrefix = "Localized.Property.Resource";
        public const string AppFileSuffix = "AppFile";

    }
    public static class ConstantStrings
    {
        public const string StripeHeaderText = "Stripe Header text";
        public const string DateTimeFormat = "dd/MM/yyyy HH:mm";
    }
    public static class ApplicationRole
    {
        public const string Guest = "Guest";
        public const string RegisterUser = "User";
        public const string Admin = "Admin";
    }
    public static class TaxMethods
    {
        public const string Exclusive = "Exclusive";
        public const string Inclusive = "Inclusive";
    }
    public static class ProductType
    {
        public const string Physical = "Physical";
        public const string Virtual = "Virtual";
    }
    public static class Settings
    {
        public const string StoreCacheOnStartup = "StoreCacheOnstartp";
    }
    public static class SiteUrl
    {
        public static string FilePath { get; set; }
    }
    public static class EnvirmenttStrings
    {
        public const string IsDevelopment = "IsDevelopment";
        public const string IsProduction = "IsProduction";
    }
}
