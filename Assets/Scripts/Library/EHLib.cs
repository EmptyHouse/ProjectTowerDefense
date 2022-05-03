
using UnityEngine;

namespace EmptyHouseGames.Utility
{
    public static class EHMath
    {
        // In the case that you know x will always be positive, you should just use regular modulo
        public static int Mod(int X, int M)
        {
            int R = X % M;
            return R < 0 ? R + M : R;
        }
    }
}

public static class EHLib
{
    
}
