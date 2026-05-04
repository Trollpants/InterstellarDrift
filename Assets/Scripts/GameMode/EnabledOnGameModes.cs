// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnabledOnGameModes.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace GameMode
{
    public sealed class EnabledOnGameModes : MonoBehaviour
    {
        public GameMode.Mode[] Modes = { GameMode.Mode.Standard };

        private void Awake()
        {
            foreach (var mode in Modes)
            {
                if (GameMode.Instance.CurrentMode == mode)
                {
                    continue;
                }

                gameObject.SetActive(false);
            }
        }
    }
}
