// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetGeneratedStars.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Data;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class SetGeneratedStars : MonoBehaviour
    {
        [SerializeField] private BackgroundType _backgroundType;

        private enum BackgroundType
        {
            Front,
            Back
        }

        private void Awake()
        {
            var meshRenderer = GetComponent<MeshRenderer>();

            meshRenderer.material.mainTexture = _backgroundType switch
            {
                BackgroundType.Front => TrackedData.Instance.SessionData.FrontStarsTexture2D,
                BackgroundType.Back => TrackedData.Instance.SessionData.BackStarsTexture2D,
                _ => throw new ArgumentOutOfRangeException(null, _backgroundType, null)
            };
        }
    }
}
