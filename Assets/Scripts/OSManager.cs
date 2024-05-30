using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Aeterponis
{
    public class OSManager : MonoBehaviour
    {
        public GameStates state;
        public StateManager stateManager;

        public static OSManager instance;
        public Transform TextParent;
        public SpawnableText AITextPrefab;
        public SpawnableText PlayerTextPrefab;
        public int steps = 0;
        bool isGameUploaded = false;

        public List<SpawnableText> spawnedTexts;
        public TMP_InputField inputField;

        public Image game1_Ico;
        public Image game2_Ico;
        public Image game3_Ico;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            stateManager?.InitState();
        }

        private void Start()
        {
            SetGameIconFillAmount(GameStates.after1, game1_Ico);
            SetGameIconFillAmount(GameStates.after2, game1_Ico, game2_Ico);
            SetGameIconFillAmount(GameStates.final, game1_Ico, game2_Ico, game3_Ico);
        }

        private void SetGameIconFillAmount(GameStates targetState, params Image[] icons)
        {
            if (state == targetState)
            {
                foreach (var icon in icons)
                {
                    icon.fillAmount = 1;
                    icon.GetComponent<Button>().interactable = false;
                }
            }
        }


        public void InstantiateAIText(string t)
        {
            var text = Instantiate(AITextPrefab, Vector3.zero, Quaternion.identity);
            spawnedTexts.Add(text);
            text.InitText(t, false);
            text.transform.parent = TextParent;
        }

        public void InstantiateAIText(string t, bool b)
        {
            var text = Instantiate(AITextPrefab, Vector3.zero, Quaternion.identity);
            spawnedTexts.Add(text);
            text.InitText(t, false, b);
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
            if (steps > 3 && !isGameUploaded)
            {
                isGameUploaded = true;
                if (state == GameStates.start)
                {
                    InstantiateAIText("Çok pardon bölüyorum ama bilgisayarýna bir oyun gönderdim kesinlikle oyna ! Süren sýnýrlý");
                    StartCoroutine(StartImageFill(game1_Ico));
                }

                if (state == GameStates.after1)
                {
                    InstantiateAIText("Ýlk oyunu geçmiþtin deeeegggil mi?? Sýrada bu var! YUKLEDIM!");
                    StartCoroutine(StartImageFill(game2_Ico));
                }

                if (state == GameStates.after2)
                {
                    InstantiateAIText("CooOOkk azzzzzz kaldi :)) bunu da oyna bakalim");
                    StartCoroutine(StartImageFill(game3_Ico));
                }

                if (state == GameStates.final)
                {
                    InstantiateAIText("KAZANDIN");
                    InstantiateAIText("KAZAN");
                    InstantiateAIText("oynNAAAAAA");
                    InstantiateAIText("hahahah");
                    Invoke("ExitGame",2f);
                    
                }


                inputField.enabled = false;
            }
        }

        public void ExitGame()
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }

        float currentFill = 0;
        IEnumerator StartImageFill(Image _image)
        {
            _image.gameObject.SetActive(true);
            currentFill = 0;
            while (currentFill < 1)
            {
                currentFill += Time.deltaTime;
                _image.fillAmount = currentFill;
                yield return null;
            }

            _image.GetComponent<Button>().interactable = true;
            _image.fillAmount = 1;
            currentFill = 0;
        }

        public void LoadGameScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}