using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireChargeManager : MonoBehaviour
{
    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
    public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.


    public float m_CurrentHealth;                      // How much health the tank currently has.


    private void OnEnable()
    {
        m_CurrentHealth = 0;
        SetHealthUI();
    }

    private void Update()
    {
        LoadBar(0.03f);
    }

    public void LoadBar(float amount)
    {
        if (m_CurrentHealth < m_StartingHealth)
        {
            if (m_CurrentHealth + amount > m_StartingHealth)
            {
                m_CurrentHealth = m_StartingHealth;
            }
            else
            {
                m_CurrentHealth += amount;
            }
        }

        // Change the UI elements appropriately.
        SetHealthUI();
    }


    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = m_CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }
}
