using UnityEngine;

// 繼承與多形 
// 繼承語法：類別後面加上冒號與要繼承的類別名稱 
// 1. 擁有類別得成員 - 欄位、事件、方法
// 2. 可以複寫繼承類別 (父類別) 的成員
// 複寫條件
// 1. 父類別要複寫的成員必須添加關鍵字 virtunl
// 2. 父類別要複寫的成員修飾詞必須是 public、protected (保護：允許子類別存取)
// 3. 子類別必須使用關鍵字 overrode 複寫
public class Boss : Enemy1
{
    [Header("進入第二階段的血量")]
    public float secondHp = 300;
    [Header("魔王攻擊：第二階段特效")]
    public ParticleSystem psAttackSecond;
    [Header("第二階段攻擊力"), Range(0, 1000)]
    public float attackSecond = 10;

    /// <summary>
    /// 魔王的狀態
    /// </summary>
    public StateBoss stateBoss;
    public override void Hit(float damage)
    {
        base.Hit(damage);            // 指父類別原本的程式區塊 

        // 判斷血量並切換第二階段
        if (hp <= secondHp)
        {
            radiusAttack = 5;
            stateBoss = StateBoss.second;
        }           
    }

    protected override void AttackState()
    {
        switch (stateBoss)
        {
            case StateBoss.first:
                base.AttackState();
                break;
            case StateBoss.second:
                timer = 0;
                ani.SetTrigger("攻擊觸發");
                psAttackSecond.transform.position = transform.position + transform.right * 3 + transform.up *-1f;
                psAttackSecond.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 180, 0);
                psAttackSecond.Play();             
                break;            
        }        
    }

    protected override void Dead()
    {
        base.Dead();

        StartCoroutine(player.GetComponent<Player>().GameOver("You Win"));
    }
    protected override void Start()
    {
        base.Start();

        psAttackSecond.GetComponent<ParticleSystemData>().attack = attackSecond;
    }
}

//  列舉
//  語法：修飾詞 列舉 列舉名稱 { 選項1，選項2，....}
/// <summary>
/// 魔王狀態：第一階段、第二階段
/// </summary>
public enum StateBoss
{
    first, second
}

