using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private Button closeButton;

        [Inject] private EventsManager eventsManager;

        private void Start()
        {
            closeButton.onClick.AddListener(OnCloseButtonClick);
            eventsManager.AddListener(GameEvents.WinGame, OnWinGame);
            eventsManager.AddListener(GameEvents.LoseGame, OnLoseGame);
        }

        private void OnCloseButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }

        private void OnWinGame(object[] args)
        {
            winPanel.SetActive(true);
        }

        private void OnLoseGame(object[] args)
        {
            losePanel.SetActive(true);
        }
    }
}