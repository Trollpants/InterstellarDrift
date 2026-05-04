// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KeyboardController.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Controllers
{
    public sealed class KeyboardController : BaseController
    {
        private GameInput _input;

        private void Awake() => _input = new GameInput();
        private void OnEnable() => _input.Keyboard.Enable();
        private void OnDisable() => _input.Keyboard.Disable();
        private void OnDestroy() => _input?.Dispose();

        private void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            var horizontal = _input.Keyboard.Steer.ReadValue<float>();

            if (Mathf.Abs(horizontal) > 0.1f)
            {
                IsInputActive = true;

                if (horizontal > 0f)
                {
                    IsMovingRight = true;
                }
                else if (horizontal < 0f)
                {
                    IsMovingRight = false;
                }

                return;
            }

            IsInputActive = false;
        }

        private void FixedUpdate()
        {
            if (!IsInitialized)
            {
                return;
            }

            if (_input.Keyboard.Boost.IsPressed())
            {
                Boost();
            }
            else
            {
                MoveForward();

                if (IsInputActive)
                {
                    if (IsMovingRight)
                    {
                        MoveRight();
                    }
                    else
                    {
                        MoveLeft();
                    }
                }
            }

            BaseFixedUpdate();
        }
    }
}
