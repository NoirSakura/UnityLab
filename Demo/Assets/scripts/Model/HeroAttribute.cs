using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttribute : AttributeBase {
    [SerializeField]string heroName = "Unknown";
    [SerializeField]int maxHp = 100;
    [SerializeField]int maxEn = 100;
    [SerializeField]int baseAtkPoint = 50;
    [SerializeField]int baseDefPoint = 10;

    private string m_HeroName;

    private void Start() {
        initHeroAttributes();
        //Debug.Log(this.AtkPoint);
    }

    private void Update() {
        //
    }

    private void initHeroAttributes() {
        // 设定初始状态下的数据
        this.MaxHealthPoint = maxHp;
        this.MaxEnergyPoint = maxEn;
        this.CurHealthPoint = maxHp;
        this.CurEnergyPoint = maxEn;
        this.AtkPoint = baseAtkPoint;
        this.DefPoint = baseDefPoint;
        this.m_HeroName = heroName;
    }

}
