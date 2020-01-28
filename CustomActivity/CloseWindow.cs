using System.Activities;
using System.Windows.Forms;

namespace DesktopNotification
{
    [LocalizedCategory("CloseWindowCategory")]
    [LocalizedDisplayName("CloseWindowDisplayName")]
    [LocalizedDescription("CloseWindowDescription")]
    public class CloseWindow : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            if (Application.OpenForms.Count > 0)
            {
                for (var idx = 0; idx < Application.OpenForms.Count; idx++)
                {
                    if (Application.OpenForms[idx].Name.Equals(Properties.Resources.FormName))
                    {
                        var form = Application.OpenForms[idx];
                        form.Close();
                        form.Dispose();
                        break;
                    }
                }
            }
        }
    }
}