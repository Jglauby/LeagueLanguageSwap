using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private OpenFileDialog openFileDialog;
        private Label selectedPathLabel;

        private string LeagueLauncherPath = "C:\\Riot Games\\League of Legends\\LeagueClient.exe";
        private string LeagueClientSettings = "C:\\Riot Games\\League of Legends\\Config\\LeagueClientSettings.yaml";

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
            this.Text = "League Language Swap";
            this.Size = new Size(500, 470);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            TableLayoutPanel formTable = new TableLayoutPanel();
            formTable.Dock = DockStyle.Fill;
            formTable.Padding = new Padding(5);
            formTable.AutoSize = true;
            formTable.ColumnCount = 1;
            formTable.RowCount = 2;

            Label instructionLabel = new Label();
            instructionLabel.Text = "Ensure you are logged out of league and your client is closed. \nThen proceed to click the language you want to switch the game to!";
            instructionLabel.Size = new Size(this.Width, 25);

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

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.None;
            buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            buttonPanel.AutoSize = true;
            buttonPanel.Width = ClientSize.Width;
            buttonPanel.Location = new Point((ClientSize.Width - buttonPanel.Width) / 2, buttonPanel.Location.Y);

            openFileDialog= new OpenFileDialog();
            openFileDialog.InitialDirectory = LeagueLauncherPath;
            openFileDialog.Filter = "Exe files (*.exe)|*.exe";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            selectedPathLabel = new Label();
            selectedPathLabel.Text = LeagueLauncherPath;
            selectedPathLabel.Width = this.Width;

            Button selectPathButton = new Button();
            selectPathButton.Text = "Select League LeagueClient.exe";
            selectPathButton.Click += new EventHandler(SelectPathButton_Click);
            selectPathButton.Size = new Size(this.Width-30, 50);

            Label moreInfoLabel = new Label();
            moreInfoLabel.Text = "If you don't launch the client direclty the language won't change. \n Create a shortcut to the launcher directly";
            moreInfoLabel.Size = new Size(this.Width, 25);

            Button createShortcutButton = new Button();
            createShortcutButton.Text = "Create Shortcut";
            createShortcutButton.Size = new Size(this.Width - 30, 50);
            createShortcutButton.Click += new EventHandler(CreateShortcut_Click);

            this.SuspendLayout();

            foreach (Button button in buttons)
            {
                buttonPanel.Controls.Add(button);
            }

            formTable.Controls.Add(instructionLabel, 0, 0);
            formTable.Controls.Add(buttonPanel, 0, 1);
            formTable.Controls.Add(selectedPathLabel, 0, 2);
            formTable.Controls.Add(selectPathButton, 0, 3);
            formTable.Controls.Add(moreInfoLabel, 0, 4);
            formTable.Controls.Add(createShortcutButton, 0, 5);

            this.Controls.Add(formTable);
            this.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // handle button click event
        }

        private void CreateShortcut_Click(object sender, EventArgs e)
        {
            //create a shortcut to desktop
        }

        private void SelectPathButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                selectedPathLabel.Text = filePath;

                LeagueClientSettings = $"{Path.GetDirectoryName(filePath)}\\Config\\LeagueClientSettings.yaml";
                // Do something with the file path
            }
        }
    }
}
#endregion