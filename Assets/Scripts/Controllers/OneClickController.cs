// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OneClickController.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Controllers
{
    /// <summary>
    ///  Provides an implementation of the BaseController that uses a single mouse-click or touch.
    /// </summary>
    public sealed class OneClickController : BaseController
    {
        private GameInput _input;

        private void Awake() => _input = new GameInput();
        private void OnEnable() => _input.OneClick.Enable();
        private void OnDisable() => _input.OneClick.Disable();
        private void OnDestroy() => _input?.Dispose();

        private void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            if (_input.OneClick.Tap.IsPressed())
            {
                IsInputActive = true;
            }
            else if (_input.OneClick.Tap.WasReleasedThisFrame())
            {
                // Set input to false and flip IsMovingRight so the next movement is opposite the previous.
                IsInputActive = false;
                IsMovingRight = !IsMovingRight;
            }
        }

        private void FixedUpdate()
        {
            if (!IsInitialized)
            {
                return;
            }

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

            BaseFixedUpdate();
        }
    }
}
