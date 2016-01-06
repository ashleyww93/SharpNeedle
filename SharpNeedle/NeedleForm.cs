using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpNeedle
{
    public partial class NeedleForm : Form
    {
        public NeedleForm()
        {
            InitializeComponent();
        }


        private void LoadProcesList()
        {
            listProcesses.Items.Clear();

            Process[] procs = Process.GetProcesses();

            foreach (Process proc in procs)
            {
                ListViewItem li = new ListViewItem();
                li.Text = string.Format("{0} - {1}", proc.ProcessName, proc.Id);
                li.Tag = proc;
                listProcesses.Items.Add(li);
            }

            listProcesses.Sorting = SortOrder.Ascending;
            listProcesses.Sort();
        }

        private void btnLoadProcesses_Click(object sender, EventArgs e)
        {
            LoadProcesList();
        }

        private void NeedleForm_Load(object sender, EventArgs e)
        {
            LoadProcesList();
        }

        private void listProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProcesses.SelectedItems.Count != 1)
                return;

            ResetProcessInfo();
            ListViewItem selectedItem = listProcesses.SelectedItems[0];

            Process selectedProcess = (Process) selectedItem.Tag;

            try
            {
                lblModuleBase.Text = selectedProcess.MainModule.BaseAddress.ToString("X");
            }
            catch
            {
                // ignored
            }

            try
            {
                lblThreads.Text = selectedProcess.Threads.Count.ToString();
            }
            catch
            {
                // ignored
            }
        }

        private void ResetProcessInfo()
        {
            lblModuleBase.Text = "N/A";
            lblThreads.Text = "N/A";
        }

        private void btnInjectPayload_Click(object sender, EventArgs e)
        {
            if (listProcesses.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must select one process target", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process targetProcess = (Process) listProcesses.SelectedItems[0].Tag;

            string domainFilePath = Application.StartupPath;//Set the directory containing the dll
            string payloadFilePath = Application.StartupPath;

            PayloadInjector injector = new PayloadInjector(targetProcess, domainFilePath, textboxDomain.Text, payloadFilePath, textboxPayload.Text, textboxArgs.Text);
            injector.InjectAndForget();
        }
    }
}
