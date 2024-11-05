using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import this for Image

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] public Image ip;

    private bool stop_Game_input;
    private bool stop_Game;

    public float slow_Time;

    // Start is called before the first frame update
    void Start()
    {
        if (ip == null)
        {
            Debug.LogError("ip is not assigned in the Inspector");
        }
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
                time += Time.fixedDeltaTime;
                Time.timeScale = Mathf.Lerp(1f, 0f, time / slow_Time);
                yield return null;
            }
            Time.timeScale = 0f;
            Color img_Color = ip.color; // This line can throw an error if ip is null
            img_Color.a = 10;
            ip.color = img_Color;
        }
    }

}
