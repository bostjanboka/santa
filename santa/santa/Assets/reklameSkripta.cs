﻿using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using GoogleMobileAds.Api;
#endif
public class reklameSkripta : MonoBehaviour {

	// Use this for initialization


    public static bool showReklamo = false;
    public static bool naloziReklamo = false;
    public static bool showReklamoZak = false;
    

    float casZak = 1;
#if UNITY_ANDROID
    InterstitialAd interstitial;
    AdRequest request;
#endif

   

    void Start () {
        // mojspace.Class1.konstruktor("ca-app-pub-6604259944075538/1324230402", true);

        //mojspace.Class1.loadCelozaslonsko();

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6604259944075538/8259277603";
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        // request = new AdRequest.Builder()
        //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        //.AddTestDevice("336FD7F4CE3A8503")  // My test device.
        //.Build();


        interstitial.LoadAd(request);
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif




    }

    // Update is called once per frame
    void Update () {
        if (showReklamo)
        {
            showReklamo = false;
            
            //mojspace.Class1.showCelozaslonsko();
#if UNITY_ANDROID
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
#endif
            Debug.Log("show celo");
        }

        if (showReklamoZak)
        {
            casZak -= Time.deltaTime;
            if(casZak < 0)
            {
                showReklamoZak = false;
                showReklamo = true;
                casZak = 1;
            }
        }

        if (naloziReklamo)
        {
            //mojspace.Class1.loadCelozaslonsko();
            naloziReklamo = false;
#if UNITY_ANDROID
            interstitial.LoadAd(request);
            
#endif
            Debug.Log("nalozi reklamo");
        }
       
	}
}
