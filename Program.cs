namespace CS_Week02_22017011_CatchButton
{
    internal static class Program
    {
        public static int HighScore;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // 초기 최고점수 설정
            HighScore = 0;
            Application.Run(new MainWindow());
        }
    }
}