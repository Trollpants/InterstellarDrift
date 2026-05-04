// <copyright file="DisableSelfOnStart.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using UnityEngine;

namespace Utilities
{
    public sealed class DisableSelfOnStart : MonoBehaviour
    {
        private void Start() => gameObject.SetActive(false);
    }
}
