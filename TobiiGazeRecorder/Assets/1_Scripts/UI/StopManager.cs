using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Elie.Tobii
{
    public class StopManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer = default;

        // Update is called once per frame
        void Update()
        {
            SetTimer();
        }

        private void SetTimer()
        {
            float s = 0.0f;
            float m = 0.0f;
            float h = 0.0f;

            h = Mathf.FloorToInt(Recorder.recordDuration / 3600.0f);
            m = Mathf.FloorToInt(Recorder.recordDuration / 60.0f) - h * 60;
            s = Mathf.FloorToInt(Recorder.recordDuration) - h * 3600 - m * 60;

            string hours = h > 9 ? h.ToString() : "0" + h.ToString();
            string min = m > 9 ? m.ToString() :  "0" + m.ToString();
            string sec = s > 9 ? s.ToString() : "0" + s.ToString();

            timer.text = hours + ":" + min + ":" + sec;
            
        }
    }
}
