using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerAttackCheck
{
    bool IsInMeleeRange { get; set; }
    bool IsInProjectileRange { get; set; }

    bool IsAutoAimEnabled { get; set; }
    void SetMeleeRangeStatus(bool isInMeleeRange);
    void SetProjectileRangeStatus(bool isInProjectileRange);

    void SetAutoAimEnabled(bool isInAutoAimEnabled);
}
