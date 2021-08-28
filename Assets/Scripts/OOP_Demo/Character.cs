using UnityEngine;

public class Character : MonoBehaviour
{
    protected enum ECharacterType
    {
        None = -1,
        Player = 1,
        Enemy,
        NPC
    }

    private int hp;

    [SerializeField]
    protected ECharacterType characterType = ECharacterType.None;

    public int HP
    {
        get => hp;
        //private set { hp = hp <= 0 ? 0 : hp += value; } // ?:
        private set
        {
            if (hp <= 0)
            {
                hp = 0;
            }
            else
            {
                hp += value;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OOPBullet bullet = collision.gameObject.GetComponent<OOPBullet>();

        if (bullet != null)
        {
            switch (bullet.BulletType)
            {
                case EBulletType.Low:
                    hp -= 1;
                    break;

                case EBulletType.Mid:
                    hp -= 2;
                    break;

                case EBulletType.Hard:
                    hp -= 3;
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Turret.isDelayed = true;
        }
    }
}