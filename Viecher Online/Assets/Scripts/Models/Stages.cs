using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{
    public Dictionary<int, int> stages;
    public Dictionary<int, string> stageNames;
    public Dictionary<int, Sprite> BGFronts;
    public Dictionary<int, Sprite> BGBacks;

    void Start()
    {
        stages = new Dictionary<int, int>();
        stages.Add(1, 24);
        stages.Add(2, 36);
        stages.Add(3, 48);
        stages.Add(4, 60);
        stages.Add(5, 65);

        stageNames = new Dictionary<int, string>();
        stageNames.Add(1, "Bandit Hideout");
        stageNames.Add(2, "Offshore Steppe");
        stageNames.Add(3, "Evergreen Forest");
        stageNames.Add(4, "Hajime Woods");
        stageNames.Add(5, "High Castle");

        BGFronts = new Dictionary<int, Sprite>();
        BGFronts.Add(1, Resources.Load<Sprite>("GFX/BGs/front_grass"));
        BGFronts.Add(2, Resources.Load<Sprite>("GFX/BGs/front_factory"));
        BGFronts.Add(3, Resources.Load<Sprite>("GFX/BGs/front_grass"));
        BGFronts.Add(4, Resources.Load<Sprite>("GFX/BGs/front_factory"));
        BGFronts.Add(5, Resources.Load<Sprite>("GFX/BGs/front_deco"));

        BGBacks = new Dictionary<int, Sprite>();
        BGBacks.Add(1, Resources.Load<Sprite>("GFX/BGs/back_brick"));
        BGBacks.Add(2, Resources.Load<Sprite>("GFX/BGs/back_castle"));
        BGBacks.Add(3, Resources.Load<Sprite>("GFX/BGs/back_bridge"));
        BGBacks.Add(4, Resources.Load<Sprite>("GFX/BGs/back_bridge"));
        BGBacks.Add(5, Resources.Load<Sprite>("GFX/BGs/back_castle"));
    }


}
