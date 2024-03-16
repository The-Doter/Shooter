using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100f;
    public RectTransform valueRectTransform;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private float _maxValue;


        void Start()
        {
            _maxValue = value;
            DrawHealthBar();
        }

    public void DealDamage(float damage)
    {

        value -= damage;
        if(value <= 0)
        {
            PlayerIsDead();
        }
        
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2( value  /_maxValue, 1);
    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
            gameOverScreen.SetActive(true);
            gameplayUI.SetActive(false);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
    }
}
