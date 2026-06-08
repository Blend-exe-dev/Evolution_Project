using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class PropSpawnerSetup
{
    // scaleRange: x = min, y = max (applied per prefab path pattern in SetupBiomes)
    // Trees use /Trees/ path check; override per-biome via the biomeIndex switch below.

    private static readonly (string biomeName, string[] paths)[] BiomeConfig = new[]
    {
        // 0 – Deep Ocean (no props)
        ("Deep Ocean", new string[0]),

        // 1 – Ocean (no props)
        ("Ocean", new string[0]),

        // 2 – Beach
        ("Beach", new[]
        {
            "Assets/Models/Beach/Plants/PP_Beach_Plant_01.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_02.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_03.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_04.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_05.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_06.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_07.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_08.prefab",
            "Assets/Models/Beach/Plants/PP_Beach_Plant_09.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_01.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_02.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_03.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_04.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_05.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_06.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_07.prefab",
            "Assets/Models/Beach/Trees/PP_Palm_08.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_01.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_02.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_03.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_04.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_05.prefab",
            "Assets/Models/Beach/Trees/PP_Desert_Palm_Tree_06.prefab",
        }),

        // 3 – Desert
        ("Desert", new[]
        {
            "Assets/Models/Desert/Plants/PP_Desert_Plant_01.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_02.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_03.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_04.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_05.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_06.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Plant_07.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_01.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_02.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_03.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_04.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_05.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_06.prefab",
            "Assets/Models/Desert/Plants/PP_Desert_Grass_07.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_01.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_03.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_05.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_07.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_10.prefab",
            "Assets/Models/Desert/Plants/Cactuses/PP_Cactus_13.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_01.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_02.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_03.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_04.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_05.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Leafless_01.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Leafless_03.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Leafless_05.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Leafless_07.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Leafless_09.prefab",
        }),

        // 4 – Rainforest (trees are 1.5x larger than other biomes)
        ("Rainforest", new[]
        {
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_01.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_02.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_03.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_04.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_05.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_06.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_Curved_01.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_Curved_02.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_Curved_03.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Plant_Curved_04.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_06.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_07.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_08.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_09.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_10.prefab",
            "Assets/Models/Rainforest/Plants/PP_Bush_Fantasy_11.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Tree_01.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Tree_02.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Tree_03.prefab",
            "Assets/Models/Rainforest/Plants/PP_Vine_Tree_04.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_01.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_02.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_03.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_04.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_05.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_07.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_09.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_11.prefab",
            "Assets/Models/Rainforest/Trees/PP_Fantasy_Winding_Tree_13.prefab",
            "Assets/Models/Rainforest/Trees/PP_Weeping_Willow_01.prefab",
            "Assets/Models/Rainforest/Trees/PP_Weeping_Willow_02.prefab",
            "Assets/Models/Rainforest/Trees/PP_Weeping_Willow_03.prefab",
            "Assets/Models/Rainforest/Trees/PP_Weeping_Willow_04.prefab",
            "Assets/Models/Rainforest/Trees/PP_Weeping_Willow_05.prefab",
            "Assets/Models/Rainforest/Trees/PP_Tree_11.prefab",
            "Assets/Models/Rainforest/Trees/PP_Tree_12.prefab",
            "Assets/Models/Rainforest/Trees/PP_Tree_13.prefab",
        }),

        // 5 – Savanna
        ("Savanna", new[]
        {
            "Assets/Models/Savanah/Plants/PP_Bush_Fantasy_01.prefab",
            "Assets/Models/Savanah/Plants/PP_Bush_Fantasy_02.prefab",
            "Assets/Models/Savanah/Plants/PP_Bush_Fantasy_03.prefab",
            "Assets/Models/Savanah/Plants/PP_Bush_Fantasy_04.prefab",
            "Assets/Models/Savanah/Plants/PP_Bush_Fantasy_05.prefab",
            "Assets/Models/Savanah/Plants/PP_Desert_Plant_08.prefab",
            "Assets/Models/Savanah/Plants/PP_Desert_Plant_09.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_01.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_02.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_03.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_04.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_05.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_06.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_07.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_08.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_09.prefab",
            "Assets/Models/Savanah/Trees/PP_Fantasy_Tree_10.prefab",
            "Assets/Models/Savanah/Trees/PP_Tree_Leafless_01.prefab",
        }),

        // 6 – Grassland
        // Excluded: PP_Dragon_Blood_Tree, PP_Baobab_Tree, PP_Tree_04-10 (spherical / orange-toned)
        ("Grassland", new[]
        {
            "Assets/Models/Grassland/Plants/PP_Bush_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_02.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_04.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_05.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_06.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_Berries_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_Berries_02.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_Berries_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Bush_Berries_04.prefab",
            "Assets/Models/Grassland/Plants/PP_Dandelion_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Dandelion_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Dandelion_05.prefab",
            "Assets/Models/Grassland/Plants/PP_Dandelion_07.prefab",
            "Assets/Models/Grassland/Plants/PP_Daffodil_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Daffodil_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Daffodil_05.prefab",
            "Assets/Models/Grassland/Plants/PP_Hyacinth_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Hyacinth_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Hyacinth_05.prefab",
            "Assets/Models/Grassland/Plants/PP_Pansy_Flower_Pink_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Pansy_Flower_Pink_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Pansy_Flower_Purple_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Pansy_Flower_Purple_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Sunflower_01.prefab",
            "Assets/Models/Grassland/Plants/PP_Sunflower_03.prefab",
            "Assets/Models/Grassland/Plants/PP_Sunflower_05.prefab",
            "Assets/Models/Grassland/Plants/PP_Sunflower_07.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_01.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_02.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_03.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_04.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_05.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_06.prefab",
            "Assets/Models/Grassland/Trees/PP_Birch_Tree_07.prefab",
            "Assets/Models/Grassland/Trees/PP_Apple_Tree_01.prefab",
            "Assets/Models/Grassland/Trees/PP_Apple_Tree_02.prefab",
            "Assets/Models/Grassland/Trees/PP_Apple_Tree_03.prefab",
            "Assets/Models/Grassland/Trees/PP_Apple_Tree_04.prefab",
            "Assets/Models/Grassland/Trees/PP_Fig_Tree_01.prefab",
            "Assets/Models/Grassland/Trees/PP_Fig_Tree_02.prefab",
            "Assets/Models/Grassland/Trees/PP_Fig_Tree_03.prefab",
        }),

        // 7 – Tundra
        ("Tundra", new[]
        {
            "Assets/Models/Tundra/Snow plants/PP_Bush_Snow_01.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Bush_Snow_02.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Bush_Snow_03.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_01.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_03.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_05.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_07.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_09.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_11.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Grass_Snow_13.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Mushroom_Ice_01.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Mushroom_Ice_03.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Mushroom_Ice_05.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Mushroom_Ice_07.prefab",
            "Assets/Models/Tundra/Snow plants/PP_Mushroom_Ice_09.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Snow_01.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Snow_03.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Snow_05.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Snow_07.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Snow_09.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Leafless_Snow_01.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Leafless_Snow_03.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Leafless_Snow_05.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Tree_Leafless_Snow_07.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Snow_01.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Snow_03.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Snow_05.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Snow_07.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Long_Snow_01.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Long_Snow_03.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Fir_Tree_Long_Snow_05.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Weeping_Willow_Snow_01.prefab",
            "Assets/Models/Tundra/Snow trees/PP_Weeping_Willow_Snow_02.prefab",
        }),

        // 8 – Taiga
        ("Taiga", new[]
        {
            "Assets/Models/Taiga/Plants/PP_Grass_01.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_02.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_03.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_04.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_05.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_06.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_07.prefab",
            "Assets/Models/Taiga/Plants/PP_Grass_08.prefab",
            "Assets/Models/Taiga/Plants/PP_Plant_01.prefab",
            "Assets/Models/Taiga/Plants/PP_Plant_02.prefab",
            "Assets/Models/Taiga/Plants/PP_Plant_03.prefab",
            "Assets/Models/Taiga/Plants/PP_Plant_04.prefab",
            "Assets/Models/Taiga/Plants/PP_Plant_05.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_01.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_02.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_03.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_04.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_05.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_06.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_07.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_08.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_01.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_02.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_03.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_04.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_05.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_06.prefab",
            "Assets/Models/Taiga/Trees/PP_Tree_01.prefab",
            "Assets/Models/Taiga/Trees/PP_Tree_02.prefab",
            "Assets/Models/Taiga/Trees/PP_Tree_03.prefab",
        }),

        // 9 – Mountain
        ("Mountain", new[]
        {
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Trunk_01.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Trunk_02.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Trunk_03.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Trunk_04.prefab",
            "Assets/Models/Desert/Trees/PP_Desert_Tree_Trunk_05.prefab",
            "Assets/Models/Taiga/Plants/PP_Rocks_01.prefab",
            "Assets/Models/Taiga/Plants/PP_Rocks_02.prefab",
            "Assets/Models/Taiga/Plants/PP_Rocks_03.prefab",
            "Assets/Models/Taiga/Plants/PP_Rocks_04.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_09.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_10.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_07.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_08.prefab",
            "Assets/Models/Taiga/Trees/PP_Fir_Tree_Long_09.prefab",
        }),
    };

    private const int RainforestBiomeIndex = 4;

    // Base scale ranges
    private static readonly Vector2 TreeScaleBase       = new Vector2(4f,  9f);
    private static readonly Vector2 PlantScaleBase      = new Vector2(12f, 28f);
    // Rainforest trees are 1.5x the base
    private static readonly Vector2 RainforestTreeScale = new Vector2(6f,  13.5f);

    /// <summary>
    /// Finds the PropSpawner in the scene and fills all 10 biome slots with prefabs.
    /// Accessible via Tools > Setup Prop Spawner Biomes.
    /// </summary>
    [MenuItem("Tools/Setup Prop Spawner Biomes")]
    public static void SetupBiomes()
    {
        PropSpawner spawner = Object.FindFirstObjectByType<PropSpawner>();
        if (spawner == null)
        {
            EditorUtility.DisplayDialog("PropSpawner Setup",
                "No PropSpawner found in the current scene. Add one first.", "OK");
            return;
        }

        spawner.biomes = new BiomeSpawnData[BiomeConfig.Length];

        for (int i = 0; i < BiomeConfig.Length; i++)
        {
            var (biomeName, paths) = BiomeConfig[i];
            var propList = new List<BiomeProp>();

            foreach (string path in paths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (prefab == null)
                {
                    Debug.LogWarning($"[PropSpawnerSetup] Prefab not found: {path}");
                    continue;
                }

                bool isTree = path.Contains("/Trees/") || path.Contains("/Snow trees/");
                Vector2 scale;

                if (isTree && i == RainforestBiomeIndex)
                    scale = RainforestTreeScale;
                else if (isTree)
                    scale = TreeScaleBase;
                else
                    scale = PlantScaleBase;

                propList.Add(new BiomeProp
                {
                    prefab     = prefab,
                    density    = (i == 0 || i == 1) ? 0f : 0.06f,
                    scaleRange = scale
                });
            }

            spawner.biomes[i] = new BiomeSpawnData
            {
                biomeName = biomeName,
                props     = propList.ToArray()
            };
        }

        EditorUtility.SetDirty(spawner);
        Debug.Log("[PropSpawnerSetup] All 10 biomes populated successfully.");
        EditorUtility.DisplayDialog("PropSpawner Setup", "All 10 biomes populated! Hit Generate to spawn props.", "OK");
    }
}
