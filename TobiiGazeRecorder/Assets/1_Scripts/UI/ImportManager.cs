using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Elie.Tobii
{
    public class ImportManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField pathInput = default;
        [SerializeField] private Image pathIndicator = default;
        [SerializeField] private Button startButton = default;
        [SerializeField] private RecordsImporter importer = default;
        [Header("Settings")]
        [SerializeField] private Color validColor = default;
        [SerializeField] private Color invalidColor = default;

        private void Update()
        {
            UpdateColors();
            UpdateButton();
        }

        private void UpdateColors()
        {
            if (CheckFile()) pathIndicator.color = validColor;
            else pathIndicator.color = invalidColor;
        }
        
        private void UpdateButton()
        {
            startButton.interactable = CheckFile();
        }
        
        private bool CheckFile()
        {
            if (pathInput.text.Length == 0) return false;
            return File.Exists(pathInput.text) && pathInput.text.Contains(".gr");
        }

        public void Import()
        {
            importer.Import(pathInput.text);
            Debug.Log("File successfully imported.");
            Debug.Log(importer.Record.date+" - "+importer.Record.data.Length+" gazes recorded.");
        }
    }
}
