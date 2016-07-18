using Nancy;

namespace NancyFx.Microservice.Modules
{
    public class EchoModule : NancyModule
    {
        public EchoModule()
        {
            Get["/echo"] = _ => GetEcho();
            Get[@"/echo/{Text}"] = parameters => GetEchoWithParameter(parameters.Text);
        }

        public string GetEchoWithParameter(string text)
        {
            return $"{text}";
        }

        public string GetEcho()
        {
            return "EchoResponse";
        }
    }
}