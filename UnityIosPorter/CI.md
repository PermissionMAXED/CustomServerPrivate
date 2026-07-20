# Continuous integration

## This tool

The repository workflow `.github/workflows/unity-ios-porter-ci.yml` runs on
Ubuntu and executes:

```text
python3 -m unittest discover -s UnityIosPorter/tests -v
python3 -m compileall -q UnityIosPorter
```

Tests use synthetic temporary Unity source trees. They do not require Unity,
Xcode, network access, game binaries, extracted assets, or PyPI packages.

## An owner project

From a complete owned Unity source project that includes `UnityIosPorter/`:

```text
python3 UnityIosPorter/porter.py ci init \
  --project . \
  --attest-owned-source
```

This copies `templates/unity-ios-porter.yml` to
`.github/workflows/unity-ios-porter.yml`. It pins Python 3.11 and runs `detect`
and `scan` on Ubuntu for relevant pushes, pull requests, manual dispatches, and
changes to the generated workflow itself. The scan intentionally fails with
exit `2` when risks are found, making compatibility debt visible before a
macOS build.

Use `--dry-run` to inspect the destination and `--force` to replace an existing
generated workflow. Review workflow changes before committing.

## macOS build job

The copied v1 template is a source preflight, not a signing pipeline. A
production job must use an authorized macOS runner with:

- The project-matching Unity version and iOS Build Support.
- Xcode selected and initialized.
- Signing credentials stored in the CI provider's protected secret mechanism.
- A unique external `--work-dir`.
- A project-specific configuration and distribution method.

Invoke `doctor` first, then `all --attest-owned-source`. Retain
`build-plan.json`, `result.json`, Unity logs, the `.xcarchive`, and export logs
as access-controlled artifacts. Never print certificate passwords, API keys,
profiles, or signing material.

Do not use fork-originated, untrusted pull requests on a signing-enabled runner.
Unity Editor scripts execute code from the project during import and build.
