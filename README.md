# Getting Started

## Repository overview

This repository contains three main components:

- **C# skeleton** (`BacktestSkeleton/`) — the code you need to implement. All interfaces and infrastructure are in place; the method bodies you must write are marked with `throw new NotImplementedException()`.
- **Test cases** (`test-cases/`) — a set of backtest scenarios, each consisting of a parameters file (`.json`) and a market data file (`.csv`). The CI pipeline runs your implementation on every scenario automatically and saves the results.
- **Jupyter notebook** (`result_analysis.ipynb`) — a notebook to load and plot the backtest output files, so you can inspect the portfolio value and hedge over time.

Other public resources are available at this [link](https://gitlab.ensimag.fr/3a-if-2026/net-general-resources).

---

## Setting up the library

The project depends on a custom library (`PricingLibrary`) that is distributed through a dedicated package repository.
Before you can build or run anything locally, you need to fetch it **once** by running the following command **from the root of your repository**:

```bash
git clone --depth 1 \
  https://gitlab+deploy-token-58:<DEPLOY_TOKEN>@gitlab.ensimag.fr/net-26-training/packages.git \
  BacktestSkeleton/local-packages
```

> The `BacktestSkeleton/local-packages/` folder is in `.gitignore` — do not add it to git.  
> If the library is updated during the project, refresh it with:
> ```bash
> git -C BacktestSkeleton/local-packages pull
> ```

The CI pipeline fetches the library automatically on every push, so you only need this step for local development.

---

# CI Pipeline

Every time you push a commit, a pipeline runs automatically on GitLab in three stages:

| Stage | What it does |
|---|---|
| **build** | Compiles the solution in Release mode |
| **test** | Runs the unit tests, if any are available |
| **backtest** | Runs `BacktestConsole` on every test case in `test-cases/` and saves the outputs as artifacts |

---

## Step 1 — Open the pipeline

From your repository page, click **Build → Pipelines** in the left sidebar.

The list shows one row per push. The coloured dot on the left tells you the overall result:

- **Green (passed)** — all stages succeeded
- **Red (failed)** — at least one stage failed
- **Blue / spinning** — the pipeline is still running

Click the dot or the pipeline ID to open the detail view.

---

## Step 2 — Check the build stage

In the pipeline view the three stages are laid out left to right.

If the **build** stage is red, click the `build` job to open its log.
Compiler errors are printed with the file name and line number, for example:

```
error CS0535: 'Portfolio' does not implement interface member 'IPortfolio.UpdateValue(...)'
    → BacktestSkeleton/CoreBacktester/PortfolioHandler/Portfolio.cs (line 12)
```

Fix the error, commit, and push — the pipeline will restart automatically.

---

## Step 3 — Check the unit test results

If unit tests are provided, the **test** stage runs them and a **Tests** tab appears at the top of the pipeline page once the job has finished. The pipeline looks for a project named **`SkeletonTests`** (`BacktestSkeleton/SkeletonTests/SkeletonTests.csproj`); if that project does not exist the stage is skipped.

Click **Tests** to see:
- The total number of tests that ran and how many passed or failed
- A collapsible list of every individual test with its status
- For failing tests: the assertion message explaining what went wrong

Click the `unit-tests` job to read the raw console output. A passing run ends with:

```
Passed! - Failed: 0, Passed: 12, Skipped: 0, Total: 12, Duration: 84 ms
```

A failing run shows each failing test and the reason:

```
Failed   PortfolioTests.Constructor_SetsCashQuantity_AsPriceMinusCompositionValue [12 ms]
  Assert.That(portfolio.CashQuantity, Is.EqualTo(36.0).Within(1E-10))
  Expected: 36.0 ±1E-10
  But was:  45.0
```

### Running unit tests locally

```bash
dotnet test BacktestSkeleton/Skeletontest-cases/SkeletonTests.csproj --configuration Release
```

Add `--filter` to run only one test class:

```bash
dotnet test BacktestSkeleton/Skeletontest-cases/SkeletonTests.csproj \
    --configuration Release \
    --filter "FullyQualifiedName~PortfolioTests"
```

---

## Step 4 — Retrieve the backtest outputs

The **backtest** stage runs `BacktestConsole` on every test case in `test-cases/` and saves each output as `TestOutputs/<case_name>.json`.

### Reading the job log

Click the `backtest` job. Each test case appears as one line:

```
  Test_1_1 ... OK
  Test_1_2 ... FAILED
```

A `FAILED` line means `BacktestConsole` exited with an error for that case.
The exception or error message is printed immediately below it in the log.

### Downloading the output JSON files

Output files are saved as job artifacts and are available whether the job passed or failed.

1. Go to the pipeline page.
2. Click the **Artifacts** tab at the top (next to Jobs and Tests).  
   — or —  
   Click the **backtest** job, then click **Browse** in the *Job artifacts* panel on the right.
3. Navigate into `TestOutputs/` to view or download individual `<case_name>.json` files.

You can also download all artifacts at once using the **Download** button on the job page — the outputs will be inside `TestOutputs/` in the zip.

### Running a backtest case locally

Build the solution first (Release mode), then run:

```
BacktestConsole.exe <params-file> <data-file> <output-file>
```

For example (Windows):

```
BacktestSkeleton\BacktestConsole\bin\Release\net10.0\BacktestConsole.exe ^
    test-cases\Test_1_1\params_1_1.json ^
    test-cases\Test_1_1\data_1_1.csv ^
    TestOutputs\Test_1_1.json
```

On Linux / macOS, replace `BacktestConsole.exe` with `dotnet BacktestConsole.dll` and use forward slashes.

---

## Step 5 — Visualise the results

Open `result_analysis.ipynb` in Jupyter to plot the backtest outputs. The notebook loads the JSON files from `TestOutputs/` and draws charts of the portfolio value and hedge composition over time.

```bash
jupyter notebook result_analysis.ipynb
```

Point the notebook to the output file you want to inspect, or run all cells to plot every case in `TestOutputs/` at once.

---

# FAQ

## The pipeline is not running after I pushed

Make sure you pushed to your GitLab repository, not just saved files locally.
Run `git status` to check for uncommitted changes, then:

```bash
git add .
git commit -m "your message"
git push
```

A new pipeline row should appear in **Build → Pipelines** within a few seconds.

---

## The build fails with `NU1101: Unable to find package`

The custom library is not in `BacktestSkeleton/local-packages/`.

- **In CI**: the `PACKAGES_REPO_URL` variable is missing on this project — contact the course staff.
- **Locally**: you have not cloned the library yet, or the clone failed. Run the setup command from the *Setting up the library* section above.

---

## The git clone command fails with "project not found" or "permission denied" on a Windows machine

On Windows, Git's credential manager may intercept the HTTPS request and substitute your stored account credentials, discarding the token embedded in the URL. The server then rejects the request because your personal account does not have access to the package repository.

Fix: add `-c credential.helper=` to the command to disable the credential manager for that one invocation:

```bash
git -c credential.helper= clone --depth 1 \
  https://gitlab+deploy-token-58:<DEPLOY_TOKEN>@gitlab.ensimag.fr/net-26-training/packages.git \
  BacktestSkeleton/local-packages
```

This flag is harmless on macOS and Linux where no credential manager is typically configured.

---

## The build fails with `error CS0535` or `error CS0246`

- **CS0535** — your class does not implement all members of an interface. The log shows which member is missing and in which file.
- **CS0246** — a type or namespace is not found. Check that you have not accidentally deleted a `using` directive or renamed a class.

Click the `build` job to read the full compiler output.

---

## The Tests tab does not appear

The **Tests** tab only appears after the `unit-tests` job has run at least once, and only if a `SkeletonTests` project is present. If the **build** stage failed, the test stage is skipped. Fix the build first and push again.

---

## A unit test fails but I don't understand why

Open the `unit-tests` job log and find the failing test. The log prints the expected value, the actual value, and the line number of the assertion. You can reproduce it locally with:

```bash
dotnet test BacktestSkeleton/Skeletontest-cases/SkeletonTests.csproj \
    --configuration Release \
    --filter "FullyQualifiedName~<TestClassName>"
```

---

## Unit tests do not appear in VS Code's Test Explorer

Open the Command Palette (`Ctrl+Shift+P`) and run **Test: Refresh Tests**. VS Code sometimes does not discover tests automatically when a project is first opened or after a build; the refresh forces a rescan.

---

## A backtest case fails with an exception

Click the `backtest` job. The exception message is printed directly after the `FAILED` line for that case. Common causes:

- **Unhandled null reference or index out of range** — your implementation is not handling an edge case in the data.
- **JSON serialisation error** — the output object your code produces does not match the expected schema. Check the types and property names in `PricingResults`.
- **The run hangs / times out** — an infinite loop in your rebalancing logic. Check the conditions in your oracle or portfolio handler.

Output files for cases that did complete are still available as artifacts even when other cases fail.

---

## Do not commit binary or build output files

The `bin/`, `obj/`, and `.vs/` folders are generated automatically by the build tools and must **not** be added to git. They are already listed in `.gitignore`, so as long as you do not force-add them, git will ignore them.

Committing these folders bloats the repository, slows down clones, and can cause conflicts when the CI pipeline rebuilds the project. If you see them listed in `git status`, something has gone wrong with the `.gitignore` — contact the course staff.

---

## I accidentally committed `local-packages/` to git

Remove it from git tracking without deleting the folder:

```bash
git rm -r --cached BacktestSkeleton/local-packages
git commit -m "remove local-packages from tracking"
git push
```

The `.gitignore` entry will prevent it from being added again.

---

## The pipeline passes but my backtest output looks wrong

The CI pipeline only checks that the program runs without crashing — it does not compare your output to a reference solution. Download the output JSON files from the **backtest** job artifacts and open them in the Jupyter notebook to inspect the values visually.
