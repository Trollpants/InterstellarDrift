// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnemyDriver.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using CloudOnce;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Vehicle), typeof(TargetTransform))]
    public sealed class EnemyDriver : MonoBehaviour
    {
        [SerializeField] private bool _isEngineOn;
        [SerializeField] private float _turnRatio = 2f;

        private Vector2 targetPoint = Vector2.zero;

        private Vehicle vehicle;
        private TargetTransform target;
        private bool isInitialized;

        private Vector3 calculatedPoint = Vector3.zero;

        public bool IsEngineOn
        {
            get => _isEngineOn;
            set => _isEngineOn = value;
        }

        public float TurnRatio
        {
            get => _turnRatio;
            set => _turnRatio = value;
        }

        public Vector2 TargetPoint
        {
            get
            {
                if (target.Target)
                {
                    return target.Target.transform.position;
                }

                return targetPoint;
            }

            set => targetPoint = value;
        }

        private void Awake()
        {
            vehicle = GetComponent<Vehicle>();
            target = GetComponent<TargetTransform>();
            isInitialized = true;
        }

        private void FixedUpdate()
        {
            if (!isInitialized || !IsEngineOn || !CloudVariables.HasFinishedTutorial)
            {
                return;
            }

            vehicle.MoveForward();

            Vector2 relativePoint = transform.InverseTransformPoint(TargetPoint);
            calculatedPoint = relativePoint;

            if (relativePoint.x < -2.0)
            {
                vehicle.MoveLeft(TurnRatio);
            }
            else if (relativePoint.x > 2.0)
            {
                vehicle.MoveRight(TurnRatio);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(calculatedPoint, .5f);
        }
    }
}
