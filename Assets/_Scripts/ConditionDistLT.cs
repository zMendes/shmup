using UnityEngine;

public class ConditionDistLT : Condition
{
   Transform agent;
   Transform target;
   float maxDist;

   public ConditionDistLT(Transform ag, Transform ta, float dist) {
       agent = ag;
       target = ta;
       maxDist = dist;
   }

   public override bool Test()
   {
       if  (target != null)
            return Vector2.Distance(agent.position, target.position) <= maxDist;
        return false;
   }
}