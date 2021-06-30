using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Elie.Tobii
{
    public struct Record
    {
        public Vector2Int screen;
        public string date;
        public GazeData[] data;

        public Record(string _date, Vector2Int _screen, GazeData[] _data)
        {
            screen = _screen;
            date = _date;
            data = _data;
        }
        
        public Vector2 GetViewportPos(float _timecode)
        {
            if (_timecode <= 0.0f) return data[0].viewportPos;
            if (_timecode >= data[data.Length - 1].timecode) return data[data.Length - 1].viewportPos;

            int index = Mathf.RoundToInt(Mathf.Lerp(0, data.Length - 1,
                Mathf.InverseLerp(0.0f, data[data.Length - 1].timecode, _timecode)));
            

            while (!(data[index].timecode <= _timecode && _timecode < data[index+1].timecode))
            {
                if (data[index].timecode > _timecode) index--;
                else index++;
            }

            return Vector2.Lerp(data[index].viewportPos, data[index + 1].viewportPos,
                Mathf.InverseLerp(data[index].timecode, data[index + 1].timecode, _timecode));
        }
        
        public static Record Import(string _path)
        {
            string[] lines = File.ReadAllLines(_path);

            string date = lines[0];

            string[] screenTmp = lines[1].Split('x');
            Vector2Int screen = new Vector2Int(int.Parse(screenTmp[0]), int.Parse(screenTmp[1]));

            List<GazeData> data = new List<GazeData>();

            for (int i = 2; i < lines.Length-1; i++)
            {
                data.Add(GazeData.Decode(lines[i]));
            }

            return new Record(date, screen, data.ToArray());
        }
    }
}
