using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerBullets : MonoBehaviour
{
    [SerializeField] private Bullet _template;
    [SerializeField] private int _poolSize;
    [SerializeField] private Transform _container;

    private List<Bullet> _bullets = new List<Bullet>();

    private void Start()
    {
        FillPoll();
    }

    private void FillPoll()
    {
        for(int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_template, _container);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    public void Spawn(Transform _shootPoint)
    {
        print("here");
        Bullet bullet = _bullets.FirstOrDefault(deactiveExemplar => deactiveExemplar.gameObject.activeSelf == false);


        if (bullet != null)
        {
            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = _shootPoint.rotation;
            bullet.gameObject.SetActive(true);
        }
    }
}
