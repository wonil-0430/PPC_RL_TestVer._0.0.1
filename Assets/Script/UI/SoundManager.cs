using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI MusicVol;

    [SerializeField]
    private TextMeshProUGUI EffectVol;

    public void MusicOnSliderEvent(float value)
    {
        MusicVol.text = $"{value*5}%";
    }

    public void EffectOnSliderEvent(float value)
    {
        EffectVol.text = $"{value*5}%";
    }
}
