﻿using UnityEngine;
using UnityEngine.UI;
using System;

public class EmitterScript : MonoBehaviour
{
    public GameObject[] asteroids;          //список астероидов
    public GameObject enemyShip;            //вражеский корабль
    public GameObject powerUp;              //бонус
    public Text text;                       //текст
    public float minDelay, maxDelay;        //границы задержки времени появления вражеских объектов
    public int minX, maxX, minZ, maxZ;      //границы области появления бонусов
    public int delayTime;                   //время задержки появления бонусов
    float nextLaunchTime;                   //время появления вражеского объекта
    float nextAppearTime = 10;              //время появления бонуса
    int choice;                             //выбор вражеского объекта

    // Update is called once per frame
    void Update()
    {
        float positionZ = transform.position.z;
        float positionX = UnityEngine.Random.Range(- transform.localScale.x / 2, transform.localScale.x / 2);
        //Условие запуска вражеского объекта
        if (Time.time > nextLaunchTime)
        {
            choice = UnityEngine.Random.Range(0, 4);
            if (choice >= 0 && choice <= 2)
                Instantiate(asteroids[choice], new Vector3(positionX, 0, positionZ), Quaternion.identity);                
            else
                Instantiate(enemyShip, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextLaunchTime = Time.time + UnityEngine.Random.Range(minDelay, maxDelay);
        }
        //Условие появления бонуса
        if (Time.time > nextAppearTime)
        {
            Instantiate(powerUp, new Vector3(UnityEngine.Random.Range(minX, maxX), 0, UnityEngine.Random.Range(minZ, maxZ)), Quaternion.identity);
            nextAppearTime = Time.time + delayTime;
        }
        else
            text.text = String.Format("До появления бонуса осталось {0} сек.", Convert.ToInt16(nextAppearTime - Time.time));
    }
}
