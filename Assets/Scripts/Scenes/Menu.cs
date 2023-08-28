#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace Arkanoid
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        private void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClick);
            exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnStartButtonClick()
        {
            SceneManager.LoadScene("Game");
        }

        private void OnExitButtonClick()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif

            Application.Quit();
        }
    }
}