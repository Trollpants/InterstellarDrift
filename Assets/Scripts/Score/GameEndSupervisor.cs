// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEndSupervisor.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Data;
using GUI;
using UnityEngine;

namespace Score
{
    [RequireComponent(typeof(Canvas))]
    public sealed class GameEndSupervisor : MonoBehaviour
    {
        public AnimateData ScoreAnimateData;
        public AnimateData TimeAnimateData;

        private bool isInitialized;

        public void Init()
        {
            if (isInitialized)
            {
                return;
            }

            gameObject.SetActive(false);
            isInitialized = true;
        }

        private void Start() => Init();

        private void OnEnable()
        {
            if (!isInitialized)
            {
                return;
            }

            var selfCanvas = GetComponent<Canvas>();

            // Deactivate all other Canvases
            foreach (var canvas in FindObjectsByType<Canvas>())
            {
                if (canvas != selfCanvas)
                {
                    canvas.gameObject.SetActive(false);
                }
            }

            switch (GameMode.GameMode.Instance.CurrentMode)
            {
                case GameMode.GameMode.Mode.Standard:
                    ScoreAnimateData.PlayAnimation();
                    TimeAnimateData.gameObject.SetActive(false);
                    break;
                case GameMode.GameMode.Mode.Time:
                    ScoreAnimateData.PlayAnimation();
                    TimeAnimateData.PlayAnimation();
                    break;
            }

            // Tell the data tracker that the session has ended
            // Updates the stats
            TrackedData.Instance.SessionEnd();
        }
    }
}
