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
        public int steps = 0;
        bool isGameUploaded = false;

        public List<SpawnableText> spawnedTexts;
        public TMP_InputField inputField;

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
            spawnedTexts.Add(text);
            text.InitText(t, false);
            text.transform.parent = TextParent;
        }

        public void InstantiateAIText(string t,bool b)
        {
            var text = Instantiate(AITextPrefab, Vector3.zero, Quaternion.identity);
            spawnedTexts.Add(text);
            text.InitText(t, false,b);
            text.transform.parent = TextParent;
        }

        public void InstantiateUserText(string t)
        {
            var text = Instantiate(PlayerTextPrefab, Vector3.zero, Quaternion.identity);
            spawnedTexts.Add(text);
            text.InitText(t, true);
            text.transform.parent = TextParent;
        }

        private void Update()
        {
            if (steps >3 && !isGameUploaded)
            {
               /* for (int i = 0; i < spawnedTexts.Count; i++)
                {
                    Destroy(spawnedTexts[i]);
                }

                spawnedTexts.Clear();*/

                isGameUploaded = true;
                InstantiateAIText("Çok pardon bölüyorum ama bilgisayarýna bir oyun gönderdim kesinlikle oyna ! Süren sýnýrlý");
                inputField.enabled = false;
            }
        }
    }
}