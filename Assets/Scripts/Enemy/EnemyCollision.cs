// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnemyCollision.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Audio;
using Obstacles;
using PoolingSystem;
using Score;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Obstacle))]
    [RequireComponent(typeof(TargetTransform))]
    public sealed class EnemyCollision : MonoBehaviour
    {
        public Sound OnCollision = Sound.Death;

        [SerializeField] private int _scoreOnCollision;

        private Obstacle cachedObstacle;
        private TargetTransform cachedTarget;
        private ObjectPooler objectPooler;

        private void Awake()
        {
            cachedObstacle = GetComponent<Obstacle>();
            cachedTarget = GetComponent<TargetTransform>();
            objectPooler = GameObject.FindWithTag("ObjectPooler").GetComponent<ObjectPooler>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!cachedTarget.Target)
            {
                return;
            }

            if (SoundManager.Instance)
            {
                SoundManager.Instance.PlaySound(OnCollision);
            }

            if (_scoreOnCollision > 0 && ScoreSupervisor.Exists)
            {
                ScoreSupervisor.Instance.IncreaseScore(_scoreOnCollision, false);
            }

            var explosion = objectPooler.Spawn("Prefabs/", "Explosion", null, transform.position);
            if (explosion.TryGetComponent<ParticleSystem>(out var particles))
            {
                objectPooler.Recycle(explosion, particles.main.duration + 1f);
            }

            if (cachedObstacle != null)
            {
                cachedObstacle.RecycleSelf();
            }
        }
    }
}
