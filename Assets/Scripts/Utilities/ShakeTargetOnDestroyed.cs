// <copyright file="ShakeTargetOnDestroyed.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using DG.Tweening;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    ///  Shakes a target transform on the destruction of this gameobject.
    /// </summary>
    public sealed class ShakeTargetOnDestroyed : MonoBehaviour
    {
        public Transform ShakeTarget;

        [SerializeField] private float _duration = 2f;
        [SerializeField] private float _shakeStrength = 2f;

        private void OnDestroy()
        {
            if (ShakeTarget)
            {
                ShakeTarget.DOShakePosition(_duration, _shakeStrength).SetLink(ShakeTarget.gameObject);
                ShakeTarget.DOShakeRotation(_duration, _shakeStrength).SetLink(ShakeTarget.gameObject);
            }
        }
    }
}
