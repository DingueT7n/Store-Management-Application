using System.IO;
using System.Windows.Media;

namespace Store.ApplicationUI.Gui.ToasterGui
{
    public partial class ToastForm : Form
    {
        private static ToastForm? _Form;
        private MediaPlayer _player; // Field to keep MediaPlayer alive

        public ToastForm()
        {
            InitializeComponent();
            _player = new MediaPlayer(); // Initialize MediaPlayer
        }

        public static ToastForm Instance(string title, string description, System.Drawing.Color? color)
        {
            if (_Form == null || _Form.IsDisposed)
            {
                _Form = new ToastForm();
            }
            else
            {
                // Bring the form to the front if it exists.
                if (!_Form.Visible)
                {


                    _Form.PlayNotificationSound();
                    _Form.Show();
                    _Form.timer1.Stop();  // Stop the timer to reset it
                    _Form.timer1.Start();
                    //Thread.Sleep(500);

                }
                _Form.BringToFront();
            }
            if (color is not null)
                _Form.lblDescription.BackColor = _Form.lblTitle.BackColor = (System.Drawing.Color)color;
            else
                _Form.lblDescription.BackColor = _Form.lblTitle.BackColor = System.Drawing.Color.GreenYellow;

            _Form.lblTitle.Text = title;
            _Form.lblDescription.Text = description;
            return _Form;
        }

        private void PlayNotificationSound()
        {
            try
            {
                string soundFilePath = Path.Combine(Application.StartupPath, "successaudio.wav");
                if (!File.Exists(soundFilePath))
                {
                    //MessageBox.Show($"Sound file not found: {soundFilePath}");
                    return;
                }

                _player.Open(new Uri(soundFilePath));
                _player.MediaEnded += (s, e) => _player.Close(); // Cleanup after playback
                _player.Play();
            }
            catch (Exception)
            {
                //MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }

        private void ToastForm_Shown(object sender, EventArgs e)
        {
            PlayNotificationSound();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_Form is not null)
            {
                _Form?.Hide(); // Hide the form when the timer elapses
                timer1.Stop(); // Stop the timer to prevent repeated hiding

            }
        }
    }
}
