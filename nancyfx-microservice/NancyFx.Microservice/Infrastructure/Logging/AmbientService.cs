using System;
using Serilog.Events;

namespace NancyFx.Microservice.Infrastructure.Logging
{
    public abstract class AmbientService<T> where T : class
    {
        public delegate T CreateDelegate();

        private T _instance;

        public static CreateDelegate Create { get; set; }

        protected virtual T DefaultCreate()
        {
            return null;
        }

        public bool InDesignMode { get; set; }

        static AmbientService()
        {
            Create = () => null;
        }

        public T Instance
        {
            get
            {
                if (_instance == null && !InDesignMode)
                {
                    if (Create != null) _instance = Create();
                    if (_instance == null)
                    {
                        _instance = DefaultCreate();
                        if (_instance == null)
                        {
                            NoCreate();
                        }
                    }
                }
                return _instance;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _instance = value;
            }
        }

        private static T NoCreate()
        {
            string message = $"Create not setup for AmbientService<{typeof(T).Name}>";
            throw new Exception(message);
        }

    }
}