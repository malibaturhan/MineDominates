# Mine Dominates (TPS Prototype)

A third-person shooter prototype where I prioritized building a complete gameplay loop first (even if some parts were rough), then improving structure and polish from there. The project is a practical learning sandbox — focused on real systems, real problems, and real iteration 🙂.

**Itch.io:** [[ITCH]](https://malibaturhan.itch.io/mine-dominates)

---

## What’s in the project

- **State-driven enemies**
  - Enemies run on **state-based behavior**.
  - Debug panels are kept **visible above enemies** to make iteration and evaluation easier during development.

- **Animation blending**
  - Uses **animation blending and blend weights** to get smoother transitions and clearer feedback.

- **Interfaces (learned through repetition)**
  - I did end up with some **code repetition**, but that was a useful step: it made the value of **interfaces** (and better separation of responsibilities) very clear.

- **Singleton + events**
  - I learned and adopted a **Singleton structure mid-project**.
  - This helped me understand why **event timing / event race conditions** matter in gameplay flow.

---

## What I learned

- **Repetition can be useful**: it exposed weak coupling points and made the importance of **interfaces** obvious.
- **Singletons are powerful** but can create hidden dependencies if you don’t respect **event order and timing**.
- **Debug visibility is underrated**: keeping state/debug info in-world speeds up iteration and makes issues easier to catch.
- **Animation blending/weights** aren’t just visuals — they strongly affect how responsive and readable the game feels.

---

## How to run

1. Open the project in Unity.
2. Load the entry scene (menu/game start scene).
3. Press Play.

*(Controls, build steps, and final packaging notes will be added later.)*

---

## Notes

This is a learning-focused prototype, but I aimed to keep it structured enough to grow without collapsing under its own weight. The guiding rule was: **finish a full loop first, then refine**.

---
