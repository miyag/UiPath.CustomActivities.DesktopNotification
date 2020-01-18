using System.Activities;
using System.ComponentModel;

namespace DesktopNotification
{
    [DisplayName("Show Progress Bar")]
    [Designer(typeof(ShowProgressBarDesigner))]
    public class ShowProgressBar : ShowMessage
    {
        [Category("Input")]
        [DisplayName("ProgressPercentage(0-100)")]
        [Description("0-100")]
        public InArgument<int> ProgressPercentage { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            ConstructForm();
            UpdateForm(
                Title.Get(context), 
                Message.Get(context), 
                ProgressPercentage.Get(context), 
                true);
        }
    }
}