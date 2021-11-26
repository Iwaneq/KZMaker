# Table of contents
* [Introduction](#introduction)
* [Technologies](#technologies)
* [Launch](#launch)
* [Project's future](#future)
* [Sources](#sources)

# Introduction
### What KZMaker is?
KZMaker is my first bigger product, which allows user to create scout documents (Karty Zbiórki) faster and simplier, than on paper. 

<p align="center">
  <img src="https://user-images.githubusercontent.com/27814917/143501053-85f34fbc-7d64-47e7-a1cf-c39c2208b5ea.png">
</p>

### Why I created KZMaker?
To be honest - because of my laziness ;pp
Writing these documents on phone notepad, and then writing them by hand on printed template was taking too much time. I was thinking, how can I do all of this steps in one place, and there is where the idea was born. 
First version of app was writed in WinForms. Months later, after gainging some experience in other, smaller projects, I decided to finally recreate whole product to something more modern.

# Technologies
To write app I used:
- .NET 5.0
- MvvmCross 8.0.2
- Ookii.Dialogs.Wpf 4.0.0
- squirrel.windows 1.9.0

### Why MvvmCross as mvvm framework?
In near future I want to make Android port of KZMaker. MvvmCross allows me to have more shared between platforms code, so I won't need to write most of already existing classes, to just fit them into other platform.

<p align="center">
  <img width="300" height="200" src="https://user-images.githubusercontent.com/27814917/143502411-df061a1c-8efc-4e87-8adf-4d229883a7a0.png">
</p>

### Ookii.Dialogs?
Simple library for better Windows dialogs. I usually used them in getting saving paths by folder dialogs.

<p align="center">
  <img src="https://user-images.githubusercontent.com/27814917/143502488-332e7966-9707-4aca-a25b-b0df2e1f9c55.png">
</p>

### squirrel.windows?
Framework which allows me to implement application update features to KZMaker. In settings page you can search for new updates. If there is new release in this GitHub repo, application will take that as new version, and will ask user if he wants to update, or not.

<p align="center">
  <img src="https://user-images.githubusercontent.com/27814917/143502717-3e95da54-aa52-47f1-ba23-19ce5f315256.png">
</p>

# Launch
### What do I need to install app?
Just... .NET 5.0 Runtime, in case you don't have installed it already. System requirements at this moment are only for operating system. KZMaker at this moment is only avaible for Windows (7/8/10/11).

### How can I install KZMaker?
In GitHub repo you can download any release you want. The most recommended is the latest one.
You can also visit [Project's website](https://kzmaker.netlify.app) and download installer package from there.

After you downloaded release package, you need to open Setup.exe. Then the installation will run itself, creating KZMaker icon on your desktop.

![image](https://user-images.githubusercontent.com/27814917/143598094-c451d8b9-2424-4b8a-8750-7775dd512de5.png)

# Future
### General plans
Currently, plans for KZMaker development are simple: make sure Windows app is as best as it can and release Android version soon. If I'll be still working at this project, I will consider about integration system, between desktop app and Android one.

### Roadmap
Milestones:
- [x] Release desktop app
- [ ] Release Android app
- [ ] Make integration system between them

# Sources
### Icons

### Tools
Tools that I used to create KZMaker:
- [Figma](figma.com) - digital designer, where you can create layouts for apps, websites etc.

### Worth checking out
