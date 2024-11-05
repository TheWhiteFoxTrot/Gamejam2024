using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Start_Menu : MonoBehaviour
{
    [SerializeField] public Image ip;

    public void StartButton()
    {
        StartCoroutine(Start_Fade());
    }

    public void QuitButton()
    {
        StartCoroutine(Quit_Fade());
    }

    IEnumerator Start_Fade()
    {
        float Elapsedtime = 0;
        float Duriashon = 1;

        while (Elapsedtime < Duriashon)
        {
            Color imge_Color = ip.color;
            imge_Color.a = Mathf.Lerp(0f, 1f, Elapsedtime / Duriashon);
            ip.color = imge_Color;
            Elapsedtime += Time.fixedDeltaTime;
            yield return null;
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator Quit_Fade()
    {
        float Elapsedtime = 0;
        float Duriashon = 1;

        while (Elapsedtime < Duriashon)
        {
            Color imge_Color = ip.color;
            imge_Color.a = Mathf.Lerp(0f, 1f, Elapsedtime / Duriashon);
            ip.color = imge_Color;
            Elapsedtime += Time.fixedDeltaTime;
            yield return null;
        }
        Application.Quit();
    }

}
