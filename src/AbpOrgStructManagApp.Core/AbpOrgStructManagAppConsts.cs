using AbpOrgStructManagApp.Debugging;

namespace AbpOrgStructManagApp
{
    public class AbpOrgStructManagAppConsts
    {
        public const string LocalizationSourceName = "AbpOrgStructManagApp";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6adc2b74699f4167aeed99e24a107499";
    }
}
