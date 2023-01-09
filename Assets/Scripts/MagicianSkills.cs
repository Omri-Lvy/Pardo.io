using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianSkills : MonoBehaviour
{
    private bool _skill1, _skill2, _skill3;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject firepillar;
    [SerializeField] private GameObject poisionCloud;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1") && _skill1) {
            Fireball();
        }
        if(Input.GetKeyDown("2") && _skill2) {
            Firepillar();
        }
        if(Input.GetKeyDown("3") && _skill3) {
            PoisionCloud();
        }
    }

    private void Fireball() {
        Instantiate(fireball, )
    }
    
}
