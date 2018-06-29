using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeBase : ComponentBase {
    private int m_MaxHealthPoint;   // 最大生命值
    private int m_MaxEnergyPoint;   // 最大能量值
    private int m_CurHealthPoint;   // 当前生命值
    private int m_CurEnergyPoint;   // 当前能量值
    private int m_AtkPoint;         // 攻击力
    private int m_DefPoint;         // 防御力

    #region Getter&Setter
    public int MaxHealthPoint
    {
        get { return m_MaxHealthPoint; }
        set { m_MaxHealthPoint = m_MaxHealthPoint < 0 ? 0 : value; }
    }
    public int MaxEnergyPoint
    {
        get { return m_MaxEnergyPoint; }
        set { m_MaxEnergyPoint = m_MaxEnergyPoint < 0 ? 0 : value; }
    }
    public int CurHealthPoint
    {
        get { return m_CurHealthPoint; }
        set {
            if(value > m_MaxHealthPoint) m_CurHealthPoint = m_MaxHealthPoint;
            else if(value < 0) m_CurHealthPoint = 0;
            else m_CurHealthPoint = value; 
        }
    }
    public int CurEnergyPoint
    {
        get { return m_CurEnergyPoint; }
        set
        {
            if (value > m_MaxEnergyPoint) m_CurEnergyPoint = m_MaxEnergyPoint;
            else if (value < 0) m_CurEnergyPoint = 0;
            else m_CurEnergyPoint = value;
        }
    }
    public int AtkPoint
    {
        get { return m_AtkPoint; }
        set { m_AtkPoint = m_AtkPoint < 0 ? 0 : value; }
    }
    public int DefPoint
    {
        get { return m_DefPoint; }
        set { m_DefPoint = m_DefPoint < 0 ? 0 : value; }
    } 
    #endregion
}
