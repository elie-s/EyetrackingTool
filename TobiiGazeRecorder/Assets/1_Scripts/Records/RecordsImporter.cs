using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Elie.Tobii
{
    public class RecordsImporter : MonoBehaviour
    {
        [SerializeField] private string path;

        private Record record;

        public Record Record => record;

        public bool Import(string _path)
        {
            if (File.Exists(_path))
            {
                record = Record.Import(_path);
                return true;
            }

            return false;
        }
    }
}
