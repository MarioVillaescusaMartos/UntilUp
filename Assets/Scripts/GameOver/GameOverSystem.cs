using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSystem : MonoBehaviour
{
    private PlayerHealthSystem _healthSystem;

    [SerializeField]
    private GameObject gameOverDisplayUI;

    private void Awake()
    {
        _healthSystem = GetComponent<PlayerHealthSystem>();
    }

    private void OnEnable()
    {
        _healthSystem.OnHealthZero += ShowGameOcerDisplay;
    }

    private void OnDisable()
    {
        _healthSystem.OnHealthZero -= ShowGameOcerDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGameOcerDisplay()
    {
        if (!GameOverManager.notShowGameOver)
        {
            gameOverDisplayUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOverDisplayUI.SetActive(false);
        }
    }
}
