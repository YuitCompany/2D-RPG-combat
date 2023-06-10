using BaseBuff;
using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using BaseStats;
using BaseObject;

public class TestBuffEffect : MonoBehaviour
{
    public BuffStatus healRangeState;

    private void Awake()
    {
        healRangeState = new BuffStatus();
        healRangeState.Status = new ObjectState();
        healRangeState.Set_BuffProperty(new FloatPropertyBuff(BuffProperty.total_time, 3f));
        healRangeState.Status.Set_Property(new FloatProperty(ObjectProperty.move_speed, 4f));
    }

    public float GetBuffTime()
    {
        return healRangeState.Get_FloatBuffProperty(BuffProperty.total_time);
    }
}
