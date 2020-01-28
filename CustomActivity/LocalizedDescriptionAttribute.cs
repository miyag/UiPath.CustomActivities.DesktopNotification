using DesktopNotification.Properties;
using System;
using System.ComponentModel;

namespace DesktopNotification
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        public override string Description => Resources.ResourceManager.GetString(base.DescriptionValue) ?? base.Description;

        public LocalizedDescriptionAttribute(string displayName)
            : base(displayName)
        {
        }
    }

}