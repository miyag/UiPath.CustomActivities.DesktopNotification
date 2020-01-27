using DesktopNotification.Properties;
using System;
using System.ComponentModel;

namespace DesktopNotification
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public override string DisplayName => Resources.ResourceManager.GetString(base.DisplayNameValue) ?? base.DisplayName;

        public LocalizedDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }
    }
}