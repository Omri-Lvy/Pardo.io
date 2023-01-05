using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Levels
{
    public class WaveMob : Component
    {
        private String _monster;
        private float _interval;
        private int _max;
        private float _lastInstantiate;
        private int _instantiateCounter;

        public WaveMob(String monster, float interval, int max)
        {
            _monster = monster;
            _interval = interval;
            _max = max;
            _lastInstantiate = 0;
            _instantiateCounter = 0;
        }

        public String getMonster()
        {
            return _monster;
        }
        public float getInterval()
        {
            return _interval;
        }
        public int getMax()
        {
            return _max;
        }

        public void setLastInstantiate(float time)
        {
            _lastInstantiate = time;
        }
        public float getLastInstantiate()
        {
            return _lastInstantiate;
        }
        public void increaseInstantiateCounter()
        {
            _instantiateCounter++;
        }
        public int getInstantiateCounter()
        {
            return _instantiateCounter;
        }
    }
    
}