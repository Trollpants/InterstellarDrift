// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameMode.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace GameMode
{
    public sealed class GameMode : MonoBehaviour
    {
        private static GameMode s_instance;

        [SerializeField] private Mode _currentMode = Mode.Standard;

        public enum Mode
        {
            Standard,
            Time
        }

        public static GameMode Instance
        {
            get => s_instance;
            set
            {
                if (s_instance != null)
                {
                    return;
                }

                s_instance = value;
            }
        }

        public Mode CurrentMode
        {
            get => _currentMode;
            set => _currentMode = value;
        }

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL frame timing is driven by the browser's requestAnimationFrame; -1 lets it run at the monitor's natural refresh.
            Application.targetFrameRate = -1;
#else
            Application.targetFrameRate = (int)System.Math.Round(Screen.currentResolution.refreshRateRatio.value);
#endif
            Instance = this;
        }
    }
}
