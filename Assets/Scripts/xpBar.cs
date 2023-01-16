using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpBar : MonoBehaviour
{
    private Slider _slider;
    private GameObject _player;
    private int _maxVal;
    private int _currVal;
    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _slider.GetComponent<Slider>().maxValue = 25; // This needs to be set to level 1 max exp value.
        _slider.GetComponent<Slider>().value = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _currVal = _player.GetComponent<Player>().getStats().getXp();
        _slider.GetComponent<Slider>().value = _currVal;
    }

    public void changeMaxVal(int maxVal)
    {
        _slider.GetComponent<Slider>().maxValue = maxVal;
    }
}
