using System;
using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopNotification
{
    public enum ColorThemeType
    {
        White,
        Black,
        Gray,
        Blue
    }

    public enum WindowPositionType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    [DisplayName("Show Message")]
    [Designer(typeof(ShowMessageDesigner))]
    public class ShowMessage : CodeActivity
    {

        [Category("Input")]
        [DisplayName("Title")]
        public InArgument<String> Title { get; set; }

        [Category("Input")]
        [DisplayName("Message")]
        public InArgument<String> Message { get; set; }

        [Category("Design")]
        [DisplayName("FontSize")]
        public int FontSize { get; set; } = DEFAULT_FONT_SIZE;

        [Category("Design")]
        [DisplayName("ColorTheme")]
        public ColorThemeType ColorTheme { get; set; } = ColorThemeType.Blue;

        [Category("Design")]
        [DisplayName("WindowPosition")]
        public WindowPositionType WindowPosition { get; set; } = WindowPositionType.BottomRight;


        private static string FORM_NAME = "UiPath-DesktopNotification";
        private static string FIXED_FONT_SET = "Meiryo UI";
        private static int DEFAULT_FONT_SIZE = 12;
        protected Form form_;
        protected Color formBackColor_;
        protected Color formForeColor_;
        protected Color pBarBackColor_;
        protected Brush pBarForeColor_;

        protected override void Execute(CodeActivityContext context)
        {
            ConstructForm();
            UpdateForm(
                Title.Get(context), 
                Message.Get(context), 
                0, 
                false);
        }

        protected void UpdateForm(string title, string message, int progress, bool showProgress)
        {
            var panel = (Panel)form_.Controls["Panel"];
            var labelTitle = (Label)panel.Controls["Title"];
            var labelMsg = (Label)panel.Controls["Message"];
            var labelDate = (Label)panel.Controls["Datetime"];
            var labelPrg = (Label)panel.Controls["ProgressLabel"];
            var pboxPbar = (PictureBox)panel.Controls["ProgressBar"];
            labelTitle.Text = title;
            labelMsg.Text = message;
            labelDate.Text = DateTime.Now.ToString("HH:mm:ss");
            labelPrg.Text = progress + "%";
            labelPrg.Visible = showProgress;
            pboxPbar.BackColor = pBarBackColor_;
            pboxPbar.Visible = showProgress;
            var canvas = new Bitmap(pboxPbar.Width, pboxPbar.Height);
            var grp = Graphics.FromImage(canvas);
            pboxPbar.Image = canvas;
            if (showProgress)
            {
                grp.FillRectangle(pBarForeColor_, 0, 0,
                    Convert.ToInt32(pboxPbar.Width * progress / 100), pboxPbar.Height);
            }
            form_.Update();
        }

        protected void ConstructForm()
        {

            switch (ColorTheme)
            {
                case ColorThemeType.White:
                    formBackColor_ = Color.White;
                    formForeColor_ = Color.Black;
                    pBarBackColor_ = Color.Gray;
                    pBarForeColor_ = Brushes.Black;
                    break;
                case ColorThemeType.Black:
                    formBackColor_ = Color.FromArgb(45, 45, 45);
                    formForeColor_ = Color.White;
                    pBarBackColor_ = Color.Gray;
                    pBarForeColor_ = Brushes.White;
                    break;
                case ColorThemeType.Gray:
                    formBackColor_ = Color.FromArgb(179, 179, 179);
                    formBackColor_ = Color.Gray;
                    formForeColor_ = Color.White;
                    pBarBackColor_ = Color.SlateGray;
                    pBarForeColor_ = Brushes.White;
                    break;
                case ColorThemeType.Blue:
                    formBackColor_ = Color.FromArgb(25, 118, 210);
                    formForeColor_ = Color.White;
                    pBarBackColor_ = Color.Gray;
                    pBarForeColor_ = Brushes.White;
                    break;
                default:
                    formBackColor_ = Color.White;
                    formForeColor_ = Color.Black;
                    pBarBackColor_ = Color.Gray;
                    pBarForeColor_ = Brushes.Black;
                    break;
            }

            form_ = null;
            if (Application.OpenForms.Count > 0)
            {
                for (var idx = 0; idx < Application.OpenForms.Count; idx++)
                {
                    if (Application.OpenForms[idx].Name.Equals(FORM_NAME))
                    {
                        form_ = Application.OpenForms[idx];
                        break;
                    }
                }
            }

            if (form_ == null)
            {
                form_ = new Form
                {
                    Name = FORM_NAME,
                    StartPosition = FormStartPosition.Manual,
                    Width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.22),
                    Height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.12),
                    FormBorderStyle = FormBorderStyle.None,
                    Font = new Font(FIXED_FONT_SET, FontSize, FontStyle.Regular),
                    Opacity = 1.0
                };
                form_.Padding = new Padding(Convert.ToInt32(form_.Height * 0.1));
                form_.Show();
            }

            form_.BackColor = formBackColor_;
            form_.ForeColor = formForeColor_;

            switch (WindowPosition)
            {
                case WindowPositionType.TopLeft:
                    form_.Left = Convert.ToInt32(form_.Height * 0.1);
                    form_.Top = Convert.ToInt32(form_.Height * 0.1);
                    break;
                case WindowPositionType.TopRight:
                    form_.Left = Screen.PrimaryScreen.WorkingArea.Width - form_.Width - Convert.ToInt32(form_.Height * 0.1);
                    form_.Top = Convert.ToInt32(form_.Height * 0.1);
                    break;
                case WindowPositionType.BottomLeft:
                    form_.Left = Convert.ToInt32(form_.Height * 0.1);
                    form_.Top = Screen.PrimaryScreen.WorkingArea.Height - form_.Height - Convert.ToInt32(form_.Height * 0.1);
                    break;
                case WindowPositionType.BottomRight:
                    form_.Left = Screen.PrimaryScreen.WorkingArea.Width - form_.Width - Convert.ToInt32(form_.Height * 0.1);
                    form_.Top = Screen.PrimaryScreen.WorkingArea.Height - form_.Height - Convert.ToInt32(form_.Height * 0.1);
                    break;
                default:
                    form_.Left = Screen.PrimaryScreen.WorkingArea.Width - form_.Width - Convert.ToInt32(form_.Height * 0.1);
                    form_.Top = Screen.PrimaryScreen.WorkingArea.Height - form_.Height - Convert.ToInt32(form_.Height * 0.1);
                    break;
            }
            form_.TopMost = true;
            form_.TopMost = false;

            var panel = (Panel)form_.Controls["Panel"];
            if (panel == null)
            {
                panel = new Panel()
                {
                    Name = "Panel",
                    Width = Convert.ToInt32(form_.Width - form_.Padding.Left - form_.Padding.Right),
                    Height = Convert.ToInt32(form_.Height - form_.Padding.Top - form_.Padding.Bottom),
                    Location = new Point(form_.Padding.Right, form_.Padding.Bottom)
                };
                form_.Controls.Add(panel);
            }

            var labelTitle = (Label)panel.Controls["Title"];
            if (labelTitle == null)
            {
                labelTitle = new Label
                {
                    Name = "Title",
                    Size = new Size(Convert.ToInt32(panel.Width * 0.92), Convert.ToInt32(panel.Height * 0.22)),
                    Location = new Point(0, 0),
                    Font = new Font(form_.Font.FontFamily, form_.Font.Size, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                panel.Controls.Add(labelTitle);
            }

            var labelMsg = (Label)panel.Controls["Message"];
            if (labelMsg == null)
            {
                labelMsg = new Label()
                {
                    Name = "Message",
                    Size = new Size(panel.Width, Convert.ToInt32(panel.Height * 0.57)),
                    Location = new Point(labelTitle.Left, labelTitle.Bottom),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(0, 0, 0, 0)
                };
                panel.Controls.Add(labelMsg);
            }

            var labelDate = (Label)panel.Controls["Datetime"];
            if (labelDate == null)
            {
                labelDate = new Label()
                {
                    Name = "Datetime",
                    Size = new Size(Convert.ToInt32(panel.Width * 0.20), panel.Height - labelTitle.Height - labelMsg.Height),
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font(form_.Font.FontFamily, form_.Font.Size - 2, FontStyle.Regular),
                    Padding = new Padding(0, 0, 0, 0)
                };
                labelDate.Location = new Point(labelMsg.Right - labelDate.Width, labelMsg.Bottom);
                panel.Controls.Add(labelDate);
            }

            var labelPrg = (Label)panel.Controls["ProgressLabel"];
            if (labelPrg == null)
            {
                labelPrg = new Label()
                {
                    Name = "ProgressLabel",
                    Size = new Size(Convert.ToInt32(panel.Width * 0.15), labelDate.Height),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font(form_.Font.FontFamily, form_.Font.Size - 2, FontStyle.Regular),
                    Padding = new Padding(0, 0, 0, 0)
                };
                labelPrg.Location = new Point(labelDate.Left - labelPrg.Width, labelDate.Top);
                panel.Controls.Add(labelPrg);
            }

            var pboxPbar = (PictureBox)panel.Controls["ProgressBar"];
            if (pboxPbar == null)
            {
                pboxPbar = new PictureBox()
                {
                    Name = "ProgressBar",
                    Location = new Point(labelMsg.Left, labelMsg.Bottom + Convert.ToInt32(labelDate.Height * 0.3)),
                    Size = new Size(Convert.ToInt32(panel.Width * 0.65), Convert.ToInt32(labelDate.Height * 0.5)),
                    BorderStyle = BorderStyle.FixedSingle,
                };
                panel.Controls.Add(pboxPbar);
            }
        }
    }
}