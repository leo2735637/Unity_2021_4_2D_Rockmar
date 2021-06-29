﻿
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region 欄位
    [Header("玩家的變形元件")]
    public Transform player;
    [Header("追蹤的速度"), Range(0, 100)]
    public float speed = 30;

    //下-0.55 上0.55
    [Header("上下邊界")]
    public Vector2 limtY = new Vector2(-0.55f, 0.55f);
    //左-0.5 右136
    [Header("左右邊界")]
    public Vector2 limtX = new Vector2(-0.5f, 136f);

    #endregion

    #region 方法
    /// <summary>
    /// 攝影機追蹤玩家的座標
    /// </summary>
    private void Track()
    {
        Vector3 vCam = transform.position;      //攝影機座標
        Vector3 vPla = player.position;        //玩家做標

        //利用差值讓攝影機座標朝玩家做標移動
        vCam = Vector3.Lerp(vCam, vPla, 0.5f * speed * Time.deltaTime);
        //將攝影機Z軸恢復報預設-10
        vCam.z = -10;
        //夾住 X 與 Y 軸
        //數學的夾住(值，最小，最大) - 將值限制在最小與最大範圍內 
        vCam.x = Mathf.Clamp(vCam.x, limtX.x, limtX.y);
        vCam.y = Mathf.Clamp(vCam.y, limtY.x, limtY.y);

        //更新攝影機座標
        transform.position = vCam;
    } 

    #endregion

    #region 事件
    //延遲更新事件
    //在Update後執行
    //官方建議攝影機追蹤行為可在此事件呼叫執行
    private void LateUpdate()
    {
        Track();
    }


    #endregion

}
