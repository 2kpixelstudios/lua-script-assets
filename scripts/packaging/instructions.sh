repoFolder="/src" # TODO: Make this compatible running outside of Docker again...
version="v0.1.1"
copyFiles=( # NOTE: Corresponding meta files will automatically be checked for and copied over if possible
    ".gitignore"
    "README.md"
    "LICENSE.md"
    "CHANGELOG.md"
    "package.json"
)
unityPackageFile="package.json"
pushChanges=true
