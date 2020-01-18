using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopNotification
{
    public abstract class BaseShowWindow : CodeActivity
    {



        protected abstract void UpdateForm(CodeActivityContext context);
    }
}