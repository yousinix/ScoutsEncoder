# Guidelines

<!-- TOC depthFrom:2 -->

- [1. Commit](#1-commit)
- [2. Commit Message](#2-commit-message)
- [3. Submitting Pull Requests](#3-submitting-pull-requests)

<!-- /TOC -->

---

## 1. Commit

- Commits **shouldn't contain multiple unrelated changes**; try and make piecemeal changes if you can, to make it easier to review and merge. In particular, don't commit style/whitespace changes and functionality changes in a single commit.
- Make sure to pass all **tests** before committing.

## 2. Commit Message

- Separate subject from body with a **blank line**.
- **Do not** end the subject line with a **period**.
- **Capitalize** the subject line and each paragraph.
- Use the **imperative mood** in the subject line.
- Wrap lines of the body at **72 characters**.
- **Asterisks** are used for the bullets in message's body.
- **Punctuate** your commit message's body.

## 3. Submitting Pull Requests

1. [Fork](https://github.com/YoussefRaafatNasry/ScoutsEncoder/fork) and clone the repository.
1. Create a new branch based on `master`: `git checkout -b <my-branch-name>`
1. Make your changes, and make sure the app still runs.
1. Push to your fork and [submit a pull request](https://github.com/YoussefRaafatNasry/ScoutsEncoder/compare) from your branch to `master`
1. Pat yourself on the back and wait for your pull request to be reviewed.
1. Here are a few things you have to do:
   - Write a good commit message.
   - Keep your change as focused as possible. If there are multiple changes you would like to make that are not dependent upon each other, consider submitting them as separate pull requests.
