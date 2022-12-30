using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using static System.Net.Mime.MediaTypeNames;

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
        private string LeagueClientSettingsPath = "C:\\Riot Games\\League of Legends\\Config\\LeagueClientSettings.yaml";

        private string[] LanguageCodes = new string[]
        {
            "ja_JP",
            "ko_KR",
            "zh_CN",
            "zh_TW",
            "es_ES",
            "es_MX",
            "en_US",
            "en_GB",
            "en_AU",
            "fr_FR",
            "de_DE",
            "it_IT",
            "pl_PL",
            "ro_RO",
            "el_GR",
            "pt_BR",
            "hu_HU",
            "ru_RU",
            "tr_TR"
        };

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
            this.Size = new Size(500, 390);
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
            buttons.Add(new Button { Text = "Korean", Enabled = false });
            buttons.Add(new Button { Text = "Chinese", Enabled = false });
            buttons.Add(new Button { Text = "Taiwanese" , Enabled = false });
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

            this.SuspendLayout();

            foreach (Button button in buttons)
            {
                buttonPanel.Controls.Add(button);
            }

            formTable.Controls.Add(instructionLabel, 0, 0);
            formTable.Controls.Add(buttonPanel, 0, 1);
            formTable.Controls.Add(selectedPathLabel, 0, 2);
            formTable.Controls.Add(selectPathButton, 0, 3);

            this.Controls.Add(formTable);
            this.ResumeLayout(false);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;

                // Open the file
                StreamReader reader = new StreamReader(LeagueClientSettingsPath);

                // Read the contents of the file into a string
                string fileContents = reader.ReadToEnd();

                // replace any existing language code with clicked on code
                foreach (string code in LanguageCodes)
                {
                    fileContents = fileContents.Replace(code, getLanguageCode(button.Text));
                }

                // Close the file
                reader.Close();

                // Open the file for writing
                StreamWriter writer = new StreamWriter(LeagueClientSettingsPath);

                // Write the modified contents to the file
                writer.Write(fileContents);

                // Close the file
                writer.Close();

                DialogResult result = MessageBox.Show("Language Changed, Game Launching!", "Game Launcher", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    DirectOpen();
                }
            }
            catch
            {
                MessageBox.Show("ERROR: Make sure the path is set correctly and League is closed!");
            }
        }

        private void DirectOpen()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = LeagueLauncherPath;
            process.Start();
        }

        private void SelectPathButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                selectedPathLabel.Text = filePath;

                LeagueClientSettingsPath = $"{Path.GetDirectoryName(filePath)}\\Config\\LeagueClientSettings.yaml";
            }
        }

        //given button pressed, return proper code tied to that language
        private string getLanguageCode(string buttonText)
        {
            switch (buttonText)
            {
                case "Japanese":
                    return LanguageCodes[0];
                case "Korean":
                    return LanguageCodes[1];
                case "Chinese":
                    return LanguageCodes[2];
                case "Taiwanese":
                    return LanguageCodes[3];
                case "Spanish (Spain)":
                    return LanguageCodes[4];
                case "Spanish \n (Latin America)":
                    return LanguageCodes[5];
                case "English":
                    return LanguageCodes[6];
                case "English (GB)":
                    return LanguageCodes[7];
                case "English (AU)":
                    return LanguageCodes[8];
                case "French":
                    return LanguageCodes[9];
                case "German":
                    return LanguageCodes[10];
                case "Italian":
                    return LanguageCodes[11];
                case "Polish":
                    return LanguageCodes[12];
                case "Romanian":
                    return LanguageCodes[13];
                case "Greek":
                    return LanguageCodes[14];
                case "Portuguese":
                    return LanguageCodes[15];
                case "Hungarian":
                    return LanguageCodes[16];
                case "Russian":
                    return LanguageCodes[17];
                case "Turkish":
                    return LanguageCodes[18];
            }
            return null;
        }
    }
}
#endregion