// <copyright file="PoolingEventHook.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using UnityEngine;

namespace PoolingSystem
{
    public sealed class PoolingEventHook : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        private ObjectPooler objectPooler;

        public void SpawnPrefab()
        {
            if (objectPooler == null)
            {
                objectPooler = GetObjectPooler();
                if (objectPooler == null)
                {
                    return;
                }
            }

            var o = objectPooler.Spawn(prefab, null, transform.position, transform.localRotation);
            if (o.TryGetComponent<ParticleSystem>(out var particles))
            {
                objectPooler.Recycle(o, particles.main.duration + 1f);
            }
        }

        private static ObjectPooler GetObjectPooler()
        {
            var poolerGameObject = GameObject.FindWithTag("ObjectPooler");
            if (poolerGameObject != null && poolerGameObject.TryGetComponent<ObjectPooler>(out var pooler))
            {
                return pooler;
            }

            return null;
        }

        private void Awake() => objectPooler = GetObjectPooler();
    }
}
