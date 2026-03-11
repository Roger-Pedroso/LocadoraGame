# CONTRIBUTING.md — Guia de Contribuição

## 🌳 Branch Strategy (Git Flow)

### Branches Principais

- **`main`**: Produção (releases finais)
- **`develop`**: Desenvolvimento (integração de features)
- **`feature/*`**: Features individuais (derivadas de `develop`)
- **`bugfix/*`**: Correções de bugs (derivadas de `develop`)
- **`hotfix/*`**: Correções críticas de produção (derivadas de `main`)

### Fluxo de Trabalho

#### 1. Desenvolver uma Nova Feature

```bash
# Atualizar develop
git checkout develop
git pull origin develop

# Criar feature branch
git checkout -b feature/nome-da-feature

# Fazer commits
git commit -m "[FEAT] Descrição da feature"

# Push para o repositório
git push origin feature/nome-da-feature

# Abrir Pull Request em develop
```

#### 2. Corrigir um Bug

```bash
git checkout develop
git pull origin develop
git checkout -b bugfix/nome-do-bug
# ... fazer alterações ...
git push origin bugfix/nome-do-bug
# Abrir Pull Request em develop
```

#### 3. Hotfix (Correção Crítica em Produção)

```bash
git checkout main
git pull origin main
git checkout -b hotfix/nome-critico
# ... corrigir ...
git push origin hotfix/nome-critico
# Abrir Pull Request em main
# IMPORTANTE: Fazer merge também em develop após aprovação
```

## 📝 Convenções de Commit

### Formato
```
[TYPE] Descrição curta (máx 50 caracteres)

Descrição detalhada (quebras de linha de 72 caracteres)
Explique o que, por que e como.

Refs: #123
Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>
```

### Tipos de Commit

| Tipo | Descrição | Exemplo |
|------|-----------|---------|
| `[FEAT]` | Nova feature | `[FEAT] Add inventory system` |
| `[FIX]` | Correção de bug | `[FIX] Fix customer spawn rate` |
| `[REFACTOR]` | Refatoração (sem mudança funcional) | `[REFACTOR] Reorganize GameManager` |
| `[DOCS]` | Documentação | `[DOCS] Add setup guide` |
| `[TEST]` | Testes | `[TEST] Add unit tests for Economy` |
| `[CHORE]` | Build, deps, configs | `[CHORE] Update .gitignore` |
| `[PERF]` | Otimização de performance | `[PERF] Optimize render pipeline` |

### Exemplos de Bons Commits

```bash
# ✅ BOM - Feature com contexto
git commit -m "[FEAT] Implement GameData ScriptableObject

- Create GameData class with platform, rank, price fields
- Add 20 initial game titles to Resources
- Implement GameDatabase manager for game lookup

Refs: #013"

# ✅ BOM - Fix com explicação
git commit -m "[FIX] Prevent double customer spawn

Issue: Customers were spawning twice per hour peak
Root cause: GameManager.SpawnCustomer called twice
Solution: Add spawn queue to prevent duplicates

Refs: #42"

# ❌ RUIM - Sem contexto
git commit -m "fixes"
git commit -m "update stuff"
git commit -m "wip"
```

## ✅ Checklist de Pull Request

Antes de abrir um PR, verifique:

- [ ] Branch é derivado de `develop` (ou `main` para hotfix)
- [ ] Código segue a style guide do projeto
- [ ] Sem conflitos com a branch de destino
- [ ] Testes passam localmente (quando aplicável)
- [ ] Documentação atualizada (README, GDD, etc)
- [ ] Commits são descritivos e bem formatados
- [ ] Sem arquivos desnecessários commitados (Library/, Temp/, etc)

## 🚀 Processo de Review

1. **Abrir PR**: Incluir descrição clara e referência a issues
2. **Review**: Mínimo 1 aprovação antes de merge
3. **Feedback**: Resolver comments e fazer push de alterações
4. **Merge**: Usar "Squash and merge" para histórico limpo
5. **Delete branch**: Remover feature branch após merge

## 💡 Boas Práticas

### Commits
- ✅ Um commit = uma ideia coerente
- ✅ Commits pequenos e focados
- ✅ Teste antes de fazer push
- ✅ Rebase se necessário (não force push em shared branches)

### Code Review
- ✅ Seja respeitoso e construtivo
- ✅ Aponte melhorias, não críticas pessoais
- ✅ Aprove quando estiver satisfeito (não force)
- ✅ Teste o código localmente se possível

### Pull Requests
- ✅ Título claro e descritivo
- ✅ Descrição do que e por que foi mudado
- ✅ Screenshots/GIFs para mudanças visuais
- ✅ Referência a issues relacionadas (#123)

## 🔗 Recursos

- [Git Flow Cheatsheet](https://danielkummer.github.io/git-flow-cheatsheet/)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [How to Write a Good Git Commit Message](https://chris.beams.io/posts/git-commit/)

---

**Obrigado por contribuir!** 🎉
