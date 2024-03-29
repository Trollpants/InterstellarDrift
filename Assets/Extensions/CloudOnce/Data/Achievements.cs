// <copyright file="Achievements.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to achievements registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Achievements
    {
        private static readonly UnifiedAchievement s_nearMiss = new UnifiedAchievement("NearMiss",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "NearMiss"
#endif
            );

        public static UnifiedAchievement NearMiss
        {
            get { return s_nearMiss; }
        }

        private static readonly UnifiedAchievement s_itBegins = new UnifiedAchievement("ItBegins",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "ItBegins"
#endif
            );

        public static UnifiedAchievement ItBegins
        {
            get { return s_itBegins; }
        }

        private static readonly UnifiedAchievement s_galaxyDrift = new UnifiedAchievement("GalaxyDrift",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "GalaxyDrift"
#endif
            );

        public static UnifiedAchievement GalaxyDrift
        {
            get { return s_galaxyDrift; }
        }

        private static readonly UnifiedAchievement s_masteroid = new UnifiedAchievement("Masteroid",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "Masteroid"
#endif
            );

        public static UnifiedAchievement Masteroid
        {
            get { return s_masteroid; }
        }

        private static readonly UnifiedAchievement s_earthToMoon = new UnifiedAchievement("EarthToMoon",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "EarthToMoon"
#endif
            );

        public static UnifiedAchievement EarthToMoon
        {
            get { return s_earthToMoon; }
        }

        private static readonly UnifiedAchievement s_sunToMercury = new UnifiedAchievement("SunToMercury",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToMercury"
#endif
            );

        public static UnifiedAchievement SunToMercury
        {
            get { return s_sunToMercury; }
        }

        private static readonly UnifiedAchievement s_sunToVenus = new UnifiedAchievement("SunToVenus",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToVenus"
#endif
            );

        public static UnifiedAchievement SunToVenus
        {
            get { return s_sunToVenus; }
        }

        private static readonly UnifiedAchievement s_sunToEarth = new UnifiedAchievement("SunToEarth",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToEarth"
#endif
            );

        public static UnifiedAchievement SunToEarth
        {
            get { return s_sunToEarth; }
        }

        private static readonly UnifiedAchievement s_sunToMars = new UnifiedAchievement("SunToMars",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToMars"
#endif
            );

        public static UnifiedAchievement SunToMars
        {
            get { return s_sunToMars; }
        }

        private static readonly UnifiedAchievement s_sunToJupiter = new UnifiedAchievement("SunToJupiter",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToJupiter"
#endif
            );

        public static UnifiedAchievement SunToJupiter
        {
            get { return s_sunToJupiter; }
        }

        private static readonly UnifiedAchievement s_sunToSaturn = new UnifiedAchievement("SunToSaturn",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToSaturn"
#endif
            );

        public static UnifiedAchievement SunToSaturn
        {
            get { return s_sunToSaturn; }
        }

        private static readonly UnifiedAchievement s_sunToUranus = new UnifiedAchievement("SunToUranus",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToUranus"
#endif
            );

        public static UnifiedAchievement SunToUranus
        {
            get { return s_sunToUranus; }
        }

        private static readonly UnifiedAchievement s_sunToNeptune = new UnifiedAchievement("SunToNeptune",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToNeptune"
#endif
            );

        public static UnifiedAchievement SunToNeptune
        {
            get { return s_sunToNeptune; }
        }

        private static readonly UnifiedAchievement s_sunToPluto = new UnifiedAchievement("SunToPluto",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            ""
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            ""
#else
            "SunToPluto"
#endif
            );

        public static UnifiedAchievement SunToPluto
        {
            get { return s_sunToPluto; }
        }

        public static readonly UnifiedAchievement[] All =
        {
            s_nearMiss,
            s_itBegins,
            s_galaxyDrift,
            s_masteroid,
            s_earthToMoon,
            s_sunToMercury,
            s_sunToVenus,
            s_sunToEarth,
            s_sunToMars,
            s_sunToJupiter,
            s_sunToSaturn,
            s_sunToUranus,
            s_sunToNeptune,
            s_sunToPluto,
        };

        public static string GetPlatformID(string internalId)
        {
            return s_achievementDictionary.ContainsKey(internalId)
                ? s_achievementDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedAchievement> s_achievementDictionary = new Dictionary<string, UnifiedAchievement>
        {
            { "NearMiss", s_nearMiss },
            { "ItBegins", s_itBegins },
            { "GalaxyDrift", s_galaxyDrift },
            { "Masteroid", s_masteroid },
            { "EarthToMoon", s_earthToMoon },
            { "SunToMercury", s_sunToMercury },
            { "SunToVenus", s_sunToVenus },
            { "SunToEarth", s_sunToEarth },
            { "SunToMars", s_sunToMars },
            { "SunToJupiter", s_sunToJupiter },
            { "SunToSaturn", s_sunToSaturn },
            { "SunToUranus", s_sunToUranus },
            { "SunToNeptune", s_sunToNeptune },
            { "SunToPluto", s_sunToPluto },
        };
    }
}
