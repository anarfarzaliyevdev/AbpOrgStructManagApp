using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AbpOrgStructManagApp.Localization
{
    public static class AbpOrgStructManagAppLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpOrgStructManagAppConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpOrgStructManagAppLocalizationConfigurer).GetAssembly(),
                        "AbpOrgStructManagApp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
