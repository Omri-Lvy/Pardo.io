using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Snail;
    [SerializeField] private GameObject Blue_Snail;
    [SerializeField] private GameObject Shroom;
    [SerializeField] private GameObject Mano;
    private int _lvl;
    private int _wave;
    private Level1 _lvl1;
    // private Level2 _lvl2;
    // private Level3 _lvl3;
    private float _timer;
    private Dictionary<String, GameObject> MOBS;
    private List<WaveMob> _lvlWave;


    // Start is called before the first frame update
    void Start()
    {
        _lvl = 1;
        _wave = 1;
        _lvl1 = new Level1();
        _timer = 0;
        MOBS = new Dictionary<string, GameObject>()
        {
            {"Snail",Snail},
            {"Blue_Snail",Blue_Snail},
            {"Shroom",Shroom},
            {"Mano",Mano},
        };
        _lvlWave = _lvl1.getWave(1);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += 1 * Time.deltaTime;
        if (_timer > 50)
        {
            _wave += 1;
            _lvlWave = _lvl1.getWave(_wave);
            _timer = 0;
        }
        if (_lvl < 3 && _wave <= 6 || _lvl == 3 && _wave <= 8)
        {
            handleSpwan();
        }
        else
        {
            _lvl++;
            _wave = 1;
            // if (_lvl == 2)
            // {
            //     _lvlWave = _lvl2.getWave(_wave);
            // }
            // else if (_lvl == 3)
            // {
            //     _lvlWave = _lvl3.getWave(_wave);
            // }
        }
       
    }

    void handleSpwan()
    {
        if (_lvl == 1)
        {
            if (_wave == 1)
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                }
            }
            else if (_wave == 2)
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        float xPos = Random.Range(-5.5f, 5.5f);
                        float yPos = Random.Range(-6f, 6f);
                        if (xPos < 0) xPos -= 4.6f;
                        else if (xPos >= 0) xPos += 4.6f;
                        if (yPos < 0) yPos -= 8.5f;
                        else if (yPos >= 0) yPos += 8.5f;
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                }
            }
            else if (_wave == 3)
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                }
            }
            else if (_wave == 4)
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                }
            }
            else if (_wave == 5)
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                }
            }
            else
            {
                foreach (WaveMob mob in _lvlWave)
                {
                    if (mob.getInterval() < _timer - mob.getLastInstantiate() &&  mob.getInstantiateCounter() <= mob.getMax())
                    {
                        Instantiate(MOBS[mob.getMonster()],new Vector3(getRandomX(), getRandomY(), 0), Quaternion.identity);
                        mob.increaseInstantiateCounter();
                        mob.setLastInstantiate(_timer);
                    }
                } 
            }
        } 
    }

    private float getRandomX()
    {
        float xPos = Random.Range(-5.5f, 5.5f);
        if (xPos < 0) xPos -= 4.6f;
        else if (xPos >= 0) xPos += 4.6f;
        return xPos;
        
    }

    private float getRandomY()
    {
        float yPos = Random.Range(-6f, 6f);
        if (yPos < 0) yPos -= 8.5f;
        else if (yPos >= 0) yPos += 8.5f;
        return yPos;
    }
}
