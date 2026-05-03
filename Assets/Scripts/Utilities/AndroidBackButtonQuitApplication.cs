// <copyright file="AndroidBackButtonQuitApplication.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace InterstellarDrift
{
    using UnityEngine;

    public class AndroidBackButtonQuitApplication : MonoBehaviour
    {
#if UNITY_ANDROID
        private GameInput _input;

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.System.Enable();
        }

        private void OnDisable()
        {
            _input.System.Disable();
        }

        private void OnDestroy()
        {
            _input?.Dispose();
        }

        private void Update()
        {
            if (_input.System.Quit.WasPressedThisFrame())
            {
                Application.Quit();
            }
        }
#endif
    }
}
