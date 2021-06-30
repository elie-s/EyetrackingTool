using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Tobii.Gaming;

namespace Elie.Tobii
{
    public static class Recorder
    {
        private static bool toggleStop = false;
        public static bool isRecording { get; private set; }
        public static float recordDuration { get; private set; }
        
        public static IEnumerator RecordRoutine(string _path)
        {
            isRecording = true;
            toggleStop = false;
            
            recordDuration = 0.0f;
            string tmpFile = Path.GetTempFileName();
            
            Debug.Log("Starting record.");
            Debug.Log(("Temp file: " + tmpFile));
            
            WriteFile(tmpFile, System.DateTime.Now.ToLongDateString() + "\n" + Screen.width + "x" + Screen.height);
            Application.runInBackground = true;
            
            
            while (!toggleStop)
            {
                GazeData gaze = new GazeData(recordDuration, TobiiAPI.GetGazePoint().Screen, TobiiAPI.GetGazePoint().Viewport);

                WriteFile(tmpFile, gaze.Encode());
                
                yield return null;
                recordDuration += Time.deltaTime;
            }
            
            Debug.Log("Stopping record.");
            isRecording = false;
            toggleStop = false;
            
            File.Copy(tmpFile, _path);
            Debug.Log("File created: "+_path);
            
            File.Delete(tmpFile);
            Debug.Log("Temp file deleted.");
            
        }

        public static void StopRecording()
        {
            if (isRecording) toggleStop = true;
        }
        
        private static async Task WriteFile(string _path, string _text)
        {
            using StreamWriter file = new StreamWriter(_path, append: true);
            await file.WriteLineAsync(_text);
        }
    }
}
