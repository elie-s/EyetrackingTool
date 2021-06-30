using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

namespace Elie.Tobii
{
    public class GazeDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject gazePrefab = default;

        private GazePrefabBehaviour gazePrefabBehaviour;

        private void OnEnable()
        {
            gazePrefabBehaviour = Instantiate(gazePrefab, transform).GetComponent<GazePrefabBehaviour>();
        }

        private void Update()
        {
            gazePrefabBehaviour.SetAnchoredPosition(TobiiAPI.GetGazePoint().Screen);
        }
    }
}
