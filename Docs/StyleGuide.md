# 🎨 Style Guide — LocadoraIdle Fase 1

## 🎯 Visão Artística

**Estilo Visual Definido**: **PIXEL ART RETRÔ**

### Justificativa
- ✅ Autêntico para a era PS2/PS3 (nostalgia genuína)
- ✅ Menos custoso de produzir em indie
- ✅ Funciona bem em dispositivos mobile (performance)
- ✅ Comunidade ativa (asset packs, ferramentas)
- ✅ Direto ao ponto visual vs cartoon (evita ambiguidade)

---

## 🎨 Paleta de Cores

### Cores Primárias (UI e Branding)
```
Cor Principal (Accent):     #FF6B35  (Laranja vibrante - nostalgia retro)
Cor Secundária:             #004E89  (Azul profundo - confiança)
Cor Terciária:              #00D9FF  (Ciano neon - destaque/interação)
```

### Cores de Neutrals (Fundo, Texto)
```
Preto:                      #1A1A1A  (Preto suave, não puro)
Branco:                     #F5F5F5  (Branco quase puro)
Cinza Escuro:               #2D2D2D  (Fundo escuro)
Cinza Médio:                #666666  (Texto secundário)
Cinza Claro:                #CCCCCC  (Borders, separadores)
```

### Cores de Status
```
Sucesso (Verde):            #2ECC71  (Compra bem-sucedida, durabilidade alta)
Aviso (Amarelo):            #F39C12  (Durabilidade média, alerta)
Crítico (Vermelho):         #E74C3C  (Sem saldo, durabilidade crítica)
Info (Azul):                #3498DB  (Mensagens, desbloques)
```

### Exemplo de Uso
```
Button "COMPRAR":
- Cor de fundo: #FF6B35 (laranja)
- Cor de texto: #F5F5F5 (branco)
- Hover: #CC5528 (laranja escuro)
- Disabled: #999999 (cinza)

Barra de Durabilidade:
- Verde: 100–60% | Amarelo: 59–20% | Vermelho: <20%
```

---

## 📐 Tamanhos de Sprite

### Resolução Base
```
Pixel Size: 16 pixels = 1 "unidade game"
Canvas Resolution: 1080 × 1920 (9:16 mobile portrait)
```

### Tamanhos Padrão

| Elemento | Dimensão | Pixels Unity | Notas |
|----------|----------|--------------|-------|
| Ícone Jogo | 64×64 px | 64×64 | Card de inventário |
| Ícone UI | 32×32 px | 32×32 | Buttons, status |
| Cliente (sprite) | 48×48 px | 48×48 | Animado, 4 quadros |
| Console (estação) | 128×96 px | 128×96 | Background estático |
| Prateleira (fundo) | 256×96 px | 256×96 | Repeating background |

### Grid de Pixel Art
```
Resolução: 16×16 pixels base (referência visual)
Escala no jogo: 2x (32×32 pixel size for sprites)
Ex: Cliente 48×48 = 3×3 tiles de 16px cada
```

---

## 🎮 Estilo de Sprites

### Características
- ✅ Pixel art puro (sem anti-aliasing)
- ✅ Paleta limitada (max 16 cores por sprite, total 64 cores projeto)
- ✅ Linhas limpas, sem gradients suavizados
- ✅ Proporções: cartoon/chibi (cabeças maiores, corpo menor = lindo)
- ✅ Expressões simples mas claras (olhos grandes, boca simples)

### Exemplos de Referência
- **Fire Emblem: The Binding Blade** (GBA) — proporções e cores
- **Stardew Valley** — estilo amigável, paleta quente
- **Game Dev Tycoon** — simplicidade UI
- **Grounded** (estilo pixel) — detalhes organicamente dispostos

---

## 📱 Interface (UI) Style

### Typography

```
Fonte Principal: "Press Start 2P" ou similar retro
  └─ Headlines: 24-32 px
  └─ Body: 16 px
  └─ Small: 12 px

Fallback (system): Arial, Helvetica (se font não carregar)
```

### Button Style
```
Tipo: Pixel Art Bordered

Exemplo "COMPRAR":
┌──────────────┐
│   COMPRAR    │ ← Texto branco
│ #FF6B35      │ ← Fundo laranja
└──────────────┘

Estados:
├─ Normal: Laranja (#FF6B35) com border preto 2px
├─ Hover: Laranja escuro (#CC5528)
├─ Pressed: Laranja escuro com offset -2px (pressionado)
└─ Disabled: Cinza (#999999) sem brilho
```

### Card Style
```
┌────────────────────────────┐
│ 🎮 GTA San Andreas [Rank B]│ ← Header com ícone
├────────────────────────────┤
│ ⭐⭐⭐⭐ 95%           │ ← Avaliação + durabilidade
├────────────────────────────┤
│ Preço: 150 moedas          │ ← Info principal
└────────────────────────────┘

Border: Preto 1px (#1A1A1A)
Shadow: Preto 2px offset (1, 1) com 30% opacity
Fundo: Cinza claro (#F5F5F5)
Hover: Cinza mais escuro (#EEEEEE) + glow
```

---

## 🎬 Animações

### Movimento de Cliente
```
Walk Cycle: 4 quadros, 200ms total (50ms por frame)
├─ Frame 1: Pé esquerdo frente
├─ Frame 2: Pé direito frente
├─ Frame 3: Pé esquerdo trás
└─ Frame 4: Pé direito trás

Loop contínuo enquanto cliente circula
```

### UI Transitions
```
Fade In/Out: 200ms (easing: ease-out)
Slide In (Bottom Nav): 300ms (easing: ease-out-back)
Button Click: 100ms scale (0.95 → 1.0)
Coin Animation: Fly + spin (500ms, curve)
```

---

## 🌅 Ambiente da Loja

### Cores Ambientes
```
DIA (8h–18h):
├─ Sky: #87CEEB (céu azul)
├─ Interior: #F5DEB3 (bege quente)
└─ Sombras: suaves

NOITE (18h–22h):
├─ Sky: #1A1A4D (azul escuro)
├─ Interior: #3D3D5C (roxo escuro)
└─ Sombras: mais acentuadas, brilho artificial
```

### Padrão de Prateleiras
```
Repetição 2x horizontalmente
Altura: 96 pixels
Cor estrutura: #8B7355 (madeira escura)
Cor fundo: #DEB887 (bege)
Padrão: Grade simples
```

---

## 👥 Personagens (Clientes)

### Tipos Base (3 variações)

#### 1️⃣ Criança (Child)
```
Proporções:
├─ Cabeça: 24×24 px (grande proporcionalmente)
├─ Corpo: 24×24 px (menor)
└─ Total: 24×48 px

Cores padrão:
├─ Skin: #FDBCB4 (pele quente)
├─ Cabelo: #8B4513 (marrom)
├─ Roupas: #FF1493 (rosa vibrante — criança energética)
└─ Olhos: ⚫ ⚫ (preto puro, grandes)

Expressão: Feliz sempre :)
Animação: Pula ao caminhar (mais energética)
```

#### 2️⃣ Adolescente (Teenager)
```
Proporções:
├─ Cabeça: 20×20 px
├─ Corpo: 28×28 px
└─ Total: 28×48 px

Cores padrão:
├─ Skin: #FDBCB4 (pele)
├─ Cabelo: #2F4F4F (cinza escuro/preto)
├─ Roupas: #004E89 (azul — estilo gamer)
└─ Olhos: ⚫ ⚫ (normal)

Expressão: Neutra/entediada
Animação: Caminha normal
```

#### 3️⃣ Adulto (Adult)
```
Proporções:
├─ Cabeça: 20×20 px
├─ Corpo: 28×28 px
└─ Total: 28×48 px (mesma altura que adolescente, mas diferentes proporções)

Cores padrão:
├─ Skin: #FDBCB4 (pele)
├─ Cabelo: #4A4A4A (cinza — mais envelhecido)
├─ Roupas: #333333 (preto/cinza — formal)
└─ Olhos: ⚫ ⚫ (pequenos)

Expressão: Sério/concentrado
Animação: Caminha devagar
```

---

## 🎯 Ícones de Jogo (Styles)

### Padrão de Design
```
Tamanho: 64×64 px
Borda: Preto 2px (#1A1A1A)
Fundo: Cor específica por rank

Rank D (Comum): #C0C0C0 (prata)
Rank C (Incomum): #FFD700 (ouro)
Rank B (Raro): #FF1493 (magenta/rosa)
Rank A (Épico): #FF6B35 (laranja — não em Fase 1)
Rank S (Lendário): #00D9FF (ciano — não em Fase 1)
```

### Exemplos
- GTA: Mapa com "GTA" em letras
- Metal Gear: Placa com "MGS"
- Crash: Cabeça do Crash em pixel art
- Devil May Cry: Símbolo de demônio

Todos centrados, com ícone pequeno/legível

---

## 📏 Responsividade

### Pontos de Quebra (Breakpoints)
```
Mobile Pequeno (720×1280):  100% do design
Mobile Padrão (1080×1920):  100% do design (alvo)
Mobile Grande (1440×2560):  Upscale 1.33x
```

### Estratégia
- Design mobile-first (1080×1920)
- Sem layout responsivo drástico (UI fixa)
- Escalagem uniforme para resoluções maiores

---

## ✅ Critérios de Aceite

- [x] Estilo visual definido: **Pixel Art Retrô**
- [x] Paleta de cores completa (16 cores)
- [x] Tamanhos de sprites padronizados
- [x] Typography definida
- [x] UI component style definido
- [x] Animações especificadas
- [x] Personagens base desenhados (3 tipos)
- [x] Referências visuais listadas
- [x] Responsividade documentada

---

## 📚 Referências Visuais

| Jogo/App | Aspecto Inspirador |
|----------|-------------------|
| **Stardew Valley** | Warmth, paleta terracota, character charm |
| **Game Dev Tycoon** | UI simplicity, readable fonts |
| **Fire Emblem (GBA)** | Character proportions, chibi style |
| **Grounded (pixel style)** | Nature colors, organized layouts |
| **Old School Runescape** | Pixel UI nostalgia, functional design |

---

## 🔄 Próximos Passos

1. ✅ **Fase 0**: Este style guide (#005 — Concluído)
2. **Fase 0**: #006 — Concept art da loja (usa este guia)
3. **Fase 0**: #007 — Concept art de clientes (usa este guia)
4. **Fase 1**: Implementar assets em Unity (#013+)

---

**Documento criado**: 2026-03-11  
**Estilo**: Pixel Art Retrô — Confirmado  
**Status**: Aprovado para produção artística
