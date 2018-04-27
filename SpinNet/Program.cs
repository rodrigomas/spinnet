using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SpinNet
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm Form = new MainForm();

            if (args.Length == 0)
            {
                Application.Run(Form);
            }
            else
            {
                IntPtr ptr = GetForegroundWindow();

                int u;

                GetWindowThreadProcessId(ptr, out u);

                Process process = Process.GetProcessById(u);

                if (process.ProcessName == "cmd")
                {
                    AttachConsole(process.Id);
                }
                else
                {
                    AllocConsole();
                }

                Console.Out.WriteLine("\nSpinNet Command Line");
                Console.Out.WriteLine("Developed by: Rodrigo Marques\n");

                int atoms = 0;
                int steps = 0;
                double J = 1;
                double T = 0.12;
                bool gpu = false;
                
                String FinalImageFile = null;
                String InitialImage = null;
                String FinalMatrix = null;
                String InitialMatrix = null;

                System.Globalization.CultureInfo Info = new System.Globalization.CultureInfo("en-us");

                try 
	            {	        
		            for(int i = 0 ; i < args.Length ; i++)
                    {
                        String cmd = args[i].Substring(0,2);
                        //-a=
                        switch(cmd)
                        {
                            case "-a":
                                {
                                    atoms = int.Parse(args[i].Substring(3));
                                };
                                break;

                            case "-h":
                                {
                                    ShowOptions();

                                    FreeConsole();
                                };
                                return;

                            case "-j": 
                                {
                                    J =  double.Parse(args[i].Substring(3).Replace(",", "."), Info);
                                };
                                break;

                            case "-s": 
                                {
                                    steps = int.Parse(args[i].Substring(3));
                                };
                                break;

                            case "-t": 
                                {
                                    T =  double.Parse(args[i].Substring(3).Replace(",", "."), Info);
                                };
                                break;

                            case "-g": 
                                {
                                    gpu = true;
                                };
                                break;

                            case "-f": 
                                {
                                   FinalImageFile = args[i].Substring(3);
                                };
                                break;

                            case "-o": 
                                {
                                   FinalMatrix = args[i].Substring(3);
                                };
                                break;

                            case "-m": 
                                {
                                   InitialMatrix = args[i].Substring(3);
                                };
                                break;

                            case "-i": 
                                {
                                   InitialImage = args[i].Substring(3);
                                };
                                break;
                        }
                    }   
	            }
	            catch (Exception)
	            {
                    Console.Out.WriteLine("Invalid command line call.");

                    ShowOptions();
	            }
             
                if( atoms == 0 || steps == 0)
                {
                    Console.Out.WriteLine("Invalid command line call.");
                    ShowOptions();
                } else
                {
                    Console.Out.Write("Running ");

                    DateTime T0 = DateTime.Now;

                    try
                    {
                        Form.SetRunAndSave(atoms, steps, J, T, gpu, FinalImageFile, InitialImage, FinalMatrix, InitialMatrix);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(" [ERROR]");
                        Console.Out.WriteLine(String.Format("Information: {0}", EncodeTo64(String.Format("Error Message: {0}\n\nStacktrace:{1}", ex.Message, ex.StackTrace))));
                    }

                    TimeSpan delta = (DateTime.Now - T0);
                    
                    Console.Out.WriteLine(String.Format("Time: {0:00}:{1:00}:{2:00}:{3:00}:{4:00}", delta.Days, delta.Hours, delta.Minutes, delta.Seconds, delta.Milliseconds));
                    Console.Out.WriteLine(String.Format("Time (ms): {0:0.000}", delta.TotalMilliseconds));
                }

                FreeConsole();
            }
        }

        static private string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        private static void ShowOptions()
        {
            Console.Out.WriteLine("Command Line Format: SpinNet -a=[int] -s=[int] -i=teste.png");
            Console.Out.WriteLine("Options:");
            Console.Out.WriteLine("");

            Console.Out.WriteLine("\t-a: Number of Atoms [Required]");
            Console.Out.WriteLine("\t-j: Temperature");
            Console.Out.WriteLine("\t-t: J Factor");
            Console.Out.WriteLine("\t-s: Number of Steps [Required]");
            Console.Out.WriteLine("\t-g: Use GPU");
            Console.Out.WriteLine("\t-f: Save Final Image");
            Console.Out.WriteLine("\t-o: Save Final Matrix CSV");
            Console.Out.WriteLine("\t-m: Save Initial Image");
            Console.Out.WriteLine("\t-i: Save Initial Matrix CSV");
            Console.Out.WriteLine("\t-h: Show this help");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("");

        }
    }
}
