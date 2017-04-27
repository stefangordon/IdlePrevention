using IdlePrevention.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdlePrevention
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IdleContext());
        }
    }

    public class IdleContext : ApplicationContext
    {
        private bool enabled;
        private NotifyIcon trayIcon;
        Timer idleTimer;

        public IdleContext()
        {
            // Disable at start
            enabled = false;

            // Configure timer for 50 seconds, as the shortest windows screen idle time is 60 seconds.
            idleTimer = new Timer();
            idleTimer.Interval = 50 * 1000;
            idleTimer.Tick += TimerElapsed;

            // Setup the menu
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Enable Idle Prevention", ToggleIdle),
                new MenuItem("Quit Program", Quit)
            }),
                Visible = true
            };
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            Native.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);
        }

        void ToggleIdle(object sender, EventArgs e)
        {
            MenuItem menu = (MenuItem)sender;

            if (enabled)
            { 
                // Turn off
                menu.Text = "Enable Idle Prevention";
                idleTimer.Stop();
            }
            else
            {
                // Turn on
                menu.Text = "Disable Idle Prevention";
                idleTimer.Start();
            }

            enabled = !enabled;
        }

        void Quit(object sender, EventArgs e)
        {
            // Hide icon before exiting
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
