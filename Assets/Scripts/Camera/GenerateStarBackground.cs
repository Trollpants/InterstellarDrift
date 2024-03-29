﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenerateStarBackground.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace InterstellarDrift
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(MeshRenderer))]
    public class GenerateStarBackground : MonoBehaviour
    {
        private static readonly Color s_backgroundColor = new Color32(18, 18, 43, 255);

        [SerializeField] private Camera _sourceCamera;
        [SerializeField] private ParticleSystem _starParticleSystem;
        [SerializeField] private BackgroundType _backgroundType;
        [SerializeField] private Shader _backShader;

        private MeshRenderer meshRenderer;

        private enum BackgroundType
        {
            Front,
            Back
        }

        private static Texture2D TakeScreenshot(Camera screenshotCamera, int width = 2048, int height = 1024)
        {
            if (width < 1 || height < 1)
            {
                return null;
            }

            var screenshot = new Texture2D(width, height, TextureFormat.ARGB32, false);
            var renderTex = new RenderTexture(width, height, 32);
            screenshotCamera.targetTexture = renderTex;
            screenshotCamera.Render();
            RenderTexture.active = renderTex;
            screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenshot.Apply(true);
            screenshotCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(renderTex);
            return screenshot;
        }

        private void Awake()
        {
            if (_sourceCamera == null || _starParticleSystem == null)
            {
                Debug.LogWarning("Source Camera or Star Particle System is null");
                return;
            }

            meshRenderer = GetComponent<MeshRenderer>();

            switch (_backgroundType)
            {
                case BackgroundType.Front:
                    if (TrackedData.Instance.SessionData.FrontStarsTexture2D != null)
                    {
                        meshRenderer.material.mainTexture = TrackedData.Instance.SessionData.FrontStarsTexture2D;
                        gameObject.layer = 14;
                        return;
                    }

                    _sourceCamera.clearFlags = CameraClearFlags.Depth;
                    break;
                case BackgroundType.Back:
                    if (TrackedData.Instance.SessionData.BackStarsTexture2D != null)
                    {
                        meshRenderer.material.mainTexture = TrackedData.Instance.SessionData.BackStarsTexture2D;
                        meshRenderer.material.shader = _backShader;
                        gameObject.layer = 15;
                        return;
                    }

                    _sourceCamera.clearFlags = CameraClearFlags.Color;
                    _sourceCamera.backgroundColor = s_backgroundColor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _starParticleSystem.Play();
            Invoke(nameof(Snap), 0.15f);
        }

        private void Snap()
        {
            var tex2D = TakeScreenshot(_sourceCamera);
            meshRenderer.material.mainTexture = tex2D;
            _starParticleSystem.Stop();
            _starParticleSystem.gameObject.SetActive(false);
            _sourceCamera.gameObject.SetActive(false);
            switch (_backgroundType)
            {
                case BackgroundType.Front:
                    gameObject.layer = 14;
                    TrackedData.Instance.SessionData.FrontStarsTexture2D = tex2D;
                    byte[] bytes = tex2D.EncodeToPNG();
                    System.IO.File.WriteAllBytes("C:\\Users\\jizc\\Downloads\\SavedScreen.png", bytes);
                    break;
                case BackgroundType.Back:
                    gameObject.layer = 15;
                    meshRenderer.material.shader = _backShader;
                    TrackedData.Instance.SessionData.BackStarsTexture2D = tex2D;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
