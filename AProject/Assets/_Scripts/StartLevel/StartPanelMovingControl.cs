﻿/*
 * 
 *      Title:滑动面板移动控制
 * 
 *      Description:
 * 
 *      Date:
 * 
 *      Version:
 * 
 *      Modify Recoder:
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StartPanelMovingControl : MonoBehaviour,IBeginDragHandler,IDragHandler {

    private float _FloStartPositionX; // 鼠标开始的偏移量
    private float _FloPosX;  // 鼠标移动的偏移量
    private float _FloSliderSpeed = 1000;
    private float _FloSmooth = 3F;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
        // 滑动脚本完善 添加边界
        print(this.transform.localPosition.x);
        
        if(this.transform.localPosition.x > 0  ) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * _FloSmooth);
        }else if(this.transform.localPosition.x < -3200) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(-3200, 0, 0), Time.deltaTime * _FloSmooth);
        }else if(this.transform.localPosition.x <0 && this.transform.localPosition.x >= -800) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(-800, 0, 0), Time.deltaTime * _FloSmooth);
        }else if(this.transform.localPosition.x < -800 && this.transform.localPosition.x >= -1600) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(-1600, 0, 0), Time.deltaTime * _FloSmooth);
        }else if(this.transform.localPosition.x < -1600 && this.transform.localPosition.x >= -2400) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(-2400, 0, 0), Time.deltaTime * _FloSmooth);
        } else if (this.transform.localPosition.x < -2400 && this.transform.localPosition.x >= -3200) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(-3200, 0, 0), Time.deltaTime * _FloSmooth);
        }

    }

    public void OnBeginDrag(PointerEventData eventData) {
        _FloStartPositionX = eventData.position.x;
        
    }

    public void OnDrag(PointerEventData eventData) {
        
        _FloPosX = eventData.position.x - _FloStartPositionX;
        float changeSpeed = _FloPosX / _FloSliderSpeed;

        // 移动面板
        this.transform.Translate(new Vector3(changeSpeed, 0, 0), Space.World);
        
        
        
        
    }
}
