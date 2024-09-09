FROM 2kpixelstudios/unity-project-packager

# NOTE: The WORKDIR resets after the FROM command! It does NOT get inherited from the base image.
WORKDIR /src
COPY . .
