﻿using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _level;
    private int _currentHp;
    private int _maxHp;
    private readonly float _damageCooldown = 1f;
    private bool _canTakeDamage;

    public MeshRenderer cubeMesh;
    public void Initialize(int level)
    {
        SetLevel(level);
        SetHp();
        SetDamageStatus();
        SetColor();
    }

    private void SetLevel(int level)
    {
        _level = level;
    }

    private void SetHp()
    {
        _maxHp = _level * 3;
        _currentHp = _maxHp;
    }

    private void SetDamageStatus()
    {
        _canTakeDamage = true;
    }

    private void SetColor()
    {
        float healthRatio = _currentHp / (float) _maxHp;
        if (healthRatio > .7f)
        {
            cubeMesh.material.color = Color.green;
        }
        else if (healthRatio <= .7f && healthRatio >= .4f)
        {
            cubeMesh.material.color = Color.yellow;
        }
        else if (healthRatio <= .4f)
        {
            cubeMesh.material.color = Color.red;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") || !_canTakeDamage) return;

        _canTakeDamage = false;
        ProcessHit();
        StartCoroutine(Countdown());
    }

    private void ProcessHit()
    {
        _currentHp--;
        SetColor();
        if (_currentHp <= 0)
        {
            ObjectPool.Instance.Recycle(gameObject);
        }
    }
    
    private IEnumerator Countdown()
    {
        float duration = _damageCooldown;
        float normalizedTime = 0;
        while(normalizedTime <= _damageCooldown)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        yield return _canTakeDamage = true;
    }
}
