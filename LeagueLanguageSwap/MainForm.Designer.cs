using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LeagueLanguageSwap
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private List<Button> buttons = new List<Button>();


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Size = new Size(240, 500);

            buttons.Add(new Button { Text = "Japanese" });
            buttons.Add(new Button { Text = "Korean" });
            buttons.Add(new Button { Text = "Chinese" });
            buttons.Add(new Button { Text = "Taiwanese" });
            buttons.Add(new Button { Text = "Spanish (Spain)" });
            buttons.Add(new Button { Text = "Spanish \n (Latin America)" });
            buttons.Add(new Button { Text = "English" });
            buttons.Add(new Button { Text = "English (GB)" });
            buttons.Add(new Button { Text = "English (AU)" });
            buttons.Add(new Button { Text = "French" });
            buttons.Add(new Button { Text = "German" });
            buttons.Add(new Button { Text = "Italian" });
            buttons.Add(new Button { Text = "Polish" });
            buttons.Add(new Button { Text = "Romanian" });
            buttons.Add(new Button { Text = "Greek" });
            buttons.Add(new Button { Text = "Portuguese" });
            buttons.Add(new Button { Text = "Hungarian" });
            buttons.Add(new Button { Text = "Russian" });
            buttons.Add(new Button { Text = "Turkish" });

            foreach (Button button in buttons)
            {
                button.Size = new Size(100, 40);
                button.Click += new EventHandler(Button_Click);
            }
            this.SuspendLayout();

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.FlowDirection = FlowDirection.TopDown;

            foreach (Button button in buttons)
            {
                panel.Controls.Add(button);
            }

            this.Controls.Add(panel);
            this.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // handle button click event
        }
    }
}
#endregion