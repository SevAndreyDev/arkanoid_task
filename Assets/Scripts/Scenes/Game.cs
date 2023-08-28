using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        
        private void Start()
        {
            closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}