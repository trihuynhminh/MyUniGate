namespace UniGate.Student
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new UniGate.Student.Forms.FormForgetPassword());
        }
    }
}
