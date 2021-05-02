
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
   
    [Header("移動速度"),Range(0, 1000)]   
    public float speed = 10.5f;
    [Header("跳躍高度"),Range(0, 3000)]
    public int jump = 100;
    [Range(0, 200)]
    public float hp = 100f;
    [Header("是否在地板上"), Tooltip("地板")]
    public bool floor = false;
    [Header("子彈"), Tooltip("子彈")]
    public GameObject bullet;
    [Header("元件子彈生成點"), Tooltip("子彈生成點")]
    public Transform Bulletgenerate;
    [Range(0, 5000)]
    public int bulletSpeed = 800;
    [Header("開槍音效"), Tooltip("槍聲")]
    public AudioClip Gunshots;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator    ani;

    #endregion

    #region 事件

    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

    }

    /// <summary>
    /// 開槍
    /// </summary>
    private void Fire()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    private void Hit(float damage)
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool Dead()
    {
        return false;
    }

    // <summary>
    /// 吃道具
    /// </summary>
    /// <param name="prop">道具的名稱</param>
    private void Eatprop(string prop)
    {
       
    }

    #endregion


}
