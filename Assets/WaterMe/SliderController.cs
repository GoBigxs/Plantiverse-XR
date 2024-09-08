using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider loadingBar;            // Reference to the slider
    public ParticleSystem waterEffect;   // Reference to the particle system
    public Image smileEmoji;             // Reference to the smile emoji image
    public float loadingDuration = 3f;   // Time in seconds for the slider to fill

    public bool isFilling = false;
    private float fillTime = 0f;

    private void Start()
    {
        // Set initial states
        loadingBar.value = 0;
        smileEmoji.gameObject.SetActive(false); // Hide the smile emoji at the start
    }

    private void Update()
    {
        if (isFilling)
        {
            waterEffect.Play();
            // Increment the fill time based on elapsed time
            fillTime += Time.deltaTime;

            // Calculate the fill amount based on elapsed time and duration
            float fillAmount = Mathf.Clamp01(fillTime / loadingDuration);

            // Set the slider value
            loadingBar.value = fillAmount;

            // Stop the water effect and show emoji when the slider is full
            if (fillAmount >= 1)
            {
                StopWaterEffect();
                ShowEmoji();
            }
        }
    }

    private void StopWaterEffect()
    {
        // Stop the water effect and reset filling state
        waterEffect.Stop();
        isFilling = false;
    }

    private void ShowEmoji()
    {
        // Show the smile emoji when the slider fills to 100%
        smileEmoji.gameObject.SetActive(true);
    }
}
