using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HeroManager : MonoBehaviour
{
    public HeroList heroList;

    void Start()
    {
        LoadHeroesFromJson();
    }

    void LoadHeroesFromJson()
    {
        string filePath = Path.Combine(Application.Assets, "playerlistchar.json");

        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            Debug.Log("Dữ liệu JSON đọc được: " + jsonContent); // Debug JSON

            heroList = JsonUtility.FromJson<HeroList>(jsonContent);

            if (heroList == null || heroList.heroes.Count == 0)
            {
                Debug.LogError("Dữ liệu HeroList bị null hoặc rỗng!");
                return;
            }

            // Kiểm tra dữ liệu
            foreach (var hero in heroList.heroes)
            {
                Debug.Log($"Tên nhân vật: {hero.name}, Hệ: {hero.element}, HP: {hero.stats.hp}");
                foreach (var skill in hero.skills)
                {
                    Debug.Log($"  - Skill: {skill.name}, Damage: {skill.damage}, Mana: {skill.mana_cost}, Cooldown: {skill.cooldown}");
                }
            }
        }
        else
        {
            Debug.LogError("Không tìm thấy file JSON tại: " + filePath);
        }
    }
}
