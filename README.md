# 🎮 LocadoraIdle

Um jogo mobile idle/tycoon onde você gerencia sua própria locadora de videogames na era dourada do PS2, PS3 e Xbox 360.

## 📋 Informações do Projeto

- **Gênero**: Idle / Tycoon / Simulação
- **Plataforma**: Mobile (Android e iOS)
- **Engine**: Unity 2022 LTS
- **Linguagem**: C#

## 📂 Estrutura do Projeto

```
LocadoraGame/
├── Assets/
│   ├── Scripts/          # Código C# (Controllers, Managers, Systems)
│   ├── Scenes/           # Cenas do Unity
│   ├── Sprites/          # Assets gráficos (PNG, sprites)
│   ├── Prefabs/          # Prefabs reutilizáveis
│   ├── ScriptableObjects/# Dados configuráveis (GameData, configs)
│   ├── UI/               # Componentes de UI (Prefabs, Layouts)
│   ├── Data/             # Arquivos de dados (CSV, JSON)
│   ├── Audio/            # Sons e música
│   └── Resources/        # Assets carregados dinamicamente
├── Docs/                 # Documentação (GDD, design docs)
├── ProjectSettings/      # Configurações do Unity
└── README.md
```

## 🚀 Setup do Projeto

### Requisitos
- **Unity 2022 LTS** (ou superior)
- **Git** instalado
- Account GitHub com acesso ao repositório

### Como Clonar e Abrir

```bash
# Clonar o repositório
git clone https://github.com/[seu-user]/LocadoraGame.git
cd LocadoraGame

# Abrir no Unity
# File > Open Project > Selecionar pasta LocadoraGame
```

### Primeiros Passos
1. Abrir Unity Hub
2. Adicionar projeto (selecionar esta pasta)
3. Abrir com Unity 2022 LTS
4. Aguardar importação de assets
5. Abrir a cena principal em `Assets/Scenes/`

## 🌳 Branch Strategy

```
main (produção)
  └── develop (desenvolvimento)
       └── feature/* (features individuais)
```

### Fluxo de Trabalho
1. Criar feature branch a partir de `develop`
2. Fazer commits descritivos
3. Push para feature branch
4. Abrir Pull Request em `develop`
5. Code review e merge

**Exemplo:**
```bash
# Criar nova feature
git checkout -b feature/inventory-system develop
# ... fazer alterações ...
git commit -m "[FEAT] Implement inventory system"
git push origin feature/inventory-system
```

## 📝 Convenções de Commit

Use o padrão **Conventional Commits**:

```
[TYPE] Descrição curta

Descrição detalhada (opcional)

Closes #123
Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>
```

**Tipos**:
- `[FEAT]` - Nova feature
- `[FIX]` - Correção de bug
- `[REFACTOR]` - Refatoração
- `[DOCS]` - Documentação
- `[TEST]` - Testes
- `[CHORE]` - Tarefas de build, deps, etc.

## 🔗 Documentação

- **GDD (Game Design Document)**: `../locadora_idle_gdd.md`
- **Issues & Roadmap**: `../issues_fase0_fase1.md`
- **Documentação Técnica**: `Docs/` (será preenchida ao longo do desenvolvimento)

## 👥 Equipe

- [Seu Nome/Equipe]

## 📅 Roadmap

- **Fase 0**: Pré-Produção (GDD, Arte, Economia)
- **Fase 1**: MVP/Protótipo Jogável
- **Fase 2**: Alpha
- **Fase 3**: Beta
- **Fase 4**: Lançamento
- **Fase 5**: Pós-Lançamento

## 📄 Licença

[Defina a licença do seu projeto]

---

**Última atualização**: 2026-03-11