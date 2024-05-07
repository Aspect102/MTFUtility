using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using ListBox = System.Windows.Controls.ListBox;
using MessageBox = System.Windows.MessageBox;
using AutoHotkey.Interop;
using RadioButton = System.Windows.Controls.RadioButton;
using Clipboard = System.Windows.Clipboard;
using Velopack;
using Velopack.Sources;
using Microsoft.Extensions.Logging;

namespace MTFUtility
{
    class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            => Console.WriteLine(formatter(state, exception));
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const string briefPath = "MTFUtility.SCPBriefs.";

        public static RadioButton? selectedRadioButton;

        private AutoHotkeyEngine ahk = AutoHotkeyEngine.Instance;

        UpdateManager mgr = new UpdateManager(new GithubSource("https://github.com/Aspect102/MTFUtility", null, false), logger: new ConsoleLogger());

        UpdateInfo NewVersion;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (mgr.IsInstalled) txtbox_CurrentVersion.Text = mgr.CurrentVersion.ToString() ?? "0.0.0";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedRadioButton = sender as RadioButton;
        }
        private void PasteIntoRoblox(double delay, ListBox testSubjects, ListBox civil, ListBox security)
        {
            Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");

            if (processes.Length > 0)
            {
                IntPtr mainWindowHandle = processes[0].MainWindowHandle;
                SetForegroundWindow(mainWindowHandle);

                if (selectedRadioButton == null) { MessageBox.Show("ArgumentNullException: Please ensure you select a brief option using the radio buttons."); return; }

                switch (selectedRadioButton.Name)
                {
                    case ("radio_testsubjects"):
                        for (int i = 0; i < testSubjects.Items.Count; i++)
                        {
                            Thread.Sleep((int)(delay * 1000) / 3);
                            SendKeys.SendWait("/");
                            Thread.Sleep((int)(delay * 1000) / 3);
                            if (chkbox_paste.IsChecked == true)
                            {
                                Clipboard.SetDataObject(testSubjects.Items[i].ToString());
                                SendKeys.SendWait("^(V)");
                            }
                            else SendKeys.SendWait(testSubjects.Items[i].ToString());
                            Thread.Sleep((int)(delay * 1000) / 3);
                            ahk.ExecRaw("Send, {enter}");
                        }
                        break;
                    case ("radio_civil"):
                        for (int i = 0; i < civil.Items.Count; i++)
                        {
                            Thread.Sleep((int)(delay * 1000) / 3);
                            SendKeys.SendWait("/");
                            Thread.Sleep((int)(delay * 1000) / 3);
                            if (chkbox_paste.IsChecked == true)
                            {
                                Clipboard.SetDataObject(civil.Items[i].ToString());
                                SendKeys.SendWait("^(V)");
                            }
                            else SendKeys.SendWait(civil.Items[i].ToString());
                            Thread.Sleep((int)(delay * 1000) / 3);
                            ahk.ExecRaw("Send, {enter}");
                        }
                        break;
                    case ("radio_security"):
                        for (int i = 0; i < security.Items.Count; i++)
                        {
                            Thread.Sleep((int)(delay * 1000) / 3);
                            SendKeys.SendWait("/");
                            Thread.Sleep((int)(delay * 1000) / 3);
                            if (chkbox_paste.IsChecked == true)
                            {
                                Clipboard.SetDataObject(security.Items[i].ToString());
                                SendKeys.SendWait("^(V)");
                            }
                            else SendKeys.SendWait(security.Items[i].ToString());
                            Thread.Sleep((int)(delay * 1000) / 3);
                            ahk.ExecRaw("Send, {enter}");
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("ROBLOX not detected. Please ensure roblox is running before attempting to paste, or contact discord: Invariem");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)combox_scpselector.SelectedItem;
            string selectedName = selectedItem.Name;
            PopulateFields(selectedName);
        }

        // populates fields wow
        private void PopulateFields(string selectedName)
        {
            try
            {
                listbox_testsubjects.Items.Clear();
                listbox_civil.Items.Clear();
                listbox_security.Items.Clear();
                using StreamReader sr = new(Assembly.GetExecutingAssembly().GetManifestResourceStream(briefPath + selectedName + ".txt"));
                string textContent = sr.ReadToEnd();
                string[] splitter = textContent.Split("\r\n", StringSplitOptions.None);

                int i = 0;
                foreach (string line in splitter)
                {
                    if (line == "")
                    {
                        i++;
                        continue;
                    }

                    switch (i)
                    {
                        case (0):
                            listbox_testsubjects.Items.Add(line);
                            break;

                        case (1):
                            listbox_civil.Items.Add(line);
                            break;

                        case (2):
                            listbox_security.Items.Add(line);
                            break;

                        case (> 2):
                            MessageBox.Show("Line overflow in text file, ths should be impossible. Contact Invariem with details.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                switch (ex.GetType().Name)
                {
                    case nameof(ArgumentNullException):
                        MessageBox.Show("ArgumentNullException: Brief file was not found.");
                        break;
                    default:
                        MessageBox.Show("UnknownError: Application fault with population of brief listboxes. No further information.");
                        break;
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PasteIntoRoblox(slider_delay.Value, listbox_testsubjects, listbox_civil, listbox_security);
        }

        private async void btn_CheckForUpdate_Click(object sender, RoutedEventArgs e)
        {
            // check for new version
            var newVersion = await mgr.CheckForUpdatesAsync();
            if (newVersion == null) { btn_Update.IsEnabled = false; return; }
            else btn_Update.IsEnabled = true;

            NewVersion = newVersion;
        }

        private async void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            // download new version
            await mgr.DownloadUpdatesAsync(NewVersion);

            // apply new updates
            mgr.ApplyUpdatesAndRestart(NewVersion);

            MessageBox.Show("Updates successfully");
        }
    }
}