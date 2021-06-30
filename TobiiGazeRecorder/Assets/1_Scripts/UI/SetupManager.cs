using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Elie.Tobii
{
    public class SetupManager : MonoBehaviour
    {
        
        [SerializeField] private RecordManager recordManager = default;
        [SerializeField] private TMP_InputField pathInput = default;
        [SerializeField] private Image pathIndicator = default;
        [SerializeField] private TMP_InputField nameInput = default;
        [SerializeField] private Image nameIndicator = default;
        [SerializeField] private Button startButton = default;
        [Header("Settings")]
        [SerializeField] private Color validColor = default;
        [SerializeField] private Color invalidColor = default;
        [SerializeField] private string fileExtension = "gr";

        public string filePath => GetPath() + nameInput.text + "." + fileExtension;
        
        void Update()
        {
            UpdateColors();
            UpdateButton();
        }

        private void UpdateColors()
        {
            if (CheckPath()) pathIndicator.color = validColor;
            else pathIndicator.color = invalidColor;

            if (CheckFile()) nameIndicator.color = validColor;
            else nameIndicator.color = invalidColor;
        }

        private void UpdateButton()
        {
            startButton.interactable = CheckFile();
        }

        private bool CheckPath()
        {
            if (pathInput.text.Length == 0) return false;
            return Directory.Exists(GetPath());
        }

        private bool CheckFile()
        {
            if (!CheckPath() || nameInput.text.Length == 0) return false;
            return !File.Exists(filePath);
        }

        private string GetPath()
        {
            string result = pathInput.text;

            if (result[result.Length - 1] != '/' && result[result.Length - 1] != '\\') result += "/";

            return result;
        }
    }
}
