namespace webapi;

public class AppSettings
{
    public const string SECTION_NAME = "blabla";
    // configuration - Settings
    // usages:  (가장 나중에 덮어씌움) args > env > appsettings.json (먼저 읽음)
    //    in args: dotnet run blabla:Test=arg_value
    //    in env : set blabla__Test=env_value
    //    in appsettings.json : "blabla":{"Test": "app_value"}        

    public string Test { get; set; } = "DEFAULT_TEST_VALUE";
    public string? Sample { get; set; } = null;
}

internal static class AppSettingsExt
{
    public static IServiceCollection AddAppSettingsService
        (this IServiceCollection services
        , IConfiguration config
        , out AppSettings settings)
    {
        var configSection = config.GetSection(AppSettings.SECTION_NAME);
        services.Configure<AppSettings>(configSection);
        settings = configSection.Get<AppSettings>()
            ?? new AppSettings(); // with default values

        services.AddSingleton(settings);
        return services;
    }

    public static IServiceCollection AddAppSettingsService
        (this IServiceCollection services
        , IConfiguration config)
    {
        return services.AddAppSettingsService(config, out var _);
    }
}