using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;
    public AnimationClip animationClip;

    float nextFire;
    int gunIndex; 

    public enum GunType
    {
        BASIC,
        MACHINEGUN
    }

    [System.Serializable]
    public struct GunCharacteristics
    {
        public GunType type;
        public Sprite sprite;
        public float bulletPower;
        public float bulletSpeed;
        public float fireRate;
        public float trajectoryError;
        public int level;
    }

    public GunCharacteristics[] gun;

    // Use this for initialization
	void Awake () {
        gunIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Fire();
        ChoseGun();
    }

    public void ChoseGun()
    {
        for (int i = 0; i < gun.Length; i++)
        {
            if (ExperienceManager.currentLevel >= gun[i].level)
            {
                gunIndex = i;
                gameObject.GetComponent<SpriteRenderer>().sprite = gun[i].sprite;
            }
        }
    }
    void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            GetComponent<Animator>().Play(animationClip.name);
            nextFire = Time.time + gun[gunIndex].fireRate;
            bullet.GetComponent<Bullet>().speed = gun[gunIndex].bulletSpeed;
            bullet.GetComponent<Bullet>().power = gun[gunIndex].bulletPower;
            bullet.GetComponent<Bullet>().trajectoryError = gun[gunIndex].trajectoryError;
            GameObject bulletInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
            Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
