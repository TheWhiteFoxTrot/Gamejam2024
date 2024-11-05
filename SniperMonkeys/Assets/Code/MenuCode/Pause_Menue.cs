using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] public Image ip;
    [SerializeField] public Image boarder; // Border image to be faded
    [SerializeField] public Button continueButton; // Continue button
    [SerializeField] public Button quitButton; // Quit button

    private bool stop_Game;
    private bool menu_is_Open;
    public float slow_Time = 1f; // Default value, can be adjusted in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        if (ip == null)
        {
            Debug.LogError("ip is not assigned in the Inspector");
        }

        // Ensure buttons and border are initially hidden
        continueButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        boarder.color = new Color(boarder.color.r, boarder.color.g, boarder.color.b, 0f);

        // Add listeners for button functionality
        continueButton.onClick.AddListener(() => StartCoroutine(StartingGame()));
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed"); // Add this line for debugging
            if (!menu_is_Open)
            {
                StartCoroutine(AwaitingUserInput());
            }
            else
            {
                StartCoroutine(StartingGame());
            }
        }
    }

    IEnumerator AwaitingUserInput()
    {
        if (!stop_Game && !menu_is_Open)
        {
            stop_Game = true;
            float time = 0f;

            // Show buttons before starting animation
            continueButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);

            while (time < slow_Time)
            {
                time += Time.unscaledDeltaTime;
                Color img_Color = ip.color;
                Color boarder_Color = boarder.color;
                img_Color.a = Mathf.Lerp(0f, 0.5f, time / slow_Time);
                boarder_Color.a = Mathf.Lerp(0f, 0.5f, time / slow_Time);
                ip.color = img_Color;
                boarder.color = boarder_Color;
                Time.timeScale = Mathf.Lerp(1f, 0f, time / slow_Time);

                // Fade in buttons
                Color buttonColor = continueButton.image.color;
                buttonColor.a = Mathf.Lerp(0f, 1f, time / slow_Time);
                continueButton.image.color = buttonColor;
                quitButton.image.color = buttonColor;

                yield return null; // Prevent freezing
            }

            Time.timeScale = 0f;
            menu_is_Open = true;
            stop_Game = false;
        }
    }

    IEnumerator StartingGame()
    {
        if (menu_is_Open)
        {
            float time = 0f;

            while (time < slow_Time)
            {
                time += Time.unscaledDeltaTime;
                Color img_Color = ip.color;
                Color boarder_Color = boarder.color;
                img_Color.a = Mathf.Lerp(0.5f, 0f, time / slow_Time);
                boarder_Color.a = Mathf.Lerp(0.5f, 0f, time / slow_Time);
                ip.color = img_Color;
                boarder.color = boarder_Color;
                Time.timeScale = Mathf.Lerp(0f, 1f, time / slow_Time);

                // Fade out buttons
                Color buttonColor = continueButton.image.color;
                buttonColor.a = Mathf.Lerp(1f, 0f, time / slow_Time);
                continueButton.image.color = buttonColor;
                quitButton.image.color = buttonColor;

                yield return null; // Prevent freezing
            }

            // Hide buttons after animation
            continueButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);

            Time.timeScale = 1f;
            menu_is_Open = false;
        }
    }

    void QuitGame()
    {
        // Handle quitting logic here
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}