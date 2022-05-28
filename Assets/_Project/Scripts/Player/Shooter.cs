using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletBehaviour bulletBehaviour;

    [SerializeField] private Transform companionTransform;
    
    
    
    private Vector2 shootDir;

    [SerializeField]  private bool canShoot=true;

    private void Update()
    {
        shootDir =   (companionTransform.position-transform.position).normalized;

        if (canShoot && Input.anyKeyDown)
        {
            StartCoroutine(ShootSequence());
        }
    }


    private IEnumerator ShootSequence()
    {
        canShoot = false;

        var _bullet = Instantiate(bulletBehaviour,companionTransform.position,quaternion.identity).GetComponent<BulletBehaviour>();
        _bullet.SelectSingleShot();
        _bullet.AddForce(shootDir);
        
        
        yield return new WaitForSeconds(_bullet.currentBullet.delayTime);

        canShoot = true;
    }
}