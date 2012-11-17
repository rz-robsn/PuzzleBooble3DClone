using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleBooble3DClone.GameComponents
{
    public interface HangingBallsObserver
    {
        void OnPlayerWins();

        void OnPlayerLoses();
    }
}
