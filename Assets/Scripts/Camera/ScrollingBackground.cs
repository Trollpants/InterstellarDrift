// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScrollingBackground.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class ScrollingBackground : MonoBehaviour
    {
        public UnityEngine.Camera BackgroundCamera;
        public float Speed = 1;

        private MeshRenderer background;
        private Material space;
        private Vector3 oldCameraPosistion;

        private void Awake()
        {
            background = GetComponent<MeshRenderer>();
            space = background.material;
        }

        private void Update()
        {
            var newCameraPosition = BackgroundCamera.transform.position;
            var deltaPosition = newCameraPosition - oldCameraPosistion;
            space.mainTextureOffset += Speed * Time.deltaTime * (Vector2)deltaPosition.normalized;
            oldCameraPosistion = BackgroundCamera.transform.position;
        }
    }
}
