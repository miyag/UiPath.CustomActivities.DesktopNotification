using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopNotification
{
    [DisplayName("Close")]
    public class CloseWindow : CodeActivity
    {
        private readonly string FORM_NAME = "UiPath-DesktopNotification";

        protected override void Execute(CodeActivityContext context)
        {
            if (Application.OpenForms.Count > 0)
            {
                for (var idx = 0; idx < Application.OpenForms.Count; idx++)
                {
                    if (Application.OpenForms[idx].Name.Equals(FORM_NAME))
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