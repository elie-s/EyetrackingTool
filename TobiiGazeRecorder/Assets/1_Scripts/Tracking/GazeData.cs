using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elie.Tobii
{
    public struct GazeData
    {
        public float timecode;
        public Vector2 screenPos;
        public Vector2 viewportPos;

        public GazeData(float _timeCode, Vector2 _screenPos, Vector2 _viewportPos)
        {
            timecode = _timeCode;
            screenPos = _screenPos;
            viewportPos = _viewportPos;
        }

        public string Encode()
        {
            return "<" + timecode + "|" + screenPos.x + ";" + screenPos.y + "|" + viewportPos.x + ";" +
                   viewportPos.y + ">";
        }

        

        public static GazeData Decode(string _line)
        {
            string[] data = _line.Replace("<", "").Replace(">", "").Split('|');
            string[] dataScreen = data[1].Split(';');
            string[] dataViewport = data[2].Split(';');

            float timecode = float.Parse(data[0]);
            Vector2 screenPos = new Vector2(float.Parse(dataScreen[0]), float.Parse(dataScreen[1]));
            Vector2 viewportPos = new Vector2(float.Parse(dataViewport[0]), float.Parse(dataViewport[1]));

            return new GazeData(timecode, screenPos, viewportPos);
        }
    }
}
