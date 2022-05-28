using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletBehaviour bulletBehaviour;

    [SerializeField] private Transform companionTransform;


    private Vector2 shootDir;

    [SerializeField] private bool canShoot = true;


    [SerializeField] private bool isClockWise;


    private void Update()
    {
        shootDir = (companionTransform.position - transform.position).normalized;

        if (canShoot && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            EventManager.FireEvent();
        }
    }


    private void OnEnable()
    {
        EventManager.OnFire += ShootStarter;

        EventManager.OnclockWise += ()=> isClockWise = true;
        EventManager.OncounterClockWise += ()=> isClockWise = false;
    }

    private void OnDisable()
    {
        EventManager.OnFire -= ShootStarter;
        
    }


    private void SelectSingleShot()
    {
    }


    private void ShootStarter()
    {
        StartCoroutine(ShootSequence());

        IEnumerator ShootSequence()
        {
            canShoot = false;

            var _bullet = Instantiate(bulletBehaviour, companionTransform.position, quaternion.identity).GetComponent<BulletBehaviour>();


            if (isClockWise)
            {
                _bullet.SelectSingleShot();
            }
            else
            {
                _bullet.SelectBigShot();
            }


            _bullet.AddForce(shootDir);


            yield return new WaitForSeconds(_bullet.currentBullet.delayTime);

            canShoot = true;
        }
    }


    

    
}