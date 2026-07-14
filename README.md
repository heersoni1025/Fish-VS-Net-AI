# 🐠 Fish VS Net AI (Unity ML-Agents)

A reinforcement learning simulation built in **Unity 3D** using **Unity ML-Agents**, where AI-controlled fish learn to collect food while avoiding a falling fishing net. Through rewards, penalties, Ray Perception Sensors, and curriculum learning, the agents gradually develop survival behaviors within a dynamic aquarium environment.


<img width="800" height="423" alt="fish-vs-net-demo" src="https://github.com/user-attachments/assets/23804b92-3038-4425-8294-a9d93ea48c55" />

---

## 🎥 Project Overview

In this simulation, multiple fish agents navigate an aquarium environment where they must:

- 🍽️ Search for and collect food
- 🪤 Avoid a dynamically falling fishing net
- 🌊 Navigate a 3D aquarium environment
- 🤖 Improve their behavior over time using reinforcement learning

The project models an ecological scenario inspired by real-world fish foraging behavior and predator avoidance.

---

## ✨ Features

- Unity ML-Agents reinforcement learning
- Multi-agent fish simulation
- Dynamic food spawning
- Falling fishing net hazard
- Ray Perception Sensor 3D for environmental awareness
- Reward-based learning system
- Curriculum learning with increasing difficulty
- 3D aquarium environment
- PPO (Proximal Policy Optimization) training

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

The project gradually increases difficulty during training.

### Stage 1
- Food collection only
- Fish learn basic navigation and reward-seeking behavior

### Stage 2
- Falling fishing net introduced
- Fish must balance collecting food while avoiding danger

### Stage 3
- Faster fishing net creates a more challenging environment
- Fish refine survival strategies under increased difficulty

---

## 👁️ Agent Sensors

Each fish agent uses:

- Ray Perception Sensor 3D
- Vector observations
- Continuous action space

These sensors allow the fish to detect nearby food, obstacles, tank boundaries, and the fishing net to make intelligent movement decisions.

---

## 🛠️ Technologies

- Unity 3D
- C#
- Unity ML-Agents
- Python
- PPO (Proximal Policy Optimization)
- Anaconda

---

## 📁 Repository Contents

This repository contains the custom source code and scripts developed for this project.

To keep the repository lightweight, large Unity-generated folders, build files, and third-party assets have been excluded from version control.

The included scripts are designed to work with compatible **fish**, **food**, and **fishing net** models assigned to the appropriate GameObjects within a Unity scene.

---

## 🎥 Demo

A demonstration video is included in this repository showcasing the trained reinforcement learning agents.

The demo highlights:

- 🐟 Multi-agent fish behavior
- 🍽️ Food collection
- 🪤 Fishing net avoidance
- 📈 Curriculum learning progression
- 🤖 Reinforcement learning in action

---

## 📚 Inspiration

This project was inspired by ecological concepts including:

- Fish foraging behavior
- Predator avoidance
- Competition for limited resources
- Reinforcement learning in dynamic environments






---

## 🚀 Future Improvements

- Fish schooling behavior
- Hunger and energy system
- Multiple predator types
- More realistic fish animations
- Diverse aquatic species
- More complex underwater ecosystem
- Dynamic weather or water current effects

---

## 👩‍💻 Author

**Heer Soni**

Computer Science Student  
Indiana University Bloomington

GitHub: https://github.com/heersoni1025
