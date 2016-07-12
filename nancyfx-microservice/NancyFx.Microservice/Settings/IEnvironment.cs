namespace NancyFx.Microservice.Settings
{
    public interface IEnvironment
    {
        string[] GetCommandLineArgs();
    }
}