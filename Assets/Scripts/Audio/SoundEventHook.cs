// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SoundEventHook.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Audio
{
    /// <summary>
    ///  Provides helper-methods for inspector-events to hook into the soundmanager-singleton.
    /// </summary>
    public sealed class SoundEventHook : MonoBehaviour
    {
        [SerializeField] private Sound _sound = Sound.Score;

        public void PlaySound()
        {
            if (SoundManager.Instance)
            {
                SoundManager.Instance.PlaySound(_sound);
            }
        }

        public void StopSound()
        {
            if (SoundManager.Instance)
            {
                SoundManager.Instance.StopSound(_sound);
            }
        }
    }
}
