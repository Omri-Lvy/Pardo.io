using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Levels;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Canvas CanvasPrefab;
    [SerializeField] private GameObject Pardo;
    [SerializeField] private GameObject PardoMage;
    [SerializeField] private GameObject PardoArcher;
    [SerializeField] private GameObject PardoAssassin;
    [SerializeField] private GameObject Job_Menu;
    [SerializeField] private GameObject Snail;
    [SerializeField] private GameObject Blue_Snail;
    [SerializeField] private GameObject Shroom;
    [SerializeField] private GameObject Mano;
<<<<<<< Updated upstream
    [SerializeField] private GameObject Red_Snail;
    [SerializeField] private GameObject Orange_Mashroom;
    [SerializeField] private GameObject Blue_Mashroom;
    [SerializeField] private GameObject Pig;
    [SerializeField] private GameObject Renegade_Shroom;
    [SerializeField] private GameObject Mushmom;
    [SerializeField] private GameObject Ribbon_Pig;
    [SerializeField] private GameObject Slime;
    [SerializeField] private GameObject Green_Mashroom;
    [SerializeField] private GameObject Fairy;
    [SerializeField] private GameObject King_Slime;
=======
    
    private GameObject CanvasInstance;
>>>>>>> Stashed changes
    private int _lvl;
    private int _wave;
    private float _timer;
    private Dictionary<String, GameObject> MOBS;
    private List<WaveMob> _lvlWave;
<<<<<<< Updated upstream
    private Levels _levels;
=======
    private CanvasGroup _canvasgroup;
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
        _lvl = 1;
        _wave = 1;
        _levels = new Levels();
        _timer = 0;
        MOBS = new Dictionary<string, GameObject>()
        {
            {"Snail",Snail},
            {"Blue_Snail",Blue_Snail},
            {"Shroom",Shroom},
            {"Mano",Mano},
            {"Red_Snail",Red_Snail},
            {"Orange_Mashroom",Orange_Mashroom},
            {"Blue_Mashroom",Blue_Mashroom},
            {"Pig",Pig},
            {"Renegade_Shroom",Renegade_Shroom},
            {"Mushmom",Mushmom},
            {"Ribbon_Pig",Ribbon_Pig},
            {"Slime",Slime},
            {"Green_Mashroom",Green_Mashroom},
            {"Fairy",Fairy},
            {"King_Slime",King_Slime}
        };
        _lvlWave = _levels.getWave(_lvl,_wave);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
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
        }
       
    }

    void handleSpwan()
    {
        if (_levels.getIsBoss(_lvl))
        {
            GameObject[] mobs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject mob in mobs)
            {
                Destroy(mob);
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

    private float getRandomX() {
        float xPos = Random.Range(-5.5f, 5.5f);
        if (xPos < 0) xPos -= 4.6f;
        else if (xPos >= 0) xPos += 4.6f;
        return xPos;
    }

    private float getRandomY() {
        float yPos = Random.Range(-6f, 6f);
        if (yPos < 0) yPos -= 4.6f;
        else if (yPos >= 0) yPos += 4.6f;
        return yPos;
    }

    public void selectCharacter(int i) {
        
        Debug.Log(i);
        GameObject pardo = GameObject.FindGameObjectWithTag("Player");

        Vector3 currentPosition = pardo.transform.position;
        Quaternion currentRotation = pardo.transform.rotation;

        Destroy(pardo);

        GameObject chosenPardo = Pardo;

        if (i == 1) {
            chosenPardo = PardoMage;
        } else if (i == 2) {
            chosenPardo = PardoArcher;
        } else if (i == 3) {
            chosenPardo = PardoAssassin;
        }

        GameObject selectedPardo = Instantiate(chosenPardo, currentPosition, currentRotation);
        pardo.transform.position = currentPosition;
        pardo.transform.rotation = currentRotation;

    }

    public void resume() {
        
        _canvasgroup.alpha = 0f;
        _canvasgroup.interactable = false;
      
        Time.timeScale = 1f;
        //GameObject.FindGameObjectWithTag("Player").GameObject.setActive(false);
    }

}
