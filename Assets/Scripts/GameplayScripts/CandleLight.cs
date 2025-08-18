using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoT.Interfaces;
using JetBrains.Annotations;
using Unity.VisualScripting.ReorderableList;

public class CandleLight : MonoBehaviour
{
    Light _candleLight;

    float
        _candleLightTimer,
        _maxCandleLightRadius = 50f;

    public float candleDisplayTime {  get; private set; }

    private void Start()
    {
        _candleLight = GetComponent<Light>();

        if (CandleLightTimer(true, 300))
            Debug.Log("Candle Dead");
    }

    private void Update()
    {
        if (CandleLightTimer())
            DeathByDarkness();
    }

    public bool CandleLightTimer(bool startTimer = false, float cooldownTime = 0)
    {
        if (startTimer)
        {
            _candleLightTimer += cooldownTime;

            if (_candleLightTimer > 300)
                _candleLightTimer = 300;
        }
            
        if (_candleLightTimer > 0)
        {
            _candleLightTimer -= Time.deltaTime;

            candleDisplayTime = Mathf.RoundToInt(_candleLightTimer);

            float candleLifePercentage = (_candleLightTimer / 300) * 100;

            _candleLight.spotAngle = (candleLifePercentage / 100) * _maxCandleLightRadius;
        }

        else
        {
            candleDisplayTime = 0;
            _candleLight.spotAngle = 0;

            return true;
        }

        return false;
    }

    void DeathByDarkness()
    {
        Debug.Log("The shadows close in… your last candle flickers out, swallowed by the endless darkness.");

        gameObject.SetActive(false);
    }
}
