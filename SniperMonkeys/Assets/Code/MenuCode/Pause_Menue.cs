using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this for Image

public class Pause_Menu : MonoBehaviour
{
    PlayerMovementScript Pm_Script; // Assuming this is used elsewhere

    [SerializeField] public Image ip;

    private bool stop_Game_input;
    private bool stop_Game;

    public float slow_Time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stop_Game_input = Input.GetKeyDown(KeyCode.E);
        if (stop_Game_input)
        {
            Debug.Log("Stop"); 
            StartCoroutine(AwaitingUserInput());
        }
    }

    IEnumerator AwaitingUserInput()
    {
        if (stop_Game_input && !stop_Game)
        {
            stop_Game = true;
        }

        if (stop_Game)
        {
            float time = 0f;
            while (time < slow_Time)
            {
                time += Time.unscaledDeltaTime;
                Color img_Color = ip.color;
                img_Color.a = Mathf.Lerp(0f, 1f, time / slow_Time);
                ip.color = img_Color;

                Time.timeScale = Mathf.Lerp(1f, 0f, time / slow_Time);

                yield return null;
            }
            Time.timeScale = 0f; // Ensure the time scale is fully stopped
        }
    }
}
