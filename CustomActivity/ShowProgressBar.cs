using System.Activities;
using System.ComponentModel;

namespace DesktopNotification
{
    [LocalizedDisplayName(nameof(Properties.Resources.ShowProgressBarDisplayName))]
    [Designer(typeof(ShowProgressBarDesigner))]
    public class ShowProgressBar : ShowMessage
    {
        [LocalizedCategory(nameof(Properties.Resources.InputCategory))]
        [LocalizedDisplayName(nameof(Properties.Resources.ProgressPercentageDisplayName))]
        [LocalizedDescription(nameof(Properties.Resources.ProgressPercentageDescription))]
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