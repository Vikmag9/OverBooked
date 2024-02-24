using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        int count = 5;

        while (count > 0)
        {
            Debug.Log("Countdown: " + count);
            yield return new WaitForSeconds(1f); // Vänta i 1 sekund
            count--;
        }

        SceneManager.LoadScene("Scenes/original");
    }
}
