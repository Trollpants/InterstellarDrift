// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShakeCamera.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using DG.Tweening;
using UnityEngine;

namespace Camera
{
    public sealed class ShakeCamera : MonoBehaviour
    {
        [SerializeField] private float _duration = 2f;
        [SerializeField] private float _shakeStrength = 2f;

        private Transform shakeTarget;

        public void Shake()
        {
            if (shakeTarget)
            {
                shakeTarget.DOShakePosition(_duration, _shakeStrength).SetLink(shakeTarget.gameObject);
                shakeTarget.DOShakeRotation(_duration, _shakeStrength).SetLink(shakeTarget.gameObject);
            }
        }

        private void Awake() => shakeTarget = GameObject.FindWithTag("MainCamera").transform;
    }
}
