using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aeterponis
{
    public class OSManager : MonoBehaviour
    {
        public static OSManager instance;
        public Transform TextParent;
        public SpawnableText AITextPrefab;
        public SpawnableText PlayerTextPrefab;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public void InstantiateAIText(string t)
        {
            var text = Instantiate(AITextPrefab, Vector3.zero, Quaternion.identity);
            text.InitText(t, false);
        }

        public void InstantiateUserText(string t)
        {
            var text = Instantiate(AITextPrefab, Vector3.zero, Quaternion.identity);
            text.InitText(t, false);
        }
    }
}