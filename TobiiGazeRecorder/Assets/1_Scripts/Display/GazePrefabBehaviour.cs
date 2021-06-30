using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Elie.Tobii
{
    public class GazePrefabBehaviour : MonoBehaviour
    {
        
        private RectTransform rectTransform => transform as RectTransform;
        private Vector2 anchoredPos = default;

        private void Update()
        {
            if (anchoredPos != rectTransform.anchoredPosition) rectTransform.anchoredPosition = anchoredPos;
        }

        public void SetAnchoredPosition(Vector2 _pos) => anchoredPos = _pos;
    }
}
