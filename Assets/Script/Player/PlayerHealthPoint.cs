using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPoint : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField]
    private GameObject gameOver;
    public void GetHitDamage(float damage, ref float health, ref int reviveCount)
    {
        if (health == 0) return;

        health -= damage;

        if (health <= 0)
        {
            health = 0;

            if (reviveCount <= 0)
            {

                PlayerDead();
            }
            else
            {
                PlayerRevive(ref health);
                reviveCount--;
            }

        }

        StopAllCoroutines();
        StartCoroutine(HitSpriteCoroutine());

        UpdateHealthPointImage(health);
    }
    private void UpdateHealthPointImage(float curhealthpoint)
    {
        hpImage.fillAmount = curhealthpoint / GetComponent<MainCharacterScript>().playerInfomation.maxHp;
    }

    private void PlayerDead()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    private void PlayerRevive(ref float health)
    {
        Debug.Log("Player Revive");

        health = GetComponent<MainCharacterScript>().playerInfomation.maxHp / 2.0f;
    }

    private IEnumerator HitSpriteCoroutine() // 피격시 색깔 시뻘건색 되는거
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }
}
 