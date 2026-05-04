// <copyright file="IncrementHerder.cs" company="Jan Ivar Z. Carlsen">
// Copyright (c) 2018 Jan Ivar Z. Carlsen. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    /// <summary>
    ///  Spawns "+amount" / "-amount" popups that stack and float upward while fading out.
    /// </summary>
    public sealed class IncrementHerder : MonoBehaviour
    {
        [SerializeField] private float _holdDuration = .6f;
        [SerializeField] private float _animationDuration = .5f;
        [SerializeField] private float _floatDistance = 50f;
        [SerializeField] private float _stackMargin = 8f;
        [SerializeField] private float _slotReleaseDelay = .15f;

        private GameObject popupTemplate;
        private Vector3 spawnAnchor;
        private readonly List<RectTransform> slots = new();

        public void Init()
        {
            // The first child is a hidden template we clone for each popup.
            popupTemplate = transform.GetChild(0).gameObject;
            spawnAnchor = popupTemplate.transform.localPosition;
        }

        public void Increment(int amount) => Popup(amount, "+");
        public void Decrement(int amount) => Popup(amount, "-");

        private void Popup(int amount, string prefix)
        {
            var obj = Instantiate(popupTemplate, transform, false);
            var rt = (RectTransform)obj.transform;

            // A popup occupies a stack slot during its hold phase; the slot is released a short while
            // after it starts floating away to give the previous popup time to clear.
            var slot = AcquireSlot(rt);
            var slotSpacing = rt.rect.height + _stackMargin;
            var startLocal = spawnAnchor - new Vector3(0, slotSpacing * slot, 0);
            rt.localPosition = startLocal;

            var text = obj.GetComponent<Text>();
            text.text = prefix + amount;
            obj.SetActive(true);

            DOTween.Sequence()
                .AppendInterval(_holdDuration)
                .Append(rt.DOLocalMoveY(startLocal.y + _floatDistance, _animationDuration).SetEase(Ease.OutQuad))
                .Join(text.DOFade(0f, _animationDuration))
                .InsertCallback(_holdDuration + _slotReleaseDelay, () => ReleaseSlot(slot, rt))
                .OnComplete(() => Destroy(obj))
                .OnKill(() => ReleaseSlot(slot, rt))
                .SetLink(obj, LinkBehaviour.KillOnDestroy);
        }

        private int AcquireSlot(RectTransform rt)
        {
            for (var i = 0; i < slots.Count; i++)
            {
                if (slots[i] == null)
                {
                    slots[i] = rt;
                    return i;
                }
            }

            slots.Add(rt);
            return slots.Count - 1;
        }

        private void ReleaseSlot(int slot, RectTransform rt)
        {
            if (slot >= 0 && slot < slots.Count && slots[slot] == rt)
            {
                slots[slot] = null;
            }
        }
    }
}
