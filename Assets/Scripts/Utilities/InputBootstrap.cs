// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputBootstrap.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Utilities
{
    internal static class InputBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void EnableEnhancedTouch()
        {
            EnhancedTouchSupport.Enable();
        }
    }
}
