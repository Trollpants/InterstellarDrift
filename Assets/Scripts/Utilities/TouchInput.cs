// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TouchInput.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace InterstellarDrift
{
    using UnityEngine.InputSystem.EnhancedTouch;

    public static class TouchInput
    {
        public static bool TwoFingerOppositeHalves(int halfScreenWidth)
        {
            var touches = Touch.activeTouches;
            if (touches.Count != 2)
            {
                return false;
            }

            var aOnLeft = touches[0].screenPosition.x < halfScreenWidth;
            var bOnLeft = touches[1].screenPosition.x < halfScreenWidth;
            return aOnLeft != bOnLeft;
        }
    }
}
