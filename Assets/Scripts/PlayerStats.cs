using System;
using UnityEngine;

namespace Scripts
{
    public class PlayerStats : Component
    {
        private float _currentHealth;
        private float _maxHealth;
        private bool _isDead;
        private float _attack;
        private float _def;
        private float _speed;
        private int _exp;
        private int _maxExp;
        private int _level;

        public PlayerStats()
        {
            _maxHealth = 100;
            _currentHealth = _maxHealth;
            _isDead = false;
        }
        public PlayerStats(float attack, float speed, float def)
        {
            _maxHealth = 100;
            _currentHealth = _maxHealth;
            _isDead = false;
            _attack = attack;
            _speed = speed;
            _def = def;
            _exp = 0;
            _maxExp = 100;
            _level = 1;
        }

        public void getHit(float attack)
        {
            _currentHealth -= attack * (1 - _def / 100);
            if (_currentHealth <= 0 && _isDead == false)
            {
                Debug.Log("DEAD: " + _currentHealth);
                _isDead = true;

            }
        }

        public void setCurrenthealth(float newHealth)
        {
            _currentHealth = Math.Min(_maxHealth, newHealth);
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
        public bool isDead()
        {
            return _isDead;
        }

        public int getLevel()
        {
            return _level;
        }
        public int getXp()
        {
            return _exp;
        }

        public bool needLevelup()
        {
            if (_exp >= _maxExp)
            {
                return true;
            }
            return false;
        }

        public void LevelUp()
        {
            _attack += 3;
            _def += 5;
            _maxHealth += 10;
            _currentHealth = _maxHealth;
            _exp = 0;
            _level = _level + 1;
        }

        public void addXp(int xp)
        {
            _exp = +xp;
        }
    }
}