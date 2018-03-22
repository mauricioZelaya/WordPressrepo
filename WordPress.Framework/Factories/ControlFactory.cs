using System;

namespace WordPress.Framework.Factories
{
    public static class ControlFactory
    {
        public static T GetControl<T>(object locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { locator, value, controlName });
        }
        
        public static T GetControl<T>(object container, object locator, string value, string controlName)
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { container, locator, value, controlName });
        }
        
    }
}
