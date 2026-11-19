# README.md
# C_Sharp_GC_GenerationCounter

## C#_GC_GenerationCounter

### Задание «Контрольная точка №40 — GC в .NET 10: поколения, регионы, DATAS»[cite: 13]

Вариант 1. Счётчик поколений[cite: 13]
1. Зафиксируйте `GC.CollectionCount(0) / (1) / (2)` перед началом эксперимента[cite: 13].
2. Выполните массовое выделение короткоживущих объектов (например, 200 000 коротких массивов `new byte[50]`) в цикле, не сохраняя ссылок[cite: 13].
3. Снова зафиксируйте счётчики. Выведите, сколько сборок Gen0/Gen1/Gen2 добавилось[cite: 13].
4. Аллоцируйте 5 объектов размером > 85 000 байт (`new byte[90_000]`) — сравните, как ведут себя Gen0 и Gen2[cite: 13].
5. Выведите `GC.GetGCMemoryInfo().HeapSizeBytes` до и после эксперимента[cite: 13].

---

### Результаты и проверочные ключи:

<img width="1530" height="483" alt="изображение" src="https://github.com/user-attachments/assets/1cb7784a-08ab-40c7-83d7-255c20045d30" />


### Результат работы программы:

<img width="1725" height="1086" alt="изображение" src="https://github.com/user-attachments/assets/101785f5-9999-4ea0-8d43-1f645fd52baa" />
