using UnityEngine;
using UnityEngine.UI;

public class DoubtMeter : MonoBehaviour
{
    public Slider doubtSlider;
    public float maxDoubt = 100f;
    [Range(0, 100)] public float doubt = 0f;   // current doubt

    void Start()
    {
        doubtSlider.minValue = 0f;
        doubtSlider.maxValue = maxDoubt;
    }

    void Update()
    {
        doubtSlider.value = doubt;
    }

    public void AddDoubt(float amount)
    {
        doubt = Mathf.Clamp(doubt + amount, 0f, maxDoubt);

        if (doubt >= maxDoubt)
        {
            Debug.Log("Doubt is full!");   // game over, effects, etc.
        }
    }

    public void ReduceDoubt(float amount)
    {
        AddDoubt(-amount);
    }
}