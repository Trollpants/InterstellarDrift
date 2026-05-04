// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionData.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

namespace Data
{
    public sealed class SessionData
    {
        public SessionData()
        {
            Init();
        }

        public int DistanceTravelled { get; set; }
        public int Score { get; set; }

        public int MillisecondsSurvived { get; set; }

        public int SecondsSurvived => MillisecondsSurvived / 1000;

        public Texture FrontStarsTexture { get; set; }
        public Texture BackStarsTexture { get; set; }

        public void Init()
        {
            DistanceTravelled = 0;
            Score = 0;
            MillisecondsSurvived = 0;
        }
    }
}
