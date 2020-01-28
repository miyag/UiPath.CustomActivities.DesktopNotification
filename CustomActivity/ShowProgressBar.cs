using System.Activities;
using System.ComponentModel;

namespace DesktopNotification
{
    [LocalizedCategory("ShowProgressBarCategory")]
    [LocalizedDisplayName("ShowProgressBarDisplayName")]
    [LocalizedDescription("ShowProgressBarDescription")]
    [Designer(typeof(ShowProgressBarDesigner))]
    public class ShowProgressBar : ShowMessage
    {
        [LocalizedCategory("InputCategory")]
        [LocalizedDisplayName("ProgressPercentageDisplayName")]
        [LocalizedDescription("ProgressPercentageDescription")]
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