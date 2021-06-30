using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Elie.Tobii
{
    public class RecordVideoPlayer : MonoBehaviour
    {
        [SerializeField] private RecordsImporter importer = default;
        [SerializeField] private RawImage displayer = default;
        [SerializeField] private VideoPlayer player = default;
        [SerializeField] private VideoClip clip = default;
        [SerializeField] private RenderTexture texture = default;
        [SerializeField] private RecordDisplayer gazeDisplayer = default;
        [SerializeField] private float timeCorrection = 0.0f;
        [SerializeField, Range(0.0f, 1.0f)] private float recordProgress = 0.0f;
        
        private RectTransform rectTransform => transform as RectTransform;
        private int gazeDisplayerIndex;

        private void StartClip()
        {
            SetTextureSize();
            SetWindowSize();
            gazeDisplayerIndex = gazeDisplayer.RegisterGaze();
        }
        
        private void SetTextureSize()
        {
            texture.width = (int)clip.width;
            texture.height = (int)clip.height;
        }

        private void SetWindowSize()
        {
            rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
        }

        private float GetTimecode()
        {
            return (float)player.time + timeCorrection;
        }

        private void HandleGaze()
        {
            gazeDisplayer.UpdateGaze(gazeDisplayerIndex, importer.Record.GetViewportPos(GetTimecode()));
        }
    }
}
