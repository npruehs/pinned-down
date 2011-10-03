using System.Windows.Forms;
using PinnedDownCardListEditor.Control;

namespace PinnedDownCardListEditor.View
{
    /// <summary>
    /// The form used for indicating the progress of heavy tasks.
    /// </summary>
    public partial class ProgressForm : Form
    {
        #region Fields
        /// <summary>
        /// The controller to be notified when the user tries to close this
        /// progress form.
        /// </summary>
        private Controller controller;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a new form for indicating the progress of heavy tasks.
        /// </summary>
        /// <param name="controller">
        /// The controller to be notified when the user tries to close the
        /// new progress form.
        /// </param>
        public ProgressForm(Controller controller)
        {
            InitializeComponent();

            this.controller = controller;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates this progress form to show the passed status message
        /// and indicate the specified progress percentage.
        /// </summary>
        /// <param name="statusMessage">
        /// The status message to show.
        /// </param>
        /// <param name="value">
        /// The progress percentage to indicate.
        /// </param>
        public void UpdateProgressForm(string statusMessage, int value)
        {
            labelStatusMessage.Text = statusMessage;
            progressBar.Value = value;
        }

        /// <summary>
        /// Notifies the controller that the user closed this form by clicking
        /// the red cross icon to the top-right of the window. Hides this form
        /// instead of disposing it.
        /// </summary>
        /// <param name="sender">
        /// Ignored.
        /// </param>
        /// <param name="e">
        /// The event args used for preventing the application from disposing
        /// this form.
        /// </param>
        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.HideProgressForm();

            e.Cancel = true;
        }
        #endregion
    }
}
