using Nancy;

namespace NancyFx.Microservice.Modules
{
    public class EchoModule : NancyModule
    {
        public EchoModule()
        {
            Get["/echo"] = _ => GetEcho();
        }

        public string GetEcho()
        {
            return "EchoResponse";
        }
    }
}