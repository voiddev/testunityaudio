using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BandGenarator : MonoBehaviour {

    public GameObject[] bands;

    public float[] bandsValue ;

    public float[] maxBandsValue ;

    AudioSource audio;


    float[] spectrum = new float[128];

    public int smoothRate = 20;

    int currentFrame = 0;
    int[] spectrumSteps = new int [] {3 , 3, 4, 4 , 16, 18, 24 , 56};
    //4 + 6 +8+ 12 +16+18+ 24 + 40




    void Start() {
        audio = GetComponent<AudioSource>();

        bandsValue = new float[bands.Length];
        maxBandsValue = new float[bands.Length];

    }

    void Update() {



        audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float max = spectrum[0];
        int specI = 0;
        int bandI = 0;

        for (int i = 0 ; i < spectrum.Length; i++) {

            if (max < spectrum[i]) {
                max = spectrum[i];
            }
            specI++;
            if (specI == spectrumSteps[bandI]) {
                bandsValue[bandI] = Mathf.Exp(max * (bandI + 1)) * 15;
                max = spectrum[i];
                bandI++;
                specI = 0;

                //                spectrumStep;
            }


        }


        for (int i = 0; i < bandsValue.Length; i++) {
            if (maxBandsValue[i] < bandsValue[i]) {
                maxBandsValue[i] = bandsValue[i];
            }
        }

        if (currentFrame++ < smoothRate) {

        } else {
            Debug.Log("Reset frame, currentFrame = " + currentFrame + " smoothRate=" + smoothRate);
            currentFrame = 0;


            updatePosition();

            for (int i = 0; i < maxBandsValue.Length;i++) {
                maxBandsValue[i] = 0;
            }
        }

        for (int i = 0; i < bands.Length;i++) {
            bands[i].transform.Translate(Vector3.down * 1f * Time.deltaTime, Space.World);
            bands[i].GetComponent<Renderer>().material.DOColor(Color.green, 4f);
        }
    }

    void updatePosition() {
        for (int i = 0; i < maxBandsValue.Length; i++) {
            animateBand(i, maxBandsValue[i]);
        }
    }

    void animateBand(int i, float value) {
        bands[i].transform.DOMoveY(value, 0.5f);
        if (value >= 20) {
            bands[i].GetComponent<Renderer>().material.DOColor(Color.red, 0.1f);
        }

    }
}
