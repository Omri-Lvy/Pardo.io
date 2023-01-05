using System;
using Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _attack = 40;
    [SerializeField] private float _def = 10;
    [SerializeField] private float _health = 100;
    [SerializeField] private int _xpGiven = 10;
    [SerializeField] public Animator _animator;
    private PlayerStats _playerStats;
    private EnemyStats _stats;
    private float timer;
    private float timerLimit = 0.25f;
    private string _moveAnim;
    private string _dieAnim;
    private string _hitAnim;


    // Start is called before the first frame update
    void Start()
    {
        _stats = new EnemyStats(_attack, _speed, _def, _health, _xpGiven);
        _player = GameObject.FindGameObjectWithTag("Player");
        _moveAnim = gameObject.name.Split(" ")[0].Replace("(Clone)","") + "_move";
        _dieAnim = gameObject.name.Split(" ")[0].Replace("(Clone)","") + "_die";
        _hitAnim = gameObject.name.Split(" ")[0].Replace("(Clone)","") + "_hit";
    }

    // Update is called once per frame
    void Update()
    {
        if (_stats.isDead())
        {
            _animator.Play(_dieAnim);
            Destroy(gameObject, 1f);
            if(!_stats.gaveXP()) {
                _player.GetComponent<Player>().getStats().addXp(_xpGiven);
                _stats.setGaveXP(true);
            }
            
        }
        else if (_stats.getIsHit() && !_stats.isDead())
        {
            if (timer < timerLimit)
            {
                timer += 1 * Time.deltaTime;
                _stats.setSpeed(0);
            }
            else
            {
                _stats.setIsHit(false);
                timer = 0;
            }
        }
        else if (!_stats.getIsHit() && !_stats.isDead())
        {
            _stats.setSpeed(_speed);
            _animator.Play(_moveAnim);
        }
        if (_player.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (_player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _stats.getSpeed() * Time.deltaTime);
    }

    public EnemyStats getStats()
    {
        return _stats;
    }

    public void getHit(float damage)
    {
        if (!_stats.isDead())
        {
            _stats.getHit(damage);
            timer = 0;
            _stats.setSpeed(0);
            _animator.Play(_hitAnim);
        }
    }

}
