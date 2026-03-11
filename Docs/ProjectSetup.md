# LocadoraIdle — Estrutura de Projeto Unity

## 📋 Checklist de Setup Inicial

### Unity Editor
- [ ] Versão: Unity 2022 LTS
- [ ] Plataforma alvo: Android + iOS
- [ ] Resolução: 1080x1920 (portrait)
- [ ] Target API Level: Android 12+

### Packages Recomendados
```
Unity.Addressables
Unity.DOTween
Unity.UI.GraphicsTools
Unity.TextMeshPro
```

### Estrutura de Assets
- **Scripts/**: Organized by feature/system
  - `Managers/` (GameManager, UIManager, etc.)
  - `Systems/` (InventorySystem, CustomerSystem, etc.)
  - `Controllers/` (PlayerController, etc.)
  - `Data/` (Models, ScriptableObjects scripts)
  - `UI/` (Canvas scripts)
  - `Utils/` (Helpers, Extensions)

- **Sprites/**: Organized by type
  - `UI/`
  - `Characters/`
  - `Environment/`
  - `Items/`

- **Scenes/**: One scene per major view
  - `MainShop.unity`
  - `MainMenu.unity`
  - `InventoryScreen.unity`
  - etc.

### Configurações Importantes
- Aspect ratio: 9:16 (portrait mobile)
- UI Canvas: Render Mode = Screen Space - Overlay
- Input System: Modern (não legacy)

---

## 🎨 Estilo Visual (a definir)

Pendente: **[ART] #005 — Definir estilo visual e style guide**

---

**Setup completo em**: `CONTRIBUTING.md`
