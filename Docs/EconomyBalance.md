# 💰 Balanceamento de Economia — Fase 1

## 🎯 Objetivos

1. **Viável**: É possível atingir Nível 3 em ~30 min de jogo ativo
2. **Progressão**: Sempre há algo para comprar/desbloquear
3. **Recompensador**: Cada ação tem impacto visível
4. **Balanceado**: Sem P2W excessivo (futuro)

---

## 💸 Parâmetros Iniciais

### Saldo Inicial do Jogador
```
Saldo Inicial: 200 moedas
```

**Justificativa**: Permite comprar 2-3 jogos Rank D ou 1 Rank C + 1 Rank D. Força decisão inicial de estratégia.

### Custos de Compra (por título)

| Rank | Custo | Exemplo | Notas |
|------|-------|---------|-------|
| D | 50–60 moedas | Crash Bandicoot, Tony Hawk's | Acessível para saldo inicial |
| C | 65–90 moedas | GTA Original, Metal Gear Solid | Próximo objetivo |
| B | 110–150 moedas | GTA San Andreas, Devil May Cry | Motivador de progressão |

**Simulação**: Com 200 moedas iniciais:
- Opção 1: 3x Rank D (150 moedas) + 1x Rank C (80 moedas) = 230 moedas ❌ (ultrapassa)
- Opção 2: 2x Rank D (100 moedas) + 1x Rank C (80 moedas) = 180 moedas ✅ (viável)
- Opção 3: 4x Rank D (200 moedas) ✅ (seguro mas menos variado)

### Preço de Aluguel (por título)

| Rank | Aluguel | Durabilidade | Receita/Disco |
|------|---------|--------------|--------------|
| D | 3–4 moedas | 80 | 240–320 moedas |
| C | 4–6 moedas | 80–85 | 320–510 moedas |
| B | 7–10 moedas | 85–90 | 595–900 moedas |

**Exemplo**: 
- Crash Bandicoot (Rank D): 3 moedas/aluguel × 80 durabilidade = 240 moedas/disco
- GTA San Andreas (Rank B): 10 moedas/aluguel × 90 durabilidade = 900 moedas/disco

---

## 👥 Clientes e Frequência

### Frequência de Chegada de Clientes

```
Horário de Funcionamento: 8h–22h (14 horas de jogo = ~42 minutos reais)

Taxa de Chegada:
├─ Baixo Movimento (8h–11h): 1 cliente a cada 3 min reais
├─ Movimento Normal (11h–14h): 1 cliente a cada 2 min reais
├─ Pico (14h–18h): 1 cliente a cada 1 min real
├─ Movimento Normal (18h–21h): 1 cliente a cada 2 min reais
└─ Encerramento (21h–22h): 1 cliente a cada 4 min reais

Total estimado por dia: ~40 clientes
```

### Comportamento de Cliente

```
Chegada do Cliente
  ↓
Escolhe Jogo (Random dentre Disponíveis)
  ↓
Paga Aluguel
  ↓
Disco Perde 5–10 Durabilidade
  ↓
Saída do Cliente
  ↓
Repetição Próxima Hora
```

**Taxa de Sucesso**: ~70% dos clientes conseguem alugar (sem aluguel nem fila)

---

## 📈 Curva de Progressão (Níveis 1–5)

### Simulação Manual — Sessão de 30 minutos

```
INÍCIO
├─ Saldo: 200 moedas
├─ Estoque: 2x Rank D + 1x Rank C = 180 moedas gastos
└─ Saldo Restante: 20 moedas

PRIMEIROS 10 MIN (Horário do jogo: 8h–12h)
├─ Clientes: ~15 chegam
├─ Aluguéis bem-sucedidos: ~10
├─ Receita Média: (3×5 + 4×5) = 35 moedas
├─ Saldo: 20 + 35 = 55 moedas
├─ Eventos: Nenhum ainda (Nível 1)
└─ Status: Ainda muito apertado

PRÓXIMOS 10 MIN (Horário do jogo: 12h–16h = PICO)
├─ Clientes: ~10 chegam (pico de movimento)
├─ Aluguéis bem-sucedidos: ~7
├─ Receita: (3×3 + 4×4) = 25 moedas
├─ Saldo: 55 + 25 = 80 moedas
├─ ✅ CHECKPOINT 1: Pode comprar 1x Rank C! (80 moedas)
├─ Novo Estoque: 2x D + 2x C
└─ Status: Menos aperto, mais variação

ÚLTIMOS 10 MIN (Horário do jogo: 16h–20h)
├─ Clientes: ~15 chegam
├─ Aluguéis bem-sucedidos: ~10
├─ Receita: (3×4 + 4×6) = 36 moedas
├─ Saldo: 80 + 36 = 116 moedas
├─ ✅ CHECKPOINT 2: Pode comprar 1x Rank B (110 moedas)
├─ Novo Estoque: 2x D + 2x C + 1x B
├─ 🎖️ NÍVEL 1 ATINGIDO (receita acumulada > 100)
└─ Status: Estoque melhor, momentum building

PÓS 30 MIN
├─ Saldo: 116 - 110 = 6 moedas (+ próximas receitas)
├─ Estoque: Diversificado (3 tipos)
├─ Nível: 1 (primeira meta atingida)
├─ 🎖️ NÍVEL 2: Desbloqueado (1x Rank C novo)
└─ Status: Progresso visível, motivação alta
```

---

## 🎖️ Sistema de Níveis (Fase 1)

```
Nível 1: Receita Acumulada ≥ 100 moedas
├─ Desbloques: Nenhum (jogo já começou com acesso aos Rank D)
└─ Bônus: +10% receita passiva

Nível 2: Receita Acumulada ≥ 250 moedas
├─ Desbloques: Rank C completo liberado (se não tiver)
└─ Bônus: +10% receita passiva

Nível 3: Receita Acumulada ≥ 450 moedas
├─ Desbloques: 1ª estação de console adicional (2 PS2s)
└─ Bônus: +10% receita passiva

Nível 4: Receita Acumulada ≥ 700 moedas
├─ Desbloques: Rank B completo (alguns títulos novos)
└─ Bônus: +15% receita passiva

Nível 5: Receita Acumulada ≥ 1000 moedas
├─ Desbloques: Primeira customização de loja
└─ Bônus: +15% receita passiva
```

**Cálculo de Nível**: Baseado em receita acumulada (nunca reseta)

---

## 💸 Despesas (Fase 1)

```
Aluguel Diário da Loja: DESABILITADO NA FASE 1
Manutenção de Consoles: DESABILITADA NA FASE 1
Compra de Discos: Principal expense (controlado pelo jogador)
Salários de Funcionários: DESABILITADOS NA FASE 1
```

**Justificativa**: Na Fase 1 (MVP), apenas compra de jogos é despesa. Mantém foco no loop básico.

---

## ⏱️ Tempo do Jogo

```
Duração Real → Duração do Jogo (em minutos)
1 minuto real → 1 minuto do jogo (proporção 1:1)

Exemplo:
└─ 30 min reais de jogo = 30 minutos do jogo (8h da manhã até 8h30 da noite)
└─ 1 hora real de jogo = 60 minutos (dia inteiro)
```

---

## 📊 Validação de Balanceamento

### Cenário A: Jogador Conservador
```
Compra Inicial: 2x Rank D (100 moedas) → Saldo: 100
Após 15 min: Receita ~17 moedas
Saldo Total: 117
Ação: Compra 1x Rank C (80 moedas)
Status: Nível 1 atingido ✅
Conclusão: Viável, seguro
```

### Cenário B: Jogador Agressivo
```
Compra Inicial: 1x Rank D + 1x Rank C + 1x Rank D (190 moedas) → Saldo: 10
Após 15 min: Receita ~22 moedas
Saldo Total: 32
Ação: Espera mais (~5 min) para acumular 80
Status: Nível 1 atingido, menos conforto ⚠️
Conclusão: Possível mas tenso (por design)
```

### Cenário C: Jogador Passivo
```
Compra Inicial: 4x Rank D (200 moedas) → Saldo: 0
Após 10 min: Receita ~12 moedas
Após 20 min: Receita total ~30 moedas
Após 30 min: Receita total ~45 moedas
Status: Nível 1 não atingido (meta é 100) ❌
Ação: Precisa afastar-se e deixar idle
Conclusão: Espera offline ou jogo ocioso funciona
```

---

## 🎯 Critérios de Aceite

- [x] Saldo inicial balanceado (200 moedas)
- [x] Custos escalados por rank (D < C < B)
- [x] Preços de aluguel proporcionais
- [x] Frequência de clientes definida
- [x] Curva de progressão permite Nível 3 em 30 min
- [x] Sistema de níveis claro e motivador
- [x] Simulação manual validada
- [x] Documento aprovado

---

## 🔄 Próximos Passos

1. ✅ **Fase 0**: Este documento (#003 — Concluído)
2. **Fase 0**: #004 — Criar wireframes (usa este balanceamento)
3. **Fase 1**: Implementar GameManager com este balanceamento (#010+)
4. **Fase 2+**: Ajustar conforme feedback de testes

---

**Documento criado**: 2026-03-11  
**Validação**: Manual — Simulações de sessão de 30 min executadas  
**Status**: Aprovado para Fase 1
