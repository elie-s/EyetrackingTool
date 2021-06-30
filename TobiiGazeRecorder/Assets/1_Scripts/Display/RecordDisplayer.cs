using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elie.Tobii
{
    public class RecordDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject gazePrefab = default;

        private RectTransform rectTransform => transform as RectTransform;
        
        private Dictionary<int, GazePrefabBehaviour> gazes = new Dictionary<int, GazePrefabBehaviour>();
        private int id = 0;

        public int RegisterGaze()
        {
            gazes.Add(id, Instantiate(gazePrefab, transform).GetComponent<GazePrefabBehaviour>());
            id++;

            return id - 1;
        }

        public void Unregister(int _id)
        {
            GazePrefabBehaviour gaze = gazes[_id];
            gazes.Remove(_id);
            Destroy(gaze.gameObject);
        }

        public void UpdateGaze(int _id, Vector2 _viewportPos)
        {
            Vector2 pos = new Vector2(rectTransform.sizeDelta.x * _viewportPos.x,
                rectTransform.sizeDelta.y * _viewportPos.y);
            
            gazes[_id].SetAnchoredPosition(pos);
        }
    }
}
