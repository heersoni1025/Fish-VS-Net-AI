# 🐠 Fish VS Net AI (Unity ML-Agents)

A reinforcement learning simulation built in **Unity 3D** using **Unity ML-Agents**, where fish learn to collect food while avoiding a falling fishing net. The project demonstrates how AI agents can learn survival behaviors through rewards, penalties, and curriculum learning.

## 🎥 Project Overview

In this simulation, multiple fish agents navigate an aquarium environment where they must:

- 🍽️ Search for and collect food
- 🪤 Avoid a dynamically falling fishing net
- 🌊 Navigate a 3D aquarium environment
- 🤖 Improve behavior over time using reinforcement learning

The project models an ecological scenario inspired by fish foraging behavior and predator avoidance.

---

## ✨ Features

- Unity ML-Agents reinforcement learning
- Multi-agent fish simulation
- Dynamic food spawning
- Falling fishing net hazard
- Ray Perception Sensors for environmental awareness
- Reward-based learning system
- Curriculum learning with increasing difficulty
- 3D aquarium environment

---

## 🧠 AI Learning

The fish learn through reinforcement learning by receiving rewards and penalties based on their actions.

### Rewards
- ✅ Collecting food
- ✅ Moving toward the nearest food source

### Penalties
- ❌ Getting trapped by the fishing net
- ❌ Moving inefficiently
- ❌ Hitting tank boundaries

As training progresses, the agents learn to balance food collection with avoiding environmental hazards.

---

## 🎓 Curriculum Learning

The project gradually increases difficulty during training:

### Stage 1
- Food collection only

### Stage 2
- Falling fishing net introduced

### Stage 3
- Faster fishing net for a more challenging environment

---

## 👁️ Agent Sensors

Each fish uses:

- Ray Perception Sensor 3D
- Vector observations
- Continuous action space

The agents detect nearby food, obstacles, and the fishing net to make movement decisions.

---

## 🛠️ Technologies

- Unity 3D
- C#
- Unity ML-Agents
- Python
- PPO (Proximal Policy Optimization)
- Anaconda

---

## 📚 Inspiration

This project was inspired by ecological concepts including:

- Fish foraging behavior
- Predator avoidance
- Competition for resources
- Reinforcement learning in dynamic environments

---

## 📷 Screenshots

> Add screenshots or gameplay GIFs here.

---

## 🚀 Future Improvements

- Fish schooling behavior
- Hunger and energy system
- Additional predators
- More realistic fish animations
- Diverse aquatic species
- More complex underwater ecosystem

---

## 👩‍💻 Author

**Heer Soni**

Computer Science Student  
Indiana University Bloomington

GitHub: https://github.com/heersoni1025
