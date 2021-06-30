using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elie.Tobii
{
    public class RecordManager : MonoBehaviour
    {
        [SerializeField] private string recordPath = default;
        [SerializeField] private string recordName = "record";
        [SerializeField] private string recordExtension = "gr";
        [Header("Tests")]
        [SerializeField] private float recordDuration = 300;

        private string filePath => recordPath + "/" + recordName + "." + recordExtension;

        [ContextMenu("Start Record")]        
        private void StartRecord()
        {
            if (Recorder.isRecording) return;

            StartCoroutine(Recorder.RecordRoutine(filePath));

            if (recordDuration > 0.0f) StartCoroutine(StopRecordRoutine());
        }
        
        public void StartRecord(string _filePath)
        {
            if (Recorder.isRecording) return;

            StartCoroutine(Recorder.RecordRoutine(_filePath));
        }

        private IEnumerator StopRecordRoutine()
        {
            yield return new WaitForSeconds(recordDuration);
            
            StopRecord();
        }

        [ContextMenu("Stop")]
        public void StopRecord()
        {
            Recorder.StopRecording();
        }
        
    }
}
