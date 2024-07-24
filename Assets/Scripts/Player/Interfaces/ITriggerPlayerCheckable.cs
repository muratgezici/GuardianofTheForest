using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerPlayerCheckable 
{
    bool IsInCollectRange { get; set; }
    bool IsInTreeCutRange { get; set; }
    bool IsInInteractRange {  get; set; }

    void SetInCollectRangeStatus(bool isInCollectRange);
    void SetInTreeCutRangeStatus(bool isInTreeCutRange);
    void SetInInteractRangeStatus(bool isInInteractRange);
}
