using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button retryButton;
    [SerializeField] private Image fader;
    void Start()
    {
        retryButton = GetComponent<Button>();
        
        retryButton.onClick.AddListener(LoadNext);
    }

    public void LoadNext()
    {
        fader.gameObject.SetActive(true);
        fader.DOFade(1f, 1f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });
    }
}
