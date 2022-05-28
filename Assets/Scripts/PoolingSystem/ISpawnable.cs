﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpawnable.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace InterstellarDrift
{
    public interface ISpawnable
    {
        void OnSpawned(ObjectPooler pooler);
        void OnRecycled();
    }
}
