using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace SpinNet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int Border = 30;

        int AtomSize = 15;

        int AtomSpace = 5;

        float Zoom = 1.0f;

        double T = 0.12;
        double J = 1;
        //double K = 1.3806503E-23;

        int nAtoms = 20;
        int nSteps = 10;

        int[] MatrixS = null;
        int[] Matrix0 = null;
        int[] MatrixR = null;

        [DllImport("SpinSimCUDA.dll", CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int SpinSimulateGPU(int[] m, int N, int nAtoms, float J, float T, int Steps, int cuBlockSize);        

        bool ShowInitial = false;

        delegate void RenderInvoker(string statusText);

        System.Globalization.CultureInfo Info = new System.Globalization.CultureInfo("en-us");

        private void RenderCall(string statusText)
        {
            Engine.Refresh();
        }

        DateTime T0;       

        private void Run_Click(object sender, EventArgs e)
        {
            nAtoms = (int)AtomsUP.Value;
            nSteps = (int)StepsUP.Value;

            if (nAtoms * nAtoms != MatrixS.Length)
            {
                MatrixReuse.Checked = false;
            }

            T = double.Parse(TempTB.Text.Replace(",", "."), Info);
            J = double.Parse(ChangeTB.Text.Replace(",", "."), Info);

            Run.Enabled = false;
            CancelBT.Enabled = true;

            Zoom = ZoomBar.Value / 100.0f;

            int size = nAtoms * (AtomSize + AtomSpace) + 2 * Border;

            Engine.Width = (int)(size * Zoom);

            Engine.Height = Engine.Width;

            MainContainer_Resize(sender, e);

            Progress.Value = 0;

            T0 = DateTime.Now;

            SimTimer.Enabled = true;

            if (UseGPU.Checked)
            {
                CancelBT.Enabled = false;
                Progress.Style = ProgressBarStyle.Continuous;
                SimulatorGPU.RunWorkerAsync();  
            }
            else
            {
                Simulator.RunWorkerAsync();
            }

            Done = false;
        }

        bool IsOffLine = false;
        bool Done = false;

        public void SetRunAndSave(int Atoms, int Steps, double J, double T, bool UseGPU, String FinalImageFile, String InitialImage, String FinalMatrix, String InitialMatrix)
        {
            nAtoms = Atoms;
            nSteps = Steps;

            MatrixReuse.Checked = false;            

            this.T = T;
            this.J = J;

            Run.Enabled = false;
            CancelBT.Enabled = true;
            IsOffLine = true;

            Zoom = ZoomBar.Value / 100.0f;

            int size = nAtoms * (AtomSize + AtomSpace) + 2 * Border;

            Engine.Width = (int)(size * Zoom);

            Engine.Height = Engine.Width;

            MainContainer_Resize(null, null);

            Progress.Value = 0;

            T0 = DateTime.Now;

            Done = false;

            if (UseGPU)
            {
                CancelBT.Enabled = false;
                Progress.Style = ProgressBarStyle.Continuous;
                SimulatorGPU.RunWorkerAsync();
            }
            else
            {
                Simulator.RunWorkerAsync();
            }

            while (!Done)
            {
                if (UseGPU)
                {
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
                Console.Out.Write(".");
            }


            Console.Out.WriteLine(" [DONE]");
            
            if (!String.IsNullOrEmpty(FinalImageFile))
            {
                Console.Out.WriteLine("Final Image [SAVED]");
                MatrixR = MatrixS;

                Engine.Refresh();

                using (Bitmap bmp = new Bitmap(Engine.Width, Engine.Height))
                {
                    Engine.DrawToBitmap(bmp, new Rectangle(0, 0, Engine.Width, Engine.Height));

                    bmp.Save(FinalImageFile);
                }
            }

            if (!String.IsNullOrEmpty(FinalMatrix))
            {
                Console.Out.WriteLine("Final Matrix [SAVED]");
                MatrixR = MatrixS;
                using (StreamWriter writer = new StreamWriter(FinalMatrix))
                {
                    for (int i = 0; i < nAtoms; i++)
                    {
                        String Line = "";

                        for (int j = 0; j < nAtoms; j++)
                        {
                            int p = i * nAtoms + j;

                            Line += String.Format("{0};", MatrixR[p]);
                        }

                        Line = Line.Remove(Line.Length - 1);

                        writer.WriteLine(Line);
                    }
                }
            }

            if (!String.IsNullOrEmpty(InitialMatrix))
            {
                Console.Out.WriteLine("Initial Matrix [SAVED]");
                MatrixR = Matrix0;
                using (StreamWriter writer = new StreamWriter(InitialMatrix))
                {
                    for (int i = 0; i < nAtoms; i++)
                    {
                        String Line = "";

                        for (int j = 0; j < nAtoms; j++)
                        {
                            int p = i * nAtoms + j;

                            Line += String.Format("{0};", MatrixR[p]);
                        }

                        Line = Line.Remove(Line.Length - 1);

                        writer.WriteLine(Line);
                    }
                }
            }

            if (!String.IsNullOrEmpty(InitialImage))
            {
                Console.Out.WriteLine("Initial Image [SAVED]");
                MatrixR = Matrix0;

                Engine.Refresh();

                using (Bitmap bmp = new Bitmap(Engine.Width, Engine.Height))
                {
                    Engine.DrawToBitmap(bmp, new Rectangle(0, 0, Engine.Width, Engine.Height));

                    bmp.Save(InitialImage);
                }
            }

            MatrixR = MatrixS;
        }

        private void Simulator_DoWork(object sender, DoWorkEventArgs e)
        {
            Done = false;

            int size = nAtoms * nAtoms;                      

            Random Rnd = new Random();

            sbyte [] Values = new sbyte [] { -1, 1 };            

            MatrixR = null;

            if (!MatrixReuse.Checked)
            {
                MatrixS = new int[size];

               // Position = new int[size];

                //// Initialization
                //for (int i = 0; i < size; i++)
                //{
                //    Position[i] = i;
                //}

                // Initialization
                for (int i = 0; i < size; i++)
                {
                    MatrixS[i] = Values[Rnd.Next(2)];
                }

                Matrix0 = MatrixS.Clone() as int[];
            }
            else
            {
                MatrixS = Matrix0.Clone() as int[];
            }

            if (ShowInitial)
            {
                MatrixR = Matrix0;
            }
            else
            {
                MatrixR = MatrixS;
            }

            //for (int l = 0; l < 10; l++)
            //{
            //    for (int i = 0; i < size; i++)
            //    {
            //        int p0 = i;//Rnd.Next(0, size);
            //        int p1 = Rnd.Next(0, size);

            //        int val = Position[p0];
            //        Position[p0] = Position[p1];
            //        Position[p1] = val;
            //    }
            //}
            
            int prog = 0;
            long cnt = 0;
            long total = nSteps * (long)size;
            // 
            for (int k = 0; k < nSteps; k++)
            {

                if (Simulator.CancellationPending)
                    break;

                // Rotate Vector
                //for (int l = 0; l < size; l++)
                //for (int l = 0; l < nSteps; l++)
                //{
                //    for (int i = 0; i < size; i++)
                //    {
                //        int p0 = i;//Rnd.Next(0, size);
                //        int p1 = Rnd.Next(0, size);

                //        int val = Position[p0];
                //        Position[p0] = Position[p1];
                //        Position[p1] = val;
                //    }
                //}

                // Main Vector
                //for (int i = 0; i < nAtoms; i++)
                //System.Threading.Tasks.Parallel.For(0, nAtoms, i =>
                System.Threading.Tasks.Parallel.For(0, size, i =>
                {
                   // for (int j = 0; j < nAtoms; j++)
                    {
                        int p = Rnd.Next(0, size);//Position[i * nAtoms + j];

                        int ii = p / nAtoms;
                        int jj = p % nAtoms;

                        int[] neighbours = new int[4];

                        LoadNeightbours(ii, jj, nAtoms, nAtoms, MatrixS, neighbours);

                        double dE = 0;
                        double E0 = 0;
                        double Ef = 0;

                        int Sum = 0;

                        for (int m = 0; m < neighbours.Length; m++)
                        {
                            Sum += MatrixS[p] * neighbours[m];
                        }

                        E0 = -(J / T) * Sum;
                        Ef = (J / T) * Sum;

                        dE = Ef - E0;

                        if (dE < 0)
                        {
                            MatrixS[p] = -MatrixS[p];
                        }
                        else
                        {
                            //double E = Math.Exp(-dE / (K * T));
                            double E = Math.Exp(-dE / (T));

                            double Z = Rnd.NextDouble();

                            if (E >= Z)
                            {
                                MatrixS[p] = -MatrixS[p];
                            }                            
                        }

                        cnt++;

                        prog = (int)(cnt * 100.0 / total);

                        if (prog != Progress.Value)
                        {
                            prog = Math.Max(0, prog);
                            Simulator.ReportProgress(prog);
                        }
                    }
               // }
                });
               
            } // MC

            Done = true;

            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new RenderInvoker(RenderCall), "Status text");
            //}
            //else
            //{
            //    RenderCall("Status text");
            //}
        }

        private void LoadNeightbours(int i, int j, int lines, int cols, int[] Matrix0, int[] neighbours)
        {
            // UP
            if (i == 0) neighbours[0] = Matrix0[((lines - 1) * lines + j)];
            else neighbours[0] = Matrix0[((i - 1) * lines + j)];

            //LEFT
            if (j == cols - 1) neighbours[1] = Matrix0[(i * lines + 0)];
            else neighbours[1] = Matrix0[(i * lines + j + 1)];

            // Down
            if (i == lines - 1) neighbours[2] = Matrix0[(0 + j)];
            else neighbours[2] = Matrix0[((i + 1) * lines + j)];

            //RIGHT
            if (j == 0) neighbours[3] = Matrix0[(i * lines + cols - 1)];
            else neighbours[3] = Matrix0[(i * lines + j - 1)];
        }

        private void CancelBT_Click(object sender, EventArgs e)
        {
            Simulator.CancelAsync();
        }

        private void Simulator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Done = true;
            Progress.Style = ProgressBarStyle.Blocks;

            Run.Enabled = true;
            CancelBT.Enabled = false;

            Progress.Value = 0;

            SimTimer.Enabled = false;

            TimeSpan delta = (DateTime.Now - T0);

            RunningLabel.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", delta.Days, delta.Hours, delta.Minutes, delta.Seconds, delta.Milliseconds);

            if (!Simulator.CancellationPending)
            {
                ListViewItem it = new ListViewItem() { Text = String.Format("{0}", nAtoms) };

                it.SubItems.Add(nSteps.ToString());

                it.SubItems.Add(delta.TotalMilliseconds.ToString());
                
                TimeList.Items.Add(it);
            }
            
            Engine.Refresh();

            MainContainer_Resize(sender, e);
        }

        private void SaveImageBT_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Portable Network Grphics (*.png)|*.png";
                dlg.FileName = String.Format("SpinNetSim-{0:dd-MM-yyy-HH-mm-ss}.png", DateTime.Now);
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    using(Bitmap bmp = new Bitmap(Engine.Width,Engine.Height))
                    {
                        Engine.DrawToBitmap(bmp, new Rectangle(0, 0, Engine.Width, Engine.Height));

                        bmp.Save(dlg.FileName);
                    }                    
                }                
            }            
        }

        Font BaseFont = new Font("Arial", 32);

        Font BorderFont = new Font("Arial", 10);

        private void Engine_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.ScaleTransform(Zoom, Zoom);

            int size = nAtoms * (AtomSize + AtomSpace) + 2 * Border;

            Rectangle Area = new Rectangle(0, 0, size, size);

            g.FillRectangle(Brushes.White, Area);

            if (!RenderIt.Checked)
                return;

            g.DrawRectangle(Pens.Black, Border, Border, size - 2 * Border, size - 2 * Border);

            if (MatrixR == null || (!IsOffLine && (Simulator.IsBusy || SimulatorGPU.IsBusy)) || (IsOffLine && !Done))
            {
                if ((!IsOffLine && (Simulator.IsBusy || SimulatorGPU.IsBusy)) || (IsOffLine && !Done))
                {
                    SizeF s = g.MeasureString("Processing", BaseFont);

                    g.DrawString("Processing", BaseFont, Brushes.Black, (size - s.Width) / 2.0f, (size - s.Height) / 2.0f);
                }

                return;
            }

            for (int i = 0; i < nAtoms; i++)
            {
                float y = Border + i * (AtomSize + AtomSpace) + AtomSpace / 2.0f;

                if (i % 2 == 0)
                {
                    g.DrawString(String.Format("{0}", i + 1), BorderFont, Brushes.Black, 5, y);

                    g.DrawString(String.Format("{0}", i + 1), BorderFont, Brushes.Black, y, 5);
                }

                for (int j = 0; j < nAtoms; j++)
                {
                    int p = i * nAtoms + j;

                    float x = Border + j * (AtomSize + AtomSpace) + AtomSpace / 2.0f;

                    if (MatrixR[p] > 0)
                    {
                        g.FillEllipse(Brushes.Blue, x, y, AtomSize, AtomSize);
                    } else
                    {
                        g.FillEllipse(Brushes.Red, x, y, AtomSize, AtomSize);
                    }                    
                }
            }

            g.Flush();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            TimeList_Resize(sender, e);

            MatrixCombo.SelectedIndex = 1;

            int size = nAtoms * nAtoms;

            MatrixS = new int[size];

            Random Rnd = new Random();

            sbyte[] Values = new sbyte[] { -1, 1 };

            // Initialization
            for (int i = 0; i < size; i++)
            {
                MatrixS[i] = Values[Rnd.Next(2)];
            }

            Matrix0 = MatrixS.Clone() as int[];

            MatrixR = Matrix0;

            Zoom = ZoomBar.Value / 100.0f;

            int size2 = nAtoms * (AtomSize + AtomSpace) + 2 * Border;

            Engine.Width = (int)(size2 * Zoom);

            Engine.Height = Engine.Width;

            Engine.Refresh();
        }

        private void RefreshBT_Click(object sender, EventArgs e)
        {
            Engine.Refresh();

            MainContainer_Resize(sender, e);
        }

        private void MainContainer_Resize(object sender, EventArgs e)
        {
            Engine.Top = Math.Max((MainContainer.Height - Engine.Height) / 2, 0);
            Engine.Left = Math.Max((MainContainer.Width - Engine.Width) / 2, 0);
        }

        private void AtomSizeUP_ValueChanged(object sender, EventArgs e)
        {
            AtomSize = (int)AtomSizeUP.Value;
        }

        private void AtomSpaceUP_ValueChanged(object sender, EventArgs e)
        {
            AtomSpace = (int)AtomSpaceUP.Value;
        }

        private void ZoomBar_ValueChanged(object sender, EventArgs e)
        {
            Zoom = ZoomBar.Value / 100.0f;

            int size = nAtoms * (AtomSize + AtomSpace) + 2 * Border;

            Engine.Width = (int)(size * Zoom);

            Engine.Height = Engine.Width;

            MainContainer_Resize(sender, e);
        }

        private void Simulator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Value = e.ProgressPercentage;
        }

        private void SaveIMatrixBT_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Comma Separed Values (*.csv)|*.csv";
                dlg.FileName = String.Format("SpinNetSim-{0:dd-MM-yyy-HH-mm-ss}.csv", DateTime.Now);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dlg.FileName))
                    {
                        for (int i = 0; i < nAtoms; i++)
                        {
                            String Line = "";

                            for (int j = 0; j < nAtoms; j++)
                            {
                                int p = i * nAtoms + j;

                                Line += String.Format("{0};", MatrixR[p]);
                            }

                            Line = Line.Remove(Line.Length - 1);

                            writer.WriteLine(Line);
                        }
                    }
                }
            }        
        }

        private void RenderIt_CheckedChanged(object sender, EventArgs e)
        {
            Engine.Refresh();
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SpinNet v1.0\n\nDeveloped By: Rodrigo Marques");
        }

        private void MatrixCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatrixCombo.SelectedIndex == 0)
            {
                ShowInitial = true;
                if(MatrixR != Matrix0)
                {
                    MatrixR = Matrix0;
                    Engine.Refresh();
                }
            }
            else
            {
                ShowInitial = false;
                if (MatrixR != MatrixS)
                {
                    MatrixR = MatrixS;
                    Engine.Refresh();
                }
            }

        }

        private void SimTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan delta = (DateTime.Now - T0);

            RunningLabel.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", delta.Days, delta.Hours, delta.Minutes, delta.Seconds, delta.Milliseconds);
        }

        private void AtomsUP_ValueChanged(object sender, EventArgs e)
        {
            MatrixReuse.Checked = false;
        }

        private void ListClear_Click(object sender, EventArgs e)
        {
            TimeList.Items.Clear();
        }

        private void ListSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Comma Separed Values (*.csv)|*.csv";
                dlg.FileName = String.Format("SpinNetSim-Time-{0:dd-MM-yyy-HH-mm-ss}.csv", DateTime.Now);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dlg.FileName))
                    {
                        for (int i = 0; i < TimeList.Items.Count; i++)
                        {
                            writer.WriteLine(String.Format("{0};{1};{2}", TimeList.Items[i].Text, TimeList.Items[i].SubItems[1].Text, TimeList.Items[i].SubItems[2].Text));
                        }
                    }
                }
            }       
        }

        private void TimeList_Resize(object sender, EventArgs e)
        {
            TimeList.Columns[2].Width = Math.Max(15, TimeList.Width - TimeList.Columns[1].Width - TimeList.Columns[0].Width - 10);
        }

        private void SimulatorGPU_DoWork(object sender, DoWorkEventArgs e)
        {
            Done = false;

            int size = nAtoms * nAtoms;

            Random Rnd = new Random();

            sbyte[] Values = new sbyte[] { -1, 1 };

            MatrixR = null;

            if (!MatrixReuse.Checked)
            {
                MatrixS = new int[size];

                // Initialization
                for (int i = 0; i < size; i++)
                {
                    MatrixS[i] = Values[Rnd.Next(2)];
                }

                Matrix0 = MatrixS.Clone() as int[];
            }
            else
            {
                MatrixS = Matrix0.Clone() as int[];
            }

            if (ShowInitial)
            {
                MatrixR = Matrix0;
            }
            else
            {
                MatrixR = MatrixS;
            }

            int x = SpinSimulateGPU(MatrixS, size, nAtoms, (float)J, (float)T, nSteps, 512);

            Done = true;
        }    
    }
}
