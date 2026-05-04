// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenerateStarBackground.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Data;
using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class GenerateStarBackground : MonoBehaviour
    {
        private static readonly Color s_backgroundColor = new Color32(18, 18, 43, 255);

        [SerializeField] private UnityEngine.Camera _sourceCamera;
        [SerializeField] private ParticleSystem _starParticleSystem;
        [SerializeField] private BackgroundType _backgroundType;
        [SerializeField] private Shader _backShader;

        private MeshRenderer meshRenderer;

        private enum BackgroundType
        {
            Front,
            Back
        }

        private static bool IsValid(Texture tex) => tex != null && (tex is not RenderTexture rt || rt.IsCreated());

        private static RenderTexture RenderToTexture(UnityEngine.Camera screenshotCamera, int width = 2048, int height = 1024)
        {
            if (width < 1 || height < 1)
            {
                return null;
            }

            var renderTex = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
            screenshotCamera.targetTexture = renderTex;
            screenshotCamera.Render();
            screenshotCamera.targetTexture = null;
            return renderTex;
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
                    if (IsValid(TrackedData.Instance.SessionData.FrontStarsTexture))
                    {
                        meshRenderer.material.mainTexture = TrackedData.Instance.SessionData.FrontStarsTexture;
                        gameObject.layer = 14;
                        return;
                    }

                    _sourceCamera.clearFlags = CameraClearFlags.Depth;
                    break;
                case BackgroundType.Back:
                    if (IsValid(TrackedData.Instance.SessionData.BackStarsTexture))
                    {
                        meshRenderer.material.mainTexture = TrackedData.Instance.SessionData.BackStarsTexture;
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
            var rt = RenderToTexture(_sourceCamera);
            meshRenderer.material.mainTexture = rt;
            _starParticleSystem.Stop();
            _starParticleSystem.gameObject.SetActive(false);
            _sourceCamera.gameObject.SetActive(false);
            switch (_backgroundType)
            {
                case BackgroundType.Front:
                    gameObject.layer = 14;
                    TrackedData.Instance.SessionData.FrontStarsTexture = rt;
                    break;
                case BackgroundType.Back:
                    gameObject.layer = 15;
                    meshRenderer.material.shader = _backShader;
                    TrackedData.Instance.SessionData.BackStarsTexture = rt;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(null, _backgroundType, null);
            }
        }
    }
}
