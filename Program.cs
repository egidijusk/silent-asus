using Silent_ASUS.Properties;
using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Silent_ASUS
{
    internal static class Program
    {

        private static readonly string appGuid = "a8675f7c-5928-4435-a236-b5e5204f74e6";

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyCustomApplicationContext());
            }

        }

    }

    public class MyCustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public MyCustomApplicationContext()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            LoopSound();
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void LoopSound()
        {
            byte[] bytes = Convert.FromBase64String(soundB64);
            Stream stream = new MemoryStream(bytes);

            SoundPlayer player = new SoundPlayer(stream);
            player.PlayLooping();
        }

        // 10 milliseconds of silence in WAV format (encoded in base64)
        private const String soundB64 = "UklGRpYDAABXQVZFZm10IBAAAAABAAEARKwAAIhYAQACABAAZGF0YXIDAAAAAAAA//8CAP7/AQAAAAAAAAAAAP//AgD+/wIA/v8BAAAAAAAAAAAA//8CAP7/AgD+/wIA/v8DAPz/BAD9/wIA/v8CAP7/AwD8/wMA/v8BAAAAAAD//wIA/v8BAAAA//8CAP7/AQD//wIA/v8CAP3/AgAAAAAAAAAAAP//AgD9/wQA/P8DAP////8CAP7/AgD+/wIA/v8CAP//AAAAAAAAAQD+/wMA/P8EAP3/AgD+/wIA/v8CAP7/AQAAAP//AQD//wEAAAD//wEA/v8EAPv/BgD6/wQA/v8BAAAAAAAAAP//AQD//wEAAAD//wEA//8BAP//AQD+/wMA/f8CAAAA/v8DAP3/AwD9/wMA/f8DAP///v8EAPz/AwD+/wEA//8DAPz/BAD8/wMA/v8CAP7/AgD+/wEAAQD9/wMA/////wMA/P8DAP//AAAAAAAA//8DAPz/BAD8/wMA//8AAAEA/v8DAP3/AgD//wEA//8BAP//AAABAP//AQD//wEA//8BAP//AQD//wEA//8BAP//AQD+/wMA/f8DAP3/AgD//wEA//8AAAEA//8BAP//AAAAAAEA//8BAP7/AgD//wAAAQD+/wIA//8AAAAAAQD//wEA/v8DAP3/AwD9/wIAAAD+/wMA/f8DAP7/AAABAAAA//8CAP3/AwD/////AgD9/wMA/////wMA+/8FAP3/AQAAAAAAAAAAAAAA//8CAP////8CAP3/AwD/////AgD+/wEAAAD//wIA/v8CAP7/AQAAAP//AgD+/wIA/f8EAPz/BAD8/wMA/v8BAAEA/f8EAPv/BQD8/wMA/f8DAP3/AgAAAP7/AwD9/wIA//8AAAEA//8AAAEA//8AAAIA/f8DAP7/AAACAP3/AwD+/wEA//8BAP7/AwD+/wAAAgD8/wQA/v8BAP//AQD//wIA/v8BAAAA//8CAP////8DAPv/BQD9/wIA/v8CAP7/AQABAP7/AgD/////AgD+/wIA//8AAAAAAAAAAAEA/v8CAP7/AgD//wAAAAD//wMA/f8DAPz/AwD//wEA//8BAP3/BAD9/wMA/v8AAAEA/v8EAPz/AwD+/wEAAAD//wIA/f8EAPz/AgAAAP//AQAAAP7/AwD+/wEAAAD+/wMA/v8BAAAA//8BAP//AQAAAP//AgD9/wIAAAA=";

    }

}
