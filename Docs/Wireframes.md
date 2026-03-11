# 🎨 Wireframes — Fase 1

## 📐 Especificações

- **Formato**: Baixa fidelidade (sketches em texto/ASCII e descrição)
- **Resolução Alvo**: 1080x1920 (Portrait)
- **Aspect Ratio**: 9:16
- **Framework**: Unity Canvas (Screen Space - Overlay)

---

## 1️⃣ Tela Principal da Loja (ShopScreen)

### Layout ASCII
```
┌─────────────────────────────────────┐
│ ⏰ 14:30  💰 325  ⭐ Lv.1            │ ← HUD Topo
├─────────────────────────────────────┤
│                                       │
│   [Prateleiras de Jogos Visuais]    │
│   ┌────┐ ┌────┐ ┌────┐              │
│   │ GTA│ │MGS │ │DBZ │  ...         │
│   │(D) │ │(C) │ │(B) │              │
│   └────┘ └────┘ └────┘              │
│                                       │
│   [Estação PS2]                      │
│   ┌──────────────┐                   │
│   │  Ocupada     │                   │
│   │  Cliente: :)  │                  │
│   └──────────────┘                   │
│                                       │
│   [Clientes na Fila/Caminhando]      │
│   😊 😊 😊 😊 😊                        │
│                                       │
├─────────────────────────────────────┤
│ [Inventário] [Shop] [Finanças] [⚙️] │ ← Bottom Nav
└─────────────────────────────────────┘
```

### Componentes
- **HUD Topo** (40 px altura):
  - Relógio digital (esquerda)
  - Saldo de moedas (centro-esquerda)
  - Nível da loja (direita)
  
- **Área Central** (viewport expansível):
  - Fundo: Interior da loja (concept art)
  - Prateleiras de jogos: Grid 3 colunas × N linhas (scrollável)
  - Estações de console: Posicionadas visualmente
  - Clientes: Animados circulando/em fila
  
- **Bottom Navigation** (60 px altura):
  - 4 abas: Inventário, Shop, Finanças, Configurações
  - Ícones + labels
  - Aba ativa destacada

### Interações
- ✋ Drag para mover câmera
- 🔍 Pinch para zoom (0.8x–1.5x)
- 🎯 Tap em jogo para ver detalhes (popup)
- 🎯 Tap em cliente para história breve (tooltip)

---

## 2️⃣ Tela de Estoque (InventoryScreen)

### Layout ASCII
```
┌─────────────────────────────────────┐
│ ◄ Inventário         💰 325          │ ← Header
├─────────────────────────────────────┤
│ [Todos] [Rank D] [Rank C] [Rank B]  │ ← Filtros
├─────────────────────────────────────┤
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 GTA San Andreas    [Rank B]   │ │
│ │ ⭐⭐⭐⭐  | Cópias: 1 | 🔋 95%    │ │
│ │ Preço Aluguel: 10 moedas          │ │
│ └──────────────────────────────────┘ │
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 Metal Gear Solid   [Rank C]   │ │
│ │ ⭐⭐⭐⭐  | Cópias: 2 | 🔋 78%    │ │
│ │ Preço Aluguel: 6 moedas           │ │
│ └──────────────────────────────────┘ │
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 Crash Bandicoot    [Rank D]   │ │
│ │ ⭐⭐⭐⭐  | Cópias: 3 | 🔋 45%    │ │ ← Crítico!
│ │ Preço Aluguel: 3 moedas           │ │
│ └──────────────────────────────────┘ │
│                                       │
├─────────────────────────────────────┤
│ [📊 Estatísticas]                    │ ← Footer
└─────────────────────────────────────┘
```

### Componentes
- **Header** (50 px):
  - Botão voltar (◄)
  - Título "Inventário"
  - Saldo visível
  
- **Filtros** (50 px):
  - Abas: Todos, Rank D, Rank C, Rank B
  - Ativa destacada
  
- **Lista de Jogos** (scrollável):
  - Card por jogo:
    - Ícone (64x64)
    - Nome + Rank
    - Avaliação ⭐ (visual apenas)
    - Número de cópias
    - Barra de durabilidade (cor: verde/amarelo/vermelho)
    - Preço de aluguel
  
- **Footer Opcional**:
  - Botão para ver estatísticas agregadas

### Interações
- 🎯 Tap em jogo: Ver detalhes (nome completo, descrição, história)
- 🔄 Swipe esquerda: Opções (vender, descartar — futuro)
- ⬆️ Scroll: Navegar lista

---

## 3️⃣ Tela de Shop (GameShopScreen)

### Layout ASCII
```
┌─────────────────────────────────────┐
│ ◄ Catálogo de Distribuidora 💰 325   │ ← Header
├─────────────────────────────────────┤
│ [Todas] [Rank D] [Rank C] [Rank B]  │ ← Filtros
├─────────────────────────────────────┤
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 Tony Hawk's Pro Skater  [D]  │ │
│ │ Preço: 50 moedas                  │ │
│ │          [COMPRAR]                │ │
│ └──────────────────────────────────┘ │
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 Devil May Cry            [B]  │ │
│ │ Preço: 130 moedas                 │ │
│ │      [SALDO INSUFICIENTE] ❌      │ │
│ └──────────────────────────────────┘ │
│                                       │
│ ┌──────────────────────────────────┐ │
│ │ 🎮 Halo 3                  [🔒]  │ │
│ │ Requer: Xbox 360 (Fase 2)         │ │
│ │      [BLOQUEADO]                  │ │
│ └──────────────────────────────────┘ │
│                                       │
├─────────────────────────────────────┤
│ [ℹ️ Categoria não disponível]        │
└─────────────────────────────────────┘
```

### Componentes
- **Header**: Voltar, título, saldo destacado
- **Filtros**: Todos, Rank D, C, B (por rank da loja)
- **Cards de Jogo**:
  - Ícone
  - Nome + Rank
  - Preço em destaque
  - Botão COMPRAR (ativo/desabilitado)
  
- **Estados Possíveis**:
  - ✅ Disponível: Verde, botão ativo
  - ❌ Saldo insuficiente: Vermelho, botão desabilitado
  - 🔒 Bloqueado: Cinza, ícone cadeado (requer console/nível)

### Interações
- 🎯 Tap COMPRAR: Confirma compra (anima moeda saindo, jogo indo para estoque)
- 🎯 Tap em jogo bloqueado: Tooltip com requisito
- ⬆️ Scroll: Navegar catálogo

---

## 4️⃣ Tela de Finanças (FinancesScreen)

### Layout ASCII
```
┌─────────────────────────────────────┐
│ ◄ Finanças              💰 Saldo: 325│ ← Header
├─────────────────────────────────────┤
│                                       │
│ ┌─ RECEITA DE HOJE ─────────────────┐ │
│ │ Aluguéis: 125 moedas               │ │
│ │ Média/Cliente: 3.1 moedas          │ │
│ │ Clientes Hoje: 40                  │ │
│ └────────────────────────────────────┘ │
│                                       │
│ ┌─ SALDO TOTAL ─────────────────────┐ │
│ │ 325 moedas 📈                       │ │
│ │ (vs. 200 iniciais: +62.5%)         │ │
│ └────────────────────────────────────┘ │
│                                       │
│ ┌─ HISTÓRICO (últimas 7 sessões) ──┐ │
│ │ Dia 1: ████████░░░░ 125 moedas    │ │
│ │ Dia 2: █████░░░░░░░ 75 moedas     │ │
│ │ Dia 3: ██████████░░ 150 moedas    │ │
│ │ ...                                │ │
│ └────────────────────────────────────┘ │
│                                       │
│ ┌─ ESTATÍSTICAS ────────────────────┐ │
│ │ Receita Total: 500 moedas          │ │
│ │ Nível: 1 (próximo: 250 moedas)    │ │
│ │ Taxa Sucesso Aluguel: 72%          │ │
│ │ Jogo Mais Popular: GTA San Andreas │ │
│ └────────────────────────────────────┘ │
│                                       │
├─────────────────────────────────────┤
└─────────────────────────────────────┘
```

### Componentes
- **Header**: Voltar, título, saldo em grande destaque
- **Cards de Estatísticas**:
  - Receita do dia (com breakdown)
  - Saldo total e crescimento %
  - Gráfico simples de histórico (barras)
  - KPIs agregados (receita total, nível progresso, taxa sucesso, jogo popular)

### Interações
- 📊 Tap em histórico: Ver detalhes do dia
- ⬆️ Scroll: Ver mais estatísticas

---

## 5️⃣ HUD Principal

### Elementos Sempre Visíveis
```
┌─────────────────────────────────────┐
│ ⏰ 14:30  💰 325  ⭐ Lv.1  🔔        │ ← Topo da loja
└─────────────────────────────────────┘

⏰ Relógio: HH:MM (dinâmico)
💰 Saldo: Número de moedas (atualiza em real-time)
⭐ Nível: Número com ícone
🔔 Notificações: Ícone com badge (rojo se houver alerts)
```

### Notificações
- 📭 Disco crítico (durabilidade < 20%)
- 📭 Fila de clientes cheia (sem estação disponível)
- 📭 Nível desbloqueado
- 📭 Novo jogo desbloqueado

---

## 🧭 Fluxo de Navegação

```
┌─────────────┐
│   LOJA      │ ◄─── Tela Inicial (ShopScreen)
│ (Principal) │
└────┬────────┘
     │
     ├─► [Inventário] ──► InventoryScreen
     │
     ├─► [Shop] ──────► GameShopScreen
     │
     ├─► [Finanças] ──► FinancesScreen
     │
     └─► [⚙️ Settings] ──► SettingsScreen (futuro)
```

### Transições
- Bottom nav: Troca abas (fade in/out, 200ms)
- Back button: Volta à loja (animate out)
- Popups: Fade + scale animation

---

## ✅ Critérios de Aceite

- [x] Wireframes criados em baixa fidelidade
- [x] Layout definido para todas as 5 telas
- [x] Fluxo de navegação documentado
- [x] Componentes listados e descritos
- [x] Interações especificadas
- [x] Aspect ratio 9:16 considerado
- [x] HUD definido com informações essenciais

---

## 🔄 Próximos Passos

1. ✅ **Fase 0**: Este documento (#004 — Concluído)
2. **Fase 0**: #005 — Definir estilo visual (usa estes wireframes)
3. **Fase 1**: Implementar layouts no Unity (#010+)
4. **Fase 1**: Criar art finais (screenshots, etc)

---

**Documento criado**: 2026-03-11  
**Formato**: Wireframes em ASCII + descrição (pronto para Figma/designer)  
**Status**: Aprovado para Fase 1
