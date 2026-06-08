using UnityEngine;
using UnityEditor;

/// <summary>
/// Batch-creates all BodyData and CreaturePartData ScriptableObject assets from the design doc.
/// Run via Tools > Creature > Generate All Data Assets.
/// </summary>
public static class CreatureDataSetupTool
{
    private const string BodiesDir    = "Assets/Scripts/Scriptable Assets/Bodies";
    private const string HeadsDir     = "Assets/Scripts/Scriptable Assets/Heads";
    private const string LegsDir      = "Assets/Scripts/Scriptable Assets/Legs";
    private const string BodyPrefabs  = "Assets/Scripts/Scriptable Assets/Bodies/Prefabs";
    private const string HeadPrefabs  = "Assets/Scripts/Scriptable Assets/Heads/Prefabs";
    private const string LegPrefabs   = "Assets/Scripts/Scriptable Assets/Legs/Prefabs";

    [MenuItem("Tools/Creature/Generate All Data Assets")]
    public static void GenerateAll()
    {
        int count = 0;
        count += GenerateBodies();
        count += GenerateHeads();
        count += GenerateLegs();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log($"[CreatureDataSetupTool] Done — {count} assets created or updated.");
    }

    // ─── Bodies ──────────────────────────────────────────────────────────────

    private static int GenerateBodies()
    {
        int n = 0;

        n += Body("Standard Quadruped", "Standard Quadruped",
            sp: 1,  pr: 0,  wm: 0,  ms: 1,  se: 0, sr: 0, hg: 1,
            headSlots: 1, legSlots: 4, hasTail: true);

        n += Body("Tripod", "Tripod",
            sp: -1, pr: 0,  wm: -1, ms: 2,  se: 0, sr: 1, hg: 1,
            headSlots: 1, legSlots: 3, hasTail: false);

        n += Body("Upright", "Upright",
            sp: 0,  pr: 0,  wm: 1,  ms: 1,  se: 0, sr: 1, hg: 0,
            headSlots: 1, legSlots: 4, hasTail: false);

        n += Body("Vermiform", "Vermiform",
            sp: 2,  pr: 0,  wm: 0,  ms: 0,  se: 0, sr: 0, hg: -1,
            headSlots: 1, legSlots: 0, hasTail: true);

        n += Body("Mini", "Small semi-Bipedal",
            sp: 2,  pr: -1, wm: 0,  ms: -1, se: 2, sr: 0, hg: -1,
            headSlots: 1, legSlots: 4, hasTail: true);

        n += Body("Teardrop", "Teardrop",
            sp: 1,  pr: 0,  wm: 0,  ms: 0,  se: 0, sr: 0, hg: 2,
            headSlots: 1, legSlots: 2, hasTail: true);

        n += Body("Carapace", "Carapace",
            sp: 0,  pr: 2,  wm: 1,  ms: -1, se: 0, sr: 0, hg: 0,
            headSlots: 1, legSlots: 4, hasTail: false);

        n += Body("Barrel", "Barrel or Twink",
            sp: -2, pr: 1,  wm: 1,  ms: 1,  se: 0, sr: 1, hg: 1,
            headSlots: 1, legSlots: 4, hasTail: true);

        n += Body("Glider", "Glider",
            sp: 2,  pr: -1, wm: 0,  ms: -1, se: 1, sr: 0, hg: 0,
            headSlots: 1, legSlots: 4, hasTail: true);

        return n;
    }

    // ─── Heads ───────────────────────────────────────────────────────────────

    private static int GenerateHeads()
    {
        int n = 0;

        // Desert
        n += Head("Large Ears",   "Large Ears",   BiomeTag.Desert,
            sp: 1,  pr: 0,  wm: -1, ms: -1, se: 1,  sr: -1, hg: -1);
        n += Head("Narrow Snout", "Narrow Snout", BiomeTag.Desert,
            sp: 1,  pr: 1,  wm: 0,  ms: 1,  se: -1, sr: 1,  hg: 0);
        n += Head("Burrow Head",  "Burrow Head",  BiomeTag.Desert,
            sp: -1, pr: 1,  wm: 1,  ms: 1,  se: 1,  sr: -1, hg: 0);

        // Savannah
        n += Head("Sensor Head (Savannah)", "Sensor Head", BiomeTag.Savannah,
            sp: 1,  pr: 0,  wm: 0,  ms: 0,  se: 2,  sr: 0,  hg: -1);
        n += Head("Heavy Head",             "Heavy Head",  BiomeTag.Savannah,
            sp: 0,  pr: 1,  wm: -1, ms: 2,  se: 0,  sr: 1,  hg: 1);

        // Tundra
        n += Head("Insulated Fur Head", "Big Fur",    BiomeTag.Tundra,
            sp: 0,  pr: 0,  wm: 2,  ms: 1,  se: 0,  sr: 0,  hg: 1);
        n += Head("Jaw Head",           "Blind Jaw",  BiomeTag.Tundra,
            sp: 0,  pr: 1,  wm: 1,  ms: 0,  se: -1, sr: 2,  hg: 1);
        n += Head("Quick Warm Head",    "Quick Warm", BiomeTag.Tundra,
            sp: 1,  pr: -1, wm: 2,  ms: 0,  se: 0,  sr: 0,  hg: 0);

        // Rainforest
        n += Head("Camo Head",       "Camo Head",    BiomeTag.Rainforest,
            sp: 0,  pr: 2,  wm: 0,  ms: 0,  se: 1,  sr: 0,  hg: 0);
        n += Head("Climber Head",    "Climber Head", BiomeTag.Rainforest,
            sp: 1,  pr: 1,  wm: 0,  ms: 0,  se: 1,  sr: 0,  hg: -1);
        n += Head("Wide Sight Head", "Wide Sight",   BiomeTag.Rainforest,
            sp: 0,  pr: 0,  wm: 0,  ms: -1, se: 3,  sr: 0,  hg: -1);

        // Taiga
        n += Head("Tracker Head", "Tracker Head", BiomeTag.Taiga,
            sp: 1,  pr: 0,  wm: 0,  ms: 0,  se: 1,  sr: 2,  hg: -1);
        n += Head("Cold Head",    "Cold Blubber", BiomeTag.Taiga,
            sp: -1, pr: 1,  wm: 2,  ms: 1,  se: 0,  sr: 0,  hg: 0);

        // Grassland
        n += Head("Grazer Head", "Grazer Head", BiomeTag.Grassland,
            sp: 0,  pr: 0,  wm: 0,  ms: 0,  se: 2,  sr: 0,  hg: -1);
        n += Head("Horned Head", "Horned Head", BiomeTag.Grassland,
            sp: -1, pr: 2,  wm: 0,  ms: 1,  se: 0,  sr: 1,  hg: 1);
        n += Head("Runner Head", "Runner Head", BiomeTag.Grassland,
            sp: 2,  pr: 0,  wm: 0,  ms: 0,  se: 1,  sr: -1, hg: -1);

        // Ocean
        n += Head("Filter Head",         "Filter Head",  BiomeTag.Ocean,
            sp: 0,  pr: 0,  wm: 0,  ms: 0,  se: 1,  sr: 0,  hg: 2);
        n += Head("Aquatic Head",        "Aquatic Head", BiomeTag.Ocean,
            sp: 1,  pr: 1,  wm: 0,  ms: 0,  se: 1,  sr: 0,  hg: 1);
        n += Head("Sensor Head (Ocean)", "Lighting Head", BiomeTag.Ocean,
            sp: 1,  pr: -1, wm: 0,  ms: 0,  se: 3,  sr: -1, hg: -2);

        return n;
    }

    // ─── Legs ────────────────────────────────────────────────────────────────

    private static int GenerateLegs()
    {
        int n = 0;
        n += Leg("Paws",        "Paws",     wm: 1);
        n += Leg("Claws",       "Claws",    sr: 1);
        n += Leg("Hooves",      "Hooves",   pr: 1);
        n += Leg("Wings",       "Wings",    se: 1);
        n += Leg("Fins",        "Fins",     sp: 1);
        n += Leg("Pointed",     "Pointed",  wm: -1);
        n += Leg("Webbed Feet", "Webbed",   sp: 1);
        n += Leg("Spindly",   "Spindily", hg: 1);
        n += Leg("Stompers",  "Stompers", ms: 1);
        return n;
    }

    // ─── Factory helpers ──────────────────────────────────────────────────────

    private static int Body(string assetName, string prefabName,
        float sp, float pr, float wm, float ms, float se, float sr, float hg,
        int headSlots, int legSlots, bool hasTail)
    {
        var data = CreateOrLoad<BodyData>($"{BodiesDir}/{assetName}.asset");
        data.biome       = BiomeTag.Any;
        data.baseStats   = Stats(sp, pr, wm, ms, se, sr, hg);
        data.headSlots   = headSlots;
        data.legSlots    = legSlots;
        data.hasTailSlot = hasTail;
        data.prefab      = Prefab($"{BodyPrefabs}/{prefabName}.prefab");
        EditorUtility.SetDirty(data);
        return 1;
    }

    private static int Head(string assetName, string prefabName, BiomeTag biome,
        float sp, float pr, float wm, float ms, float se, float sr, float hg)
    {
        var data = CreateOrLoad<CreaturePartData>($"{HeadsDir}/{assetName}.asset");
        data.type          = PartType.Head;
        data.biome         = biome;
        data.statModifiers = Stats(sp, pr, wm, ms, se, sr, hg);
        data.prefab        = Prefab($"{HeadPrefabs}/{prefabName}.prefab");
        EditorUtility.SetDirty(data);
        return 1;
    }

    private static int Leg(string assetName, string prefabName,
        float sp = 0, float pr = 0, float wm = 0,
        float ms = 0, float se = 0, float sr = 0, float hg = 0)
    {
        var data = CreateOrLoad<CreaturePartData>($"{LegsDir}/{assetName}.asset");
        data.type          = PartType.Legs;
        data.biome         = BiomeTag.Any;
        data.statModifiers = Stats(sp, pr, wm, ms, se, sr, hg);
        data.prefab        = Prefab($"{LegPrefabs}/{prefabName}.prefab");
        EditorUtility.SetDirty(data);
        return 1;
    }

    private static StatBlock Stats(float sp, float pr, float wm, float ms,
                                   float se, float sr, float hg)
    {
        return new StatBlock
        {
            speed      = sp,
            protection = pr,
            warmth     = wm,
            mass       = ms,
            sight      = se,
            strength   = sr,
            hunger     = hg
        };
    }

    private static T CreateOrLoad<T>(string path) where T : ScriptableObject
    {
        var existing = AssetDatabase.LoadAssetAtPath<T>(path);
        if (existing != null) return existing;
        var asset = ScriptableObject.CreateInstance<T>();
        AssetDatabase.CreateAsset(asset, path);
        return asset;
    }

    private static GameObject Prefab(string path)
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (prefab == null)
            Debug.LogWarning($"[CreatureDataSetupTool] Prefab not found at: {path}");
        return prefab;
    }
}
