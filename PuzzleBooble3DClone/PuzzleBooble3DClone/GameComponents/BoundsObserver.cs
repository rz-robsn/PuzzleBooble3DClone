using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleBooble3DClone.GameComponents
{
    public interface BoundsObserver
    {
        void OnOneRowRemoved(FieldBounds bound);
    }
}
