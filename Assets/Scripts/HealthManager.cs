﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject[] chacaters;
    public float m_StartingHealth = 100f;               // The amount of health each tank starts with.
    public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
    public Image m_FillImage;                           // The image component of the slider.
    public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.

    [SerializeField]
    private float m_CurrentHealth;                      // How much health the tank currently has.
    private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?


    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        //m_FillImage = m_Slider.GetComponentInChildren<Image>();

        // Update the health slider's value and color.
        SetHealthUI();
    }


    public void TakeDamage(float amount)
    {
        // Reduce current health by the amount of damage done.
        m_CurrentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            OnDeath();
        }
    }


    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        m_Slider.value = m_CurrentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        m_Dead = true;

        for (int i = 0; i < chacaters.Length; i++)
        {
            if (chacaters[i] != null)
            {
                if (chacaters[i].name != this.name)
                {
                    PlayerPrefs.SetInt("winner", i);
                    if (chacaters[i].name == "YuraPlayer" || chacaters[i].name == "YuraIA")
                    {
                        if (PlayerPrefs.GetInt("mapSelected") == 0)
                        {
                            if (this.name == "YuraPlayer" || this.name == "YuraIA")
                            {
                                SceneManager.LoadScene("MirrorYuraMap1");
                            }
                            else
                            {
                                SceneManager.LoadScene("YuraWinMap1");
                            }
                        }
                        else
                        {
                            if (this.name == "YuraPlayer" || this.name == "YuraIA")
                            {
                                SceneManager.LoadScene("MirrorYuraMap2");
                            }
                            else
                            {
                                SceneManager.LoadScene("YuraWinMap2");
                            }
                        }
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("mapSelected") == 0)
                        {
                            if (this.name == "TamachiPlayer" || this.name == "TamachiIA")
                            {
                                SceneManager.LoadScene("MirrorTamachiMap1");
                            }
                            else
                            {
                                SceneManager.LoadScene("TamachiWinMap1");
                            }
                        }
                        else
                        {
                            if (this.name == "TamachiPlayer" || this.name == "TamachiIA")
                            {
                                SceneManager.LoadScene("MirrorTamachiMap2");
                            }
                            else
                            {
                                SceneManager.LoadScene("TamachiWinMap2");
                            }
                        }
                    }
                }
            }
        }
    }
}
