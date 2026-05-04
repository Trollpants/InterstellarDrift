// <copyright file="ShipSupervisor.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using Controllers;
using Enemy;
using Score;
using UnityEngine;

namespace Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class ShipSupervisor : MonoBehaviour
    {
        [SerializeField] private bool _initializeSelf;
        [SerializeField] private Controller _desiredController;

        private EffectsShepherd effects;
        private DetectionRadius detectionRadius;

        public BaseController ControllerInstance { get; private set; }

        public void Init()
        {
            if (effects == null)
            {
                effects = gameObject.AddComponent<EffectsShepherd>();
                effects.Init();
            }

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            _desiredController = Controller.Keyboard;
#endif
            ControllerInstance = AddControllerOfType(_desiredController);
            ControllerInstance.Init(effects);
            ControllerInstance.SetMaxVelocity(150f);

            detectionRadius = gameObject.AddComponent<DetectionRadius>();
            detectionRadius.Init(10);
        }

        private void Awake()
        {
            if (_initializeSelf)
            {
                Init();
            }
        }

        private BaseController AddControllerOfType(Controller type) => type switch
        {
            Controller.OneClick => gameObject.AddComponent<OneClickController>(),
            Controller.TwoButton => gameObject.AddComponent<TwoButtonController>(),
            Controller.Keyboard => gameObject.AddComponent<KeyboardController>(),
            Controller.Enemy => gameObject.AddComponent<EnemyController>(),
            _ => null
        };
    }
}
