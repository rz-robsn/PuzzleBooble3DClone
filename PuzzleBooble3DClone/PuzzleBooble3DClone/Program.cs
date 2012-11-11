using System;

namespace PuzzleBooble3DClone
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PuzzleBooble3dGame game = new PuzzleBooble3dGame())
            {
                game.Run();
            }
        }
    }
#endif
}

