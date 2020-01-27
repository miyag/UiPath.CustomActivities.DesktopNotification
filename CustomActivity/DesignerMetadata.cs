using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Threading;
using System.Activities.Presentation.Metadata;
using DesktopNotification.Properties;

namespace DesktopNotification
{
    class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            addCustomAttributes_PathUtils_categories(builder);
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        private void addCustomAttributes_PathUtils_categories(AttributeTableBuilder builder)
        {
            // 1.Activitiesペイン上のツリー構造を構築する。
            {
                builder.AddCustomAttributes(typeof(ShowMessage), new CategoryAttribute("デスクトップ通知"));
            }

            // 3.Activitiesペイン上のアクティビティをポイントしたときに表示されるツールチップ文言
            {
                builder.AddCustomAttributes(typeof(ShowMessage), new DescriptionAttribute("ツールチップに説明文を書こう"));
            }
        }
    }
}
