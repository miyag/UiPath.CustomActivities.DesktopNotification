using DesktopNotification.Properties;
using System;
using System.ComponentModel;

namespace DesktopNotification
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class LocalizedCategoryAttribute : CategoryAttribute
    {
        public LocalizedCategoryAttribute(string category)
            : base(category)
        {
        }

        protected override string GetLocalizedString(string value)
        {
            return Resources.ResourceManager.GetString(value) ?? base.GetLocalizedString(value);
        }
    }
}