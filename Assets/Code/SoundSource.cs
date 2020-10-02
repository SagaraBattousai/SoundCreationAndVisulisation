using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundSource : MonoBehaviour {

    private AudioSource audioSource;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float[] spectrum = GetAudioFrequencyHistogram();
        meshRenderer.material.color = new Color(Utils.SumArray(spectrum, 0, 85), Utils.SumArray(spectrum, 85, 170), Utils.SumArray(spectrum, 170, 256));

        Debug.Log(spectrum.Min() + "  -  " + spectrum.Max());



    }

    private float[] GetAudioFrequencyHistogram(int samples = 256)//, int sampleRate = 0)
    {

        float[] spectrum = new float[samples];

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        return spectrum.Select(spec => Mathf.Log(spec + 10, 2)).ToArray();
    }
}
