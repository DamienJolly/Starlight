using System;

namespace Starlight.Utils
{
	internal static class ConsoleUtil
	{
        internal static void ClearConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            ShowStarlightMessage();
        }

        private static void ShowStarlightMessage()
        {
            Console.WriteLine();
            Console.WriteLine("        " + @" ______   ______  ______   ______   __       __   ______   __  __   ______");
            Console.WriteLine("        " + @"/\  ___\ /\__  _\/\  __ \ /\  == \ /\ \     /\ \ /\  ___\ /\ \_\ \ /\__  _\");
            Console.WriteLine("        " + @"\ \___  \\/_/\ \/\ \  __ \\ \  __< \ \ \____\ \ \\ \ \__ \\ \  __ \\/_/\ \/");
            Console.WriteLine("        " + @" \/\_____\  \ \_\ \ \_\ \_\\ \_\ \_\\ \_____\\ \_\\ \_____\\ \_\ \_\  \ \_\");
            Console.WriteLine("        " + @"  \/_____/   \/_/  \/_/\/_/ \/_/ /_/ \/_____/ \/_/ \/_____/ \/_/\/_/   \/_/");
            Console.WriteLine();
            Console.WriteLine("        " + "BUILD " + Starlight.VERSION + " By Damien Jolly");
            Console.WriteLine();
        }
    }
}
