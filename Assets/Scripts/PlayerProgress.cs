using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI _levelValueTMP;
    public List<PlayerProgressLevel> levels; 

    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }
    
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;

        var grenadeCaster = GetComponent<GranadeCaster>();
        grenadeCaster.damage = currentLevel.grenadeDamage;

        if(currentLevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else
            grenadeCaster.enabled = true;
    }

    public void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2( _experienceCurrentValue  /_experienceTargetValue, 1);
        _levelValueTMP.text = _levelValue.ToString();
    }
}
