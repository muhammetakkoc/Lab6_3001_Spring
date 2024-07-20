using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeNode
{
    
    public abstract TreeNode Evaluate();

    
    public static void Traverse(TreeNode node)
    {
        
        if (node != null)
        {
            Traverse(node.Evaluate());
        }
    }
}

public abstract class DecisionNode : TreeNode
{
    public TreeNode yes = null;
    public TreeNode no = null;
}

public class ActionNode : TreeNode
{
    
    public override TreeNode Evaluate()
    {
        return null;
    }
}

public class VisibleDecision : DecisionNode
{
    public bool visible;

    public override TreeNode Evaluate()
    {
        return visible ? yes : no;
    }
}

public class AudibleDecision : DecisionNode
{
    public bool audible;

    public override TreeNode Evaluate()
    {
        return audible ? yes : no;
    }
}

public class NearDecision : DecisionNode
{
    public bool near;

    public override TreeNode Evaluate()
    {
        return near ? yes : no;
    }
}

public class FlankDecision : DecisionNode
{
    public bool flank;

    public override TreeNode Evaluate()
    {
        return flank ? yes : no;
    }
}

public class CreepAction : ActionNode
{
    public override TreeNode Evaluate()
    {
        Debug.Log("Creeping. . .");
        return base.Evaluate();
    }
}

public class AttackAction : ActionNode
{
    public override TreeNode Evaluate()
    {
        Debug.Log("Attacking!!!");
        return base.Evaluate();
    }
}

public class MoveAction : ActionNode
{
    public override TreeNode Evaluate()
    {
        Debug.Log("Moving...");
        return base.Evaluate();
    }
}

public class DecisionTreeLE6 : MonoBehaviour
{
    void Start()
    {
        VisibleDecision visible = new VisibleDecision();
        AudibleDecision audible = new AudibleDecision();
        NearDecision near = new NearDecision();
        FlankDecision flank = new FlankDecision();

        ActionNode creep = new CreepAction();
        ActionNode attack = new AttackAction();
        ActionNode move = new MoveAction();

        visible.no = audible;
        visible.yes = near;

        audible.yes = creep;
        audible.no = null;

        near.no = flank;
        near.yes = attack;

        flank.no = attack;
        flank.yes = move;

        // Outputs "Creeping. . ."
        visible.visible = false;
        audible.audible = true;
        near.near = false;
        flank.flank = false;
        TreeNode.Traverse(visible);

        // Output: "Attacking!!!"
        visible.visible = true;
        audible.audible = true;
        near.near = true;
        flank.flank = false;
        TreeNode.Traverse(visible);


        // Output: "Moving..."
        visible.visible = true;
        audible.audible = true;
        near.near = true;
        flank.flank = true;
        TreeNode.Traverse(visible);


        // Output: Nothing
        visible.visible = false;
        audible.audible = true;
        near.near = false;
        flank.flank = false;
        TreeNode.Traverse(visible);



        // Output: "Attacking!!!"
        visible.visible = true;
        audible.audible = true;
        near.near = true;
        flank.flank = false;
        TreeNode.Traverse(visible);
        


        
    }
}