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
        private bool [] _skills;


        public PlayerStats(float attack, float speed, float def)
        {
            _maxHealth = 100;
            _currentHealth = _maxHealth;
            _isDead = false;
            _attack = attack;
            _speed = speed;
            _def = def;
            _exp = 0;
            _maxExp = 25;
            _level = 1;
            _skills = new bool[3];
            _skills[0] = true;
            _skills[1] = false;
            _skills[2] = false;
        }

        public PlayerStats(float currentHealth, float maxHealth, bool isDead, float attack, float def, float speed, int exp, int maxExp, int level, bool[] skills)
        {
            _currentHealth = currentHealth;
            _maxHealth = maxHealth;
            _isDead = isDead;
            _attack = attack;
            _def = def;
            _speed = speed;
            _exp = exp;
            _maxExp = maxExp;
            _level = level;
            _skills = new bool [3];
            _skills[0] = skills[0];
            _skills[1] = skills[1];
            _skills[2] = skills[2];
        }

        public void getHit(float attack)
        {
            _currentHealth -= attack * (100/(100 + _def));
            if (_currentHealth <= 0 && _isDead == false)
            {
                Debug.Log("DEAD: " + _currentHealth);
                _isDead = true;

            }
        }

        public void setXP(int xp)
        {
            _exp = xp;
        }
        public void setLevel(int lvl)
        {
            _level = lvl;
        }

        public void setMaxXp(int maxXp)
        {
            _maxExp = maxXp;
        }

        public void setMaxHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public float getMaxHealth()
        {
            return _maxHealth;
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

        public void addXp(int xp)
        {
            _exp += xp;
        }

        public int getMaxXp()
        {
            return _maxExp;
        }

        public void needLevelup()
        {
            if (_exp >= _maxExp)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            _attack += 3;
            _def += 5;
            _maxHealth += 10;
            _currentHealth = _maxHealth;
            _exp = _exp - _maxExp; // Take carry over xp
            _maxExp += 10;
            _level += 1;
            GameObject.Find("XP_Bar").GetComponent<xpBar>().changeMaxVal(_maxExp);
            GameObject.Find("Health_Bar").GetComponent<healthBar>().changeMaxVal(_maxHealth);
            GameObject.Find("Level_Text").GetComponent<LevelText>().changeVal(_level);
            Debug.Log("Leveled up! Now level: " + _level);

            if(_level == 2) {
                _skills[1] = true;
            }
            if(_level == 3) {
                _skills[2] = true;
            }
        }

        public bool [] getSkills() {
            return _skills;
        }

        public bool getSkill(int i) {
            return _skills[i];
        }

        public void setSkill(int i, bool val) {
            _skills[i] = val;
        }
    }
}