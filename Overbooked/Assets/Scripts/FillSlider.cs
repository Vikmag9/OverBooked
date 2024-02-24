using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FillSlider : MonoBehaviour
{
    public Slider slider;
    public float fillDuration = 5f;
    private float targetFill = 1f;

    void Start()
    {
        StartCoroutine(FillSliderOverTime());
    }

    IEnumerator FillSliderOverTime()
    {
        float timer = 0f;
        float startFill = slider.value;

        while (timer < fillDuration)
        {
            timer += Time.deltaTime;
            float fillAmount = Mathf.Lerp(startFill, targetFill, timer / fillDuration);
            slider.value = fillAmount;
            yield return null;
        }

        slider.value = targetFill;
        SceneManager.LoadScene("Scenes/original");
    }
}
