using System;
using UnityEngine;

namespace Scripts
{
    public class EnemyStats : Component
    {
        private const int MAX_HEALTH = 100;
        private float _currentHealth;
        private bool _isDead;
        private float _attack;
        private float _def;
        private float _speed;
        private bool _isHit;
        private int _xpGiven;

        public EnemyStats()
        {
            _currentHealth = MAX_HEALTH;
            _isDead = false;
        }
        public EnemyStats(float attack, float speed, float def, float health, int xpGiven)
        {
            _currentHealth = health;
            _isDead = false;
            _attack = attack;
            _speed = speed;
            _def = def;
            _xpGiven = xpGiven;
        }

        public void getHit(float attack)
        {
            _currentHealth -= attack * (1 - _def / 100);
            _isHit = true;
            if (_currentHealth <= 0 && _isDead == false)
            {
                Debug.Log("DEAD: " + _currentHealth);
                _isDead = true;
            }
        }

        public void setCurrenthealth(float newHealth)
        {
            _currentHealth = Math.Min(MAX_HEALTH, newHealth);
        }
        public float getCurrentHealth()
        {
            return _currentHealth;
        }

        public void setAttack(float newAttack)
        {
            _attack = newAttack;
        }
        public float getAttack()
        {
            return _attack;
        }

        public void setDef(float newDef)
        {
            _def = newDef;
        }
        public float getDef()
        {
            return _def;
        }

        public void setSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }
        public float getSpeed()
        {
            return _speed;
        }

        public void setIsDead(bool isDead)
        {
            _isDead = isDead;
        }

        public void setIsHit(bool hit)
        {
            _isHit = hit;
        }

        public bool getIsHit()
        {
            return _isHit;
        }
        public bool isDead()
        {
            return _isDead;
        }
    }
}