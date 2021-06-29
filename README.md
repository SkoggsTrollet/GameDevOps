# GameDevOps

The goal of this project is to explore how contemporary software practices and DevOps can be integrated into game development.

## Roadmap

This is a list of various topics we'd like to explore this summer:

- [X] Project setup
  - [X] Open source game development
  - [X] Issue management and project boards
- [X] Test Driven Development
  - [X] Introduction to TDD
  - [X] TDD in Unity
- [X] Git
  - [X] Introduction to Git
  - [ ] Dealing with large binaries
    - [ ] Shallow cloning
    - [X] Git LFS
    - [ ] Unity packages
- [ ] Unity Assets
- [X] Debugging
- [ ] GitHub Actions
  - [X] Introduction
  - [ ] Automating Unity workflows
- [ ] DORA metrics in Unity
- [ ] Automating lifecycles
  - [ ] Game builds
  - [ ] Packages
  - [ ] Assets
- [ ] Dependency and configuration management
- [ ] Release automation
  - [ ] Itch.io
  - [ ] Steam

## Project flow

### Workflow

We'll use the following basic workflow for now:

- Code changes should be tied to an issue in [the board](https://github.com/Praqma/GameDevOps/projects/1)
  - Reference in commit messages (`"WIP #3"`, `"Fixes #3"`)
- Code changes should happen on a branch
  - Name: Related issue number, lowercase, dash-separated `3-add-giant-lasers`
- Merging is done through a pull request

### Project flow

While the actual game being developed is extremely fun and interesting, let's not forget the overlapping goal of the project. For now, let's follow this little flow for now, we can readjust at any time.

- Game development continuously ongoing
- Monday and Wednesday fikas and project discussion 
- Friday demos
- During fikas and demos, we'll:
  - Find ways to improve our workflow, by either adding or removing processes/skills/tools
  - Book the time to hold some workshops/trainings to achieve those things
  - Where applicable, add them as isues to the board.
