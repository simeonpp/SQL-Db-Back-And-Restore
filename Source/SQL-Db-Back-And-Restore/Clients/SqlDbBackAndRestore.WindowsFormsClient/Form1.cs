namespace SqlDbBackAndRestore.WindowsFormsClient
{
    using Core;
    using Core.Contracts;
    using Ninject;
    using System;
    using System.Windows.Forms;


    public partial class JobServiceApplication : Form
    {
        private IKernel kernal;
        private ITaskManager taskManager;
        private ISqlTaskFactory sqlTaskFactory;

        public JobServiceApplication()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RegisterMappings();
            this.taskManager = kernal.Get<TaskManager>();
            this.sqlTaskFactory = new SqlTaskFactory();

            this.RestoreFormToInitialState();
        }

        private void RegisterMappings()
        {
            kernal = new StandardKernel();
            kernal.Bind<ITaskManager>().To<TaskManager>().InSingletonScope();
        }

        private void tbDatabaseName_TextChanged(object sender, EventArgs e)
        {
            this.tbDbBackupLocation.Enabled = true;
            this.btnDbBackupBrowse.Enabled = true;

            this.tbBackupPath.Enabled = true;
            this.btnDbRestoreBrowse.Enabled = true;
        }

        private void btnDbBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDbBackupLocation.Text.CompareTo(string.Empty) == 0)
                {
                    MessageBox.Show("Please choose a location.");
                    return;
                }

                ITask backUpDbTask = sqlTaskFactory.GetSqlBackupDbTask(tbConnectionString.Text, tbDbBackupLocation.Text);
                backUpDbTask.Finished += ObservableTaskFinished;
                taskManager.ProcessTask(backUpDbTask);

                MessageBox.Show("Your back up task is processing. You will be notified when you task is finished. While you are waiting you can run another process.");
                this.RestoreFormToInitialState();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreFormToInitialState()
        {
            tbConnectionString.Text = string.Empty;
            tbDbBackupLocation.Text = string.Empty;
            tbBackupPath.Text = string.Empty;

            this.tbDbBackupLocation.Enabled = false;
            this.btnDbBackupBrowse.Enabled = false;
            this.btnDbBackup.Enabled = false;

            this.tbBackupPath.Enabled = false;
            this.btnDbRestoreBrowse.Enabled = false;
            this.btnDbRestore.Enabled = false;
        }

        private static void ObservableTaskFinished(object sender, string message)
        {
            MessageBox.Show(message + "\nThis does not affect your current actions.");
        }

        private void btnDbBackupBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbDbBackupLocation.Text = dialog.SelectedPath;
                this.btnDbBackup.Enabled = true;
            }
        }

        private void btnDbRestoreBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbBackupPath.Text = dialog.FileName;
                this.btnDbRestore.Enabled = true;
            }
        }

        private void btnDbRestore_Click(object sender, EventArgs e)
        {
            ITask restoreDbTask = sqlTaskFactory.GetSqlRestoreDbTask(tbConnectionString.Text, tbBackupPath.Text);
            restoreDbTask.Finished += ObservableTaskFinished;
            taskManager.ProcessTask(restoreDbTask);

            MessageBox.Show("Your restore task is processing. You will be notified when you task is finished. While you are waiting you can run another process.");
            this.RestoreFormToInitialState();
        }
    }
}
