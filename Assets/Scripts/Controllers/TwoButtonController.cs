// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoButtonController.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace InterstellarDrift
{
    using UnityEngine;

    /// <summary>
    ///  Provides an implementation of the BaseController that splits the screen into two buttons by width.
    /// </summary>
    public class TwoButtonController : BaseController
    {
        private GameInput _input;

        private static int HalfScreenWidth => Screen.width / 2;

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.TwoButton.Enable();
        }

        private void OnDisable()
        {
            _input.TwoButton.Disable();
        }

        private void OnDestroy()
        {
            _input?.Dispose();
        }

        private void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            if (_input.TwoButton.Press.IsPressed())
            {
                IsInputActive = true;
            }

            if (_input.TwoButton.Press.WasReleasedThisFrame())
            {
                IsInputActive = false;
            }

            if (IsInputActive)
            {
                var pointerX = _input.TwoButton.PointerPosition.ReadValue<Vector2>().x;
                if (pointerX <= HalfScreenWidth)
                {
                    // Left side touched
                    IsMovingRight = false;
                }
                else
                {
                    // Right side touched
                    IsMovingRight = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (!IsInitialized)
            {
                return;
            }

            if (TouchInput.TwoFingerOppositeHalves(HalfScreenWidth))
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
