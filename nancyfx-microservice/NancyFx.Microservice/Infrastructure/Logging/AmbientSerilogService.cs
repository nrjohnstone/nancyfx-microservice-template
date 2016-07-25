using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace NancyFx.Microservice.Infrastructure.Logging
{

    public class AmbientSerilogService : AmbientService<ILogger>, ILogger
    {
        protected override ILogger DefaultCreate()
        {
            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.AppSettings()
                  .Enrich.With(new ApplicationDetailsEnricher())
                  .CreateLogger();

            return Log.Logger;
        }

        public ILogger ForContext(ILogEventEnricher enricher)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(IEnumerable<ILogEventEnricher> enrichers)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(string propertyName, object value, bool destructureObjects = false)
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext<TSource>()
        {
            throw new NotImplementedException();
        }

        public ILogger ForContext(Type source)
        {
            throw new NotImplementedException();
        }

        public void Write(LogEvent logEvent)
            => Instance.Write(logEvent);

        public void Write(LogEventLevel level, string messageTemplate)
            => Instance.Write(level, messageTemplate);

        public void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue)
            => Instance.Write<T>(level, messageTemplate, propertyValue);

        public void Write<T0, T1>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1, T2>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Write(LogEventLevel level, string messageTemplate, params object[] propertyValues)
            => Instance.Write(level, messageTemplate, propertyValues);

        public void Write(LogEventLevel level, Exception exception, string messageTemplate)
            => Instance.Write(level, exception, messageTemplate);

        public void Write<T>(LogEventLevel level, Exception exception, string messageTemplate, T propertyValue)
            => Instance.Write<T>(level, exception, messageTemplate, propertyValue);

        public void Write<T0, T1>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Write<T0, T1, T2>(LogEventLevel level, Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Write(LogEventLevel level, Exception exception, string messageTemplate,
            params object[] propertyValues)
            => Instance.Write(level, exception, messageTemplate, propertyValues);

        public bool IsEnabled(LogEventLevel level)
        {
            throw new NotImplementedException();
        }

        public void Verbose(string messageTemplate)
            => Instance.Verbose(messageTemplate);

        public void Verbose<T>(string messageTemplate, T propertyValue)
            => Instance.Verbose<T>(messageTemplate, propertyValue);

        public void Verbose<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Verbose(string messageTemplate, params object[] propertyValues)
            => Instance.Verbose(messageTemplate, propertyValues);

        public void Verbose(Exception exception, string messageTemplate)
            => Instance.Verbose(exception, messageTemplate);

        public void Verbose<T>(Exception exception, string messageTemplate, T propertyValue)
            => Instance.Verbose<T>(exception, messageTemplate, propertyValue);

        public void Verbose<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Verbose<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
            => Instance.Verbose(exception, messageTemplate, propertyValues);

        public void Debug(string messageTemplate)
            => Instance.Debug(messageTemplate);

        public void Debug<T>(string messageTemplate, T propertyValue)
            => Instance.Debug<T>(messageTemplate, propertyValue);

        public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Debug(Exception exception, string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Debug<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Debug<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Information(string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Information<T>(string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Information(Exception exception, string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Information<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Information<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Warning(string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Warning<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Error(string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Error<T>(string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Error<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Error<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T>(string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string messageTemplate)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            throw new NotImplementedException();
        }

        public void Fatal<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            throw new NotImplementedException();
        }

        public bool BindMessageTemplate(string messageTemplate, object[] propertyValues, out MessageTemplate parsedTemplate,
            out IEnumerable<LogEventProperty> boundProperties)
        {
            throw new NotImplementedException();
        }

        public bool BindProperty(string propertyName, object value, bool destructureObjects, out LogEventProperty property)
        {
            throw new NotImplementedException();
        }
    }
}