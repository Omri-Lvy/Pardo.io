using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthBar : MonoBehaviour
{
    private Slider _slider;
    private GameObject _player;
    private float _maxVal;
    private float _currVal;
    [SerializeField] private TMP_Text _text;
    
    private void Awake()
    {
        _maxVal = 100;
        _slider = gameObject.GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _slider.GetComponent<Slider>().maxValue = 100; // This needs to be set to level 1 max exp value.
        _slider.GetComponent<Slider>().value = 100;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _currVal = _player.GetComponent<Player>().getStats().getCurrentHealth();
        _slider.GetComponent<Slider>().value = _currVal;
        _text.text = Mathf.Floor(_currVal) + " / " + Mathf.Floor(_maxVal);
    }

    public void changeMaxVal(float maxVal)
    {
        _maxVal = maxVal;
        _slider.GetComponent<Slider>().maxValue = Mathf.Floor(maxVal);
    }
}
