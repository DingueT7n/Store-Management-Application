using Microsoft.Extensions.DependencyInjection;

namespace Store.ApplicationUI.Code.System
{
    public class ControlManager
    {
        private readonly IServiceProvider _provider;
        private readonly Dictionary<Type, UserControl> _cache = new();
        private readonly Dictionary<Type, Form> _cacheF = new();
        private readonly Dictionary<Type, DevExpress.XtraReports.UI.XtraReport> _cacheR = new();

        public ControlManager(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Get<T>() where T : UserControl
        {
            if (!_cache.TryGetValue(typeof(T), out var ctrl))
            {
                ctrl = _provider.GetRequiredService<T>();
                _cache[typeof(T)] = ctrl;
                return (T)ctrl;

            }
            else
            {
                var method = ctrl.GetType().GetMethod("LoadData", Type.EmptyTypes);
                if (method != null)
                {
                    method.Invoke(ctrl, null); // Call LoadData()
                }
                return (T)ctrl;

            }

        }
        public T GetR<T>() where T : DevExpress.XtraReports.UI.XtraReport
        {
            if (!_cacheR.TryGetValue(typeof(T), out var ctrl))
            {
                ctrl = _provider.GetRequiredService<T>();
                _cacheR[typeof(T)] = ctrl;
                return (T)ctrl;

            }
            else
            {

                return (T)ctrl;

            }

        }

        public T GetF<T>() where T : Form
        {
            var ctrl = _provider.GetRequiredService<T>();
            return ctrl;
        }
        public T Getff<T>() where T : Form
        {
            if (_cacheF.TryGetValue(typeof(T), out var ctrl))
            {
                if (ctrl.IsDisposed)
                {
                    _cacheF.Remove(typeof(T));
                    ctrl = _provider.GetRequiredService<T>();
                    ctrl.FormClosed += (s, e) => _cacheF.Remove(typeof(T));
                    _cacheF[typeof(T)] = ctrl;
                }
            }
            else
            {
                ctrl = _provider.GetRequiredService<T>();
                ctrl.FormClosed += (s, e) => _cacheF.Remove(typeof(T));
                _cacheF[typeof(T)] = ctrl;
            }

            return (T)ctrl;
        }
        public void RemoveForm<T>() where T : Form
        {
            _cacheF.Remove(typeof(T));
        }
        public bool IsCreated<T>() where T : UserControl
        {
            return _cache.ContainsKey(typeof(T));
        }
        public bool IsCreatedF<T>() where T : Form
        {
            return _cacheF.ContainsKey(typeof(T));
        }
        public bool TryGet<T>(out T? control) where T : UserControl
        {
            if (_cache.TryGetValue(typeof(T), out var ctrl))
            {
                control = (T)ctrl;
                return true;
            }
            control = null;
            return false;
        }
        public bool TryGetF<T>(out T? control) where T : Form
        {
            if (_cacheF.TryGetValue(typeof(T), out var ctrl))
            {
                control = (T)ctrl;
                return true;
            }
            control = null;
            return false;
        }
        public T Create<T>() where T : UserControl
        {
            // This creates a fresh instance from the DI container
            return _provider.GetRequiredService<T>();
        }
        public T CreateF<T>() where T : Form
        {
            // This creates a fresh instance from the DI container
            return _provider.GetRequiredService<T>();
        }
    }
}
