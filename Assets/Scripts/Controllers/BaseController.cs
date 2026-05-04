// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Audio;
using Ship;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    ///  Provides the base functionality for ship-movement using 2d-physics.
    /// </summary>
    [RequireComponent(typeof(EffectsShepherd))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseController : MonoBehaviour
    {
        private const ForceMode2D forceMode = ForceMode2D.Impulse;

        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _boostModifier = 3f;
        [SerializeField] private float _turnSpeed;
        [SerializeField] private bool _isEngineOn = true;
        [SerializeField] private bool _isInputActive;
        [SerializeField] private bool _isMovingRight;

        private float forwardForce;
        private float turnForce;

        public EffectsShepherd Effects { get; private set; }

        public bool IsEngineOn
        {
            get => _isEngineOn;
            set => _isEngineOn = value;
        }

        public bool IsInputActive
        {
            get => _isInputActive;
            protected set => _isInputActive = value;
        }

        public bool IsMovingRight
        {
            get => _isMovingRight;
            protected set => _isMovingRight = value;
        }

        protected bool IsInitialized { get; set; }

        private Rigidbody2D CachedRigidbody2D { get; set; }

        public void Init(EffectsShepherd effects)
        {
            Effects = GetComponent<EffectsShepherd>();
            CachedRigidbody2D = GetComponent<Rigidbody2D>();

            // IMPORTANT: If drag is 1f, Mass is 1f and ForceMode is set to Impulse, Force^2 = MaxVelocity. Ex: 2f^2 = 4 maxVel.
            // This means that we can calculate the needed constant force from the maximum velocity;
            // we can set a top speed and calculate the force needed to get there.
            CachedRigidbody2D.linearDamping = 1f;

            // Sets default values
            SetMaxVelocity(25f);
            SetTurnSpeed(2f);
            IsInputActive = false;
            IsMovingRight = false;

            IsInitialized = true;
        }

        protected void MoveForward()
        {
            if (!_isEngineOn)
            {
                return;
            }

            if (Effects.IsBoostParticlesActive)
            {
                Effects.DeactivateBoostParticles();
            }

            CachedRigidbody2D.AddForce(forwardForce * Time.fixedDeltaTime * transform.up, forceMode); // Provides motion in the forward direction

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(Sound.MainBoost);
            }
        }

        protected void MoveLeft()
        {
            CachedRigidbody2D.AddTorque(turnForce * Time.fixedDeltaTime, forceMode);

            // Activate the right adjustment-thruster visuals
            Effects.ActivateThruster(Thruster.Right);
            Effects.DeactivateThruster(Thruster.Left);

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(Sound.SideBoost);
            }
        }

        protected void MoveRight()
        {
            CachedRigidbody2D.AddTorque(-turnForce * Time.fixedDeltaTime, forceMode);

            // Activate the left adjustment-thruster visuals
            Effects.ActivateThruster(Thruster.Left);
            Effects.DeactivateThruster(Thruster.Right);

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(Sound.SideBoost);
            }
        }

        protected void Boost()
        {
            if (!_isEngineOn)
            {
                return;
            }

            if (!Effects.IsBoostParticlesActive)
            {
                Effects.ActivateBoostParticles();
            }

            CachedRigidbody2D.AddForce(_boostModifier * forwardForce * Time.fixedDeltaTime * transform.up, forceMode);

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(Sound.MainBoost);
            }
        }

        protected void BaseFixedUpdate()
        {
            if (!IsInitialized)
            {
#if DEBUG
                Debug.LogWarning("Controller not initialized!");
#endif
                return;
            }

            // Check if the thrusters should be turned off because of too little angular momentum
            // Doesn't make sense to have thrusters firing when there is no apparent force applied in that direction
            if (Mathf.Abs(CachedRigidbody2D.angularVelocity) <= 115f
                && (Effects.IsThrusterActive(Thruster.Left) || Effects.IsThrusterActive(Thruster.Right)))
            {
                TurnOffThrusters();
            }
        }

        public void SetMaxVelocity(float value)
        {
            if (value < 0f)
            {
#if DEBUG
                Debug.LogWarning("Tried to set MaxVelocity to less than 0.");
#endif
                return;
            }

            _maxVelocity = value;
            forwardForce = Mathf.Sqrt(_maxVelocity);
        }

        private void SetTurnSpeed(float value)
        {
            if (value < 0f)
            {
#if DEBUG
                Debug.LogWarning("Tried to set TurnSpeed to less than 0.");
#endif
                return;
            }

            _turnSpeed = value;
            turnForce = Mathf.Sqrt(_turnSpeed);
        }

        private void TurnOffThrusters()
        {
            Effects.DeactivateThruster(Thruster.Left);
            Effects.DeactivateThruster(Thruster.Right);

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.StopSound(Sound.SideBoost);
            }
        }
    }
}
