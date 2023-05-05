using Assets.Scenes.Script.Enemy;
using Assets.Scenes.Script.Enemy.Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerMark;
    [SerializeField] private LayerMask builetMark;
    [SerializeField] private Transform builetPosi;
    [SerializeField] private Transform headPosi;
    [SerializeField] private List<Transform> builetRain;
    
    
    private MoveB move;
    private int swordCount ;
    private Animator aniBoss;
    private float coolDown=Mathf.Infinity;
    private float coolDownSkill=10f;

    public GameObject sword;
    public Transform swordPosition;
    public PlayerStatic playerStatic;
    public Builet builetPlayer;

    //For boss increase attack
    private float swordSpeed=0.5f;
    private float swordMax=5f;

    // Start is called before the first frame update
    void Start()
    {
        aniBoss = GetComponent<Animator>();
        move = GetComponent<MoveB>();
        sword = GameObject.Find("Sword");
        sword.SetActive(false);
        Transform builetPosis = GameObject.Find("BuiletRain").transform;
        foreach(Transform child in builetPosis)
        {
            builetRain.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coolDown += Time.deltaTime;
        if (PlayerInSight())
        {
            CheckAttack();
            move.enabled = false;
            if (coolDown >= attackCooldown)
            {
                //attack
                coolDown = 0;
                aniBoss.SetTrigger("BossAttack");
            }
        }
        if (coolDown >= coolDownSkill)
        {
            Skill();
            coolDown = 0;
        }
        if (BuiletPlayerInSight())
        {
            move.enabled = false;
            aniBoss.SetBool("BossBlock",true);
        }
        if (HPBoss.instance.CurrentHP() == 50)
        {
            BossLow();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,new Vector3(boxCollider.bounds.size.x * range,boxCollider.bounds.size.y,boxCollider.bounds.size.z ),0,
            Vector2.left,0,playerMark);
        if (hit.collider != null)
        {
            playerStatic = hit.transform.GetComponent<PlayerStatic>();
        }
        return hit.collider!=null;
    }
    private bool BuiletPlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0,
            Vector2.left, 0, builetMark);
        if (hit.collider != null)
        {
            builetPlayer = hit.transform.GetComponent<Builet>();
        }
        return hit.collider != null;
    }
    private void CheckAttack()
    {
        if (HPBoss.instance.CurrentHP() >= 50f) return;
        aniBoss.SetFloat("StyleAttack", 1);
        attackCooldown = 0.3f;
        coolDownSkill = 5f;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));    
    }
    public float GetScale()
    {
        return transform.localScale.x;
    }
    private void Skill()
    {
        move.enabled = false;
        int skill = Random.Range(1,5);
        switch (skill)
        {
            case 1:
                aniBoss.SetTrigger("BossCast");
                break;
            case 2:
                aniBoss.SetTrigger("Rain");
                break;
            case 3:
                aniBoss.SetBool("Sword",true);
                break;
            case 4:
                transform.position += new Vector3(0, 1.5f, 0);
                aniBoss.SetTrigger("BossKame");
                break;
            default:
                return;
        }

    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && playerStatic.CurrentHP()>0)
            playerStatic.DamegePlayer();
    }

    private void RainBuilet()
    {
        for(int i = 0; i < builetRain.Count; i++)
        {
            BuiletManager.instance.SpamBuilet("RainBuilet", builetRain[i].position, 1);
        }
    }
    private void SpamBuilet()
    {
        BuiletManager.instance.SpamBuilet("BossBuilet", builetPosi.position, 2 * GetScale());
    }
    
    private void SpamSword()
    {
        InvokeRepeating(nameof(Sword), 1f, swordSpeed);
    }
    private void BossMove()
    {
        move.enabled = true;
        aniBoss.ResetTrigger("BossCast");
        aniBoss.ResetTrigger("Rain");
    }
    private void BossNoBlock()
    {
        move.enabled = true;
        aniBoss.SetBool("BossBlock",false);
    }
    
    private void BosDown()
    {
        transform.position += new Vector3(0, -1.5f, 0);
        BossMove();
    }

    private void DestroyBuilet()
    {
        Destroy(builetPlayer.gameObject);
    }
    private void Sword()
    {
        sword.SetActive(true);
        BuiletManager.instance.SpamBuilet("SwordAttack", swordPosition.position, 1);
        swordCount+=1;
        if (swordCount >= swordMax)
        {
            aniBoss.SetBool("Sword", false);
            BossMove();
            CancelInvoke();
            sword.SetActive(false);
            swordCount = 0;
        }
    }
    private void Kame()
    {
        BuiletManager.instance.SpamBuilet("HeadAttack", headPosi.position, 1);
    }
    private void BossLow()
    {
        swordSpeed = 0.2f;
        swordMax = 10f;
    }
}
