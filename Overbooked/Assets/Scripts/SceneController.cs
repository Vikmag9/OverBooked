using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public int sceneID;
    public void StartGame()
    {
        StartCoroutine(LoadGameSequence());
    }

    private IEnumerator LoadGameSequence()
    {
        // Ladda scen 2 (laddningsskärmen)
        SceneManager.LoadScene("turtorial");

        // Vänta i 5 sekunder
        yield return new WaitForSeconds(3f);

        // Ladda scen 3 (spelet)
        MoveToScene(sceneID);
    }

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
